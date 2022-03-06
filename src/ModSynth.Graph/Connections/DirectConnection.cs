using ModSynth.Graph.Connections.Interfaces;
using ModSynth.Graph.Ports.Interfaces;

namespace ModSynth.Graph.Connections
{
    public class DirectConnection<T> : IConnection<T, T>
    {
        public DirectConnection(IPortOut<T> outPrt, IPortIn<T> inPort)
        {
            OutPort = outPrt;
            InPort = inPort;
        }

        public IPortIn<T> InPort { get; }

        public IPortOut<T> OutPort { get; }

        public T Execute(float sample)
        {
            return OutPort.Execute(sample);
        }
    }
}
