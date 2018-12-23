namespace ElectronMaster.Domain
{
    public class Konfigurace
    {

        /// <summary>
        /// Vytvoří objektový zápis elektronové konfigurace
        /// </summary>
        /// <param name="cisloPeriody">Číslo periody 1 až 7</param>
        /// <param name="typOrbitalu">Typ orbitalu s,p,d,f,g</param>
        /// <param name="pocetElektronu">Počet elektronů, které zaplnily orital</param>
        public Konfigurace(int cisloPeriody, TypOrbitalu typOrbitalu, int pocetElektronu)
        {
            CisloPeriody = cisloPeriody;
            TypOrbitalu = typOrbitalu;
            PocetElektronu = pocetElektronu;
        }

        /// <summary>
        /// Vrací textovou podobu konfigurace
        /// </summary>
        /// <returns>Číslo periody, typ orbitalu, počet elektronů 1S2</returns>
        public override string ToString()
        {
            return string.Concat(CisloPeriody, TypOrbitalu.ToString(), PocetElektronu);
        }

        #region Vlastnosti
        public int CisloPeriody { get; private set; }
        public TypOrbitalu TypOrbitalu { get; private set; }
        public int PocetElektronu { get; set; }
        #endregion

    }
}