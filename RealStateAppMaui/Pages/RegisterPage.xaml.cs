using RealStateAppMaui.Services;

namespace RealStateAppMaui.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private async void btnRegister_Clicked(object sender, EventArgs e)
    {
        var response = await ApiService.RegisterUser(entName.Text, entEmail.Text, entPassword.Text, entPhone.Text);
        if (response)
        {
            await DisplayAlert("", "Your Account has been created", "Alright");
            //entName.Text = string.Empty; entEmail.Text=string.Empty; entPassword.Text=string.Empty; entPhone.Text = string.Empty;
            await Navigation.PushModalAsync(new LoginPage());
        }
        else
        {
            await DisplayAlert("", "Opps something went wrong", "Cancel");
        }
    }

    private async void TapLogin_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
    }
}