using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModSynth.Graph.Nodes.PCM;
using ModSynth.Common;

namespace ModSynth.ViewModels.ViewModels
{
    public class MixPCMNodeViewModel : ObservableObject
    {
        MixPCMNode _mPCMNode;
        AudioFrame _waveA, _waveB;

        public MixPCMNodeViewModel()
        {
            _mPCMNode = new MixPCMNode();
        }

        public MixPCMNode MixPCMNode 
        { 
            get => _mPCMNode;
        }

        public AudioFrame WaveFormA
        {
            get => _waveA;
            set
            {
                _mPCMNode.WaveInPortA.Fallback = value;
                _waveA = value;
            }
        }

        public AudioFrame WaveFormB
        {
            get => _waveB;
            set
            {
                _mPCMNode.WaveInPortB.Fallback = value;
                _waveB = value;
            }
        }
    }
}
