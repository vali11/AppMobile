using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AppMobile.Data;
using AppMobile.Models;

namespace AppMobile.Data
{
    public class WishListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public WishListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<WishList>().Wait();
            _database.CreateTableAsync<Totebag>().Wait();
            _database.CreateTableAsync<ListTotebag>().Wait();
        }
        public Task<int> SaveTotebagAsync(Totebag totebag)
        {
            if (totebag.ID != 0)
            {
                return _database.UpdateAsync(totebag);
            }
            else
            {
                return _database.InsertAsync(totebag);
            }
        }
        public Task<int> DeleteTotebagAsync(Totebag totebag)
        {
            return _database.DeleteAsync(totebag);
        }
        public Task<List<Totebag>> GetTotebagsAsync()
        {
            return _database.Table<Totebag>().ToListAsync();
        }

        public Task<List<WishList>> GetWishListsAsync()
        {
            return _database.Table<WishList>().ToListAsync();
        }
        public Task<WishList> GetWishListAsync(int id)
        {
            return _database.Table<WishList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveWishListAsync(WishList wlist)
        {
            if (wlist.ID != 0)
            {
                return _database.UpdateAsync(wlist);
            }
            else
            {
                return _database.InsertAsync(wlist);
            }
        }
        public Task<int> DeleteWishListAsync(WishList wlist)
        {
            return _database.DeleteAsync(wlist);
        }

        public Task<int> SaveListTotebagAsync(ListTotebag listw)
        {
            if (listw.ID != 0)
            {
                return _database.UpdateAsync(listw);
            }
            else
            {
                return _database.InsertAsync(listw);
            }
        }
        public Task<List<Totebag>> GetListTotebagsAsync(int wishlistid)
        {
            return _database.QueryAsync<Totebag>(
            "select T.ID, T.Description from Totebag T"
            + " inner join ListTotebag LT"
            + " on T.ID = LT.TotebagID where LT.WishListID = ?",
            wishlistid);
        }

    }
}
