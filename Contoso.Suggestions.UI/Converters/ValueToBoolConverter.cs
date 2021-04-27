using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;

namespace Contoso.Suggestions.UI.Converters
{
    public sealed class ValueToBooleanConverter : IValueConverter
    {
        public bool InvertValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolean = true;

            switch (value)
            {
                case null:
                    boolean = false;
                    break;

                case bool val:
                    boolean = val;
                    break;

                case string val:
                    boolean = !string.IsNullOrWhiteSpace(val);
                    break;

                case DateTime val:
                    boolean = !(val == DateTime.MinValue || val == DateTime.MaxValue);
                    break;

                case int val:
                    boolean = !(val == int.MinValue || val == int.MaxValue);
                    break;

                case long val:
                    boolean = !(val == long.MinValue || val == long.MaxValue);
                    break;

                case double val:
                    boolean = !(val == double.MinValue || val == double.MaxValue || double.IsNaN(val));
                    break;

                case float val:
                    boolean = !(val == float.MinValue || val == float.MaxValue || float.IsNaN(val));
                    break;

                case IEnumerable val:
                    boolean = val.GetEnumerator().MoveNext();
                    break;
            }

            if (this.InvertValue)
                return !boolean;
            else
                return boolean;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
