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

        public void Execute(AudioFrame frame)
        {
            Note note = InPort.Execute(frame);
            Tuning tuning = TuningInPort.Execute(frame);
            OutPort.Value = tuning.TuneNote(note);
        }
    }
}
