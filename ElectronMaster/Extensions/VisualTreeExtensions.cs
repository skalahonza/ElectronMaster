using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ElectronMaster.Extensions
{
    public static class VisualTreeExtensions
    {
        public static Panel GetItemsPanel(this DependencyObject itemsControl)
        {
            var itemsPresenter = GetVisualChild<ItemsPresenter>(itemsControl);
            var itemsPanel = VisualTreeHelper.GetChild(itemsPresenter, 0) as Panel;
            return itemsPanel;
        }

        public static T GetVisualChild<T>(this DependencyObject parent) where T : Visual
        {
            var child = default(T);

            var numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < numVisuals; i++)
            {
                var v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T ?? GetVisualChild<T>(v);
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
    }
}