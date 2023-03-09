using RealStateAppMaui.Models;
using RealStateAppMaui.Services;

namespace RealStateAppMaui.Pages;

public partial class PropertyListPage : ContentPage
{
	public PropertyListPage(int categoryId,string categoryName)
	{
		InitializeComponent();
		Title= categoryName;
		GetPropteriesList(categoryId);
	}

    private async void GetPropteriesList(int categoryId)
    {
		var properties = await ApiService.GetPropertyByCategory(categoryId);
		CvProperties.ItemsSource= properties;
    }

    private void CvProperties_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as PropertybyCategory;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new PropertyDetailPage(currentSelection.Id));
        ((CollectionView)sender).SelectedItem = null;
    }
}