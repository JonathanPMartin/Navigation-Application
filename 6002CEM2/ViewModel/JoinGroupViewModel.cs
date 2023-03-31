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
    public partial class JoinGroupViewModel : ObservableObject
    {

        [ObservableProperty]
        string groupass;
        [ObservableProperty]
        string groupname;
        [ObservableProperty]
        string id;
        [ObservableProperty]
        Users user;
        [ObservableProperty]
        string colour;
        [ObservableProperty]
        Color backgroundcolour;
        public async void Load()
        {
            User = await SQLService.GetUser(Int32.Parse(Id));
            //var user = await SQLService.GetUser(Int32.Parse("1"));
            Backgroundcolour = Color.FromRgba(Colour);
        }
        [RelayCommand]
        async void add()
        {
            //var user = new Users();
            //int ID = await SQLService.logIn(username, password);
            //var user =await SQLService.GetUser(ID);
            string HashPass = SQLService.Hash(Groupass);
            var group = await SQLService.GroupLogin(Groupname, HashPass);
            User.group= group.Id;
            //user.Username = tem.Username;
            await Shell.Current.GoToAsync($"{nameof(GroupSettings)}?Id={Id}",
                new Dictionary<string, object>
                {
       
                    ["Colour"] = Colour
                });

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
            await Shell.Current.GoToAsync("..");
        }
    }
}
