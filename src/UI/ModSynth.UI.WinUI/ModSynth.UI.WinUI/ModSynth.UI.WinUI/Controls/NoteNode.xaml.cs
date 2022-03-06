using Microsoft.UI.Xaml.Controls;
using ModSynth.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ModSynth.UI.WinUI.Controls
{
    public sealed partial class NoteNode : UserControl
    {
        public NoteNode()
        {
            this.InitializeComponent();
        }

        public NoteNodeViewModel ViewModel => DataContext as NoteNodeViewModel;
    }
}
