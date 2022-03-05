using Microsoft.UI.Xaml;
using ModSynth.UI.WinUI.Rendering;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ModSynth.UI.WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private AudioGraphRenderer _renderer;

        public MainWindow()
        {
            this.InitializeComponent();
            _renderer = new AudioGraphRenderer();
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_renderer.IsInitialized) await _renderer.InitializeAsync();

            if (_renderer.IsPlaying)
            {
                _renderer.Pause();
                myButton.Content = "Play";
            }
            else
            {
                _renderer.Play();
                myButton.Content = "Pause";
            }
        }
    }
}
