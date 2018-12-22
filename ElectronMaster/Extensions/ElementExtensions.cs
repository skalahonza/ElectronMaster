using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using ElectronMaster.Model;

namespace ElectronMaster.Extensions
{
    public static class ElementExtensions
    {
        const int margin = 5;

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

        public static IEnumerable<Shape> GetGraphics(this Configuration subConfiguration)
        {
            //rozpoznání orbitalu  
            int electronsToConfig = subConfiguration.Electrons;

            //vykreslení potřebného množství čtverečku
            for (int count = 0; count < (int)subConfiguration.OrbitalType * 2 + 1; count++)
            {
                var rect = new Rectangle { Width = 50, Height = 50, Stroke = Brushes.Gray, Fill = Brushes.White, StrokeThickness = 3 };
                Canvas.SetLeft(rect, count * 50);
                yield return rect;
            }

            //výstavbový princip
            //spinové pravidlo
            //elektrony s kladným spinem
            for (int count = 0; count < (int)subConfiguration.OrbitalType * 2 + 1; count++)
            {
                if (electronsToConfig > 0)
                {
                    yield return ArrowUp(count * 50 + 25);
                    electronsToConfig--;
                }
            }
            //elektrony s opačným spinem
            for (int count = 0; count < (int)subConfiguration.OrbitalType * 2 + 1; count++)
            {
                if (electronsToConfig > 0)
                {
                    yield return ArrowDown(count * 50 + 25);
                    electronsToConfig--;
                }
            }
        }

        private static Polyline ArrowUp(int xStredu, int yStredu = 25)
        {
            return new Polyline //šipka nahoru
            {
                Points = new PointCollection
                {
                    new Point(xStredu - margin -5, yStredu - 3),
                    new Point(xStredu - margin, yStredu - 10),
                    new Point(xStredu - margin, yStredu + 15)

                },
                Stroke = Brushes.CadetBlue,
                Fill = Brushes.Transparent,
                StrokeThickness = 3
            };
        }

        private static Polyline ArrowDown(int xStredu, int yStredu = 25)
        {
            return new Polyline //šipka nahoru
            {
                Points = new PointCollection
                {
                    new Point(xStredu + margin, yStredu - 13),
                    new Point(xStredu + margin, yStredu + 11),
                    new Point(xStredu + margin + 5, yStredu + 3)
                },
                Stroke = Brushes.Tomato,
                Fill = Brushes.Transparent,
                StrokeThickness = 3
            };
        }
    }
}