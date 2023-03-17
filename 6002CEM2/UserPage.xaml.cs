using _6002CEM2.ViewModel;

namespace _6002CEM2;

public partial class UserPage : ContentPage
{
	public UserPage(UserPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}