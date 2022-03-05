using ModSynth.Common;
using ModSynth.Graph.Connections.Interfaces;
using ModSynth.Graph.Ports.Interfaces;

namespace ModSynth.Graph.Connections
{
    public class DirectConnection<T> : IConnection<T, T>
    {
        internal DirectConnection(IPortOut<T> outPrt, IPortIn<T> inPort)
        {
            OutPort = outPrt;
            InPort = inPort;
        }

        public IPortIn<T> InPort { get; }

        public IPortOut<T> OutPort { get; }

        public T Execute(AudioFrame frame)
        {
            return OutPort.Execute(frame);
        }
    }
}
