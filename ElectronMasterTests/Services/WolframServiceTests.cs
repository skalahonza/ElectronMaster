using System.Threading.Tasks;
using ElectronMaster.Model;
using ElectronMaster.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElectronMasterTests.Services
{
    [TestClass()]
    public class WolframServiceTests
    {
       
        [TestMethod()]
        public async Task GetElementInfoTest()
        {
            var service = new WolframService();
            var result = await service.GetElementInfo(new Element() { Electrons = 29 });
            
        }
    }
}