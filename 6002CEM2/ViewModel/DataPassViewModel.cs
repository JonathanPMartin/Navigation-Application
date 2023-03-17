using Android.App;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace _6002CEM2
{
    [QueryProperty(nameof(id), "ID")]
    public partial class DataPassViewModel:ObservableObject
    {
        [ObservableProperty]
        int id;
    }
}
