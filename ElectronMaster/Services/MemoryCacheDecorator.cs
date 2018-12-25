using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronMaster.Model;
using ElectronMaster.Model.Wolfram;

namespace ElectronMaster.Services
{
    public class MemoryCacheDecorator : IElementInfoService
    {
        private readonly IElementInfoService _service;
        private readonly Dictionary<int, ElementInfo> _cache = new Dictionary<int, ElementInfo>();

        public MemoryCacheDecorator(IElementInfoService service)
        {
            _service = service;
        }

        public async Task<ElementInfo> GetElementInfo(Element element)
        {
            if (!_cache.TryGetValue(element.Electrons, out var result))
            {
                result = await _service.GetElementInfo(element);
                _cache[result.Element.Electrons] = result;
            }
            return result;
        }
    }
}