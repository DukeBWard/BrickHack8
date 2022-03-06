using ModSynth.Common;
using ModSynth.Common.Enums;
using ModSynth.Common.Models;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;

namespace ModSynth.Graph.Nodes.Input
{
    public class NoteNode : INode
    {
        public NoteNode()
        {
            OutPort = new OutPort<Note>(this);
        }

        public NoteNode(Note note) : this()
        {
            Note = note;
        }

        public Note Note { get; set; } = new Note(NoteName.A, 4);

        public OutPort<Note> OutPort { get; }

        public void Execute(float sample)
        {
            OutPort.Value = Note;
        }
    }
}
