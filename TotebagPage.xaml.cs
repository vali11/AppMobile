namespace AppMobile;
using AppMobile.Models;
using AppMobile.Data;

public partial class TotebagPage : ContentPage
{
    WishList wl;
	public TotebagPage(WishList wlist)
	{
        InitializeComponent();
        wl= wlist;
            
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var totebag = (Totebag)BindingContext;
        await App.Database.SaveTotebagAsync(totebag);
        listView.ItemsSource = await App.Database.GetTotebagsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var totebag = (Totebag)BindingContext;
        await App.Database.DeleteTotebagAsync(totebag);
        listView.ItemsSource = await App.Database.GetTotebagsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Totebag t;
        if (listView.SelectedItem != null)
        {
            t = listView.SelectedItem as Totebag;
            var lt = new ListTotebag()
            {
                WishListID = wl.ID,
                TotebagID = t.ID
            };
            await App.Database.SaveListTotebagAsync(lt);
            t.ListTotebags = new List<ListTotebag> { lt };
            await Navigation.PopAsync();
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetTotebagsAsync();
    }

}