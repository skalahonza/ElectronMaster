using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using ElectronMaster.Model;
using ElectronMaster.Properties;

namespace ElectronMaster.View
{
    /// <summary>
    /// Interaction logic for ElectronDiagram.xaml
    /// </summary>
    public partial class ElectronDiagram : UserControl, INotifyPropertyChanged
    {
        const int margin = 5;  //čím menší tím budou šipky blíže k sobě

        public ElectronDiagram()
        {
            InitializeComponent();
        }

        public ElectronDiagram(Configuration subConfiguration)
        {
            InitializeComponent();
            SubConfiguration = subConfiguration;
        }

        private void Render()
        {
            //rozpoznání orbitalu  
            var electronsToConfig = SubConfiguration.Electrons;

            ToolTip = SubConfiguration.ToString();
            Width = (int)(SubConfiguration.OrbitalType) * 100 + 50; //přizpůsobení šířky

            //vykreslení potřebného množství čtverečku
            for (var count = 0; count < (int)SubConfiguration.OrbitalType * 2 + 1; count++)
            {
                var rect = new Rectangle() { Width = 50, Height = 50, Stroke = Brushes.Gray, Fill = Brushes.White, StrokeThickness = 3 };

                Canvas.SetLeft(rect, count * 50);
                KresliciPlocha.Children.Add(rect);
            }

            //výstavbový princip
            //spinové pravidlo
            //elektrony s kladným spinem
            for (var count = 0; count < (int)SubConfiguration.OrbitalType * 2 + 1; count++)
            {
                if (electronsToConfig > 0)
                {
                    KresliciPlocha.Children.Add(ArrowUp(count * 50 + 25));
                    electronsToConfig--;
                }
            }
            //elektrony s opačným spinem
            for (var count = 0; count < (int)SubConfiguration.OrbitalType * 2 + 1; count++)
            {
                if (electronsToConfig > 0)
                {
                    KresliciPlocha.Children.Add(ArrowDown(count * 50 + 25));
                    electronsToConfig--;
                }
            }
        }

        public static readonly DependencyProperty SubConfigurationProperty = DependencyProperty.Register(
            nameof(SubConfiguration), typeof(Configuration), typeof(ElectronDiagram), new PropertyMetadata(default(Configuration)));

        public Configuration SubConfiguration
        {
            get => (Configuration)GetValue(SubConfigurationProperty);
            set
            {
                SetValue(SubConfigurationProperty, value);
                OnPropertyChanged();
                Render();
            }
        }

        private Polyline ArrowUp(int xStredu, int yStredu = 25)
        {
            return new Polyline() //šipka nahoru
            {
                Points = new PointCollection()

                {
                    new Point(xStredu - margin -5, yStredu - 3),
                    new Point(xStredu - margin, yStredu - 10),
                    new Point(xStredu - margin, yStredu + 15)

                },
                Stroke = Brushes.CadetBlue,
                Fill = Brushes.Transparent,
                StrokeThickness = 3
            };
        }

        private Polyline ArrowDown(int xStredu, int yStredu = 25)
        {
            return new Polyline() //šipka nahoru
            {
                Points = new PointCollection()

                {
                    new Point(xStredu + margin, yStredu - 13),
                    new Point(xStredu + margin, yStredu + 11),
                    new Point(xStredu + margin + 5, yStredu + 3)
                },
                Stroke = Brushes.Tomato,
                Fill = Brushes.Transparent,
                StrokeThickness = 3
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
