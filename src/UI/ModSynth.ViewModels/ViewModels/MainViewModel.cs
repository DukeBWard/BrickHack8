using ModSynth.Graph;
using ModSynth.Graph.Nodes.Interfaces;

namespace ModSynth.ViewModels.ViewModels
{
    public class MainViewModel
    {
        SynthGraph _synthGraph;

        List<INode> preset1 = new List<INode>() 
        {

        };

        public MainViewModel()
        {
            _synthGraph = new SynthGraph();
        }
    }
}
