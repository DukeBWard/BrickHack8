using ModSynth.Common.Enums;
using ModSynth.Common.Models;
using ModSynth.Graph.Connections;
using ModSynth.Graph.Connections.Interfaces;
using ModSynth.Graph.Nodes.Conversion;
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
            tuning.BasisNoteInPort.Fallback = new Note(NoteName.A, 4);
            tuning.BasisFrequencyInPort.Fallback = 440;
            NoteToFrequencyNode a3Freq = new NoteToFrequencyNode();
            a3Freq.InPort.Fallback = new Note(NoteName.A, 3);
            NoteToFrequencyNode c4Freq = new NoteToFrequencyNode();
            c4Freq.InPort.Fallback = new Note(NoteName.C, 4);
            NoteToFrequencyNode e4Freq = new NoteToFrequencyNode();
            e4Freq.InPort.Fallback = new Note(NoteName.E, 4);
            WaveGeneratorNode A3Wave = new WaveGeneratorNode();
            WaveGeneratorNode C4Wave = new WaveGeneratorNode();
            WaveGeneratorNode E4Wave = new WaveGeneratorNode();
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
            CreateConnection(tuning.OutPort, a3Freq.TuningInPort);
            CreateConnection(tuning.OutPort, c4Freq.TuningInPort);
            CreateConnection(tuning.OutPort, e4Freq.TuningInPort);
            CreateConnection(a3Freq.OutPort, A3Wave.FrequencyInPort);
            CreateConnection(c4Freq.OutPort, C4Wave.FrequencyInPort);
            CreateConnection(e4Freq.OutPort, E4Wave.FrequencyInPort);
            CreateConnection(A3Wave.WaveOutPort, mix1.WaveInPortA);
            CreateConnection(C4Wave.WaveOutPort, mix1.WaveInPortB);
            CreateConnection(mix1.WaveOutPort, mix2.WaveInPortA);
            CreateConnection(E4Wave.WaveOutPort, mix2.WaveInPortB);
            CreateConnection(mix2.WaveOutPort, OutputNode.InPort);
        }

        public List<INode> Nodes { get; }

        public List<IConnection> Connections { get; }

        public AudioOutputNode OutputNode { get; }

        private void AddNode(INode node)
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
