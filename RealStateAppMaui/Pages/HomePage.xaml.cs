using RealStateAppMaui.Models;
using RealStateAppMaui.Services;

namespace RealStateAppMaui.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		lblUsername.Text="Hi," + Preferences.Get("username",string.Empty);
		GetCategories();
		GetTradingProperties();
	}

    private async void GetTradingProperties()
    {
        var properties = await ApiService.GetTrandingProperties();
        CvTopPicks.ItemsSource = properties;
    }

    private async void GetCategories()
    {
		var categories=await ApiService.GetCategories();
        CvCategories.ItemsSource = categories;
    }

    private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
        if (currentSelection == null) return;
        Navigation.PushAsync(new PropertyListPage(currentSelection.Id, currentSelection.Name));
        ((CollectionView)sender).SelectedItem = null;
    }
}