using System.ComponentModel.DataAnnotations;

namespace Contoso.Suggestions.Core.Models
{
    public class Item : BaseModel
    {
        private string _Id;
        public string Id
        {
            get => _Id;
            set => SetProperty(ref _Id, value);
        }

        private string _Text;
        [Required, MinLength(3), MaxLength(6)]
        public string Text
        {
            get => _Text;
            set => SetProperty(ref _Text, value);
        }

        private string _Description;
        [Required, MaxLength(10)]
        public string Description
        {
            get => _Description;
            set => SetProperty(ref _Description, value);
        }

        private string _Password;
        [Required]
        public string Password
        {
            get => _Password;
            set => SetProperty(ref _Password, value);
        }

        private string _ConfirmPassword;
        [Compare(nameof(Password))]
        public string ConfirmPassword
        {
            get => _ConfirmPassword;
            set => SetProperty(ref _ConfirmPassword, value);
        }

        private double? _Latitude;
        [Range(-90, 90)]
        public double? Latitude
        {
            get => _Latitude;
            set => SetProperty(ref _Latitude, value);
        }

        private double? _Longitude;
        [Required, Range(-180, 180)]
        public double? Longitude
        {
            get => _Longitude;
            set => SetProperty(ref _Longitude, value);
        }
    }
}