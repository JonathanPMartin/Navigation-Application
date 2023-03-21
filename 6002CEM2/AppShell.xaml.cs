namespace _6002CEM2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));
        Routing.RegisterRoute(nameof(CreateJoinGroup), typeof(CreateJoinGroup));
        Routing.RegisterRoute(nameof(JoinGroup), typeof(JoinGroup));
        Routing.RegisterRoute(nameof(MakeGroup), typeof(MakeGroup));
    }
}
