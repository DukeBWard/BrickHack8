using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModSynth.Graph.Nodes.PCM;

namespace ModSynth.ViewModels.ViewModels
{
    public class WaveGeneratorNodeViewModel : ObservableObject
    {
        private WaveGeneratorNode _wgNode;

        public WaveGeneratorNodeViewModel()
        {
            _wgNode = new WaveGeneratorNode();
        }

        public WaveGeneratorNode WaveGeneratorNode { get => _wgNode; }

        public float Frequency { get => _wgNode.FrequencyInPort.Fallback;}
    }
}
