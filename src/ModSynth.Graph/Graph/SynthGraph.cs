using ModSynth.Common;
using ModSynth.Common.Enums;
using ModSynth.Common.Models;
using ModSynth.Graph.Connections;
using ModSynth.Graph.Connections.Interfaces;
using ModSynth.Graph.Nodes.Conversion;
using ModSynth.Graph.Nodes.Input;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Nodes.Output;
using ModSynth.Graph.Ports.Interfaces

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
