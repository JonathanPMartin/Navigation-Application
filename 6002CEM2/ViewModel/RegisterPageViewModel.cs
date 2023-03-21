using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6002CEM2.ViewModel
{
    public partial class RegisterPageViewModel : ObservableObject
    {
        public RegisterPageViewModel() {
           
        }
       // public void Load()
        //{

        //}

        
        [RelayCommand]
        async void Register()
        {
            if (password2 == password)
            {
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var _cancelTokenSource = new CancellationTokenSource();
                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                var lon = location.Longitude;
                var lat = location.Latitude;
                var alt = location.Altitude;
                await SQLService.AddLoc(lon, lat);
                var LocId = await SQLService.GetLocID(lon, lat);
                await SQLService.Adduser(username, password, LocId);
                await Shell.Current.GoToAsync($"{nameof(LogIn2)}");
            }
        }
         
        [ObservableProperty]
        string username;
        [ObservableProperty]
        string password;
        [ObservableProperty]
        string password2;
       


    }
}
