using System.Windows.Media;
using ElectronMaster.Model;

namespace ElectronMaster.View
{
    /// <summary>
    /// Interaction logic for RadekPrvku.xaml
    /// </summary>
    public partial class RadekPrvku
    {
        public RadekPrvku(Prvek prvek)
        {
            InitializeComponent();

            PrvekRadku = prvek;

            NazevCesky.Text = prvek.NazevCesky;
            TypPrvkuTb.Text = prvek.TypPrvku.ToString();
            PocetElektronu.Text = prvek.PocetElektronu.ToString();

            Znacka.Text = prvek.Znacka;
            NazevLatinsky.Text = prvek.NazevLatinsky;

            switch (prvek.TypPrvku)
            {
                case TypPrvku.Nekov:
                    ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE44424"));
                    break;
                case TypPrvku.Polokov:
                    ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF67BCDB"));
                    break;
                case TypPrvku.Kov:
                    ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA2AB58"));
                    break;
                default:
                    ZnackaPozadi.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#252526"));
                    break;
            }
        }

        public Prvek PrvekRadku { get; private set; }
    }
}
