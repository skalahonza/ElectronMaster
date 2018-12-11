using System.Collections.Generic;

namespace ElectronMaster.Model
{
    public class Prvek
    {
        private int elektronyKeKonfiguraci;

        public Prvek(string znacka, string nazevCesky, string nazevLatinsky, TypPrvku typPrvku, int pocetElektronu)
        {
            Znacka = znacka;
            NazevCesky = nazevCesky;
            NazevLatinsky = nazevLatinsky;
            TypPrvku = typPrvku;
            PocetElektronu = elektronyKeKonfiguraci = pocetElektronu;
            SpecialniKonfigurace = false;
        }

        /// <summary>
        /// Vytvoří elektronovou konfiguraci prvku
        /// </summary>
        /// <returns>Elektronové konfigurace v listu - lze k nim přistupovat objektově</returns>
        public List<Konfigurace> ElektronovaKonfigurace()
        {
            List<Konfigurace> vyslednaKonfigurace = new List<Konfigurace>();
            int perioda = 1;
            while (elektronyKeKonfiguraci > 0)
            {
                vyslednaKonfigurace.AddRange(KonfiguraceProPeriodu(perioda));
                perioda++;
            }
            //odberání možné null která mohla vzniknout důsledkem neúplné konfigurace
            vyslednaKonfigurace.RemoveAll(x => x == null); //mělo by odebrat všechny konfigurace které jsou null
            elektronyKeKonfiguraci = PocetElektronu;
            // kdyby byla konfigrace požadována znovu je potřeba aby proměnná elektronyKeKonfiguraci nebyla prázdná

            //kontrola pro stabilitu D5 a D10
            //když je D4 nebo D9 tak elektron z orbitalu S se přesune do orbitalu D

            for (int limit = 4; limit <= 9; limit += 5)
            {
                if (vyslednaKonfigurace[vyslednaKonfigurace.Count - 1].TypOrbitalu == TypOrbitalu.d &&
                    vyslednaKonfigurace[vyslednaKonfigurace.Count - 1].PocetElektronu == limit
                    && PocetElektronu < 80)
                {
                    //přidání elektronu do orbitalu
                    vyslednaKonfigurace[vyslednaKonfigurace.Count - 1].PocetElektronu++;

                    //hledání nejbližšího s orbitalu
                    for (int i = vyslednaKonfigurace.Count - 1; i >= 0; i--)
                        if (vyslednaKonfigurace[i].TypOrbitalu == TypOrbitalu.s)
                        {
                            vyslednaKonfigurace[i].PocetElektronu--;
                            SpecialniKonfigurace = true;
                            break;
                        }
                }
            }
            return vyslednaKonfigurace;
        }

