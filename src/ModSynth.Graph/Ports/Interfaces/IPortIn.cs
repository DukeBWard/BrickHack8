using ModSynth.Common;
using ModSynth.Graph.Connections.Interfaces;

namespace ModSynth.Graph.Ports.Interfaces
{
    public interface IPortIn<T> : IPort
    {
        public T Execute(AudioFrame frame);

        public void SetConnection(IConnectionIn<T> connection);
    }
}
