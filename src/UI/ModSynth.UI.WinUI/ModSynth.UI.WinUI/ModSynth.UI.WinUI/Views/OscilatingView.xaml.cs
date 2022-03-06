using Microsoft.UI.Xaml.Controls;
using ModSynth.ViewModels.Presets;
using ModSynth.ViewModels.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ModSynth.UI.WinUI.Views
{
    public sealed partial class OscilatingView : UserControl
    {
        public Preset3 _preset;

        public OscilatingView(MainViewModel mainViewModel)
        {
            ViewModel = mainViewModel;
            this.InitializeComponent();

            _preset = new Preset3();
            ViewModel.Preset = _preset;
            WaveViewModel1 = new WaveGeneratorNodeViewModel(_preset.WaveGeneratorNode1);
            WaveViewModel2 = new WaveGeneratorNodeViewModel(_preset.WaveGeneratorNode2);
        }

        public MainViewModel ViewModel { get; set; }

        public WaveGeneratorNodeViewModel WaveViewModel1 { get; }

        public WaveGeneratorNodeViewModel WaveViewModel2 { get; }
    }
}
