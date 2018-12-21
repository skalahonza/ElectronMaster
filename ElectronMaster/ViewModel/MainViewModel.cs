﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using ElectronMaster.Model;
using ElectronMaster.Extensions;

namespace ElectronMaster.ViewModel
{
    public class ElementFrameViewModel : ElementViewModel
    {        
        private int _col;
        private int _row;        

        public int Col
        {
            get => _col;
            set => _col = FluentOnPropertyChanged(value);
        }

        public int Row
        {
            get => _row;
            set => _row = FluentOnPropertyChanged(value);
        }
    }

    public class MainViewModel:ViewModelBase
    {
        private Element _examinedElement;
        private string _searchText;
        private readonly Element[] _elements = new Element[]
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
        private ElementType? _selectedElementType;

        public MainViewModel()
        {
            Elements = new ObservableCollection<ElementViewModel>(_elements.Select(x => new ElementViewModel(x)));
        }

        public Element ExaminedElement
        {
            get => _examinedElement;
            set
            {
                Configurations = new ObservableCollection<Configuration>(ExaminedElement.ElectronConfiguration());
                OnPropertyChanged(nameof(TextConfiguration));
                OnPropertyChanged(nameof(Configurations));
                OnPropertyChanged(nameof(RareGasConfiguration));
                _examinedElement = FluentOnPropertyChanged(value);
            }
        }

        public ObservableCollection<ElementViewModel> Elements { get; set; }

        public string SearchText
        {
            get => _searchText;
            set => _searchText = FluentOnPropertyChanged(value);
        }

        public ObservableCollection<Configuration> Configurations { get; private set; } = new ObservableCollection<Configuration>();

        public Paragraph TextConfiguration
        {
            get
            {
                var text = new Paragraph();
                foreach (var configuration in Configurations)
                {
                    text.Inlines.Add(new Run(configuration.PeriodNumber.ToString()));
                    text.Inlines.Add(new Run(configuration.OrbitalType.ToString()));
                    text.Inlines.Add(new Run(configuration.Electrons.ToString()) { BaselineAlignment = BaselineAlignment.Superscript, FontSize = 10 });
                    text.Inlines.Add(new Run(" "));
                }                    
                text.Inlines.Remove(text.Inlines.Last(x => true));
                return text;
            }
        }

        public Paragraph RareGasConfiguration
        {
            get
            {
                var text = new Paragraph();
                if (ExaminedElement.Electrons <= 2)
                {                    
                    text.Inlines.Add(new Run("Nelze napsat zkrácenou konfiguraci."));
                }
                else
                {
                    var closestRareGas = _elements[1]; // zvolit Helium
                    var rareGases = _elements.RareGases(ExaminedElement.Electrons).ToList();
                    if (rareGases.Any())
                        closestRareGas = rareGases.Last();
                    {
                        text.Inlines.Add(new Run("["));
                        text.Inlines.Add(new Run(closestRareGas.Electrons.ToString()) { BaselineAlignment = BaselineAlignment.Subscript, FontSize = 10 });
                        text.Inlines.Add(new Run(closestRareGas.Symbol + "]"));
                    }

                    for (int i = closestRareGas.ElectronConfiguration().Count;
                        i < ExaminedElement.ElectronConfiguration().Count;
                        i++)
                    {
                        text.Inlines.Add(new Run(" "));
                        text.Inlines.Add(new Run(Configurations[i].PeriodNumber + Configurations[i].OrbitalType.ToString()));
                        text.Inlines.Add(new Run(Configurations[i].Electrons.ToString()) { BaselineAlignment = BaselineAlignment.Superscript, FontSize = 10 });
                    }
                }

                return text;
            }
        }

        public ElementType? SelectedElementType
        {
            get => _selectedElementType;
            set => _selectedElementType = FluentOnPropertyChanged(value);
        }

        public GenericRelayCommand<object> ClearFilter => new GenericRelayCommand<object>(o =>
            {
                SelectedElementType = null;
                SearchText = "";
                ApplyFilter.Execute(null);
            });

        public GenericRelayCommand<object> ApplyFilter => new GenericRelayCommand<object>(o =>
        {
            //deactivate all
            foreach (var elementFrameViewModel in Elements)
                elementFrameViewModel.IsActive = false;

            //use filter
            var active = Elements.Where(x =>
                x.Element.CzechName.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
                || x.Element.LatinName.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

            if (SelectedElementType != null)
                active = active.Where(x => x.Element.ElementType == SelectedElementType.Value);

            foreach (var elementFrameViewModel in active)
                elementFrameViewModel.IsActive = true;
        });

        public GenericRelayCommand<Element> ExaminedElementChanged => new GenericRelayCommand<Element>(element =>
            {
                //změnit ramecek zkoumaného rpvku
                // text orazek plyn konfiurace
                //hlaska o textu     
                ExaminedElement = element;                
                //jednotlivé rendrovací komponenty budou mít referenci na tento prvek a hotovo
            });
    }
}