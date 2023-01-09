namespace AppMobile;
using AppMobile.Models;

public partial class SupplierEntryPage : ContentPage
{
	public SupplierEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetSuppliersAsync();
    }
    async void OnSupplierAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SupplierPage
        {
            BindingContext = new Supplier()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new SupplierPage
            {
                BindingContext = e.SelectedItem as Supplier
            });
        }
    }
}