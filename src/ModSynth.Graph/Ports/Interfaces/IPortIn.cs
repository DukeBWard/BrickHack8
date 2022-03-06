using ModSynth.Graph.Connections.Interfaces;

namespace ModSynth.Graph.Ports.Interfaces
{
    public interface IPortIn<T> : IPort
    {
        public T Execute(float frame);

        public void SetConnection(IConnectionIn<T> connection);
    }
}
