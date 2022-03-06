using ModSynth.Rendering;
using ModSynth.ViewModels.Presets.Abstract;

namespace ModSynth.ViewModels.ViewModels
{
    public class MainViewModel
    {
        private AudioRenderer _renderer;
        private Preset? _preset;

        public MainViewModel(AudioRenderer renderer)
        {
            _renderer = renderer;
            _renderer.Play();
        }

        public Preset? Preset
        {
            get => _preset;
            set
            {
                if (value == null) return;

                _preset = value;
                _renderer.Graph = value.SynthGraph;
            }
        }
    }
}
