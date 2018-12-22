using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Shapes;
using ElectronMaster.Extensions;
using ElectronMaster.Model;

namespace ElectronMaster.Controls
{
    public class ElectronDiagram : AppUserControl
    {
        public static readonly DependencyProperty SubConfigurationProperty = DependencyProperty.Register(
            nameof(SubConfiguration), typeof(Configuration), typeof(ElectronDiagram), new PropertyMetadata(default(Configuration)));

        public ElectronDiagram()
        {
            DataContext = this;
        }

        public Configuration SubConfiguration
        {
            get => (Configuration) GetValue(SubConfigurationProperty);
            set
            {
                SetValue(SubConfigurationProperty, value);
                Shapes = new ObservableCollection<Shape>(SubConfiguration.GetGraphics());

                OnPropertyChanged();
                OnPropertyChanged(nameof(Shapes));
                OnPropertyChanged(nameof(OptimalWidth));
                OnPropertyChanged(nameof(SubConfigurationText));
            }
        }

        public double OptimalWidth => (int) (SubConfiguration.OrbitalType) * 100 + 50;
        [Bindable(true)]
        public string SubConfigurationText => SubConfiguration.ToString();

        public ObservableCollection<Shape> Shapes { get; set; } = new ObservableCollection<Shape>();
    }
}