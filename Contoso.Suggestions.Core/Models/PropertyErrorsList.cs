using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Contoso.Suggestions.Core.Models
{
    public sealed class PropertyErrorsList : ObservableCollection<ValidationResult>
    {
        public string Separator { get; set; } = Environment.NewLine;

        public PropertyErrorsList(IEnumerable<ValidationResult> errors = null, string separator = null)
        {
            if (separator != null)
                Separator = separator;
            Merge(errors);
        }

        public void Add(string propertyName, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(propertyName) is false && string.IsNullOrWhiteSpace(errorMessage) is false)
                Add(new ValidationResult(errorMessage, new List<string> { propertyName }));
        }

        public void Merge(IEnumerable<ValidationResult> errors)
        {
            if (errors is not null)
                foreach (var error in errors)
                    Add(error);
        }

        public override string ToString()
        {
            if (this?.Any() ?? false)
                return string.Join(Separator, this);
            else
                return default;
        }
    }
}