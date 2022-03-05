using ModSynth.Graph.Ports.Interfaces;

namespace ModSynth.Graph.Connections.Interfaces
{
    public interface IConnection<T1, T2> : IConnectionOut<T1>, IConnectionIn<T2>
    {
    }
}
