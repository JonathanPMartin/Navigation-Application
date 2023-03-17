namespace _6002CEM2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));
    }
}
