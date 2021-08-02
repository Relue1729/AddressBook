using System.Globalization;
using System.Windows.Controls;

namespace AddressBook.ValidationRules
{
    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is null)
            {
                return new ValidationResult(false, "Введите имя");
            }
            
            string rawValue = (string)value;
            
            if (rawValue.Length < 2 || rawValue.Length > 50)
            {
                return new ValidationResult(false, "Имя не может быть меньше 2 и более 50 символов");
            }

            return ValidationResult.ValidResult;
        }
    }
}