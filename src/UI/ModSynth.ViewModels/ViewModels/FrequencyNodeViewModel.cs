using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModSynth.Graph.Nodes.Input;

namespace ModSynth.ViewModels.ViewModels
{
    public class FrequencyNodeViewModel : ObservableObject
    {
        private FrequencyNode _freqNode;
        private float _frequency;

        public FrequencyNodeViewModel()
        {
            _freqNode = new FrequencyNode();
        }

        public float Frequency 
        {
            get => _frequency; 
            set 
            {
                SetProperty(ref _frequency, value);
                _freqNode.Frequency = value;
            }
        }
    }
}
