using Contoso.Suggestions.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Contoso.Suggestions.UI.Converters
{
    public class ValidationResultsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ICollection<ValidationResult> result)
                if (parameter is null)
                    return result;
                else if (parameter is Binding binding)
                    return new PropertyErrorsList(result.Where(s => s.MemberNames.Contains(GetName(binding.Path))));
                else
                    return new PropertyErrorsList(result.Where(s => s.MemberNames.Contains(parameter)));
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new ArgumentException();
        }

        private string GetName(string path)
        {
            var parts = path.Split('.');
            return parts[parts.Length - 1];
        }
    }
}