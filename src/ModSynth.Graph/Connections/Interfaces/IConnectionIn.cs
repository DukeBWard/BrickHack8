using ModSynth.Common;
using ModSynth.Graph.Ports.Interfaces;

namespace ModSynth.Graph.Connections.Interfaces
{
    public interface IConnectionIn<T> : IConnection
    {
        public T Execute(AudioFrame frame);

        public IPortIn<T> InPort { get; }
    }
}
