using _6002CEM2.ViewModel;

namespace _6002CEM2;

public partial class Settings : ContentPage
{
    protected override void OnAppearing()
    {
        //data is a tad slow but is updating kinda
        base.OnAppearing();
        ((SettingsViewModel)BindingContext).Load();
    }
    public Settings(SettingsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}