using ModSynth.Rendering;
using System;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Media;
using Windows.Media.Audio;
using Windows.Media.Devices;
using Windows.Media.MediaProperties;
using Windows.Media.Render;
using WinRT;
using GraphFrame = Windows.Media.AudioFrame;
using AudioFrame = ModSynth.Common.AudioFrame;

namespace ModSynth.UI.WinUI.Rendering
{
    /// <summary>
    /// A <see cref="AudioRenderer"/> using <see cref="AudioGraph"/>s.
    /// </summary>
    public class AudioGraphRenderer : AudioRenderer
    {
        private AudioGraph _graph;
        private AudioDeviceOutputNode _outputNode;
        private AudioFrameInputNode _inputNode;
        private double _theta = 0;
        private bool _isPlaying = false;

        public event EventHandler<float[]> FramePlayed;

        /// <summary>
        /// Gets a value indicating whether or not the <see cref="AudioRenderer"/> is initialized.
        /// </summary>
        public bool IsInitialized => _graph != null;

        /// <summary>
        /// Gets value indicating whether or not the <see cref="AudioRenderer"/> is playing.
        /// </summary>
        public bool IsPlaying => _isPlaying;

        /// <summary>
        /// Initializes the <see cref="AudioRenderer"/>.
        /// </summary>
        /// <returns>An asynchronous task that returns a status indicating the initializion success.</returns>
        public async Task<bool> InitializeAsync()
        {
            var settings = new AudioGraphSettings(AudioRenderCategory.Media);
            settings.PrimaryRenderDevice = await GetDefaultRenderDevice();

            var status = true;

            status = await CreateGraph(settings);
            if (!status) return false;

            status = await CreateOutputNode();
            if (!status) return false;

            CreateInputNode();

            return status;
        }

        /// <summary>
        /// Begins or resumes playback.
        /// </summary>
        /// <returns>The success status.</returns>
        public bool Play()
        {
            if (_graph == null)
                return false;

            if (_isPlaying == true) return true;

            _outputNode.Start();
            _inputNode.Start();
            _graph.Start();
            _isPlaying = true;
            return true;
        }

        /// <summary>
        /// Pauses playback.
        /// </summary>
        /// <returns>The success status.</returns>
        public bool Pause()
        {
            if (_graph == null)
                return false;

            _outputNode.Stop();
            _inputNode.Stop();
            _graph.Stop();
            _isPlaying = false;
            return true;
        }

        /// <summary>
        /// Stops playback.
        /// </summary>
        /// <returns>The success status.</returns>
        public bool Stop()
        {
            var status = Pause();
            if (!status) return false;

            _theta = 0;
            return true;
        }

        private async Task<bool> CreateGraph(AudioGraphSettings settings)
        {
            var result = await AudioGraph.CreateAsync(settings);
            if (result.Status != AudioGraphCreationStatus.Success) return false;
            _graph = result.Graph;
            return true;
        }

        private async Task<bool> CreateOutputNode()
        {
            if (_graph == null) return false;
            CreateAudioDeviceOutputNodeResult result = await _graph.CreateDeviceOutputNodeAsync();
            if (result.Status != AudioDeviceNodeCreationStatus.Success) return false;
            _outputNode = result.DeviceOutputNode;
            return true;
        }

        private void CreateInputNode()
        {
            AudioEncodingProperties encodingProperties = _graph.EncodingProperties;
            encodingProperties.ChannelCount = 1; // Explict mono for now.
            _inputNode = _graph.CreateFrameInputNode(encodingProperties);
            _inputNode.AddOutgoingConnection(_outputNode);
            _inputNode.Stop();
            _inputNode.QuantumStarted += QuantumStarted;
        }

        private async Task<DeviceInformation> GetDefaultRenderDevice()
        {
            string id = MediaDevice.GetDefaultAudioRenderId(AudioDeviceRole.Default);
            return await DeviceInformation.CreateFromIdAsync(id);
        }

        private unsafe GraphFrame GenerateAudioFrame(uint samples)
        {
            double sampleIncrement = 1d / (int)_graph.EncodingProperties.SampleRate;
            AudioFrame generatedFrame = new AudioFrame(_theta, (int)samples, sampleIncrement);
            generatedFrame = GenerateFrame(generatedFrame);
            _theta += samples * sampleIncrement;

            uint bufferSize = samples * sizeof(float);
            GraphFrame frame = new GraphFrame(bufferSize);

            using (AudioBuffer buffer = frame.LockBuffer(AudioBufferAccessMode.Write))
            using (IMemoryBufferReference reference = buffer.CreateReference())
            {
                byte* dataInBytes;
                uint capcityInBytes;
                float* dataInFloat;

                reference.As<IMemoryBufferByteAccess>().GetBuffer(out dataInBytes, out capcityInBytes);

                dataInFloat = (float*)dataInBytes;

                for (int i = 0; i < samples; i++)
                {
                    dataInFloat[i] = generatedFrame.Payload[i];
                }
            }

            FramePlayed?.Invoke(this, generatedFrame.Payload);
            return frame;
        }

        private void QuantumStarted(AudioFrameInputNode sender, FrameInputNodeQuantumStartedEventArgs args)
        {
            uint requestedSamples = (uint)args.RequiredSamples;

            if (requestedSamples != 0)
            {
                GraphFrame audioFrame = GenerateAudioFrame(requestedSamples);
                _inputNode.AddFrame(audioFrame);
            }
        }
    }
}
