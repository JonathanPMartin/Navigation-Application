using _6002CEM2.ViewModel;

namespace _6002CEM2;

public partial class JoinGroup : ContentPage
{
    protected override void OnAppearing()
    {
        //data is a tad slow but is updating kinda
        base.OnAppearing();
        ((JoinGroupViewModel)BindingContext).Load();
    }
    public JoinGroup(JoinGroupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}