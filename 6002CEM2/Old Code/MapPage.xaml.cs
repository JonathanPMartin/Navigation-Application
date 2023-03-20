using Microsoft.Maui.Maps;

namespace _6002CEM2;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();
	}
    protected override  async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var Loc = new Location(20.7557, -155.9880);
        MapSpan mapSpan = MapSpan.FromCenterAndRadius(Loc, Distance.FromKilometers(3));
        map.MoveToRegion(mapSpan);
        await Launcher.OpenAsync("geo:0,0?q=20.7557,-155.9880");
    }
}