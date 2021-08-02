using AddressBook.Common;
using AddressBook.Common.Interfaces;
using AddressBook.Model;
using System;
using System.Windows;

namespace AddressBook.ViewModel
{
    class MainViewModel : ViewModelBase, IContentDisplay
    {
        public override IModel Model { get; } = new MainModel();
        public IViewModel CurrentView { get; set; } = new HomeViewModel();
        public RelayCommand CloseWindowCommand    { get; }
        public RelayCommand MinimizeWindowCommand { get; }

        Window MainWindow = Application.Current.MainWindow;

        public MainViewModel()
        {
            MinimizeWindowCommand = new RelayCommand(x => MainWindow.WindowState = WindowState.Minimized);
            CloseWindowCommand    = new RelayCommand(x => Application.Current.Shutdown());
        }
        public void ChangeViewModel(string viewModelName)
        {
            throw new NotImplementedException();
        }
    }
}