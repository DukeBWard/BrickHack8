using Microsoft.UI.Xaml.Controls;
using ModSynth.ViewModels;
using ModSynth.ViewModels.Presets;
using ModSynth.ViewModels.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ModSynth.UI.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Chord3View : Page
    {
        public Preset2 _preset;

        public Chord3View(MainViewModel mainViewModel)
        {
            ViewModel = mainViewModel;
            this.InitializeComponent();

            _preset = new Preset2();
            ViewModel.Preset = _preset;
            Note1ViewModel = new NoteNodeViewModel(_preset.Note1);
            Note2ViewModel = new NoteNodeViewModel(_preset.Note2);
            Note3ViewModel = new NoteNodeViewModel(_preset.Note3);
            Mix1ViewModel = new MixPCMNodeViewModel(_preset.Mix1);
            Mix2ViewModel = new MixPCMNodeViewModel(_preset.Mix2);
        }

        public MainViewModel ViewModel { get; set; }

        public NoteNodeViewModel Note1ViewModel { get; }

        public NoteNodeViewModel Note2ViewModel { get; }

        public NoteNodeViewModel Note3ViewModel { get; }

        public MixPCMNodeViewModel Mix1ViewModel { get; }

        public MixPCMNodeViewModel Mix2ViewModel { get; }
    }
}
