using AddressBook.Common.Interfaces;
using System.Collections.Generic;

namespace AddressBook.Model
{
    class MainModel : IModel
    {
        public IDictionary<string, string> Labels => new Dictionary<string, string>()
        {
            { "Title", "Адресная книга" }
        };
    }
}