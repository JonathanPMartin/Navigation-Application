namespace _6002CEM2;

public partial class LogIn : ContentPage
{
	public LogIn()
	{
		InitializeComponent();
	}
    async private void OnLogIn(object sender, EventArgs e)

    {
        
       
            int ID=await SQLService.logIn(Username.Text,Password.Text);
        string salt = SQLService.Hash("test");
          await DisplayAlert("Alert",salt, "OK");
        var data = "Tests";
        await Shell.Current.GoToAsync($"///{nameof(Tests)}?ID={ID}");
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        





    }
}