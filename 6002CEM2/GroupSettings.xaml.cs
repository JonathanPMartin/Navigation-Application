using _6002CEM2.ViewModel;

namespace _6002CEM2;

public partial class GroupSettings : ContentPage
{
    protected override void OnAppearing()
    {
        //data is a tad slow but is updating kinda
        base.OnAppearing();
        ((GroupSettingsViewModel)BindingContext).Load();
    }
    public GroupSettings(GroupSettingsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}