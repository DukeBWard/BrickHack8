using ModSynth.Graph;

namespace ModSynth.ViewModels.ViewModels
{
    public class MainViewModel
    {
        SynthGraph _synthGraph;

        public MainViewModel()
        {
            _synthGraph = new SynthGraph();
        }
    }
}
