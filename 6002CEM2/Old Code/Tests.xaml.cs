using CommunityToolkit.Mvvm.ComponentModel;

namespace _6002CEM2;


[QueryProperty(nameof(ID), "ID")]

public partial class Tests : ContentPage
{
    string id;

    int ID;
    public void ApplyQueryAttributes(IDictionary<string, string> query)
    {
        var ID2 = Guid.Parse(query["ID"]);
        id = ID2.ToString();
        
    }
   

    public Tests()
    {
        InitializeComponent();
    }
	
	async private void OnUpdateLocation(object sender, EventArgs e)

	{
        
        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

        var _cancelTokenSource = new CancellationTokenSource();

        Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        var lon = location.Longitude;
        var lat = location.Latitude;
        var alt = location.Altitude;
        await SQLService.AddLoc(lon, lat);
        var LocId = await SQLService.GetLocID(lon,lat);
        await DisplayAlert("Alert", LocId.ToString(), "OK");
        ID = LocId;
    }
    async private void OnGetLocation(object sender, EventArgs e)
    {
        int Currid = Convert.ToInt32(CurrLocId.Text);
        var UserLocation = await SQLService.GetLocation(Currid);
        await DisplayAlert("Alert",UserLocation.Lat.ToString()+UserLocation.Long.ToString(), "OK");
    }
    async private void OnUpdateUser(object sender, EventArgs e)
    {
       var user= await SQLService.GetUser(Convert.ToInt32(CurrUserId.Text));
        user.Loc = Convert.ToInt32(CurrLocId.Text);
        await DisplayAlert("Alert",user.Loc.ToString(), "OK");
       await SQLService.UpdateUserLocation(user);
        await DisplayAlert(Title, user.Username, "OK");
        await DisplayAlert("Alert", "you've Updated the user", "OK");
    }
    async private void GetUserLoc(object sender, EventArgs e)
    {
        var UserLoc = await SQLService.GetUserLocation(Convert.ToInt32(CurrUserId.Text));
        await DisplayAlert("Alert", UserLoc.Lat.ToString()+ UserLoc.Long.ToString(), "OK");
        await DisplayAlert("Alert", id, "OK");

    }
}