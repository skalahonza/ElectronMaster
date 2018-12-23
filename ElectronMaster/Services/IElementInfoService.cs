using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CsvHelper;
using ElectronMaster.CSV;
using ElectronMaster.Model;
using ElectronMaster.Model.Wolfram;
using Wolfram.Alpha;
using Wolfram.Alpha.Models;

namespace ElectronMaster.Services
{
    public interface IElementInfoService
    {
        Task<ElementInfo> GetElementInfo(Element element);
    }

    public class WolframService
    {        
        private readonly WolframAlphaService _service;
        public WolframService()
        {
            _service = new WolframAlphaService(ConfigurationManager.AppSettings["WolframApiKey"]);
        }

        private readonly Lazy<Dictionary<int, ElementWolframInfo>> _elementsInfo = new Lazy<Dictionary<int, ElementWolframInfo>>(GetElements);

        private static Dictionary<int, ElementWolframInfo> GetElements()
        {
            var dict = new Dictionary<int, ElementWolframInfo>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) 
                                    ?? throw new InvalidOperationException(), @"Data\elementsinfo.csv");

            using (var textReader = File.OpenText(path))
            {
                var csv = new CsvReader(textReader);
                csv.Configuration.Delimiter = "\t";
                csv.Configuration.RegisterClassMap<ElementWolframInfoMap>();
                foreach (var info in csv.GetRecords<ElementWolframInfo>())
                {
                    dict[info.ProtonNumber] = info;
                }
            }

            return dict;
        }

        public async Task<WolframAlphaResult> GetElementInfo(Element element)
        {            
            var info = _elementsInfo.Value;
            var request = new WolframAlphaRequest(info[element.Electrons].EnglishName);            
            var response = await _service.Compute(request);
            return response;
        }
    }
}