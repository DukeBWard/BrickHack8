using ModSynth.Common;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;

namespace ModSynth.Graph.Nodes.Output
{
    public class AudioOutputNode : INode
    {
        public AudioOutputNode()
        {
            InPort = new InPort<AudioFrame>(this);
        }

        public InPort<AudioFrame> InPort { get; }

        public void Execute(AudioFrame frame)
        {
            InPort.Execute(frame);
        }
    }
}
