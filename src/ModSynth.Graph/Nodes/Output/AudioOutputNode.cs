using ModSynth.Common;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;

namespace ModSynth.Graph.Nodes.Output
{
    public class AudioOutputNode : INode
    {
        public AudioOutputNode()
        {
            InPort = new InPort<float>(this);
        }

        public InPort<float> InPort { get; }

        public void Execute(float frame)
        {
            InPort.Execute(frame);
        }

        public float ExecuteOutput(float frame)
        {
            return InPort.Execute(frame);
        }
    }
}
