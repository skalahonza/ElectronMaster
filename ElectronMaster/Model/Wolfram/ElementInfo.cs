using System.Collections.Generic;
using NodaTime;
using Wolfram.Alpha.Models.Output;

namespace ElectronMaster.Model.Wolfram
{
    public class ElementInfo
    {
        public Element Element { get; set; }
        public LocalDateTime Discovery { get; set; }
        public List<ElementInfoSection> Sections { get; set; } = new List<ElementInfoSection>();
    }

    public class ElementInfoSection
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Image Image { get; set; }
    }
}