using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using ElectronMaster.Extensions;
using ElectronMaster.Services;
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
                var wrap = SchematickaKonfigurace.GetItemsPanel();
                ImageCapture.SaveToPng(wrap,sfd.FileName);
            }
        }
    }    
}
