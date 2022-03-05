using ModSynth.Graph.Ports;
using ModSynth.Graph.Ports.Interfaces;

namespace ModSynth.Graph.Connections.Interfaces
{
    public interface IConnectionOut<T> : IConnection
    {
        public IPortOut<T> OutPort { get; }
    }
}
