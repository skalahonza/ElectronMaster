using System.Collections.Generic;
using System.Linq;
using ElectronMaster.Model;

namespace ElectronMaster.Extensions
{
    public static class ElementExtensions
    {
        public static IEnumerable<Element> RareGases(this IEnumerable<Element> elements)
        {
            //pokud je poslední orbital typu P a navíc je zaplněný jedná se o vzácný plyn
            return elements.Where(
                x =>
                    x.ElectronConfiguration().Last().OrbitalType == OrbitalType.p &&
                    x.ElectronConfiguration().Last().Electrons == 6);
        }

        public static IEnumerable<Element> RareGases(this IEnumerable<Element> elements, int electrons)
        {
            return elements.RareGases()
                .Where(x => x.Electrons < electrons);
        }
    }
}