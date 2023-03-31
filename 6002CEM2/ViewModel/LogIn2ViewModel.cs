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
            //var user = new Users();
            //int ID = await SQLService.logIn(username, password);
            //var user =await SQLService.GetUser(ID);
            string HashPass = SQLService.Hash(Password);
            var user= await SQLService.LogIn2(Username, HashPass);
            //user.Username = tem.Username;
            await Shell.Current.GoToAsync($"{nameof(UserPage)}",
                new Dictionary<string, object>
                {
                    ["Id"]= user.Id.ToString(),
                    ["UserDetails"] = user,
                    ["Username"] = user.Username,
                    ["Colour"] ="#000000"
                }) ; 
        }
        [RelayCommand]
        async void register()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
    }
}
