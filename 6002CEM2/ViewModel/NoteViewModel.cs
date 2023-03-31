//using Android.Provider;
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
    public partial class NoteViewModel : ObservableObject
    {
        
        public async void Load()
        {
            User = await SQLService.GetUser(Int32.Parse(Id));
            //var user = await SQLService.GetUser(Int32.Parse("1"));
            Backgroundcolour = Color.FromRgba(Colour);

        }
        [RelayCommand]
        async void chnage()
        {
            User.Note = Usernote;
            await SQLService.UpdateUser(User);
            await Shell.Current.GoToAsync($"{nameof(UserPage)}?Id={Id}",
               new Dictionary<string, object>
               {

                   ["Colour"] = Colour
               });
        }
        [ObservableProperty]
        string id;
        [ObservableProperty]
        string colour;
        [ObservableProperty]
        Color backgroundcolour;
        [ObservableProperty]
        Users user;
        [ObservableProperty]
        string usernote;
    }
}
