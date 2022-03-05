using ComputeSharp;
using ComputeSharp.WinUI;
using ModSynth.UI.Visualizers;
using System;

namespace ModSynth.UI.WinUI.Rendering
{
    public class VisualizerRunner : IShaderRunner
    {
        private ReadOnlyBuffer<float> _pcmBuffer;
        private AudioGraphRenderer _audioRenderer;

        public VisualizerRunner(AudioGraphRenderer renderer)
        {
            AudioRenderer = renderer;
        }

        public AudioGraphRenderer AudioRenderer
        {
            get => _audioRenderer;
            set
            {
                if (_audioRenderer != null) _audioRenderer.FramePlayed -= ReadFrame;

                _audioRenderer = value;
                _audioRenderer.FramePlayed += ReadFrame;
            }
        }

        public bool TryExecute(IReadWriteNormalizedTexture2D<Float4> texture, TimeSpan timespan, object parameter)
        {
            if (_pcmBuffer == null) return false;

            GraphicsDevice.Default.ForEach(texture, new BasicShader(_pcmBuffer));
            return true;
        }

        private void ReadFrame(object sender, float[] e)
        {
            if (e.Length > 0) _pcmBuffer = GraphicsDevice.Default.AllocateReadOnlyBuffer(e);
        }
    }
}
