using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ModSynth.ViewModels.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ModSynth.UI.WinUI.Controls
{
    public sealed partial class WaveGen : UserControl
    {
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(nameof(Minimum), typeof(double), typeof(WaveGen), new PropertyMetadata(0d));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(nameof(Maximum), typeof(double), typeof(WaveGen), new PropertyMetadata(2000d));

        public static readonly DependencyProperty IncrementProperty =
            DependencyProperty.Register(nameof(Increment), typeof(double), typeof(WaveGen), new PropertyMetadata(1d));

        public WaveGen()
        {
            this.InitializeComponent();
        }

        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public double Increment
        {
            get { return (double)GetValue(IncrementProperty); }
            set { SetValue(IncrementProperty, value); }
        }

        public WaveGeneratorNodeViewModel ViewModel => DataContext as WaveGeneratorNodeViewModel;
    }
}
