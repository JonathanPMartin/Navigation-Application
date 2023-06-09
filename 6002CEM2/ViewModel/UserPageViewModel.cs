﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Maui.Audio;
using System.Collections.ObjectModel;

namespace _6002CEM2.ViewModel
{
    [QueryProperty("Id", "Id")]
    [QueryProperty("UserDetails", "UserDetails")]
    [QueryProperty("Username", "Username")]
    [QueryProperty("Colour", "Colour")]

    public partial class UserPageViewModel : ObservableObject
    {

        public UserPageViewModel(IAudioManager audioManager) {

            userName = "Welcome back" + id;
            this.audioManager = audioManager;

            //var username= UserDetails.Username;
            //UserName = "Welcome back "+ username;
            //Console.WriteLine(User);
        }
        private readonly IAudioManager audioManager;
        [RelayCommand]
        async Task Load()
        {
            var user = await SQLService.GetUser(Int32.Parse(Id));
            UserGroup = user.group;
            //UserGroup = 125;
            UserLocation = user.Loc;
            UserName = "Welcome Back " + user.Username;
            //Note="User Note: "+user.Note;
            ButtonName = Colour;
        }

        public async void LoadTest()
        {

           
            
            var user = await SQLService.GetUser(Int32.Parse(id));
            int locID = user.Loc;
            if (user.Music == null) {
                var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("The_Wombles_-_The_Wombling_Song.m4a"));
                player.Play();
               
            }
            else
            {
                var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(user.Music));
                player.Play();
            }
           
            var loc = await SQLService.GetLocation(locID);
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            Backgroundcolour = Color.FromRgba(colour);
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
            ButtonName = Colour;
            Usernote = "User Note: " + user.Note;
           
        }
        [RelayCommand]
        async void GoMusic()
        {
            var user = await SQLService.GetUser(Int32.Parse(id));
            if (user.Music == "Rick_Astley_-_Never_Gonna_Give_You_Up_Video.m4a")
            {
               
                user.Music =null;
                await SQLService.UpdateUser(user);
            }
            else
            {
               
               // user.Music = "The_Wombles_ - _The_Wombling_Song.m4a";
                user.Music = "Rick_Astley_-_Never_Gonna_Give_You_Up_Video.m4a";
                await SQLService.UpdateUser(user);
            }

        }
        [RelayCommand]
        async Task GroupLoad()
        {
            if (UserGroup < 1)
            {

                await Shell.Current.GoToAsync($"{nameof(CreateJoinGroup)}?Id={Id}",
                new Dictionary<string, object>
                {
                  
                    ["Colour"] = Colour
                });
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(GroupSettings)}?Id={Id}",
                new Dictionary<string, object>
                {
                    
                    ["Colour"] = Colour
                });
            }
        }
        [RelayCommand]
        async void GoHome()
        {
            await Shell.Current.GoToAsync($"{nameof(UserPage)}?Id={Id}",
                new Dictionary<string, object>
                {
                   
                    ["Colour"] = Colour
                });
        }
        [RelayCommand]
        async void GoBack()
        {
            await Shell.Current.GoToAsync("..",
                new Dictionary<string, object>
                {
                    ["Id"] = Id,
                    ["Colour"] = Colour
                }); ;
        }
        [RelayCommand]
        async void GoSettigns()
        {
           
            await Shell.Current.GoToAsync($"{nameof(Settings)}?Id={Id}",
                new Dictionary<string, object>
                {
                   
                    ["Colour"] = Colour
                });
            
        }
        [RelayCommand]
        async void SetNote()
        {
            await Shell.Current.GoToAsync($"{nameof(Note)}?Id={Id}",
                new Dictionary<string, object>
                {

                    ["Colour"] = Colour
                });
        }
        [RelayCommand]
        async void GoLogout()
        {
            await Shell.Current.GoToAsync($"{nameof(LogIn2)}");
            /*await Shell.Current.GoToAsync($"{nameof(Settings)}?Id={Id}",
                new Dictionary<string, object>
                {
                   
                    ["Colour"] = Colour
                });
            */
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
        [ObservableProperty]
        string colour;
        [ObservableProperty]
        Color backgroundcolour;
        [ObservableProperty]
        string usernote;
    }
    
    }

