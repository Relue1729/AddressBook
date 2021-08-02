namespace AddressBook.Common.Interfaces
{
    interface IContentDisplay
    {
        IViewModel CurrentView { get; set; }
        void ChangeViewModel(string viewModelName);
    }
}