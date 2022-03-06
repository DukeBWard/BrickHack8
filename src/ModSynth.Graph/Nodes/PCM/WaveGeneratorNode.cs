using ModSynth.Common;
using ModSynth.Common.Enums;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;
using System;

namespace ModSynth.Graph.Nodes.PCM
{
    public class WaveGeneratorNode : INode
    {
        private WaveType _waveType;
        private Func<float, float> _function;

        public WaveGeneratorNode()
        {
            WaveType = WaveType.SINE;
            FrequencyInPort = new InPort<float>(this);
            WaveOutPort = new OutPort<float>(this);
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
                    //case WaveType.SAW:
                    //    _function = SawWave;
                    //    break;
                }
            }
        }

        public InPort<float> FrequencyInPort { get; set; }

        public OutPort<float> WaveOutPort { get; }

        public void Execute(float sample)
        {
            WaveOutPort.Value = _function(sample);
        }

        private float SineWave(float sample)
        {
            float freq = FrequencyInPort.Execute(sample);
            double theta = freq * (MathF.PI * 2) * sample;
            double sinValue = Math.Sin(theta);
            return (float)sinValue;
        }
    }
}
