using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Connections.Interfaces;
using ModSynth.Graph.Ports.Interfaces;
using ModSynth.Graph.Connections;
using ModSynth.Graph;

namespace ModSynth.ViewModels.Presets.Abstract
{
    public abstract class Preset
    {
        public SynthGraph _synthGraph { get; protected set; }

        public Preset()
        {
            _synthGraph = new SynthGraph();
        }

        public List<INode> Nodes { get; }

        public List<IConnection> Connections { get; }

        protected void AddNode(INode node)
        {
            Nodes.Add(node);
        }
        protected void CreateConnection<T>(IPortOut<T> outPort, IPortIn<T> inPort)
        {
            DirectConnection<T> directConnection = new DirectConnection<T>(outPort, inPort);
            Connections.Add(directConnection);
            inPort.SetConnection(directConnection);
        }
    }
}
