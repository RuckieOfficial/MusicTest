using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1 {
    public class TodoItemDatabase {
        readonly SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath) {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<MusicGroup>().Wait();
        }

        public Task<List<MusicGroup>> GetItemsAsync() {
            return database.Table<MusicGroup>().ToListAsync();
        }

        public Task<List<MusicGroup>> GetItemsNotDoneAsync() {
            return database.QueryAsync<MusicGroup>("SELECT * FROM [MusicGroup] WHERE [Done] = 0");
        }

        public Task<MusicGroup> GetItemAsync(int id) {
            return database.Table<MusicGroup>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(MusicGroup item) {
            if (item.Id != 0) {
                return database.UpdateAsync(item);
            } else {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(MusicGroup item) {
            return database.DeleteAsync(item);
        }
    }
}
