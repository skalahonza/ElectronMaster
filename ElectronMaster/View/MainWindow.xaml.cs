using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ElectronMaster.Model;
using Microsoft.Win32;

namespace ElectronMaster.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Globální proměnné
        RadekPrvku _praveZkoumanyPrvek;
        private readonly Prvek[] _prvky = new Prvek[118]
        {
            new Prvek("H", "Vodík", "Hydrogenium", TypPrvku.Nekov, 1),
            new Prvek("He", "Helium", "Helium", TypPrvku.Nekov, 2),
            new Prvek("Li", "Lithium", "Lithium", TypPrvku.Kov, 3),
            new Prvek("Be", "Beryllium", "Beryllium", TypPrvku.Kov, 4),
            new Prvek("B", "Bor", "Borum", TypPrvku.Polokov, 5),
            new Prvek("C", "Uhlík", "Carboneum", TypPrvku.Nekov, 6),
            new Prvek("N", "Dusík", "Nitrogenium", TypPrvku.Nekov, 7),
            new Prvek("O", "Kyslík", "Oxygenium", TypPrvku.Nekov, 8),
            new Prvek("F", "Fluor", "Fluorum", TypPrvku.Nekov, 9),
            new Prvek("Ne", "Neon", "Neon", TypPrvku.Nekov, 10),
            new Prvek("Na", "Sodík", "Natrium", TypPrvku.Kov, 11),
            new Prvek("Mg", "Hořčík", "Magnesium", TypPrvku.Kov, 12),
            new Prvek("Al", "Hliník", "Aluminium", TypPrvku.Kov, 13),
            new Prvek("Si", "Křemík", "Silicium", TypPrvku.Polokov, 14),
            new Prvek("P", "Fosfor", "Phosphorus", TypPrvku.Nekov, 15),
            new Prvek("S", "Síra", "Sulphur", TypPrvku.Nekov, 16),
            new Prvek("Cl", "Chlor", "Chlorum", TypPrvku.Nekov, 17),
            new Prvek("Ar", "Argon", "Argon", TypPrvku.Nekov, 18),
            new Prvek("K", "Draslík", "Kalium", TypPrvku.Kov, 19),
            new Prvek("Ca", "Vápník", "Calcium", TypPrvku.Kov, 20),
            new Prvek("Sc", "Skandium", "Scandium", TypPrvku.Kov, 21),                                                  
            new Prvek("Ti", "Titan", "Titanium", TypPrvku.Kov, 22),
            new Prvek("V", "Vanad", "Vanadium", TypPrvku.Kov, 23),
            new Prvek("Cr", "Chrom", "Chromium", TypPrvku.Kov, 24),
            new Prvek("Mn", "Mangan", "Manganum", TypPrvku.Kov, 25),
            new Prvek("Fe", "Železo", "Ferrum", TypPrvku.Kov, 26),
            new Prvek("Co", "Kobalt", "Cobaltum", TypPrvku.Kov, 27),
            new Prvek("Ni", "Nikl", "Niccolum", TypPrvku.Kov, 28),
            new Prvek("Cu", "Měď", "Cuprum", TypPrvku.Kov, 29),
            new Prvek("Zn", "Zinek", "Zincum", TypPrvku.Kov, 30),
            new Prvek("Ga", "Gallium", "Gallium", TypPrvku.Kov, 31),
            new Prvek("Ge", "Germanium", "Germanium", TypPrvku.Polokov, 32),
            new Prvek("As", "Arsen", "Arsenicum", TypPrvku.Polokov, 33),
            new Prvek("Se", "Selen", "Selenium", TypPrvku.Nekov, 34),
            new Prvek("Br", "Brom", "Bromum", TypPrvku.Nekov, 35),
            new Prvek("Kr", "Krypton", "Krypton", TypPrvku.Nekov, 36),
            new Prvek("Rb", "Rubidium", "Rubidium", TypPrvku.Kov, 37),
            new Prvek("Sr", "Stroncium", "Strontium", TypPrvku.Kov, 38),
            new Prvek("Y", "Yttrium", "Yttrium", TypPrvku.Kov, 39),
            new Prvek("Zr", "Zirkonium", "Zirconium", TypPrvku.Kov, 40),
            new Prvek("Nb", "Niob", "Niobium", TypPrvku.Kov, 41),
            new Prvek("Mo", "Molybden", "Molybdaenum", TypPrvku.Kov, 42),
            new Prvek("Tc", "Technecium", "Technetium", TypPrvku.Kov, 43),
            new Prvek("Ru", "Ruthenium", "Ruthenium", TypPrvku.Kov, 44),
            new Prvek("Rh", "Rhodium", "Rhodium", TypPrvku.Kov, 45),
            new Prvek("Pd", "Palladium", "Palladium", TypPrvku.Kov, 46),
            new Prvek("Ag", "Stříbro", "Argentum", TypPrvku.Kov, 47),
            new Prvek("Cd", "Kadmium", "Cadmium", TypPrvku.Kov, 48),
            new Prvek("In", "Indium", "Indium", TypPrvku.Kov, 49),
            new Prvek("Sn", "Cín", "Stannum", TypPrvku.Kov, 50),
            new Prvek("Sb", "Antimon", "Stibium", TypPrvku.Polokov, 51),
            new Prvek("Te", "Tellur", "Tellurium", TypPrvku.Polokov, 52),
            new Prvek("I", "Jod", "Iodium", TypPrvku.Nekov, 53),
            new Prvek("Xe", "Xenon", "Xenon", TypPrvku.Nekov, 54),
            new Prvek("Cs", "Cesium", "Caesium", TypPrvku.Kov, 55),
            new Prvek("Ba", "Baryum", "Baryum", TypPrvku.Kov, 56),
            new Prvek("La", "Lanthan", "Lanthanum", TypPrvku.Kov, 57),
            new Prvek("Ce", "Cer", "Cerium", TypPrvku.Kov, 58),
            new Prvek("Pr", "Praseodym", "Praseodymium", TypPrvku.Kov, 59),
            new Prvek("Nd", "Neodym", "Neodymium", TypPrvku.Kov, 60),
            new Prvek("Pm", "Promethium", "Promethium", TypPrvku.Kov, 61),
            new Prvek("Sm", "Samarium", "Samarium", TypPrvku.Kov, 62),
            new Prvek("Eu", "Europium", "Europium", TypPrvku.Kov, 63),
            new Prvek("Gd", "Gadolinium", "Gadolinium", TypPrvku.Kov, 64),
            new Prvek("Tb", "Terbium", "Terbium", TypPrvku.Kov, 65),
            new Prvek("Dy", "Dysprosium", "Dysprosium", TypPrvku.Kov, 66),
            new Prvek("Ho", "Holmium", "Holmium", TypPrvku.Kov, 67),
            new Prvek("Er", "Erbium", "Erbium", TypPrvku.Kov, 68),
            new Prvek("Tm", "Thulium", "Thulium", TypPrvku.Kov, 69),
            new Prvek("Yb", "Ytterbium", "Ytterbium", TypPrvku.Kov, 70),
            new Prvek("Lu", "Lutecium", "Lutetium", TypPrvku.Kov, 71),
            new Prvek("Hf", "Hafnium", "Hafnium", TypPrvku.Kov, 72),
            new Prvek("Ta", "Tantal", "Tantalum", TypPrvku.Kov, 73),
            new Prvek("W", "Wolfram", "Wolframium", TypPrvku.Kov, 74),
            new Prvek("Re", "Rhenium", "Rhenium", TypPrvku.Kov, 75),
            new Prvek("Os", "Osmium", "Osmium", TypPrvku.Kov, 76),
            new Prvek("Ir", "Iridium", "Iridium", TypPrvku.Kov, 77),
            new Prvek("Pt", "Platina", "Platinium", TypPrvku.Kov, 78),
            new Prvek("Au", "Zlato", "Aurum", TypPrvku.Kov, 79),
            new Prvek("Hg", "Rtuť", "Hydrargyrum", TypPrvku.Kov, 80),
            new Prvek("Tl", "Thallium", "Thallium", TypPrvku.Kov, 81),
            new Prvek("Pb", "Olovo", "Plumbum", TypPrvku.Kov, 82),
            new Prvek("Bi", "Bismut", "Bismuthum", TypPrvku.Kov, 83),
            new Prvek("Po", "Polonium", "Polonium", TypPrvku.Polokov, 84),
            new Prvek("At", "Astat", "Astatum", TypPrvku.Nekov, 85),
            new Prvek("Rn", "Radon", "Radon", TypPrvku.Nekov, 86),
            new Prvek("Fr", "Francium", "Francium", TypPrvku.Kov, 87),
            new Prvek("Ra", "Radium", "Radium", TypPrvku.Kov, 88),
            new Prvek("Ac", "Aktinium", "Actinium", TypPrvku.Kov, 89),
            new Prvek("Th", "Thorium", "Thorium", TypPrvku.Kov, 90),
            new Prvek("Pa", "Protaktinium", "Protaktinium", TypPrvku.Kov, 91),
            new Prvek("U", "Uran", "Uranium", TypPrvku.Kov, 92),
            new Prvek("Np", "Neptunium", "Neptunium", TypPrvku.Kov, 93),
            new Prvek("Pu", "Plutonium", "Plutonium", TypPrvku.Kov, 94),
            new Prvek("Am", "Americium", "Americium", TypPrvku.Kov, 95),
            new Prvek("Cm", "Curium", "Curium", TypPrvku.Kov, 96),
            new Prvek("Bk", "Berkelium", "Berkelium", TypPrvku.Kov, 97),
            new Prvek("Cf", "Kalifornium", "Californium", TypPrvku.Kov, 98),
            new Prvek("Es", "Einsteinium", "Einsteinium", TypPrvku.Kov, 99),
            new Prvek("Fm", "Fermium", "Fermium", TypPrvku.Kov, 100),
            new Prvek("Md", "Mendelevium", "Mendelevium", TypPrvku.Kov, 101),
            new Prvek("No", "Nobelium", "Nobelium", TypPrvku.Kov, 102),
            new Prvek("Lr", "Lawrencium", "Lawrencium", TypPrvku.Kov, 103),
            new Prvek("Rf", "Rutherfordium", "Rutherfordium", TypPrvku.Kov, 104),
            new Prvek("Db", "Dubnium", "Dubnium", TypPrvku.Kov, 105),
            new Prvek("Sg", "Seaborgium", "Seaborgium", TypPrvku.Kov, 106),
            new Prvek("Bh", "Bohrium", "Bohrium", TypPrvku.Kov, 107),
            new Prvek("Hs", "Hassium", "Hassium", TypPrvku.Kov, 108),
            new Prvek("Mt", "Meitnerium", "Meitnerium", TypPrvku.Kov, 109),
            new Prvek("Ds", "Darmstadtium", "Darmstadtium", TypPrvku.Kov, 110),
            new Prvek("Rg", "Roentgenium", "Roentgenium", TypPrvku.Kov, 111),
            new Prvek("Cn", "Kopernicium", "Copernicium", TypPrvku.Umělý, 112),
            new Prvek("Uut", "Ununtrium", "Ununtrium", TypPrvku.Umělý, 113),
            new Prvek("Fl", "Flerovium", "Flerovium", TypPrvku.Umělý, 114),
            new Prvek("Uup", "Ununpentium", "Ununpentium", TypPrvku.Umělý, 115),
            new Prvek("Lv", "Livermorium", "Livermorium", TypPrvku.Umělý, 116),
            new Prvek("Uus", "Ununseptium", "Ununseptium", TypPrvku.Umělý, 117),
            new Prvek("Uuo", "Ununoctium", "Ununoctium", TypPrvku.Umělý, 118)
        };
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            #region nakreslení tabulky prvků
            //perioda 4 a 5
            int protonoveCislo = 19;
            for (int radek = 3; radek < 5; radek++)
                for (int sloupec = 0; sloupec < 18; sloupec ++)
                {
                    var ramec = new RamecPrvku(_prvky[protonoveCislo - 1]);
                    if (sloupec == 2) //pokud jsou to prvky třetí periody tak se oddělí od právě části tabulky
                        ramec.Margin = new Thickness(0, 0, 5, 0);
                    ramec.MouseDown += vybratRamec;
                    PeriodickaTabulka.Children.Add(ramec);
                    Grid.SetColumn(ramec, sloupec);
                    Grid.SetRow(ramec, radek);
                    protonoveCislo++;
                }
            //4 až 8 skupina 6. a 7. periody
            protonoveCislo = 72;
            for(int radek = 5; radek < 7; radek++)
            {
                for (int sloupec = 3; sloupec < 18; sloupec++)
                {
                    var ramec = new RamecPrvku(_prvky[protonoveCislo - 1]);
                    ramec.MouseDown += vybratRamec;
                    PeriodickaTabulka.Children.Add(ramec);
                    Grid.SetColumn(ramec, sloupec);
                    Grid.SetRow(ramec, radek);
                    protonoveCislo++;
                }
                protonoveCislo = 104;
            }

            //lantanoidy a aktinoidy
            protonoveCislo = 58;
            for (int radek = 7; radek < 9; radek++)
            {
                for (int sloupec = 3; sloupec < 18; sloupec++)
                {
                    var ramec = new RamecPrvku(_prvky[protonoveCislo - 1]);
                    if(radek == 7)
                        ramec.Margin = new Thickness(0, 5, 0, 0); //oddělení lantanoidů a aktinoidů od zbytku tabulky

                    ramec.MouseDown += vybratRamec;
                    PeriodickaTabulka.Children.Add(ramec);
                    Grid.SetColumn(ramec, sloupec);
                    Grid.SetRow(ramec, radek);
                    protonoveCislo++;
                }
                protonoveCislo = 90;
            }
            //prvky třetí až osmé skupiny
            protonoveCislo = 5;
            for (int radek = 1; radek < 3; radek++)
            {
                for (int sloupec = 12; sloupec < 18; sloupec++)
                {
                    var ramec = new RamecPrvku(_prvky[protonoveCislo - 1]);
                    ramec.MouseDown += vybratRamec;
                    PeriodickaTabulka.Children.Add(ramec);
                    Grid.SetColumn(ramec, sloupec);
                    Grid.SetRow(ramec, radek);
                    protonoveCislo++;
                }
                protonoveCislo = 13;
            }
            #endregion

            SearchTextBox_TextChanged(null,null);
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "Hledat...")
                ((TextBox)sender).Text = "";
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "")
                ((TextBox)sender).Text = "Hledat...";
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            try
            {
              SeznamPrvku.Items.Clear();
                foreach (var ramec in PeriodickaTabulka.Children)
                    ((RamecPrvku) ramec).IsEnabled = true;    //zapnutí všech položek v tabluce
            }
            catch
            {
                // ignored
            }

            if (SearchTextBox.Text == "Hledat...")
                //přidej do seznamu všechny prvky
                try
                {
                    foreach (var polozka in _prvky.Where(polozka => polozka != null))
                        SeznamPrvku.Items.Add(new RadekPrvku(polozka));
                }
                catch
                {
                    // ignored
                }
            else
                foreach (
                    var prvek in
                        _prvky.Where(
                            x =>
                                x.NazevCesky.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                                x.NazevLatinsky.ToLower().Contains(SearchTextBox.Text.ToLower())))
                    SeznamPrvku.Items.Add(new RadekPrvku(prvek));

            //vypnutí nepotřebných prvků
            if(SearchTextBox.Text != "Hledat..." && SearchTextBox.Text.Length > 0)
                foreach (
                    var ramec in
                        PeriodickaTabulka.Children.OfType<RamecPrvku>()
                            .Where(x => !x.ceskyNazevTB.Text.ToLower().Contains(SearchTextBox.Text.ToLower()) &&
                                        !x.NazevLatinsky.ToLower().Contains(SearchTextBox.Text.ToLower())))
                {
                    ramec.IsEnabled = false; // vypnutí neodpovídajících prvků
                }
        }

        private void SeznamPrvku_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SeznamPrvku.SelectedIndex != -1) //ošetření proti výjimce
                ZvoleniZkoumanehoPrvku(((RadekPrvku) SeznamPrvku.SelectedItem).PrvekRadku);
        } 

        /// <summary>
        /// Nastaví prvek který si vybral uživatel jako právě zkoumaný, zobrazí ho vlevo nahoře a provede jeho konfiguraci
        /// </summary>
        /// <param name="zvolenyPrvek">zvolený prvek ze seznamu nebo z tabulky</param>
        private void ZvoleniZkoumanehoPrvku(Prvek zvolenyPrvek)
        {
            if (MainGrid.Children.Contains(_praveZkoumanyPrvek))
                MainGrid.Children.Remove(_praveZkoumanyPrvek);//smazání starého prvku pokud tam je

            MainGrid.Children.Add(_praveZkoumanyPrvek = new RadekPrvku(zvolenyPrvek));

            Grid.SetRow(_praveZkoumanyPrvek, 0);
            Grid.SetColumn(_praveZkoumanyPrvek, 0);

            //TextovaKonfiguraceTb.Text = "";
            TextovaKonfiguraceTb.Document = new FlowDocument();

            TextovaKonfigurace();
            ObrazovaKonfigurace();
            KonfiguracePodleVzacnehoPlynu();

            StabilitaTB.Visibility = _praveZkoumanyPrvek.PrvekRadku.SpecialniKonfigurace
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        /// <summary>
        /// Zobrazí textovou konfiguraci proi právě zkoumaný prvek
        /// </summary>
        private void TextovaKonfigurace()
        {
            TextovaKonfiguraceTb.Visibility = Visibility.Visible;
            Paragraph text = new Paragraph();

            foreach (var konfigurace in _praveZkoumanyPrvek.PrvekRadku.ElektronovaKonfigurace())
            {
              text.Inlines.Add(new Run(konfigurace.CisloPeriody.ToString()));
              text.Inlines.Add(new Run(konfigurace.TypOrbitalu.ToString()));
              text.Inlines.Add(new Run(konfigurace.PocetElektronu.ToString()){BaselineAlignment = BaselineAlignment.Superscript, FontSize = 10});
              text.Inlines.Add(new Run(" "));
            }
            text.Inlines.Remove(text.Inlines.Last(x => true));
            TextovaKonfiguraceTb.Document.Blocks.Add(text);

        }

        /// <summary>
        /// Zobrazí grafickou konfiguraci pro právě zkoumaný prvek
        /// </summary>
        private void ObrazovaKonfigurace()
        {
            if (SchematickaKonfigurace.Children.Count != 0) 
                SchematickaKonfigurace.Children.Clear();

            foreach (var subKonfigurace in _praveZkoumanyPrvek.PrvekRadku.ElektronovaKonfigurace())
            {
                SchematickaKonfigurace.Children.Add(new ElektronovyDiagram(subKonfigurace){Margin = new Thickness(5,5,5,55)});
            }
        }

        private void KonfiguracePodleVzacnehoPlynu()
        {
            PlynovaKonfiguraceTb.Document = new FlowDocument();
            Paragraph text = new Paragraph();

            if (_praveZkoumanyPrvek.PrvekRadku.PocetElektronu <= 2)
            {
                text.Inlines.Add(new Run("Nelze napsat zkrácenou konfiguraci."));
                PlynovaKonfiguraceTb.Document.Blocks.Add(text);
                return;
            }

            Prvek nejblizsiVzacnyPlyn = _prvky[1]; //nejbližší vzácný plyn se zvolí helium
            var dostupneVzacnePlyny = _prvky.Where(
                x =>
                    x.PocetElektronu < _praveZkoumanyPrvek.PrvekRadku.PocetElektronu &&
                    x.ElektronovaKonfigurace().Last().TypOrbitalu == TypOrbitalu.p &&
                    //pokud je poslední orbital typu P a navíc je zaplněný jedná se o vzácný plyn
                    x.ElektronovaKonfigurace().Last().PocetElektronu == 6);

            if (dostupneVzacnePlyny.Any())
                nejblizsiVzacnyPlyn = dostupneVzacnePlyny.Last();
            {
             text.Inlines.Add(new Run("["));
             text.Inlines.Add(new Run(nejblizsiVzacnyPlyn.PocetElektronu.ToString()){BaselineAlignment = BaselineAlignment.Subscript, FontSize = 10});
             text.Inlines.Add(new Run(nejblizsiVzacnyPlyn.Znacka + "]"));
            }

            for (int i = nejblizsiVzacnyPlyn.ElektronovaKonfigurace().Count;
                i < _praveZkoumanyPrvek.PrvekRadku.ElektronovaKonfigurace().Count;
                i++)
            {
                text.Inlines.Add(new Run(" "));
                text.Inlines.Add(new Run(_praveZkoumanyPrvek.PrvekRadku.ElektronovaKonfigurace()[i].CisloPeriody + _praveZkoumanyPrvek.PrvekRadku.ElektronovaKonfigurace()[i].TypOrbitalu.ToString()));
                text.Inlines.Add(new Run(_praveZkoumanyPrvek.PrvekRadku.ElektronovaKonfigurace()[i].PocetElektronu.ToString()) { BaselineAlignment = BaselineAlignment.Superscript, FontSize = 10 });
            }

            PlynovaKonfiguraceTb.Document.Blocks.Add(text);
        } 

        private void vybratRamec(object sender, MouseButtonEventArgs e)
        {
            ZvoleniZkoumanehoPrvku(_prvky.First(x => x.NazevCesky == ((RamecPrvku)sender).ceskyNazevTB.Text)); 
        }

        /// <summary>
        ///  Zobrazí jen kovy polokovy nebo nekovy
        /// </summary>
        private void zvoleniTypuPrvku(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SearchTextBox.Text = "Hledat...";
                SeznamPrvku.Focus();
                SeznamPrvku.Items.Clear();

                foreach (var ramec in PeriodickaTabulka.Children)
                    ((RamecPrvku) ramec).IsEnabled = true; //zapnutí všech položek v tabluce
            }
            catch
            {
                // ignored
            }

            //přidej jen prvky stejného typu
            foreach (
                var prvek in _prvky.Where(x => x.TypPrvku == (TypPrvku) int.Parse(((TextBlock) sender).Tag.ToString())))
                SeznamPrvku.Items.Add(new RadekPrvku(prvek));

            //schovej všechny rámce, které nesjou stejného typu
            foreach (var ramec in PeriodickaTabulka.Children.OfType<RamecPrvku>().Where(x =>
                ((TypPrvku) Enum.Parse(typeof (TypPrvku), x.Kovovitost, true)) !=
                (TypPrvku) int.Parse(((TextBlock) sender).Tag.ToString())))
                ramec.IsEnabled = false;
        }

        /// <summary>
        /// Odkaz na GoID
        /// </summary>
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("http://goid.azurewebsites.net/");
        }

        /// <summary>
        /// Uloží schématickou konfiguraci jako obrázek
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsImage(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Obrázek PNG|*.png" };
            if (sfd.ShowDialog() == true)
            {
                const int dpi = 92;

                var rtb = new RenderTargetBitmap(
                    (int)SchematickaKonfigurace.ActualWidth, //width 
                    (int)SchematickaKonfigurace.ActualHeight, //height 
                    dpi, //dpi x 
                    dpi, //dpi y 
                    PixelFormats.Pbgra32 // pixelformat 
                    );
                rtb.Render(SchematickaKonfigurace);
                SaveRTBAsPNG(rtb, sfd.FileName);
            }
        }

        /// <summary>
        /// Vyexportuje vyrendrovaný obrázek jako soubor
        /// </summary>
        /// <param name="bmp">Cílový obrázek</param>
        /// <param name="filename">Cíl souboru</param>
        private void SaveRTBAsPNG(RenderTargetBitmap bmp, string filename)
        {
            var enc = new PngBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(bmp));

            using (var stm = File.Create(filename))
            {
                enc.Save(stm);
            }
        }

    }

    
}
