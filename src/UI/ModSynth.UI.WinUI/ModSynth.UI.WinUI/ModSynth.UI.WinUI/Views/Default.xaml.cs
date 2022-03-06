using Microsoft.UI.Xaml.Controls;
using ModSynth.ViewModels.Presets;
using ModSynth.ViewModels.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ModSynth.UI.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DefaultView : UserControl
    {
        public Preset1 _preset;

        public DefaultView(MainViewModel mainViewModel)
        {
            ViewModel = mainViewModel;
            this.InitializeComponent();

            _preset = new Preset1();
            ViewModel.Preset = _preset;
            WaveViewModel = new WaveGeneratorNodeViewModel(_preset.WaveGeneratorNode);
        }

        public MainViewModel ViewModel { get; set; }

        public WaveGeneratorNodeViewModel WaveViewModel { get; }
    }
}
