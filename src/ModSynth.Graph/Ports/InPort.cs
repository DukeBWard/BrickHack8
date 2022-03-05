using ModSynth.Common;
using ModSynth.Graph.Connections.Interfaces;
using ModSynth.Graph.Ports.Interfaces;
using ModSynth.Graph.Nodes.Interfaces;

namespace ModSynth.Graph.Ports
{
    public class InPort<T> : IPortIn<T>
    {
        public InPort(INode owner)
        {
            Owner = owner;
            Fallback = default;
        }

        public INode Owner { get; }

        public IConnectionIn<T>? Connection { get; set; }

        public T Fallback { get; set; }

        public void SetConnection(IConnectionIn<T> connection)
        {
            Connection = connection;
        }

        public T Execute(AudioFrame frame)
        {
            if (Connection == null) return Fallback;
            return Connection.Execute(frame);
        }
    }
}
