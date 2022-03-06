using ModSynth.Common;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;

namespace ModSynth.Graph.Nodes.Input
{
    public class FrequencyNode : INode
    {
        public FrequencyNode()
        {
            OutPort = new OutPort<float>(this);
        }

        public float Frequency { get; set; }

        public OutPort<float> OutPort { get; }

        public void Execute(float sample)
        {
            OutPort.Value = Frequency;
        }
    }
}
