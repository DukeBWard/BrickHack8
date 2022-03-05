using ModSynth.Common.Enums;
using ModSynth.Common.Models;
using ModSynth.Graph.Connections;
using ModSynth.Graph.Connections.Interfaces;
using ModSynth.Graph.Nodes.Input;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Nodes.Output;
using ModSynth.Graph.Nodes.PCM;
using ModSynth.Graph.Ports.Interfaces;
using System.Collections.Generic;

namespace ModSynth.Graph
{
    public class SynthGraph
    {
        public SynthGraph()
        {
            Nodes = new List<INode>();
            Connections = new List<IConnection>();

            OutputNode = new AudioOutputNode();
            Nodes.Add(OutputNode);

            // Sample SynthGraph

            // Create Nodes
            TuningNode tuning = new TuningNode();
            WaveGeneratorNode A3Wave = new WaveGeneratorNode();
            A3Wave.NoteInPort.Fallback = new Note(NoteName.A, 3);
            WaveGeneratorNode C4Wave = new WaveGeneratorNode();
            C4Wave.NoteInPort.Fallback = new Note(NoteName.C, 4);
            WaveGeneratorNode E4Wave = new WaveGeneratorNode();
            E4Wave.NoteInPort.Fallback = new Note(NoteName.E, 4);
            MixPCMNode mix1 = new MixPCMNode();
            MixPCMNode mix2 = new MixPCMNode();

            // Add Nodes
            AddNode(tuning);
            AddNode(A3Wave);
            AddNode(C4Wave);
            AddNode(E4Wave);
            AddNode(mix1);
            AddNode(mix2);

            // Create Connections
            CreateConnection(tuning.OutPort, A3Wave.TuningInPort);
            CreateConnection(tuning.OutPort, C4Wave.TuningInPort);
            CreateConnection(tuning.OutPort, E4Wave.TuningInPort);
            CreateConnection(A3Wave.WaveOutPort, mix1.WaveInPortA);
            CreateConnection(C4Wave.WaveOutPort, mix1.WaveInPortB);
            CreateConnection(mix1.WaveOutPort, mix2.WaveInPortA);
            CreateConnection(E4Wave.WaveOutPort, mix2.WaveInPortB);
            CreateConnection(mix2.WaveOutPort, OutputNode.InPort);
        }

        public List<INode> Nodes { get; }

        public List<IConnection> Connections { get; }

        public AudioOutputNode OutputNode { get; }

        public void AddNode(INode node)
        {
            Nodes.Add(node);
        }

        public void CreateConnection<T>(IPortOut<T> outPort, IPortIn<T> inPort)
        {
            DirectConnection<T> directConnection = new DirectConnection<T>(outPort, inPort);
            Connections.Add(directConnection);
            inPort.SetConnection(directConnection);
        }
    }
}
