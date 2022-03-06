using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModSynth.Graph.Nodes.PCM;

namespace ModSynth.ViewModels.ViewModels
{
    public class WaveGeneratorNodeViewModel : ObservableObject
    {
        private WaveGeneratorNode _wgNode;
        private float _frequency;

        public WaveGeneratorNodeViewModel()
        {
            _wgNode = new WaveGeneratorNode();
        }

        public WaveGeneratorNode WaveGeneratorNode { get => _wgNode; }

        public float Frequency 
        { 
            get => _frequency;
            set
            {
                SetProperty(ref _frequency, value);
                _wgNode.FrequencyInPort.Fallback = value;
            }
        }
    }
}
