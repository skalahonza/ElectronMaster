using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using ElectronMaster.Model;

namespace ElectronMaster.View
{
    /// <summary>
    /// Interaction logic for ElektronovyDiagram.xaml
    /// </summary>
    public partial class ElektronovyDiagram : UserControl
    {
        const int margin = 5;  //čím menší tím budou šipky blíže k sobě

        public ElektronovyDiagram(Configuration subConfiguration)
        {
            InitializeComponent();
            //rozpoznání orbitalu            


            int elektronyKeKonfiguraci = subConfiguration.Electrons;

            ToolTip = subConfiguration.ToString();
            Width = (int) (subConfiguration.OrbitalType)*100 + 50; //přizpůsobení šířky

            //vykreslení potřebného množství čtverečku
            for (int count = 0; count < (int) subConfiguration.OrbitalType * 2 + 1; count++)
            {
                Rectangle rect = new Rectangle() {Width = 50,Height = 50, Stroke = Brushes.Gray, Fill = Brushes.White,StrokeThickness = 3};
                
                Canvas.SetLeft(rect,count * 50);
                KresliciPlocha.Children.Add(rect);   
            }

            //výstavbový princip
            //spinové pravidlo
            //elektrony s kladným spinem
            for (int count = 0; count < (int)subConfiguration.OrbitalType * 2 + 1; count++)
            {
                if (elektronyKeKonfiguraci > 0)
                {
                    KresliciPlocha.Children.Add(sipkaNahoru(count*50 + 25));
                    elektronyKeKonfiguraci--;
                }
            }
            //elektrony s opačným spinem
            for (int count = 0; count < (int)subConfiguration.OrbitalType * 2 + 1; count++)
            {
                if (elektronyKeKonfiguraci > 0)
                {
                    KresliciPlocha.Children.Add(sipkaDolu(count * 50 + 25));
                    elektronyKeKonfiguraci--;
                }
            }
        }

        private Polyline sipkaNahoru(int xStredu, int yStredu = 25)
        {
            return new Polyline() //šipka nahoru
            { 
                Points = new PointCollection()
                
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

        private Polyline sipkaDolu(int xStredu, int yStredu = 25)
        {
            return new Polyline() //šipka nahoru
            {
                Points = new PointCollection()
                
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
