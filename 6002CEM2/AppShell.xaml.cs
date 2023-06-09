﻿using _6002CEM2.ViewModel;

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
        Routing.RegisterRoute(nameof(LogIn2), typeof(LogIn2));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(GroupSettings), typeof(GroupSettings));
        Routing.RegisterRoute(nameof(Settings), typeof(Settings));
        Routing.RegisterRoute(nameof(Note), typeof(Note));
        Routing.RegisterRoute(nameof(Test), typeof(Test));
    }
}
