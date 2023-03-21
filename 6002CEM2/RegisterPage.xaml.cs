using _6002CEM2.ViewModel;

namespace _6002CEM2;

public partial class RegisterPage : ContentPage
{
    
    public RegisterPage(RegisterPageViewModel  vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}