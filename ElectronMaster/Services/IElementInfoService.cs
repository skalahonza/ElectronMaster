using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronMaster.Model;
using ElectronMaster.Model.Wolfram;
using NodaTime;

namespace ElectronMaster.Services
{
    public interface IElementInfoService
    {
        Task<ElementInfo> GetElementInfo(Element element);
        LocalDateTime GetElementDiscovered(Element element);
        Dictionary<LocalDateTime, List<Element>> GetElementDiscovery(IDictionary<int, Element> elements);
    }
}