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

    public partial class CreateJoinGroupViewModel : ObservableObject
    {
       
        public async void Load()
        {
            var user = await SQLService.GetUser(Int32.Parse(Id));
            if (user.group > 0)
            {
                await Shell.Current.GoToAsync($"{nameof(GroupSettings)}?Id={Id}");
            }

        }
        [RelayCommand]
        async Task joingroup()
        {
            await Shell.Current.GoToAsync($"{nameof(JoinGroup)}?Id={Id}");
        }
        [RelayCommand]
        async Task makegroup()
        {
            await Shell.Current.GoToAsync($"{nameof(MakeGroup)}?Id={Id}");
        }
        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("..");
        }
        [ObservableProperty]
        string id;
       
    }
    
}
