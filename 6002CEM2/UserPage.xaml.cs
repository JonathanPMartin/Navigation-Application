using _6002CEM2.ViewModel;

namespace _6002CEM2;

public partial class UserPage : ContentPage
{
    protected override void OnAppearing()
    {
        //work arround used to upated data 
        base.OnAppearing();
        ((UserPageViewModel)BindingContext).LoadTest();
    }
    public UserPage(UserPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
		

    }
	

    }
