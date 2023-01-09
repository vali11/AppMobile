using AppMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMobile
{
    public class ProductPageViewModel
    {
        public ObservableCollection<Items> Items { get; set; }

        public ObservableCollection<Items> CartItems { get; set; }

        public Items SelectedItem { get; set; }

        public ICommand Itemclick { get; set; }
        public ICommand CartItemclick { get; set; }
        public ProductPageViewModel(INavigation navigation)
        {
            Items = new ObservableCollection<Items>
            {
                new Items
                {   Picture="totebag1.jpg",
                    Name="Tote Bag ESKY",
                    Quantity="1",
                    Price="49 lei"
                },
                new Items
                {   Picture="totebag2.jpg",
                    Name="Tote Bag BIRDS",
                    Quantity="1",
                    Price="55 lei"
                },
                new Items
                {   Picture="totebag3.jpg",
                    Name="Tote Bag CHILL",
                    Quantity="1",
                    Price="49 lei"
                },
                new Items
                {   Picture="totebag4.jpg",
                    Name="Tote Bag COZY",
                    Quantity="1",
                    Price="55 lei"
                },
                new Items
                {   Picture="totebag5.jpg",
                    Name="Tote Bag FEELS",
                    Quantity="1",
                    Price="49 lei"
                },
                new Items
                {   Picture="totebag6.jpg",
                    Name="Tote Bag WINTRY",
                    Quantity="1",
                    Price="55 lei"
                },
                new Items
                {   Picture="totebag7.jpg",
                    Name="Tote Bag FROST",
                    Quantity="1",
                    Price="49 lei"
                },
                new Items
                {   Picture="totebag8.jpg",
                    Name="Tote Bag DELICACY",
                    Quantity="1",
                    Price="55 lei"
                },
                new Items
                {   Picture="totebag9.jpg",
                    Name="Tote Bag ILLUSION",
                    Quantity="1",
                    Price="49 lei"
                },
                new Items
                {   Picture="totebag10.jpg",
                    Name="Tote Bag INCEPTION",
                    Quantity="1",
                    Price="55 lei"
                }
            };
            CartItems = new ObservableCollection<Items> { };
            //Itemclick = new Command<Items>(executeitemclickcommand);
            //CartItemclick = new Command<Items>(executeCartitemclickcommand);
            this.navigation = navigation;
        }
        private INavigation navigation;

        /*async void executeitemclickcommand(Items item)
        {
            this.SelectedItem = item;
            await navigation.PushModalAsync(new DetailsPage(this));
        }

        async void executeCartitemclickcommand(Items item)
        {
            this.CartItems.Add(this.SelectedItem);
            await navigation.PushModalAsync(new WishListPage(this));

        }*/
    }
}
