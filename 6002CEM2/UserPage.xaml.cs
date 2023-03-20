using _6002CEM2.ViewModel;

namespace _6002CEM2;

public partial class UserPage : ContentPage
{
    protected override void OnAppearing()
    {
        //data is a tad slow but is updating kinda
        base.OnAppearing();
        ((UserPageViewModel)BindingContext).LoadTest();
    }
    public UserPage(UserPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
		

    }
	

    }