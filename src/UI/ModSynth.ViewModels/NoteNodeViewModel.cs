using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModSynth.Common.Enums;
using ModSynth.Graph.Nodes.Input;

namespace ModSynth.ViewModels
{
    internal class NoteNodeViewModel : ObservableObject
    {
        NoteNode _noteNode;

        public NoteNodeViewModel(String note)
        {
            ModSynth.Common.Models.Note.TryParse(note, _noteNode);
        }

        
    }
}
