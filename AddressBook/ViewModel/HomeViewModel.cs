using AddressBook.Common;
using AddressBook.Common.Interfaces;
using AddressBook.DataObjects;
using AddressBook.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Linq;
using AddressBook.ValidationRules;
using System.Globalization;

namespace AddressBook.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        #region Fields & Properties
        public override IModel Model { get; } = new HomeModel();
        public ObservableCollection<Contact> Contacts { get; set; }

        public RelayCommand DeleteRowCommand { get; }
        public RelayCommand AddRowCommand    { get; set; }
        public RelayCommand CloseAddRowPopup   { get; }

        public CultureInfo CultureInfo { get; set; } = CultureInfo.GetCultureInfo("ru-RU");

        private ValidationResult phoneValidationResult;
        public ValidationResult PhoneValidationResult 
        { 
            get => phoneValidationResult;
            set 
            {
                phoneValidationResult = value;
                OnPropertyChanged();
            }
        }

        private ValidationResult nameValidationResult;
        public ValidationResult NameValidationResult
        {
            get => nameValidationResult;
            set
            {
                nameValidationResult = value;
                OnPropertyChanged();
            }
        }

        private bool addRowPopupIsOpen;
        public bool AddRowPopupIsOpen
        {
            get => addRowPopupIsOpen;
            set
            {
                addRowPopupIsOpen = value;
                OnPropertyChanged();
            }
        }
        public string PopupAddRowPhoneNumber { get; set; } = string.Empty;
        public string PopupAddRowName        { get; set; } = string.Empty;
        #endregion
        public HomeViewModel()
        {
            Contacts = (Model as HomeModel).Contacts;

            DeleteRowCommand = new RelayCommand(x => DeleteRow((int)x));
            AddRowCommand    = new RelayCommand(x => AddRow());
            CloseAddRowPopup = new RelayCommand(x => AddRowPopupIsOpen = false);
        }

        private void AddRow()
        {
            PhoneValidationResult = new PhoneValidationRule().Validate(PopupAddRowPhoneNumber, CultureInfo);
            NameValidationResult  = new NameValidationRule() .Validate(PopupAddRowName, CultureInfo);

            var nextID = Contacts.Select(x => x.ID).Max() + 1;

            if (PhoneValidationResult.IsValid && NameValidationResult.IsValid)
            {
                Contacts.Add(new Contact(nextID, PopupAddRowName, PopupAddRowPhoneNumber));
                AddRowPopupIsOpen = false;

                PopupAddRowPhoneNumber = string.Empty;
                PopupAddRowName        = string.Empty;
                OnPropertyChanged(nameof(PopupAddRowPhoneNumber));
                OnPropertyChanged(nameof(PopupAddRowName));

                XmlHandler.TrySaveContactsAsync(Contacts).ConfigureAwait(false);
            }
        }
        public void DeleteRow(int ID) 
        { 
            Contacts.Remove(Contacts.First(x => x.ID == ID));
            XmlHandler.TrySaveContactsAsync(Contacts).ConfigureAwait(false);
        }
    }
}