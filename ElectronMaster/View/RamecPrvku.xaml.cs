using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ElectronMaster.Model;

namespace ElectronMaster.View
{
    /// <summary>
    /// Interaction logic for RamecPrvku.xaml
    /// </summary>
    public partial class RamecPrvku : UserControl
    {
        private string _kovovitost;

        public string NazevCesky { get; set; }
        public string NazevLatinsky {
            get
            {
                return (string)GetValue(LatinskyDependencyProperty);
            }
            set
            {
                SetValue(LatinskyDependencyProperty,value);
            }
        }

        public string Znacka { get; set; }
        public int PocetElektronu { get; set; }
        public string Kovovitost
        {
            get { return _kovovitost; }
            set
            {

                _kovovitost = value;
                switch (_kovovitost)
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

        public static DependencyProperty CeskyDependencyProperty = DependencyProperty.Register("NazevCesky", typeof(string), typeof(RamecPrvku)); //registrace vlastnosti jako dependency <-- bude se aktualizovat a hlavně to půjde nastavit z xaml
        public static DependencyProperty ZnackaDependencyProperty = DependencyProperty.Register("Znacka", typeof(string), typeof(RamecPrvku));
        public static DependencyProperty ElektronyDependencyProperty = DependencyProperty.Register("PocetElektronu", typeof(int), typeof(RamecPrvku));
        public static DependencyProperty LatinskyDependencyProperty = DependencyProperty.Register("NazevLatinsky", typeof(string), typeof(RamecPrvku), new PropertyMetadata(string.Empty));

        public RamecPrvku()
        {
            InitializeComponent();
        }

        public RamecPrvku(Prvek prvek)
        {
            InitializeComponent();
            NazevCesky = ceskyNazevTB.Text = prvek.NazevCesky;
            NazevLatinsky = prvek.NazevLatinsky;
            Znacka = znackaTB.Text = prvek.Znacka;
            PocetElektronu = int.Parse(elektronyTB.Text = prvek.PocetElektronu.ToString());
            Kovovitost = prvek.TypPrvku.ToString();
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
