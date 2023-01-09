namespace AppMobile;
using AppMobile.Models;

public partial class SupplierPage : ContentPage
{
	public SupplierPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var supplier = (Supplier)BindingContext;
        await App.Database.SaveSupplierAsync(supplier);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var supplier = (Supplier)BindingContext;
        await App.Database.DeleteSupplierAsync(supplier);
        await Navigation.PopAsync();
    }

    /*async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var supplier = (Supplier)BindingContext;
        var address = supplier.Adress;
        var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Magazinul meu preferat" };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(location, options);
    }*/

}