using ModSynth.Common;
using ModSynth.Common.Enums;
using ModSynth.Common.Models;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;

namespace ModSynth.Graph.Nodes.Input
{
    public class NoteNode : INode
    {
        private Note _note = new Note(NoteName.A, 4);

        public NoteNode()
        {
            OutPort = new OutPort<Note>(this);
        }

        public NoteName Note
        {
            get => _note.NoteName;
            set => _note.NoteName = value;
        }

        public int Octave
        {
            get => _note.Octave;
            set => _note.Octave = value;
        }

        public OutPort<Note> OutPort { get; }

        public void Execute(AudioFrame frame)
        {
            OutPort.Value = _note;
        }
    }
}
