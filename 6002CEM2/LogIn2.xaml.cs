using _6002CEM2.ViewModel;

namespace _6002CEM2;

public partial class LogIn2 : ContentPage
{
	public LogIn2(LogIn2ViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}