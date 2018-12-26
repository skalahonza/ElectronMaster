using System;
using System.Collections.Generic;
using ElectronMaster.ViewModel;

namespace ElectronMaster.Model
{
    public class Element : ViewModelBase,IElement
    {
        private int _electronsForConfiguration;
        private string _symbol;
        private string _czechName;
        private string _latinName;
        private ElementType _elementType;
        private int _electrons;
        private bool _specialConfiguration;

        public Element()
        {
        }

        public Element(string symbol, string czechName, string latinName, ElementType elementType, int electrons)
        {
            Symbol = symbol;
            CzechName = czechName;
            LatinName = latinName;
            ElementType = elementType;
            Electrons = _electronsForConfiguration = electrons;
            SpecialConfiguration = false;
        }

        /// <summary>
        /// Vytvoří elektronovou konfiguraci prvku
        /// </summary>
        /// <returns>Elektronové konfigurace v listu - lze k nim přistupovat objektově</returns>
        public List<Configuration> ElectronConfiguration()
        {
            var result = new List<Configuration>();
            var period = 1;
            while (_electronsForConfiguration > 0)
            {
                result.AddRange(PeriodConfiguration(period));
                period++;
            }
            //odberání možné null která mohla vzniknout důsledkem neúplné konfigurace
            result.RemoveAll(x => x == null); //mělo by odebrat všechny konfigurace které jsou null
            _electronsForConfiguration = Electrons;
            // kdyby byla konfigrace požadována znovu je potřeba aby proměnná elektronyKeKonfiguraci nebyla prázdná

            //kontrola pro stabilitu D5 a D10
            //když je D4 nebo D9 tak elektron z orbitalu S se přesune do orbitalu D

            for (var limit = 4; limit <= 9; limit += 5)
            {
                if (result[result.Count - 1].OrbitalType == OrbitalType.d &&
                    result[result.Count - 1].Electrons == limit
                    && Electrons < 80)
                {
                    //přidání elektronu do orbitalu
                    result[result.Count - 1].Electrons++;

                    //hledání nejbližšího s orbitalu
                    for (var i = result.Count - 1; i >= 0; i--)
                        if (result[i].OrbitalType == OrbitalType.s)
                        {
                            result[i].Electrons--;
                            SpecialConfiguration = true;
                            break;
                        }
                }
            }
            return result;
        }

        /// <summary>
        /// Vytvoří elektronovou konfiguraci pro danou periodu
        /// </summary>
        /// <param name="period">Čislo periody - ovlivní které orbitaly se zaplní</param>
        /// <returns>Elektronová konfigurace (např.: 1s2 2s2 3p6)</returns>
        private List<Configuration> PeriodConfiguration(int period)
        {
            var result = new List<Configuration>();//postupně se přidávají konfigurace jednotlivých orbitalů
            switch (period)// pro každou periodu se nakofigurují jen ty orbitaly, které jsou potřeba
            {
                case 1:
                    result.Add(SConfiguration(period)); //obsahuje pouze orbital s
                    break;

                case 2:
                case 3:
                    result.Add(SConfiguration(period));
                    result.Add(PConfiguration(period));
                    break;

                case 4:
                case 5:
                    result.Add(SConfiguration(period));
                    result.Add(DConfiguration(period));
                    result.Add(PConfiguration(period));
                    break;
                case 6:
                case 7:
                    result.Add(SConfiguration(period));
                    result.Add(FConfiguration(period));
                    result.Add(DConfiguration(period));
                    result.Add(PConfiguration(period));
                    break;
                default:
                    throw new NotImplementedException("Elements with greater period than 7 are not supported.");
            }
            //Energie d orbitalu, který je zcela nebo z poloviny zaplněný, 
            //je nižší než energie nejbližšího s orbitalu. 
            //Proto v případě d4 a d9 prvků dochází k přeskoku jednoho elektronu 
            //z s orbitalu do orbitalu d. Např. elektronová konfigurace chromu je: [Ar] 3d5 4s1, nikoliv [Ar] 3d4 4s2
            // před vrácením hodnoty se to zkontroluje
            // ↑ to se ještě bude muset doprogramovat ↑
            return result;
        }

