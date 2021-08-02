using AddressBook.DataObjects;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AddressBook.Common
{
    static class XmlHandler
    {
        const string XmlPath = "XmlData/Contacts.xml";
        
        /// <summary>Возвращает true если контакты были успешно сохранены</summary>
        public static async Task<bool> TrySaveContactsAsync(ObservableCollection<Contact> contacts, string path = XmlPath)
        {
            if (TrySerialize(contacts, out var serialized))
            {
                try
                {
                    await File.WriteAllTextAsync("XmlData/Contacts.xml", serialized, Encoding.Unicode);
                    return true;
                }
                catch { }
            }
            return false;
        }
        public static bool TrySerialize<T>(this T value, out string serialized)
        {
            serialized = string.Empty;

            if (value is null) { return false; }

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlSerializer.Serialize(writer, value);
                    serialized = stringWriter.ToString();
                }
                return true;
            }
            catch { return false; }
        }
        public static ObservableCollection<Contact> DeserializeContacts(string path = XmlPath)
        {
            var deserialized = new ObservableCollection<Contact>();

            var xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Contact>));

            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                deserialized = (ObservableCollection<Contact>) xmlSerializer.Deserialize(reader);
            }

            return deserialized;
        }
    }
}