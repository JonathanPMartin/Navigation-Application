using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6002CEM2.ViewModel
{
    [QueryProperty("Id", "Id")]
    public partial class MakeGroupViewModel : ObservableObject
    {
        public MakeGroupViewModel()
        {

        }
        public async void Load()
        {
            User = await SQLService.GetUser(Int32.Parse(Id));
            //var user = await SQLService.GetUser(Int32.Parse("1"));
            if (User.group > 0)
            {
                await Shell.Current.GoToAsync($"{nameof(GroupSettings)}?Id={Id}");
            }

        }
        [RelayCommand]
        async void makegroup()
        {
            if (GroupPassword == GroupPassword2)
            { 
                string HashPass = SQLService.Hash(GroupPassword);
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var _cancelTokenSource = new CancellationTokenSource();
                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                var lon = location.Longitude;
                var lat = location.Latitude;
                var alt = location.Altitude;
                await SQLService.AddLoc(lon, lat);
                var LocId = await SQLService.GetLocID(lon, lat);
                await SQLService.AddGroup(GroupName, HashPass, LocId, Int32.Parse(Id));
                int groupID=  await SQLService.GetGroupID(GroupName, HashPass);
                User.group = groupID;
                await SQLService.UpdateUser(User);
                await Shell.Current.GoToAsync($"{nameof(GroupSettings)}?Id={Id}");
            }
        }
        [ObservableProperty]
        string id;
        [ObservableProperty]
        string groupName;
        [ObservableProperty]
        string groupPassword;
        [ObservableProperty]
        string groupPassword2;
        [ObservableProperty]
        Users user;
    }

}
