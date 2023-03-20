//using Android.App;

namespace _6002CEM2;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}
	async private void OnRegisterUser(object sender, EventArgs e)

	{
		if (Password2.Text == Password.Text)
		{
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            var _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
            Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            var lon = location.Longitude;
            var lat = location.Latitude;
            var alt = location.Altitude;
            await SQLService.AddLoc(lon, lat);
            var LocId = await SQLService.GetLocID(lon, lat);
            await DisplayAlert("Alert", LocId.ToString(), "OK");
            await SQLService.Adduser(Username.Text, Password.Text, LocId);
            await DisplayAlert("Alert", "Welcome "+Username.Text, "OK");

        }
		else
		{
            await DisplayAlert("Alert", "your Passwords do not match", "OK");
        }

    }
    }