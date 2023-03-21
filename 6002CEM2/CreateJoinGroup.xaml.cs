using _6002CEM2.ViewModel;

namespace _6002CEM2;

public partial class CreateJoinGroup : ContentPage
{
    protected override void OnAppearing()
    {
        //data is a tad slow but is updating kinda
        base.OnAppearing();
        ((CreateJoinGroupViewModel)BindingContext).Load();
    }
    public CreateJoinGroup(CreateJoinGroupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}