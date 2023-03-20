using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _6002CEM2.ViewModel
{
    [QueryProperty("Id", "Id")]
    [QueryProperty("UserDetails", "UserDetails")]
    [QueryProperty("Username", "Username")]

    public partial class UserPageViewModel: ObservableObject
    {
        
         public UserPageViewModel() {
            UserName = "Welcome back" + Id;

            //var username= UserDetails.Username;
            //UserName = "Welcome back "+ username;
            //Console.WriteLine(User);
        }
        [RelayCommand]
        async Task Load()
        {
            var user = await SQLService.GetUser(Int32.Parse(Id));
            //UserGroup = user.group;
            UserGroup = 125;
            UserLocation = user.Loc;
            UserName = "Welcome Back "+user.Username;
            ButtonName = "Click Here to get group info";
        }
        public async void LoadTest()
        {
            var user = await SQLService.GetUser(Int32.Parse(Id));
            //UserGroup = user.group;
            UserGroup = 125;
            UserLocation = user.Loc;
            UserName = "Welcome Back " + user.Username;
            ButtonName = "Click Here to get group info";
        }
        [RelayCommand]
        async Task GroupLoad()
        {
            if (UserGroup < 1)
            {
                
                UserName = "you have no Group";
            }
            else
            {
                UserName = UserGroup.ToString();
            }
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
        [ObservableProperty]
        Users userDetails;
        [ObservableProperty]
        string username;

    }
}
