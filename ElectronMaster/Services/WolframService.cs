using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CsvHelper;
using ElectronMaster.CSV;
using ElectronMaster.Extensions;
using ElectronMaster.Model;
using ElectronMaster.Model.Wolfram;
using Wolfram.Alpha;
using Wolfram.Alpha.Models;

namespace ElectronMaster.Services
{
    public class WolframService:IElementInfoService
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

        public async Task<ElementInfo> GetElementInfo(Element element)
        {            
            var info = _elementsInfo.Value;
            var elementWolframInfo = info[element.Electrons];
            var request = new WolframAlphaRequest(elementWolframInfo.EnglishName);            
            var response = await _service.Compute(request);

            var pods = response.QueryResult.Pods.FilterPods("Input interpretation", "Periodic table location","Image");

            var result = new ElementInfo
            {
                Element = element,
                Discovery = elementWolframInfo.Discovery,
                Sections = pods.Select(x => new ElementInfoSection
                {                    
                    Title = x.Title,
                    Text = string.Join("",x.SubPods.SelectMany(y => y.Plaintext)),
                    Image = x.SubPods.Select(y => y.Image).FirstOrDefault()
                }).ToList()
            };            

            return result;
        }
    }
}