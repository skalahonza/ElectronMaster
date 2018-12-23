using System.Linq;
using System.Threading.Tasks;
using ElectronMaster.Model;
using ElectronMaster.Model.Wolfram;

namespace ElectronMaster.Services
{
    public interface IElementInfoService
    {
        Task<ElementInfo> GetElementInfo(Element element);
    }
}