using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Contoso.Suggestions.Core.Models
{
    public abstract partial class BaseModel : INotifyPropertyChanged
    {
        #region Properties

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        protected bool SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] String propertyName = null, Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            else
            {
                storage = value;
                onChanged?.Invoke();
                NotifyPropertyChanged(propertyName);
                return true;
            }
        }

        protected void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public abstract partial class BaseModel : INotifyPropertyChanged
    {
        #region Properties

        private readonly PropertyErrorsList _errors = new();

        [JsonIgnore]
        public PropertyErrorsList PropertyErrors
        {
            get => _errors;
        }

        #endregion

        #region Methods

        public bool IsValid(params string[] propertyNames)
        {
            return IsValid(null, propertyNames);
        }

        public bool IsValid(Action<PropertyErrorsList> onIsValid, params string[] propertyNames)
        {
            PropertyErrors.Clear();

            ObservableCollection<ValidationResult> errors = new();
            var context = new ValidationContext(this);
            Validator.TryValidateObject(this, context, errors, true);

            if (propertyNames.Length > 0)
                foreach (var property in propertyNames.Where(w => !string.IsNullOrEmpty(w)))
                    PropertyErrors.Merge(errors.Where(s => s.MemberNames.Contains(property)));
            else
                PropertyErrors.Merge(errors);

            if (onIsValid is not null)
                onIsValid(PropertyErrors);

            return PropertyErrors.Count == 0;
        }

        #endregion
    }
}