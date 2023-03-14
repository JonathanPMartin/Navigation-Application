
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace _6002CEM2
{

    public partial class DefultViewModel:ObservableObject
    {
        public DefultViewModel() {
            Items = new ObservableCollection<string>();
        }
        [ObservableProperty]
        ObservableCollection<string> items;
        [ObservableProperty]
        string text;
        
        void Add()
        {
            Items.Add(Text);
            Text = string.Empty;
        }
       
    }
}
