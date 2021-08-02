using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace AddressBook.ValidationRules
{
    public class PhoneValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string rawValue = (string)value;

            if (string.IsNullOrWhiteSpace(rawValue))
            {
                return new ValidationResult(false, "Введите номер телефона");
            }

            string onlyDigits = new string(rawValue.Where(x => char.IsDigit(x)).ToArray());

            if (onlyDigits.Length != 11)
            {
                return new ValidationResult(false, "Номер телефона должен состоять из 11 чисел");
            }

            if (onlyDigits[0] != '7' && onlyDigits[0] != '8')
            {
                return new ValidationResult(false, "Неверный код страны");
            }
            return ValidationResult.ValidResult;
        }
    }
}