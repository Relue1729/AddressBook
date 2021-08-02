using System.Collections.Generic;

namespace AddressBook.Common.Interfaces
{
    interface IModel
    {
        IDictionary<string, string> Labels { get; }
    }
}