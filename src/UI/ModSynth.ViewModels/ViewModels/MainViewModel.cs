using ModSynth.Graph;
using ModSynth.Rendering;
using ModSynth.ViewModels.Presets;
using ModSynth.ViewModels.Presets.Abstract;

namespace ModSynth.ViewModels.ViewModels
{
    public class MainViewModel
    {
        Preset _preset = new Preset1();
        AudioRenderer _renderer;

        public MainViewModel(AudioRenderer renderer)
        {
            _renderer = renderer;
            _renderer.Graph = _preset.SynthGraph;
            _renderer.Play();
        }
    }
}
