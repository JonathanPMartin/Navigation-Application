﻿using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class CreateJoinGroupViewModel : ObservableObject
    {
       
        public async void Load()
        {
            var user = await SQLService.GetUser(Int32.Parse(Id));
            //var user = await SQLService.GetUser(Int32.Parse("1"));
            if (user.group > 0)
            {
                await Shell.Current.GoToAsync($"{nameof(GroupSettings)}?Id={Id}",
                new Dictionary<string, object>
                {
                    
                    ["Colour"] = Colour
                });
               
            }
            Backgroundcolour = Color.FromRgba(Colour);

        }
        [RelayCommand]
        async Task joingroup()
        {
            await Shell.Current.GoToAsync($"{nameof(JoinGroup)}?Id={Id}",
                new Dictionary<string, object>
                {
                    
                    ["Colour"] = Colour
                });
        }
        [RelayCommand]
        async Task makegroup()
        {
            await Shell.Current.GoToAsync($"{nameof(MakeGroup)}?Id={Id}",
                new Dictionary<string, object>
                {
                 
                    ["Colour"] = Colour
                });
        }
        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("..");
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
      
        [ObservableProperty]
        string id;
        [ObservableProperty]
        Color backgroundcolour;
        [ObservableProperty]
        string colour;
    }
    
}
