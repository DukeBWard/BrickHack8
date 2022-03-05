using ModSynth.Common;
using ModSynth.Common.Enums;
using ModSynth.Common.Models;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;

namespace ModSynth.Graph.Nodes.Input
{
    public class TuningNode : INode
    {
        private Tuning _tuning = new Tuning(TuningType.EqualTempered, new Note(NoteName.A, 4), 440);

        public TuningNode()
        {
            OutPort = new OutPort<Tuning>(this);
        }

        public Note BasisNote
        {
            get => _tuning.BasisNote;
            set => _tuning.BasisNote = value;
        }

        public float BasisFrequency
        {
            get => _tuning.BasisFrequency;
            set => _tuning.BasisFrequency = value;
        }

        public OutPort<Tuning> OutPort { get; }

        public void Execute(AudioFrame frame)
        {
            OutPort.Value = _tuning;
        }
    }
}
