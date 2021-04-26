using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Contoso.Suggestions.Core.Models
{
    public sealed class PropertyErrorsList : ObservableCollection<ValidationResult>
    {
        public void Add(string propertyName, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(propertyName) is false && string.IsNullOrWhiteSpace(errorMessage) is false)
                Add(new ValidationResult(errorMessage, new List<string> { propertyName }));
        }

        public void Merge(IEnumerable<ValidationResult> errors)
        {
            if (errors != null)
                foreach (var error in errors)
                    Add(error);
        }

        public override string ToString()
        {
            if (this?.Any() ?? false)
            {
                var separator = ", ";
                return string.Join(separator, this);
            }
            return default;
        }
    }
}