using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _6002CEM2.ViewModel
{
    [QueryProperty("Id", "Id")]
    public partial class UserPageViewModel: ObservableObject
    {
        protected async void OnAppearing()
        {
            await Load();
        }
         public UserPageViewModel() {
            Task.Run(async () => await Load());
        }
        [RelayCommand]
        async Task Load()
        {
            var user = await SQLService.GetUser(Int32.Parse(id));
            UserGroup = user.group;
            UserLocation = user.Loc;
            UserName = "Welcome Back "+user.Username;
            ButtonName = "Click Here to get group info";
        }
        
       [ObservableProperty]
        string id;
        [ObservableProperty]
        int userGroup;
        [ObservableProperty]
        int userLocation;
        [ObservableProperty]
        string userName;
        [ObservableProperty]
        string buttonName;
        
    }
}
