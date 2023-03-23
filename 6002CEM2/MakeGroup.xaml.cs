using _6002CEM2.ViewModel;

namespace _6002CEM2;

public partial class MakeGroup : ContentPage
{
    protected override void OnAppearing()
    {
        //data is a tad slow but is updating kinda
        base.OnAppearing();
        ((MakeGroupViewModel)BindingContext).Load();
    }
    public MakeGroup(MakeGroupViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}