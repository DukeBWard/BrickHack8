using ModSynth.Common;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;

namespace ModSynth.Graph.Nodes.PCM
{
    public class MixPCMNode : INode
    {
        public MixPCMNode()
        {
            WaveInPortA = new InPort<AudioFrame>(this);
            WaveInPortB = new InPort<AudioFrame>(this);
            WaveOutPort = new OutPort<AudioFrame>(this);
        }

        public InPort<AudioFrame> WaveInPortA { get; set; }

        public bool UseA { get; set; } = true;

        public InPort<AudioFrame> WaveInPortB { get; set; }

        public bool UseB { get; set; } = true;

        public OutPort<AudioFrame> WaveOutPort { get; }

        public void Execute(AudioFrame frame)
        {
            AudioFrame a = WaveInPortA.Execute(frame.Clone());
            AudioFrame b = WaveInPortB.Execute(frame.Clone());

            for (int i = 0; i < frame.Samples; i++)
            {
                frame.Payload[i] = 0;
                if (UseA) frame.Payload[i] += a.Payload[i];
                if (UseB) frame.Payload[i] += b.Payload[i];
            }

            WaveOutPort.Value = frame;
        }
    }
}
