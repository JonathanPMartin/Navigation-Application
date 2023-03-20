namespace _6002CEM2;

public partial class Directions : ContentPage
{
	public Directions()
	{
		InitializeComponent();
	}
    async private void OnGetLocation(object sender, EventArgs e)

    {
        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

        var _cancelTokenSource = new CancellationTokenSource();

        Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        var lon = location.Longitude;
        var lat = location.Latitude;
        var alt = location.Altitude;
      
        var query = Lat.Text + "," + Long.Text;
        query = "geo:0,0?q=" + query;
        Result.Text = lat.ToString() + " " + lon.ToString();
        
        await Launcher.OpenAsync(query);
    }
}