using System.Windows.Media;
using ElectronMaster.Model;

namespace ElectronMaster.View
{
    /// <summary>
    /// Interaction logic for RadekPrvku.xaml
    /// </summary>
    public partial class RadekPrvku
    {
        public RadekPrvku(Element element)
        {
            InitializeComponent();

            RowRadku = element;

            NazevCesky.Text = element.CzechName;
            TypPrvkuTb.Text = element.ElementType.ToString();
            PocetElektronu.Text = element.Electrons.ToString();

            Znacka.Text = element.Symbol;
            NazevLatinsky.Text = element.LatinName;

            switch (element.ElementType)
            {
                case ElementType.Nekov:
                    ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE44424"));
                    break;
                case ElementType.Polokov:
                    ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF67BCDB"));
                    break;
                case ElementType.Kov:
                    ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA2AB58"));
                    break;
                default:
                    ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#252526"));
                    break;
            }
        }

        public Element RowRadku { get; private set; }
    }
}
