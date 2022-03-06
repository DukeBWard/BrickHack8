using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModSynth.Common.Models;
using ModSynth.Graph.Nodes.Input;

namespace ModSynth.ViewModels
{
    public class NoteNodeViewModel : ObservableObject
    {
        private NoteNode _noteNode;
        private string _noteString;

        public NoteNodeViewModel(String stringNote)
        {
            _noteNode = new NoteNode();
            Note.TryParse(stringNote, out Note note);
            _noteNode.Note = note;
        }

        public string NoteString 
        { 
            get => _noteString;
            set 
            {
                bool success = Note.TryParse(value, out Note note);
                if (!success) return;
                SetProperty(ref _noteString, value);
                _noteNode.Note = note;
            }
        }
    }
}
