using NodaTime;

namespace ElectronMaster.Model.Wolfram
{
    public class ElementWolframInfo
    {
        public int ProtonNumber { get; set; }
        public string EnglishName { get; set; }
        public LocalDateTime Discovery { get; set; }
    }
}