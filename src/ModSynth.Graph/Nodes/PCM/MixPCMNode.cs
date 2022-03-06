using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;

namespace ModSynth.Graph.Nodes.PCM
{
    public class MixPCMNode : INode
    {
        public MixPCMNode()
        {
            WaveInPortA = new InPort<float>(this);
            WaveInPortB = new InPort<float>(this);
            WaveOutPort = new OutPort<float>(this);
        }

        public InPort<float> WaveInPortA { get; set; }

        public bool UseA { get; set; } = true;

        public InPort<float> WaveInPortB { get; set; }

        public bool UseB { get; set; } = true;

        public OutPort<float> WaveOutPort { get; }

        public void Execute(float sample)
        {
            float a = WaveInPortA.Execute(sample);
            float b = WaveInPortB.Execute(sample);

            float sum = 0;
            if (UseA) sum += a;
            if (UseB) sum += b;

            WaveOutPort.Value = sum;
        }
    }
}
