using RealStateAppMaui.Services;

namespace RealStateAppMaui.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        var response = await ApiService.Login (EntuserEmail.Text, EntPassword.Text);
        if (response)
        {
            Application.Current.MainPage = new CustomTabPage();
        }
        else
        {
            await DisplayAlert("", "Opps something went wrong", "Cancel");
        }
    }

    private async void TapLogin_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new RegisterPage());
    }
}