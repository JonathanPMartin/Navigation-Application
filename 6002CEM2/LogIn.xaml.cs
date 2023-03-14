namespace _6002CEM2;

public partial class LogIn : ContentPage
{
	public LogIn()
	{
		InitializeComponent();
	}
    async private void OnLogIn(object sender, EventArgs e)

    {
        
       
            string ID=await SQLService.logIn(Username.Text,Password.Text);
            await DisplayAlert("Alert", "Welcome " + ID, "OK");
        var data = "Tests";
        await Shell.Current.GoToAsync($"///{nameof(Tests)}?ID={ID}");
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        





    }
}