        #region Konfigurace jednotlivých orbitalů
        /// <summary>
        /// Vytvoří konfiguraci pro orbital s
        /// </summary>
        /// <param name="period"></param>
        /// <returns>Konfiguraci pro orbital s</returns>
        private Configuration SConfiguration(int period)
        {
            if (_electronsForConfiguration == 0)
                return null;

            Configuration orbitalS;
            if (_electronsForConfiguration >= 2) // pokud tam je 2 a více elektronů
            {
                orbitalS = new Configuration(period, OrbitalType.s, 2);
                _electronsForConfiguration -= 2;
            }
            else
            {
                orbitalS = new Configuration(period, OrbitalType.s, _electronsForConfiguration);
                _electronsForConfiguration = 0;
            }
            return orbitalS;
        }

        /// <summary>
        /// Vytvoří konfiguraci pro orbital P
        /// </summary>
        /// <param name="period"></param>
        /// <returns>Konfigurace orbitalu P</returns>
        private Configuration PConfiguration(int period)
        {
            if (_electronsForConfiguration == 0)
                return null;

            Configuration orbitalP;
            if (_electronsForConfiguration >= 6) // pokud tam je 6 a více elektronů
            {
                orbitalP = new Configuration(period, OrbitalType.p, 6);
                _electronsForConfiguration -= 6;
            }
            else
            {
                orbitalP = new Configuration(period, OrbitalType.p, _electronsForConfiguration);
                _electronsForConfiguration = 0;
            }
            return orbitalP;
        }

        /// <summary>
        /// Vytvoří konfiguraci pro orbital D
        /// </summary>
        /// <param name="period"></param>
        /// <returns>Konfigurace orbitalu D</returns>
        private Configuration DConfiguration(int period)
        {
            if (_electronsForConfiguration == 0)
                return null;

            Configuration orbitalD;
            if (_electronsForConfiguration >= 10) // pokud tam je 10 a více elektronů
            {
                orbitalD = new Configuration(period - 1, OrbitalType.d, 10);
                _electronsForConfiguration -= 10;
            }
            else
            {
                orbitalD = new Configuration(period - 1, OrbitalType.d, _electronsForConfiguration);
                _electronsForConfiguration = 0;
            }
            return orbitalD;
        }

        /// <summary>
        /// Vytvoří konfiguraci pro orbital F
        /// </summary>
        /// <param name="period"></param>
        /// <returns>Konfigurace orbitalu F</returns>
        private Configuration FConfiguration(int period)
        {
            if (_electronsForConfiguration == 0)
                return null;

            Configuration orbitalF;
            if (_electronsForConfiguration >= 14) // pokud tam je 14 a více elektronů
            {
                orbitalF = new Configuration(period - 2, OrbitalType.f, 14);
                _electronsForConfiguration -= 14;
            }
            else
            {
                orbitalF = new Configuration(period - 2, OrbitalType.f, _electronsForConfiguration);
                _electronsForConfiguration = 0;
            }
            return orbitalF;
        }

        #endregion

        #region Vlastnosti

        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                OnPropertyChanged();
            }
        }

        public string CzechName
        {
            get => _czechName;
            set
            {
                if (value == _czechName) return;
                _czechName = value;
                OnPropertyChanged();
            }
        }

        public string LatinName
        {
            get => _latinName;
            set
            {
                if (value == _latinName) return;
                _latinName = value;
                OnPropertyChanged();
            }
        }

        public ElementType ElementType
        {
            get => _elementType;
            set
            {
                if (value == _elementType) return;
                _elementType = value;
                OnPropertyChanged();
            }
        }

        public int Electrons
        {
            get => _electrons;
            set
            {
                if (value == _electrons) return;
                _electrons = value;
                OnPropertyChanged();
            }
        }

        public bool SpecialConfiguration
        {
            get => _specialConfiguration;
            set
            {
                if (value == _specialConfiguration) return;
                _specialConfiguration = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
