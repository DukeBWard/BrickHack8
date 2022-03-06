using ModSynth.Common.Enums;
using ModSynth.Common.Models;
using ModSynth.Graph.Nodes.Conversion;
using ModSynth.Graph.Nodes.Input;
using ModSynth.Graph.Nodes.PCM;
using ModSynth.ViewModels.Presets.Abstract;

namespace ModSynth.ViewModels.Presets
{
    public class Preset2 : Preset
    {
        public Preset2() : base()
        { 
            // Create Nodes
            TuningNode tuning = new TuningNode();
            tuning.BasisNoteInPort.Fallback = new Note(NoteName.A, 4);
            tuning.BasisFrequencyInPort.Fallback = 440;
            Note1 = new NoteNode(new Note(NoteName.A, 3));
            Note2 = new NoteNode(new Note(NoteName.C, 4));
            Note3 = new NoteNode(new Note(NoteName.E, 4));
            NoteToFrequencyNode a3Freq = new NoteToFrequencyNode();
            NoteToFrequencyNode c4Freq = new NoteToFrequencyNode();
            NoteToFrequencyNode e4Freq = new NoteToFrequencyNode();
            Wave1 = new WaveGeneratorNode();
            Wave2 = new WaveGeneratorNode();
            Wave3 = new WaveGeneratorNode();
            Mix1 = new MixPCMNode();
            Mix2 = new MixPCMNode();

            // Add Nodes
            AddNode(tuning);
            AddNode(Wave1);
            AddNode(Wave2);
            AddNode(Wave3);
            AddNode(a3Freq);
            AddNode(c4Freq);
            AddNode(e4Freq);
            AddNode(Mix1);
            AddNode(Mix2);

            // Create Connections
            CreateConnection(Note1.OutPort, a3Freq.InPort);
            CreateConnection(Note2.OutPort, c4Freq.InPort);
            CreateConnection(Note3.OutPort, e4Freq.InPort);
            CreateConnection(tuning.OutPort, a3Freq.TuningInPort);
            CreateConnection(tuning.OutPort, c4Freq.TuningInPort);
            CreateConnection(tuning.OutPort, e4Freq.TuningInPort);
            CreateConnection(a3Freq.OutPort, Wave1.FrequencyInPort);
            CreateConnection(c4Freq.OutPort, Wave2.FrequencyInPort);
            CreateConnection(e4Freq.OutPort, Wave3.FrequencyInPort);
            CreateConnection(Wave1.WaveOutPort, Mix1.WaveInPortA);
            CreateConnection(Wave2.WaveOutPort, Mix1.WaveInPortB);
            CreateConnection(Mix1.WaveOutPort, Mix2.WaveInPortA);
            CreateConnection(Wave3.WaveOutPort, Mix2.WaveInPortB);
            SynthGraph.CreateOutputConnection(Mix2.WaveOutPort);
        }

        public NoteNode Note1 { get; }

        public NoteNode Note2 { get; }

        public NoteNode Note3 { get; }

        public WaveGeneratorNode Wave1 { get; }

        public WaveGeneratorNode Wave2 { get; }

        public WaveGeneratorNode Wave3 { get; }

        public MixPCMNode Mix1 { get; }

        public MixPCMNode Mix2 { get; }
    }
}
