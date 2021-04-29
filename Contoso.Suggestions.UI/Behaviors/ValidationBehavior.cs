using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Contoso.Suggestions.UI.Behaviors
{
    public static class ValidationBehavior
    {
        public static readonly BindableProperty DisplayProperty =
            BindableProperty.CreateAttached(
                "Display",
                typeof(Label),
                typeof(ValidationBehavior),
                null,
                propertyChanged: OnChanged);

        public static Label GetDisplay(BindableObject view)
        {
            return (Label)view.GetValue(DisplayProperty);
        }

        public static void SetDisplay(BindableObject view, Label value)
        {
            view.SetValue(DisplayProperty, value);
        }

        static void OnChanged(BindableObject view, object oldValue, object newValue)
        {
            if (view is InputView entry && newValue is Label label)
            {
                entry.BindingContextChanged += Entry_BindingContextChanged;

                label.Text = "World";
                label.IsVisible = !string.IsNullOrWhiteSpace(label.Text);
            }
        }

        private static void Entry_BindingContextChanged(object sender, EventArgs e)
        {
            var bc = ((InputView)sender).BindingContext;
            ((InputView)sender).Text = "HI WOR:D!";
        }

        private static void Input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
