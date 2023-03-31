using _6002CEM2.ViewModel;

namespace _6002CEM2;

public partial class Note : ContentPage
{
    protected override void OnAppearing()
    {
        //data is a tad slow but is updating kinda
        base.OnAppearing();
        ((NoteViewModel)BindingContext).Load();
    }
    public Note(NoteViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}