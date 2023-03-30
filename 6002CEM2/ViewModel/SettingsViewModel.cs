using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6002CEM2.ViewModel
{

    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        Color colour;
        [ObservableProperty]
        string label;
        public async void Load()
        {
            Colour = Color.FromRgba("#E1D9D1");

        }
        [RelayCommand]
        async void ChangeColour()
        {
            Colour = Color.Parse("Black");
            Label = "TTesting the THING";

        }

    }
   
}

