using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ElectronMaster.Model;

namespace ElectronMaster.View
{
    /// <summary>
    /// Interaction logic for ElementFrame.xaml
    /// </summary>
    public partial class ElementFrame : UserControl
    {
        private string _metality;

        public string CzechName { get; set; }
        public string LatinName {
            get
            {
                return (string)GetValue(LatinDependencyProperty);
            }
            set
            {
                SetValue(LatinDependencyProperty,value);
            }
        }

        public string Symbol { get; set; }
        public int Electrons { get; set; }
        public string Metality
        {
            get { return _metality; }
            set
            {

                _metality = value;
                switch (_metality)
                {
                    case "Kov":
                        ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA2AB58"));
                        break;
                    case "Nekov":
                        ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE44424"));
                        break;
                    case "Polokov":
                        ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF67BCDB"));
                        break;
                    default:
                        ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#252526"));
                        break;
                }
            }
        }

        public static DependencyProperty CzechDependencyProperty = DependencyProperty.Register("CzechName", typeof(string), typeof(ElementFrame));
        public static DependencyProperty SymbolDependencyProperty = DependencyProperty.Register("Symbol", typeof(string), typeof(ElementFrame));
        public static DependencyProperty ElectronsDependencyProperty = DependencyProperty.Register("Electrons", typeof(int), typeof(ElementFrame));
        public static DependencyProperty LatinDependencyProperty = DependencyProperty.Register("LatinName", typeof(string), typeof(ElementFrame), new PropertyMetadata(string.Empty));

        public ElementFrame()
        {
            InitializeComponent();
        }

        public ElementFrame(Element element)
        {
            InitializeComponent();
            CzechName = ceskyNazevTB.Text = element.CzechName;
            LatinName = element.LatinName;
            Symbol = znackaTB.Text = element.Symbol;
            Electrons = int.Parse(elektronyTB.Text = element.Electrons.ToString());
            Metality = element.ElementType.ToString();
        }

        private void UI_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsEnabled)
                Opacity = 1;
            else
                Opacity = 0.5;
        }
    }
}
