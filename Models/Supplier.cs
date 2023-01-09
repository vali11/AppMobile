using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobile.Models
{
    public class Supplier
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string SupplierName { get; set; }
        public string Adress { get; set; }
        public string SupplierDetails
        {
            get
            {
                return SupplierName + " "+Adress;} }
        [OneToMany]
        public List<WishList> WishLists { get; set; }
    }
}
