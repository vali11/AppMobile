﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AppMobile.Models
{
    public class WishList
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        [Unique, MaxLength(300)]
        public string Description { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(typeof(Supplier))]
        public int SupplierID { get; set; }


    }
}
