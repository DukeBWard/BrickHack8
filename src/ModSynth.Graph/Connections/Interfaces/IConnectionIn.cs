using ModSynth.Graph.Ports.Interfaces;

namespace ModSynth.Graph.Connections.Interfaces
{
    public interface IConnectionIn<T> : IConnection
    {
        public T Execute(float frame);

        public IPortIn<T> InPort { get; }
    }
}
