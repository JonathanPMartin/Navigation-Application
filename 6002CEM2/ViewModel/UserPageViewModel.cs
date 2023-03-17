using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _6002CEM2.ViewModel
{
    [QueryProperty("Id", "Id")]
    public partial class UserPageViewModel: ObservableObject
    {
        [ObservableProperty]
        string id;
    }
}
