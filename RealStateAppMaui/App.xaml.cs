using RealStateAppMaui.Pages;

namespace RealStateAppMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var accessToken= Preferences.Get("accessToken", string.Empty);
            if(string.IsNullOrEmpty(accessToken))
            {
                MainPage=new RegisterPage();
            }
            else
            {
                MainPage=new CustomTabPage();
            }
        }
    }
}