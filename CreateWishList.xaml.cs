namespace AppMobile;
using AppMobile.Models;

public partial class CreateWishList : ContentPage
{
	public CreateWishList()
	{
		InitializeComponent();
	}
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new TotebagPage((WishList) this.BindingContext)
        {
            BindingContext = new Totebag()
        });

    }
        async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var wlist = (WishList)BindingContext;
        wlist.Date = DateTime.UtcNow;
        Supplier selectedSupplier = (SupplierPicker.SelectedItem as Supplier);
        wlist.SupplierID = selectedSupplier.ID;
        await App.Database.SaveWishListAsync(wlist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var wlist = (WishList)BindingContext;
        await App.Database.DeleteWishListAsync(wlist);
        await Navigation.PopAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var wishl = (WishList)BindingContext;
        var items = await App.Database.GetSuppliersAsync();
        SupplierPicker.ItemsSource = (System.Collections.IList)items;
        SupplierPicker.ItemDisplayBinding = new Binding("SupplierDetails");


        listView.ItemsSource = await App.Database.GetListTotebagsAsync(wishl.ID);
    }


}