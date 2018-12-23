using System;
using NodaTime;

namespace ElectronMaster.Model.Wolfram
{
    public class ElementInfo
    {
        public Element Element { get; set; }
        public DateTime Discovery { get; set; }        
    }

    public class ElementWolframInfo
    {
        public int ProtonNumber { get; set; }
        public string EnglishName { get; set; }
        public LocalDateTime Discovery { get; set; }
    }
}