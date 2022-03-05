using ModSynth.Common;

namespace ModSynth.Graph.Nodes.Interfaces
{
    public interface INode
    {
        void Execute(AudioFrame frame);
    }
}
