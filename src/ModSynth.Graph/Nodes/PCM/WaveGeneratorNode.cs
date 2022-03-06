using ModSynth.Common;
using ModSynth.Common.Enums;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;
using System;
using System.Runtime.CompilerServices;

namespace ModSynth.Graph.Nodes.PCM
{
    public class WaveGeneratorNode : INode
    {
        private WaveType _waveType;
        private Func<AudioFrame, AudioFrame> _function;

        public WaveGeneratorNode()
        {
            WaveType = WaveType.SINE;
            FrequencyInPort = new InPort<float>(this);
            WaveOutPort = new OutPort<AudioFrame>(this);
        }

        public WaveType WaveType
        {
            get => _waveType;
            set
            {
                _waveType = value;
                switch (_waveType)
                {
                    case WaveType.SINE:
                        _function = SineWave;
                        break;
                    case WaveType.SAW:
                        _function = SawWave;
                        break;
                }
            }
        }

        public InPort<float> FrequencyInPort { get; set; }

        public OutPort<AudioFrame> WaveOutPort { get; }

        public void Execute(AudioFrame frame)
        {
            WaveOutPort.Value = _function(frame);
        }

        private AudioFrame SineWave(AudioFrame frame)
        {
            double sample = frame.Theta;
            float freq = FrequencyInPort.Execute(frame);
            for (int i = 0; i < frame.Samples; i++)
            {
                double theta = freq * (MathF.PI * 2) * sample;
                double sinValue = Math.Sin(theta);
                frame.Payload[i] = (float)sinValue;

                sample += frame.SampleIncrement;
            }

            return frame;
        }

        private AudioFrame SawWave(AudioFrame frame)
        {
            const float PI2 = (MathF.PI * 2);
            double sample = frame.Theta;
            float freq = FrequencyInPort.Execute(frame);
            for (int i = 0; i < frame.Samples; i++)
            {
                double theta = (freq * PI2 * sample) % PI2;
                double x = (theta < MathF.PI) ? theta : theta - PI2;
                frame.Payload[i] = (float)x;

                sample += frame.SampleIncrement;
            }

            return frame;
        }
    }
}
