using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _6002CEM2.ViewModel
{
    public  partial class LogIn2ViewModel : ObservableObject
    {
        public LogIn2ViewModel()
        {
            
        }
        [ObservableProperty]
        string username;
        [ObservableProperty]
        string password;
        [ObservableProperty]
        string id;
        [RelayCommand]
        async void add()
        {
            int ID = await SQLService.logIn(username, password);
            await Shell.Current.GoToAsync($"{nameof(UserPage)}?Id={ID}");
        }
    }
}
