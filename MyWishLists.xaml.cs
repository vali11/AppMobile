namespace AppMobile;
using AppMobile.Models;

public partial class MyWishLists : ContentPage
{
	public MyWishLists()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetWishListsAsync();
    }
    async void OnWishListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateWishList
        {
            BindingContext = new WishList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CreateWishList
            {
                BindingContext = e.SelectedItem as WishList
            });
        }
    }

}