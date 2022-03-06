using Microsoft.UI.Xaml.Controls;
using ModSynth.ViewModels.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ModSynth.UI.WinUI.Controls
{
    public sealed partial class WaveGen : UserControl
    {
        public WaveGen()
        {
            this.InitializeComponent();
        }

        public WaveGeneratorNodeViewModel ViewModel => DataContext as WaveGeneratorNodeViewModel;
    }
}
