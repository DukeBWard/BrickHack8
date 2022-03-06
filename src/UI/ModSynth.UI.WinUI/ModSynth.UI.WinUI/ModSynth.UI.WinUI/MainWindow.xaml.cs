using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ModSynth.UI.WinUI.Rendering;
using ModSynth.UI.WinUI.Views;
using ModSynth.ViewModels.ViewModels;

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
        private MainViewModel _mainViewModel;

        public MainWindow()
        {
            this.InitializeComponent();
            _renderer = new AudioGraphRenderer();
            _mainViewModel = new MainViewModel(_renderer);
            VisualizerRunner = new VisualizerRunner(_renderer);
        }

        public VisualizerRunner VisualizerRunner { get; }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WelcomeMsg.Visibility = Visibility.Collapsed;

            string pageName = (string)((ComboBoxItem)e.AddedItems[0]).Content;

            switch (pageName)
            {
                case "Chord 3":
                    Frame.Content = new Chord3View(_mainViewModel);
                    break;
                case "Default":
                    Frame.Content = new DefaultView(_mainViewModel);
                    break;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!_renderer.IsInitialized) await _renderer.InitializeAsync();

            if (_renderer.IsPlaying)
            {
                _renderer.Pause();
                PlayPauseIcon.Symbol = Symbol.Play;
            }
            else
            {
                _renderer.Play();
                PlayPauseIcon.Symbol = Symbol.Pause;
            }
        }
    }
}
