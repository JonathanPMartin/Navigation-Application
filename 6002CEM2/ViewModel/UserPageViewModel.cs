﻿using CommunityToolkit.Mvvm.ComponentModel;
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

            userName = "Welcome back" + id;

            //var username= UserDetails.Username;
            //UserName = "Welcome back "+ username;
            //Console.WriteLine(User);
        }
        [RelayCommand]
        async Task Load()
        {
            var user = await SQLService.GetUser(Int32.Parse(id));
            userGroup = user.group;
            //UserGroup = 125;
            userLocation = user.Loc;
            userName = "Welcome Back "+user.Username;
            buttonName = "Click Here to get group info";
        }
      
        public async void LoadTest()
        {

            
            var user = await SQLService.GetUser(Int32.Parse(id));
            int locID = user.Loc;
            var loc=await SQLService.GetLocation(locID);
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            var _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
            Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            var lon = location.Longitude;
            var lat = location.Latitude;
            loc.Lat = lat;
            loc.Long = lon;
            await SQLService.UpdateLocation(loc);
            userGroup = user.group;
            //UserGroup = 125;
            userLocation = user.Loc;
            userName = "Welcome Back " + user.Username;
            buttonName = "Click Here to get group info";
        }
        [RelayCommand]
        async Task GroupLoad()
        {
            if (userGroup < 1)
            {

                await Shell.Current.GoToAsync($"{nameof(CreateJoinGroup)}?Id={id}");
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(GroupSettings)}?Id={id}");
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
        private readonly object messagingService;
    }
}
