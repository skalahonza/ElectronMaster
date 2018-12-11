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
        private readonly Element[] _prvky = new Element[118]
        {
            new Element("H", "Vodík", "Hydrogenium", ElementType.Nekov, 1),
            new Element("He", "Helium", "Helium", ElementType.Nekov, 2),
            new Element("Li", "Lithium", "Lithium", ElementType.Kov, 3),
            new Element("Be", "Beryllium", "Beryllium", ElementType.Kov, 4),
            new Element("B", "Bor", "Borum", ElementType.Polokov, 5),
            new Element("C", "Uhlík", "Carboneum", ElementType.Nekov, 6),
            new Element("N", "Dusík", "Nitrogenium", ElementType.Nekov, 7),
            new Element("O", "Kyslík", "Oxygenium", ElementType.Nekov, 8),
            new Element("F", "Fluor", "Fluorum", ElementType.Nekov, 9),
            new Element("Ne", "Neon", "Neon", ElementType.Nekov, 10),
            new Element("Na", "Sodík", "Natrium", ElementType.Kov, 11),
            new Element("Mg", "Hořčík", "Magnesium", ElementType.Kov, 12),
            new Element("Al", "Hliník", "Aluminium", ElementType.Kov, 13),
            new Element("Si", "Křemík", "Silicium", ElementType.Polokov, 14),
            new Element("P", "Fosfor", "Phosphorus", ElementType.Nekov, 15),
            new Element("S", "Síra", "Sulphur", ElementType.Nekov, 16),
            new Element("Cl", "Chlor", "Chlorum", ElementType.Nekov, 17),
            new Element("Ar", "Argon", "Argon", ElementType.Nekov, 18),
            new Element("K", "Draslík", "Kalium", ElementType.Kov, 19),
            new Element("Ca", "Vápník", "Calcium", ElementType.Kov, 20),
            new Element("Sc", "Skandium", "Scandium", ElementType.Kov, 21),                                                  
            new Element("Ti", "Titan", "Titanium", ElementType.Kov, 22),
            new Element("V", "Vanad", "Vanadium", ElementType.Kov, 23),
            new Element("Cr", "Chrom", "Chromium", ElementType.Kov, 24),
            new Element("Mn", "Mangan", "Manganum", ElementType.Kov, 25),
            new Element("Fe", "Železo", "Ferrum", ElementType.Kov, 26),
            new Element("Co", "Kobalt", "Cobaltum", ElementType.Kov, 27),
            new Element("Ni", "Nikl", "Niccolum", ElementType.Kov, 28),
            new Element("Cu", "Měď", "Cuprum", ElementType.Kov, 29),
            new Element("Zn", "Zinek", "Zincum", ElementType.Kov, 30),
            new Element("Ga", "Gallium", "Gallium", ElementType.Kov, 31),
            new Element("Ge", "Germanium", "Germanium", ElementType.Polokov, 32),
            new Element("As", "Arsen", "Arsenicum", ElementType.Polokov, 33),
            new Element("Se", "Selen", "Selenium", ElementType.Nekov, 34),
            new Element("Br", "Brom", "Bromum", ElementType.Nekov, 35),
            new Element("Kr", "Krypton", "Krypton", ElementType.Nekov, 36),
            new Element("Rb", "Rubidium", "Rubidium", ElementType.Kov, 37),
            new Element("Sr", "Stroncium", "Strontium", ElementType.Kov, 38),
            new Element("Y", "Yttrium", "Yttrium", ElementType.Kov, 39),
            new Element("Zr", "Zirkonium", "Zirconium", ElementType.Kov, 40),
            new Element("Nb", "Niob", "Niobium", ElementType.Kov, 41),
            new Element("Mo", "Molybden", "Molybdaenum", ElementType.Kov, 42),
            new Element("Tc", "Technecium", "Technetium", ElementType.Kov, 43),
            new Element("Ru", "Ruthenium", "Ruthenium", ElementType.Kov, 44),
            new Element("Rh", "Rhodium", "Rhodium", ElementType.Kov, 45),
            new Element("Pd", "Palladium", "Palladium", ElementType.Kov, 46),
            new Element("Ag", "Stříbro", "Argentum", ElementType.Kov, 47),
            new Element("Cd", "Kadmium", "Cadmium", ElementType.Kov, 48),
            new Element("In", "Indium", "Indium", ElementType.Kov, 49),
            new Element("Sn", "Cín", "Stannum", ElementType.Kov, 50),
            new Element("Sb", "Antimon", "Stibium", ElementType.Polokov, 51),
            new Element("Te", "Tellur", "Tellurium", ElementType.Polokov, 52),
            new Element("I", "Jod", "Iodium", ElementType.Nekov, 53),
            new Element("Xe", "Xenon", "Xenon", ElementType.Nekov, 54),
            new Element("Cs", "Cesium", "Caesium", ElementType.Kov, 55),
            new Element("Ba", "Baryum", "Baryum", ElementType.Kov, 56),
            new Element("La", "Lanthan", "Lanthanum", ElementType.Kov, 57),
            new Element("Ce", "Cer", "Cerium", ElementType.Kov, 58),
            new Element("Pr", "Praseodym", "Praseodymium", ElementType.Kov, 59),
            new Element("Nd", "Neodym", "Neodymium", ElementType.Kov, 60),
            new Element("Pm", "Promethium", "Promethium", ElementType.Kov, 61),
            new Element("Sm", "Samarium", "Samarium", ElementType.Kov, 62),
            new Element("Eu", "Europium", "Europium", ElementType.Kov, 63),
            new Element("Gd", "Gadolinium", "Gadolinium", ElementType.Kov, 64),
            new Element("Tb", "Terbium", "Terbium", ElementType.Kov, 65),
            new Element("Dy", "Dysprosium", "Dysprosium", ElementType.Kov, 66),
            new Element("Ho", "Holmium", "Holmium", ElementType.Kov, 67),
            new Element("Er", "Erbium", "Erbium", ElementType.Kov, 68),
            new Element("Tm", "Thulium", "Thulium", ElementType.Kov, 69),
            new Element("Yb", "Ytterbium", "Ytterbium", ElementType.Kov, 70),
            new Element("Lu", "Lutecium", "Lutetium", ElementType.Kov, 71),
            new Element("Hf", "Hafnium", "Hafnium", ElementType.Kov, 72),
            new Element("Ta", "Tantal", "Tantalum", ElementType.Kov, 73),
            new Element("W", "Wolfram", "Wolframium", ElementType.Kov, 74),
            new Element("Re", "Rhenium", "Rhenium", ElementType.Kov, 75),
            new Element("Os", "Osmium", "Osmium", ElementType.Kov, 76),
            new Element("Ir", "Iridium", "Iridium", ElementType.Kov, 77),
            new Element("Pt", "Platina", "Platinium", ElementType.Kov, 78),
            new Element("Au", "Zlato", "Aurum", ElementType.Kov, 79),
            new Element("Hg", "Rtuť", "Hydrargyrum", ElementType.Kov, 80),
            new Element("Tl", "Thallium", "Thallium", ElementType.Kov, 81),
            new Element("Pb", "Olovo", "Plumbum", ElementType.Kov, 82),
            new Element("Bi", "Bismut", "Bismuthum", ElementType.Kov, 83),
            new Element("Po", "Polonium", "Polonium", ElementType.Polokov, 84),
            new Element("At", "Astat", "Astatum", ElementType.Nekov, 85),
            new Element("Rn", "Radon", "Radon", ElementType.Nekov, 86),
            new Element("Fr", "Francium", "Francium", ElementType.Kov, 87),
            new Element("Ra", "Radium", "Radium", ElementType.Kov, 88),
            new Element("Ac", "Aktinium", "Actinium", ElementType.Kov, 89),
            new Element("Th", "Thorium", "Thorium", ElementType.Kov, 90),
            new Element("Pa", "Protaktinium", "Protaktinium", ElementType.Kov, 91),
            new Element("U", "Uran", "Uranium", ElementType.Kov, 92),
            new Element("Np", "Neptunium", "Neptunium", ElementType.Kov, 93),
            new Element("Pu", "Plutonium", "Plutonium", ElementType.Kov, 94),
            new Element("Am", "Americium", "Americium", ElementType.Kov, 95),
            new Element("Cm", "Curium", "Curium", ElementType.Kov, 96),
            new Element("Bk", "Berkelium", "Berkelium", ElementType.Kov, 97),
            new Element("Cf", "Kalifornium", "Californium", ElementType.Kov, 98),
            new Element("Es", "Einsteinium", "Einsteinium", ElementType.Kov, 99),
            new Element("Fm", "Fermium", "Fermium", ElementType.Kov, 100),
            new Element("Md", "Mendelevium", "Mendelevium", ElementType.Kov, 101),
            new Element("No", "Nobelium", "Nobelium", ElementType.Kov, 102),
            new Element("Lr", "Lawrencium", "Lawrencium", ElementType.Kov, 103),
            new Element("Rf", "Rutherfordium", "Rutherfordium", ElementType.Kov, 104),
            new Element("Db", "Dubnium", "Dubnium", ElementType.Kov, 105),
            new Element("Sg", "Seaborgium", "Seaborgium", ElementType.Kov, 106),
            new Element("Bh", "Bohrium", "Bohrium", ElementType.Kov, 107),
            new Element("Hs", "Hassium", "Hassium", ElementType.Kov, 108),
            new Element("Mt", "Meitnerium", "Meitnerium", ElementType.Kov, 109),
            new Element("Ds", "Darmstadtium", "Darmstadtium", ElementType.Kov, 110),
            new Element("Rg", "Roentgenium", "Roentgenium", ElementType.Kov, 111),
            new Element("Cn", "Kopernicium", "Copernicium", ElementType.Umělý, 112),
            new Element("Uut", "Ununtrium", "Ununtrium", ElementType.Umělý, 113),
            new Element("Fl", "Flerovium", "Flerovium", ElementType.Umělý, 114),
            new Element("Uup", "Ununpentium", "Ununpentium", ElementType.Umělý, 115),
            new Element("Lv", "Livermorium", "Livermorium", ElementType.Umělý, 116),
            new Element("Uus", "Ununseptium", "Ununseptium", ElementType.Umělý, 117),
            new Element("Uuo", "Ununoctium", "Ununoctium", ElementType.Umělý, 118)
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
                                x.CzechName.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                                x.LatinName.ToLower().Contains(SearchTextBox.Text.ToLower())))
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
                ZvoleniZkoumanehoPrvku(((RadekPrvku) SeznamPrvku.SelectedItem).RowRadku);
        } 

        /// <summary>
        /// Nastaví element který si vybral uživatel jako právě zkoumaný, zobrazí ho vlevo nahoře a provede jeho konfiguraci
        /// </summary>
        /// <param name="chosenElement">zvolený element ze seznamu nebo z tabulky</param>
        private void ZvoleniZkoumanehoPrvku(Element chosenElement)
        {
            if (MainGrid.Children.Contains(_praveZkoumanyPrvek))
                MainGrid.Children.Remove(_praveZkoumanyPrvek);//smazání starého prvku pokud tam je

            MainGrid.Children.Add(_praveZkoumanyPrvek = new RadekPrvku(chosenElement));

            Grid.SetRow(_praveZkoumanyPrvek, 0);
            Grid.SetColumn(_praveZkoumanyPrvek, 0);

            //TextovaKonfiguraceTb.Text = "";
            TextovaKonfiguraceTb.Document = new FlowDocument();

            TextovaKonfigurace();
            ObrazovaKonfigurace();
            KonfiguracePodleVzacnehoPlynu();

            StabilitaTB.Visibility = _praveZkoumanyPrvek.RowRadku.SpecialConfiguration
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        /// <summary>
        /// Zobrazí textovou konfiguraci proi právě zkoumaný element
        /// </summary>
        private void TextovaKonfigurace()
        {
            TextovaKonfiguraceTb.Visibility = Visibility.Visible;
            Paragraph text = new Paragraph();

            foreach (var konfigurace in _praveZkoumanyPrvek.RowRadku.ElectronConfiguration())
            {
              text.Inlines.Add(new Run(konfigurace.PeriodNumber.ToString()));
              text.Inlines.Add(new Run(konfigurace.OrbitalType.ToString()));
              text.Inlines.Add(new Run(konfigurace.Electrons.ToString()){BaselineAlignment = BaselineAlignment.Superscript, FontSize = 10});
              text.Inlines.Add(new Run(" "));
            }
            text.Inlines.Remove(text.Inlines.Last(x => true));
            TextovaKonfiguraceTb.Document.Blocks.Add(text);

        }

        /// <summary>
        /// Zobrazí grafickou konfiguraci pro právě zkoumaný element
        /// </summary>
        private void ObrazovaKonfigurace()
        {
            if (SchematickaKonfigurace.Children.Count != 0) 
                SchematickaKonfigurace.Children.Clear();

            foreach (var subKonfigurace in _praveZkoumanyPrvek.RowRadku.ElectronConfiguration())
            {
                SchematickaKonfigurace.Children.Add(new ElektronovyDiagram(subKonfigurace){Margin = new Thickness(5,5,5,55)});
            }
        }

        private void KonfiguracePodleVzacnehoPlynu()
        {
            PlynovaKonfiguraceTb.Document = new FlowDocument();
            Paragraph text = new Paragraph();

            if (_praveZkoumanyPrvek.RowRadku.Electrons <= 2)
            {
                text.Inlines.Add(new Run("Nelze napsat zkrácenou konfiguraci."));
                PlynovaKonfiguraceTb.Document.Blocks.Add(text);
                return;
            }

            Element nejblizsiVzacnyPlyn = _prvky[1]; //nejbližší vzácný plyn se zvolí helium
            var dostupneVzacnePlyny = _prvky.Where(
                x =>
                    x.Electrons < _praveZkoumanyPrvek.RowRadku.Electrons &&
                    x.ElectronConfiguration().Last().OrbitalType == OrbitalType.p &&
                    //pokud je poslední orbital typu P a navíc je zaplněný jedná se o vzácný plyn
                    x.ElectronConfiguration().Last().Electrons == 6);

            if (dostupneVzacnePlyny.Any())
                nejblizsiVzacnyPlyn = dostupneVzacnePlyny.Last();
            {
             text.Inlines.Add(new Run("["));
             text.Inlines.Add(new Run(nejblizsiVzacnyPlyn.Electrons.ToString()){BaselineAlignment = BaselineAlignment.Subscript, FontSize = 10});
             text.Inlines.Add(new Run(nejblizsiVzacnyPlyn.Symbol + "]"));
            }

            for (int i = nejblizsiVzacnyPlyn.ElectronConfiguration().Count;
                i < _praveZkoumanyPrvek.RowRadku.ElectronConfiguration().Count;
                i++)
            {
                text.Inlines.Add(new Run(" "));
                text.Inlines.Add(new Run(_praveZkoumanyPrvek.RowRadku.ElectronConfiguration()[i].PeriodNumber + _praveZkoumanyPrvek.RowRadku.ElectronConfiguration()[i].OrbitalType.ToString()));
                text.Inlines.Add(new Run(_praveZkoumanyPrvek.RowRadku.ElectronConfiguration()[i].Electrons.ToString()) { BaselineAlignment = BaselineAlignment.Superscript, FontSize = 10 });
            }

            PlynovaKonfiguraceTb.Document.Blocks.Add(text);
        } 

        private void vybratRamec(object sender, MouseButtonEventArgs e)
        {
            ZvoleniZkoumanehoPrvku(_prvky.First(x => x.CzechName == ((RamecPrvku)sender).ceskyNazevTB.Text)); 
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
                var prvek in _prvky.Where(x => x.ElementType == (ElementType) int.Parse(((TextBlock) sender).Tag.ToString())))
                SeznamPrvku.Items.Add(new RadekPrvku(prvek));

            //schovej všechny rámce, které nesjou stejného typu
            foreach (var ramec in PeriodickaTabulka.Children.OfType<RamecPrvku>().Where(x =>
                ((ElementType) Enum.Parse(typeof (ElementType), x.Kovovitost, true)) !=
                (ElementType) int.Parse(((TextBlock) sender).Tag.ToString())))
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
