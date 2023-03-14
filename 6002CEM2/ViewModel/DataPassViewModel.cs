using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace _6002CEM2
{
    [QueryProperty("Text","Text")]
    public partial class DataPassViewModel:ObservableObject
    {
        [ObservableProperty]
        string text;

    }
}
