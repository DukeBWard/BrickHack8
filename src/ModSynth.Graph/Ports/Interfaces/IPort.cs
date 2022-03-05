using ModSynth.Graph.Nodes.Interfaces;

namespace ModSynth.Graph.Ports.Interfaces
{
    public interface IPort
    {
        public INode Owner { get; }
    }
}
