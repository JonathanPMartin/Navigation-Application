//using Android.Gms.Common.Api.Internal;
//using Java.Lang;

namespace _6002CEM2;

public partial class Cal : ContentPage
{
    string Query = "";
    List<List<double>> Locs= new List<List<double>>();
    double TotLat = 0;
    double TotLon = 0;
    int count = 0;
    public Cal()
	{
		InitializeComponent();
	}
    async private void OnGetLocation2(object sender, EventArgs e)

    {
        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

        var _cancelTokenSource = new CancellationTokenSource();

        Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        var lon = location.Longitude;
        var lat = location.Latitude;
        var alt = location.Altitude;

        var query = Lat2.Text + "," + Long2.Text;
        foreach(var i in Locs)
        {
            count++;
            TotLat = TotLat+i[0];
            TotLon= TotLon + i[1];
        }
        TotLat = TotLat / Locs.Count;
        TotLon= TotLon / Locs.Count;
        Query=TotLat.ToString()+","+TotLon.ToString();
        query = "geo:0,0?q=" + Query;
        Result.Text = Query;

        await Launcher.OpenAsync(query);
    }
    async private void OnAddLocation(object sender, EventArgs e)

    {
        string tem = Lat2.Text;
        string tem2 = Long2.Text;
        List<double> tem4=new List<double>();
        tem4.Add(Convert.ToDouble(tem));
        tem4.Add(Convert.ToDouble(tem2));
        Locs.Add(tem4);
       
    }
    }
