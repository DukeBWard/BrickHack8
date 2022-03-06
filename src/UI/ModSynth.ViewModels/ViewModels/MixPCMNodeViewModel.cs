using Microsoft.Toolkit.Mvvm.ComponentModel;
using ModSynth.Graph.Nodes.PCM;

namespace ModSynth.ViewModels.ViewModels
{
    public class MixPCMNodeViewModel : ObservableObject
    {
        private MixPCMNode _mPCMNode;
        private bool _useA, _useB;

        public MixPCMNodeViewModel(MixPCMNode node)
        {
            _mPCMNode = node;
            _useA = _mPCMNode.UseA;
            _useB = _mPCMNode.UseB;
        }

        public MixPCMNode MixPCMNode 
        { 
            get => _mPCMNode;
        }

        public bool UseA
        {
            get => _useA;
            set
            {
                SetProperty(ref _useA, value);
                _mPCMNode.UseA = value;
            }
        }

        public bool UseB
        {
            get => _useB;
            set
            {
                SetProperty(ref _useB, value);
                _mPCMNode.UseB = value;
            }
        }
    }
}
