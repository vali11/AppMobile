using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace AppMobile.Models
{
    public class ListTotebag
    {
        
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(WishList))]
        public int WishListID { get; set; }
        public int TotebagID { get; set; }
    }
}

