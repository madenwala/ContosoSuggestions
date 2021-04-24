using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Contoso.Suggestions.Core.Models
{
    public abstract class BaseModel : INotifyPropertyChanged
    {
        #region Properties

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        //private readonly ErrorsList _Errors = new ErrorsList();

        //[JsonIgnore]
        //public ErrorsList Errors
        //{
        //    get => _Errors;
        //}

        #endregion

        #region Methods

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null, Action onChanged = null)
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

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public bool IsValid(params string[] propertyNames)
        //{
        //    return IsValid(null, propertyNames);
        //}

        //public bool IsValid(Action<ErrorsList> onIsValid, params string[] propertyNames)
        //{
        //    try
        //    {
        //        Errors.Clear();

        //        ObservableCollection<ValidationResult> errors = new ObservableCollection<ValidationResult>();
        //        var context = new ValidationContext(this);
        //        Validator.TryValidateObject(this, context, errors, true);

        //        if (propertyNames.Length > 0)
        //            foreach (var property in propertyNames.Where(w => !string.IsNullOrEmpty(w)))
        //                Errors.Merge(errors.Where(s => s.MemberNames.Contains(property)));
        //        else
        //            Errors.Merge(errors);

        //        if (onIsValid != null)
        //            onIsValid(Errors);

        //        return Errors.Count == 0;
        //    }
        //    finally
        //    {
        //        NotifyPropertyChanged(nameof(Errors));
        //    }
        //}

        #endregion
    }
}