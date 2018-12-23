namespace ElectronMaster.Model
{
    public class Configuration
    {

        /// <summary>
        /// Vytvoří objektový zápis elektronové konfigurace
        /// </summary>
        /// <param name="periodNumber">Číslo periody 1 až 7</param>
        /// <param name="orbitalType">Typ orbitalu s,p,d,f,g</param>
        /// <param name="electrons">Počet elektronů, které zaplnily orital</param>
        public Configuration(int periodNumber, OrbitalType orbitalType, int electrons)
        {
            PeriodNumber = periodNumber;
            OrbitalType = orbitalType;
            Electrons = electrons;
        }

        /// <summary>
        /// Vrací textovou podobu konfigurace
        /// </summary>
        /// <returns>Číslo periody, typ orbitalu, počet elektronů 1S2</returns>
        public override string ToString()
        {
            return string.Concat(PeriodNumber, OrbitalType.ToString(), Electrons);
        }

        #region Properties
        public int PeriodNumber { get; private set; }
        public OrbitalType OrbitalType { get; private set; }
        public int Electrons { get; set; }
        #endregion

    }
}