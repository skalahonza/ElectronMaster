namespace ElectronMaster.Model
{
    public interface IElement
    {
        string Symbol { get; set; }
        string CzechName { get; set; }
        string LatinName { get; set; }
        ElementType ElementType { get; set; }
        int Electrons { get; set; }
        bool SpecialConfiguration { get; set; }
    }
}