using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace CourseWork.Views.Control
{
    public class Element_Enter : TemplatedControl
    {
        public static readonly StyledProperty<bool> SignalProperty =
            AvaloniaProperty.Register<Element_Enter, bool>("Signal");
        public static readonly StyledProperty<bool> FocusOnElementProperty =
            AvaloniaProperty.Register<Element_Enter, bool>("FocusOnElement");

        public bool FocusOnElement
        {
            get => GetValue(FocusOnElementProperty);
            set => SetValue(FocusOnElementProperty, value);
        }

        public bool Signal 
        { 
            get => GetValue(SignalProperty);
            set => SetValue(SignalProperty, value);
        }
    }
}
