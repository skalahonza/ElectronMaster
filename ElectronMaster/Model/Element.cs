using System;
using System.Collections.Generic;

namespace ElectronMaster.Model
{
    public class Element
    {
        private int _electronsForConfiguration;

        public Element(string symbol, string czechName, string latinName, ElementType elementType, int electrons)
        {
            Symbol = symbol;
            CzechName = czechName;
            LatinName = latinName;
            ElementType = elementType;
            PocetElektronu = _electronsForConfiguration = electrons;
            SpecialniKonfigurace = false;
        }

        /// <summary>
        /// Vytvoří elektronovou konfiguraci prvku
        /// </summary>
        /// <returns>Elektronové konfigurace v listu - lze k nim přistupovat objektově</returns>
        public List<Configuration> ElectronConfiguration()
        {
            var result = new List<Configuration>();
            int period = 1;
            while (_electronsForConfiguration > 0)
            {
                result.AddRange(PeriodConfiguration(period));
                period++;
            }
            //odberání možné null která mohla vzniknout důsledkem neúplné konfigurace
            result.RemoveAll(x => x == null); //mělo by odebrat všechny konfigurace které jsou null
            _electronsForConfiguration = PocetElektronu;
            // kdyby byla konfigrace požadována znovu je potřeba aby proměnná elektronyKeKonfiguraci nebyla prázdná

            //kontrola pro stabilitu D5 a D10
            //když je D4 nebo D9 tak elektron z orbitalu S se přesune do orbitalu D

            for (int limit = 4; limit <= 9; limit += 5)
            {
                if (result[result.Count - 1].OrbitalType == OrbitalType.d &&
                    result[result.Count - 1].Electrons == limit
                    && PocetElektronu < 80)
                {
                    //přidání elektronu do orbitalu
                    result[result.Count - 1].Electrons++;

                    //hledání nejbližšího s orbitalu
                    for (int i = result.Count - 1; i >= 0; i--)
                        if (result[i].OrbitalType == OrbitalType.s)
                        {
                            result[i].Electrons--;
                            SpecialniKonfigurace = true;
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
                    result.Add(Skonfigurace(period)); //obsahuje pouze orbital s
                    break;

                case 2:
                case 3:
                    result.Add(Skonfigurace(period));
                    result.Add(Pkonfigurace(period));
                    break;

                case 4:
                case 5:
                    result.Add(Skonfigurace(period));
                    result.Add(Dkonfigurace(period));
                    result.Add(Pkonfigurace(period));
                    break;
                case 6:
                case 7:
                    result.Add(Skonfigurace(period));
                    result.Add(Fkonfigurace(period));
                    result.Add(Dkonfigurace(period));
                    result.Add(Pkonfigurace(period));
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
        /// <param name="cisloPeriody"></param>
        /// <returns>Konfiguraci pro orbital s</returns>
        private Configuration Skonfigurace(int cisloPeriody)
        {
            if (_electronsForConfiguration == 0)
                return null;

            Configuration orbitalS;
            if (_electronsForConfiguration >= 2) // pokud tam je 2 a více elektronů
            {
                orbitalS = new Configuration(cisloPeriody, OrbitalType.s, 2);
                _electronsForConfiguration -= 2;
            }
            else
            {
                orbitalS = new Configuration(cisloPeriody, OrbitalType.s, _electronsForConfiguration);
                _electronsForConfiguration = 0;
            }
            return orbitalS;
        }

        /// <summary>
        /// Vytvoří konfiguraci pro orbital P
        /// </summary>
        /// <param name="cisloPeriody"></param>
        /// <returns>Konfigurace orbitalu P</returns>
        private Configuration Pkonfigurace(int cisloPeriody)
        {
            if (_electronsForConfiguration == 0)
                return null;

            Configuration orbitalP;
            if (_electronsForConfiguration >= 6) // pokud tam je 6 a více elektronů
            {
                orbitalP = new Configuration(cisloPeriody, OrbitalType.p, 6);
                _electronsForConfiguration -= 6;
            }
            else
            {
                orbitalP = new Configuration(cisloPeriody, OrbitalType.p, _electronsForConfiguration);
                _electronsForConfiguration = 0;
            }
            return orbitalP;
        }

        /// <summary>
        /// Vytvoří konfiguraci pro orbital D
        /// </summary>
        /// <param name="cisloPeriody"></param>
        /// <returns>Konfigurace orbitalu D</returns>
        private Configuration Dkonfigurace(int cisloPeriody)
        {
            if (_electronsForConfiguration == 0)
                return null;

            Configuration orbitalD;
            if (_electronsForConfiguration >= 10) // pokud tam je 10 a více elektronů
            {
                orbitalD = new Configuration(cisloPeriody - 1, OrbitalType.d, 10);
                _electronsForConfiguration -= 10;
            }
            else
            {
                orbitalD = new Configuration(cisloPeriody - 1, OrbitalType.d, _electronsForConfiguration);
                _electronsForConfiguration = 0;
            }
            return orbitalD;
        }

        /// <summary>
        /// Vytvoří konfiguraci pro orbital F
        /// </summary>
        /// <param name="cisloPeriody"></param>
        /// <returns>Konfigurace orbitalu F</returns>
        private Configuration Fkonfigurace(int cisloPeriody)
        {
            if (_electronsForConfiguration == 0)
                return null;

            Configuration orbitalF;
            if (_electronsForConfiguration >= 14) // pokud tam je 14 a více elektronů
            {
                orbitalF = new Configuration(cisloPeriody - 2, OrbitalType.f, 14);
                _electronsForConfiguration -= 14;
            }
            else
            {
                orbitalF = new Configuration(cisloPeriody - 2, OrbitalType.f, _electronsForConfiguration);
                _electronsForConfiguration = 0;
            }
            return orbitalF;
        }

        #endregion

        #region Vlastnosti
        public string Symbol { get; set; }
        public string CzechName { get; set; }
        public string LatinName { get; set; }
        public ElementType ElementType { get; set; }
        public int PocetElektronu { get; set; }
        public bool SpecialniKonfigurace { get; set; }
        #endregion

    }
}
