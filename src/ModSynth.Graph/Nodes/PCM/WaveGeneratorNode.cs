using ModSynth.Common;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;
using System;

namespace ModSynth.Graph.Nodes.PCM
{
    public class WaveGeneratorNode : INode
    {
        public WaveGeneratorNode()
        {
            FrequencyInPort = new InPort<float>(this);
            WaveOutPort = new OutPort<AudioFrame>(this);
        }

        public InPort<float> FrequencyInPort { get; set; }

        public OutPort<AudioFrame> WaveOutPort { get; }

        public void Execute(AudioFrame frame)
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

            WaveOutPort.Value = frame;
        }
    }
}
