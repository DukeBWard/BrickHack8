using ModSynth.Common;
using ModSynth.Common.Enums;
using ModSynth.Common.Models;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;

namespace ModSynth.Graph.Nodes.Input
{
    public class TuningNode : INode
    {
        public TuningNode()
        {
            BasisNoteInPort = new InPort<Note>(this);
            BasisFrequencyInPort = new InPort<float>(this);
            OutPort = new OutPort<Tuning>(this);
        }

        public InPort<Note> BasisNoteInPort { get; set; }

        public InPort<float> BasisFrequencyInPort { get; set; }

        public OutPort<Tuning> OutPort { get; }

        public void Execute(AudioFrame frame)
        {
            Note note = BasisNoteInPort.Execute(frame);
            float frequency = BasisFrequencyInPort.Execute(frame);
            OutPort.Value = new Tuning(TuningType.EqualTempered, note, frequency);
        }
    }
}
