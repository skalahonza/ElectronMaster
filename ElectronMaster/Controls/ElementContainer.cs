using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ElectronMaster.Model;

namespace ElectronMaster.Controls
{
    public class ElementContainer:AppUserControl
    {
        public static readonly DependencyProperty ElementProperty = DependencyProperty.Register(
            nameof(Element), typeof(Element), typeof(ElementContainer), new PropertyMetadata(default(Element)));

        public Element Element
        {
            get => (Element) GetValue(ElementProperty);
            set
            {
                SetValue(ElementProperty, value);
                OnPropertyChanged();
            }
        }
    }

    public class BindableRichTextBox : RichTextBox
    {
        public static readonly DependencyProperty DocumentProperty =
            DependencyProperty.Register(nameof(Document), typeof(FlowDocument),
                typeof(BindableRichTextBox), new FrameworkPropertyMetadata
                    (null, OnDocumentChanged));

        public new FlowDocument Document
        {
            get => (FlowDocument)GetValue(DocumentProperty);
            set => SetValue(DocumentProperty, value);
        }

        public static void OnDocumentChanged(DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            var rtb = (RichTextBox)obj;
            rtb.Document = (FlowDocument)args.NewValue;
        }
    }
}