        /// <summary>
        /// Vytvoří elektronovou konfiguraci pro danou periodu
        /// </summary>
        /// <param name="cisloPeriody">Čislo periody - ovlivní které orbitaly se zaplní</param>
        /// <returns>Elektronová konfigurace (např.: 1s2 2s2 3p6)</returns>
        private List<Konfigurace> KonfiguraceProPeriodu(int cisloPeriody)
        {
            List<Konfigurace> result = new List<Konfigurace>();//postupně se přidávají konfigurace jednotlivých orbitalů
            switch (cisloPeriody)// pro každou periodu se nakofigurují jen ty orbitaly, které jsou potřeba
            {
                case 1:
                    result.Add(Skonfigurace(cisloPeriody)); //obsahuje pouze orbital s
                    break;

                case 2:
                case 3:
                    result.Add(Skonfigurace(cisloPeriody));
                    result.Add(Pkonfigurace(cisloPeriody));
                    break;

                case 4:
                case 5:
                    result.Add(Skonfigurace(cisloPeriody));
                    result.Add(Dkonfigurace(cisloPeriody));
                    result.Add(Pkonfigurace(cisloPeriody));
                    break;
                case 6:
                case 7:
                    result.Add(Skonfigurace(cisloPeriody));
                    result.Add(Fkonfigurace(cisloPeriody));
                    result.Add(Dkonfigurace(cisloPeriody));
                    result.Add(Pkonfigurace(cisloPeriody));
                    break;
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
        private Konfigurace Skonfigurace(int cisloPeriody)
        {
            if (elektronyKeKonfiguraci == 0)
                return null;

            Konfigurace orbitalS;
            if (elektronyKeKonfiguraci >= 2) // pokud tam je 2 a více elektronů
            {
                orbitalS = new Konfigurace(cisloPeriody, TypOrbitalu.s, 2);
                elektronyKeKonfiguraci -= 2;
            }
            else
            {
                orbitalS = new Konfigurace(cisloPeriody, TypOrbitalu.s, elektronyKeKonfiguraci);
                elektronyKeKonfiguraci = 0;
            }
            return orbitalS;
        }

        /// <summary>
        /// Vytvoří konfiguraci pro orbital P
        /// </summary>
        /// <param name="cisloPeriody"></param>
        /// <returns>Konfigurace orbitalu P</returns>
        private Konfigurace Pkonfigurace(int cisloPeriody)
        {
            if (elektronyKeKonfiguraci == 0)
                return null;

            Konfigurace orbitalP;
            if (elektronyKeKonfiguraci >= 6) // pokud tam je 6 a více elektronů
            {
                orbitalP = new Konfigurace(cisloPeriody, TypOrbitalu.p, 6);
                elektronyKeKonfiguraci -= 6;
            }
            else
            {
                orbitalP = new Konfigurace(cisloPeriody, TypOrbitalu.p, elektronyKeKonfiguraci);
                elektronyKeKonfiguraci = 0;
            }
            return orbitalP;
        }

        /// <summary>
        /// Vytvoří konfiguraci pro orbital D
        /// </summary>
        /// <param name="cisloPeriody"></param>
        /// <returns>Konfigurace orbitalu D</returns>
        private Konfigurace Dkonfigurace(int cisloPeriody)
        {
            if (elektronyKeKonfiguraci == 0)
                return null;

            Konfigurace orbitalD;
            if (elektronyKeKonfiguraci >= 10) // pokud tam je 10 a více elektronů
            {
                orbitalD = new Konfigurace(cisloPeriody - 1, TypOrbitalu.d, 10);
                elektronyKeKonfiguraci -= 10;
            }
            else
            {
                orbitalD = new Konfigurace(cisloPeriody - 1, TypOrbitalu.d, elektronyKeKonfiguraci);
                elektronyKeKonfiguraci = 0;
            }
            return orbitalD;
        }

        /// <summary>
        /// Vytvoří konfiguraci pro orbital F
        /// </summary>
        /// <param name="cisloPeriody"></param>
        /// <returns>Konfigurace orbitalu F</returns>
        private Konfigurace Fkonfigurace(int cisloPeriody)
        {
            if (elektronyKeKonfiguraci == 0)
                return null;

            Konfigurace orbitalF;
            if (elektronyKeKonfiguraci >= 14) // pokud tam je 14 a více elektronů
            {
                orbitalF = new Konfigurace(cisloPeriody - 2, TypOrbitalu.f, 14);
                elektronyKeKonfiguraci -= 14;
            }
            else
            {
                orbitalF = new Konfigurace(cisloPeriody - 2, TypOrbitalu.f, elektronyKeKonfiguraci);
                elektronyKeKonfiguraci = 0;
            }
            return orbitalF;
        }

        #endregion

        #region Vlastnosti
        public string Znacka { get; set; }
        public string NazevCesky { get; set; }
        public string NazevLatinsky { get; set; }
        public TypPrvku TypPrvku { get; set; }
        public int PocetElektronu { get; set; }
        public bool SpecialniKonfigurace { get; set; }
        #endregion

    }
}
