using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace ElectronMaster.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
        }    

        /// <summary>
        /// Odkaz na GoID
        /// </summary>
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("http://goid.azurewebsites.net/");
        }

        /// <summary>
        /// Uloží schématickou konfiguraci jako obrázek
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsImage(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = "Obrázek PNG|*.png" };
            if (sfd.ShowDialog() == true)
            {
                const int dpi = 92;

                var rtb = new RenderTargetBitmap(
                    (int)SchematickaKonfigurace.ActualWidth, //width 
                    (int)SchematickaKonfigurace.ActualHeight, //height 
                    dpi, //dpi x 
                    dpi, //dpi y 
                    PixelFormats.Pbgra32 // pixelformat 
                    );
                rtb.Render(SchematickaKonfigurace);
                SaveRTBAsPNG(rtb, sfd.FileName);
            }
        }

        /// <summary>
        /// Vyexportuje vyrendrovaný obrázek jako soubor
        /// </summary>
        /// <param name="bmp">Cílový obrázek</param>
        /// <param name="filename">Cíl souboru</param>
        private void SaveRTBAsPNG(RenderTargetBitmap bmp, string filename)
        {
            var enc = new PngBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(bmp));

            using (var stm = File.Create(filename))
            {
                enc.Save(stm);
            }
        }
    }    
}
