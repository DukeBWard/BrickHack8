using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModSynth.Common.Models;
using ModSynth.Graph.Nodes.Input;

namespace ModSynth.ViewModels
{
    internal class TuningNodeViewModel : ObservableObject
    {
        TuningNode _tuningNode;

        public TuningNodeViewModel()
        {
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
