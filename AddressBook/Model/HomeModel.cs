using AddressBook.Common.Interfaces;
using System.Collections.Generic;
using AddressBook.Common;
using System.Collections.ObjectModel;
using AddressBook.DataObjects;
using System;

namespace AddressBook.Model
{
    public class HomeModel : IModel
    {
        public IDictionary<string, string> Labels => new Dictionary<string, string>()
        {
            { "ID",                     "ID"},
            { "Name",                   "Имя"},
            { "Phone",                  "Телефон"},
            { "SureYouWantToDeleteRow", "Вы уверены что хотите удалить эту запись?"},
            { "AddRowTitle",            "Добавить запись"},
            { "AddRow",                 "Добавить"},
            { "Cancel",                 "Отмена"},
            { "Yes",                    "Да"},
            { "No",                     "Нет"}

        };
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        public HomeModel()
        {
            try
            {
                Contacts = XmlHandler.DeserializeContacts();
            }
            catch { }

            if (Contacts is null || Contacts.Count == 0)
            {
                Contacts = GetContactCollectionWithSampleData();
                XmlHandler.TrySaveContactsAsync(Contacts).ConfigureAwait(false);
            }
        }

        private ObservableCollection<Contact> GetContactCollectionWithSampleData()
        {
            return new ObservableCollection<Contact>()
            {
                new Contact (1, "Иванов Петр Васильевич",    "+7-111-111-11-11"),
                new Contact (2, "Петров Иван Генадьевич",    "+7-222-222-22-22"),
                new Contact (3, "Васильев Генадий Петрович", "+7-333-333-33-33"),
                new Contact (4, "Иванов Василий Петрович",   "+7-444-444-44-44"),
                new Contact (5, "Петров Генадий Васильевич", "+7-555-555-55-55"),
                new Contact (6, "Иванов Петр Васильевич",    "+7-111-111-11-11"),
                new Contact (7, "Петров Иван Генадьевич",    "+7-222-222-22-22"),
                new Contact (8, "Васильев Генадий Петрович", "+7-333-333-33-33"),
                new Contact (9, "Иванов Василий Петрович",   "+7-444-444-44-44"),
                new Contact (10,"Петров Генадий Васильевич", "+7-555-555-55-55")
            };
        }
    }
}