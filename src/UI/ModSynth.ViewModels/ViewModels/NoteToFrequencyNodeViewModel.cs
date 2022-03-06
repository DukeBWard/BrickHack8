using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModSynth.Graph.Nodes.Conversion;
using ModSynth.Common.Models;

namespace ModSynth.ViewModels.ViewModels
{
    public class NoteToFrequencyNodeViewModel : ObservableObject
    {
        private NoteToFrequencyNode _ntfNode;
        private Note _note;
        private Tuning _tuning;

        public NoteToFrequencyNodeViewModel()
        {
            _ntfNode = new NoteToFrequencyNode();
        }
        public Note Note 
        { 
            get => _note; 
            set
            {
                SetProperty(ref _note, value);
                _note = value;
                _ntfNode.InPort.Fallback = value;
            }
        }

        public Tuning Tuning
        {
            get => _tuning;
            set
            {
                SetProperty(ref _tuning, value);
                _tuning = value;
                _ntfNode.TuningInPort.Fallback = value;
            }
        }
    }
}
