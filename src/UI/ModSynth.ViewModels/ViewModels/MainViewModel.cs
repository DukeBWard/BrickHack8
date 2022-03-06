using ModSynth.Graph;
using ModSynth.ViewModels.Presets;
using ModSynth.ViewModels.Presets.Abstract;

namespace ModSynth.ViewModels.ViewModels
{
    public class MainViewModel
    {
        SynthGraph _synthGraph;
        Preset _preset1 = new Preset1();

        public MainViewModel()
        {
            _synthGraph = _preset1._synthGraph;
        }
    }
}
