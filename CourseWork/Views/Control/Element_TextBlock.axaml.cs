using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;
using System.Linq;

namespace CourseWork.Views.Control
{
    public class Element_TextBlock : TemplatedControl
    {
        public static readonly StyledProperty<string> CustomTextProperty =
            AvaloniaProperty.Register<Element_TextBlock, string>("CustomText", defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
        public static readonly StyledProperty<double> FontSizeTextProperty =
            AvaloniaProperty.Register<Element_TextBlock, double>("FontSizeText");
        public static readonly StyledProperty<FontWeight> FontWeightTextProperty =
            AvaloniaProperty.Register<Element_TextBlock, FontWeight>("FontWeightText");

        public string CustomText
        {
            get => GetValue(CustomTextProperty);
            set => SetValue(CustomTextProperty, value);
        }
        public double FontSizeText
        {
            get => GetValue(FontSizeTextProperty);
            set => SetValue(FontSizeTextProperty, value);
        }
        public FontWeight FontWeightText
        {
            get => GetValue(FontWeightTextProperty);
            set => SetValue(FontWeightTextProperty, value);
        }

        static Element_TextBlock()
        {
            DoubleTappedEvent.AddClassHandler<Element_TextBlock>(
                (sender, args) => sender.OnDoubleTapped(args));
        }

        protected virtual void OnDoubleTapped(RoutedEventArgs routedEventArgs)
        {
            var descendants = this.GetVisualDescendants();


            var textBox = descendants.OfType<TextBox>()
                                     .FirstOrDefault(
                                         control =>
                                         string.IsNullOrEmpty(control.Name) == false &&
                                         control.Name.Equals("customTextBox"));

            if (textBox != null)
            {
                textBox.IsVisible = true;
                textBox.LostFocus += OnLostFocus;
                textBox.Focus();
            }


        }

        protected virtual void OnLostFocus(object? sender, RoutedEventArgs routedEventArgs)
        {
            if (sender is TextBox textBox)
            {
                if (textBox != null)
                {
                    textBox.IsVisible = false;
                }
                if (textBox.Text == "") textBox.Text = "No name";
                textBox.LostFocus -= OnLostFocus;
            }
        }
    }
}
