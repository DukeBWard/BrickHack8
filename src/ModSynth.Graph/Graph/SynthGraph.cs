using ModSynth.Common;
using ModSynth.Graph.Connections;
using ModSynth.Graph.Nodes.Output;
using ModSynth.Graph.Ports.Interfaces;

namespace ModSynth.Graph
{
    public class SynthGraph
    {
        public SynthGraph()
        { 
            OutputNode = new AudioOutputNode();
        }

        public AudioOutputNode OutputNode { get; }

        public void CreateOutputConnection(IPortOut<AudioFrame> outPort)
        {
            DirectConnection<AudioFrame> dirCon = 
                new DirectConnection<AudioFrame>(outPort, OutputNode.InPort);
        }
    }
}
