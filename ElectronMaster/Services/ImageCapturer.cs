using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ElectronMaster.Services
{
    public static class ImageCapture
    {
        public static void SaveToBmp(FrameworkElement visual, string fileName)
        {
            var bitmapEncoder = new BmpBitmapEncoder();
            SaveUsingEncoder(visual, fileName, bitmapEncoder);
        }

        public static void SaveToPng(FrameworkElement visual, string fileName)
        {
            var pngBitmapEncoder = new PngBitmapEncoder();
            SaveUsingEncoder(visual, fileName, pngBitmapEncoder);
        }

        private static void SaveUsingEncoder(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var renderTargetBitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(visual);
            var bitmapFrame = BitmapFrame.Create(renderTargetBitmap);
            encoder.Frames.Add(bitmapFrame);
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                encoder.Save(fileStream);
            }
        }
    }
}