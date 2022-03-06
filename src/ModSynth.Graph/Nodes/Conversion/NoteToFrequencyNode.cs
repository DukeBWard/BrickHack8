using ModSynth.Common;
using ModSynth.Common.Models;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;

namespace ModSynth.Graph.Nodes.Conversion
{
    public class NoteToFrequencyNode : INode
    {
        public NoteToFrequencyNode()
        {
            InPort = new InPort<Note>(this);
            TuningInPort = new InPort<Tuning>(this); 
            OutPort = new OutPort<float>(this);
        }

        public InPort<Note> InPort { get; set; }

        public InPort<Tuning> TuningInPort { get; set; }

        public OutPort<float> OutPort { get; }

        public void Execute(float sample)
        {
            Note note = InPort.Execute(sample);
            Tuning tuning = TuningInPort.Execute(sample);
            OutPort.Value = tuning.TuneNote(note);
        }
    }
}
