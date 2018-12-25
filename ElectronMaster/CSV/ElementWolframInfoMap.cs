using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using ElectronMaster.Model.Wolfram;
using NodaTime;
using NodaTime.Text;

namespace ElectronMaster.CSV
{
    public sealed class ElementWolframInfoMap:ClassMap<ElementWolframInfo>
    {
        public ElementWolframInfoMap()
        {
            Map(x => x.ProtonNumber).Index(0);
            Map(x => x.EnglishName).Index(1);
            Map(x => x.Discovery).ConvertUsing(row => ParseDateTime(row.GetField<string>(2)));
        }

        private IEnumerable<LocalDateTimePattern> GetPatterns()
        {
            yield return LocalDateTimePattern.CreateWithInvariantCulture("yyyy gg");                                    
            yield return LocalDateTimePattern.CreateWithInvariantCulture("yyyy");            
        }

        private LocalDateTime ParseDateTime(string dateTime)
        {
            var ex = default(Exception);
            foreach (var pattern in GetPatterns())
            {
                var result = pattern.Parse(dateTime);
                if (result.Success)
                {
                    return result.Value;
                }
                else
                {
                    ex = result.Exception;
                }
            }

            // ReSharper disable once PossibleNullReferenceException
            throw ex;
        }
    }
}