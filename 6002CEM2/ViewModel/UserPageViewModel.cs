using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _6002CEM2.ViewModel
{
    [QueryProperty("Id", "Id")]
    [QueryProperty("UserDetails", "UserDetails")]
    [QueryProperty("Username", "Username")]

    public partial class UserPageViewModel : ObservableObject
    {

        public UserPageViewModel() {

            userName = "Welcome back" + id;

            //var username= UserDetails.Username;
            //UserName = "Welcome back "+ username;
            //Console.WriteLine(User);
        }
       
        [RelayCommand]
        async Task Load()
        {
            var user = await SQLService.GetUser(Int32.Parse(Id));
            UserGroup = user.group;
            //UserGroup = 125;
            UserLocation = user.Loc;
            UserName = "Welcome Back " + user.Username;
            ButtonName = "Click Here to get group info";
        }

        public async void LoadTest()
        {


            var user = await SQLService.GetUser(Int32.Parse(id));
            int locID = user.Loc;
            var loc = await SQLService.GetLocation(locID);
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            var _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
            Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            var lon = location.Longitude;
            var lat = location.Latitude;
            loc.Lat = lat;
            loc.Long = lon;
            await SQLService.UpdateLocation(loc);
            UserGroup = user.group;
            //UserGroup = 125;
            UserLocation = user.Loc;
            UserName = "Welcome Back " + user.Username;
            ButtonName = "Click Here to get group info";
        }
        [RelayCommand]
        async Task GroupLoad()
        {
            if (UserGroup < 1)
            {

                await Shell.Current.GoToAsync($"{nameof(CreateJoinGroup)}?Id={id}");
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(GroupSettings)}?Id={id}");
            }
        }
        [RelayCommand]
        async void GoHome()
        {
            await Shell.Current.GoToAsync($"{nameof(UserPage)}?Id={Id}");
        }
        [RelayCommand]
        async void GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        async void GoSettigns()
        {
            await Shell.Current.GoToAsync($"{nameof(Settings)}?Id={Id}");
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

