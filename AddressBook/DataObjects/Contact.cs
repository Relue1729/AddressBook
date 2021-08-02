using System.Linq;

namespace AddressBook.DataObjects
{
    public class Contact
    {
        public int ID      { get; set; }
        public string Name { get; set; }
        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set { ConvertValidatedNumberToSameFormat(value); }
        }

        public Contact(int ID, string Name, string PhoneNumber)
        {
            this.ID = ID;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
        }
        public Contact() { }

        private void ConvertValidatedNumberToSameFormat(string value)
        {
            string onlyDigits = new string(value.Where(x => char.IsDigit(x)).ToArray());
            onlyDigits = onlyDigits.Substring(1);
            var phoneMask = "+7-XXX-XXX-XX-XX";
            var result = string.Empty;

            for (int i = 0; i < onlyDigits.Length; i++)
            {
                if (phoneMask[i] == 'X') { result += onlyDigits[i]; }
                else
                {
                    result += phoneMask[i];
                    phoneMask = phoneMask.Remove(i, 1);
                    i--;
                }
            }
            phoneNumber = result;
        }
    }
}