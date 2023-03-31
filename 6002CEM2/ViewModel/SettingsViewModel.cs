using Android.Database.Sqlite;
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
    [QueryProperty("Colour", "Colour")]
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        string id;
        [ObservableProperty]
        string colour;
        [ObservableProperty]
        string labelname;
        [ObservableProperty]
        Color backgroundcolour;
        public async void Load()
        {
            Backgroundcolour = Color.FromRgba(Colour);

        }
        [RelayCommand]
        async void ChangeColour()
        {
            if (Colour == "#000000")
            {     
                Backgroundcolour = Color.FromRgba("#E1D9D1");
                Colour = "#E1D9D1";
                Labelname = "Testing the THING";
            }
            else
            {
                Backgroundcolour = Color.FromRgba("#000000");
                Colour = "#000000";
                Labelname = "Testing the THING";
            }

        }
        [RelayCommand]
        async void GoHome()
        {
            await Shell.Current.GoToAsync($"{nameof(UserPage)}",
                new Dictionary<string, object>
                {
                    ["Id"] =Id,
                    ["Colour"] =Colour
                });
        }
        [RelayCommand]
        async void GoBack()
        {
            await Shell.Current.GoToAsync($"{nameof(UserPage)}?Id={Id}",
                new Dictionary<string, object>
                {
                    
                    ["Colour"] = Colour
                });
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

    }
   
}

