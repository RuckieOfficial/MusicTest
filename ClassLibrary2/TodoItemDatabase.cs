using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2 {
    public class TodoItemDatabase {
        readonly SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath) {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Group>().Wait();
            database.CreateTableAsync<Gendre>().Wait();
            database.CreateTableAsync<Meta>().Wait();
        }

        public Task<List<Group>> GetItemsAsync() {
            return database.Table<Group>().ToListAsync();
        }
        public Task<List<Gendre>> GetItemsAsync2() {
            return database.Table<Gendre>().ToListAsync();
        }
        public Task<List<Meta>> GetItemsAsync3() {
            return database.Table<Meta>().ToListAsync();
        }

        public Task<List<Group>> GetItemsNotDoneAsync() {
            return database.QueryAsync<Group>("SELECT * FROM [MusicGroup]");
        }
        public Task<List<Gendre>> GetItemsNotDoneAsync2() {
            return database.QueryAsync<Gendre>("SELECT * FROM [MusicGendre]");
        }
        public Task<List<Meta>> GetItemsNotDoneAsync3() {
            return database.QueryAsync<Meta>("SELECT * FROM [MetaTab]");
        }

        public Task<Group> GetItemAsync(int id) {
            return database.Table<Group>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<Gendre> GetItemAsync2(int id) {
            return database.Table<Gendre>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<Meta> GetItemAsync3(int id) {
            return database.Table<Meta>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Group item) {
            if (item.Id != 0) {
                return database.UpdateAsync(item);
            } else {
                return database.InsertAsync(item);
            }
        }
        public Task<int> SaveItemAsync2(Gendre item) {
            if (item.Id != 0) {
                return database.UpdateAsync(item);
            } else {
                return database.InsertAsync(item);
            }
        }
        public Task<int> SaveItemAsync3(Meta item) {
            if (item.Id != 0) {
                return database.UpdateAsync(item);
            } else {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Group item) {
            return database.DeleteAsync(item);
        }
        public Task<int> DeleteItemAsync2(Gendre item) {
            return database.DeleteAsync(item);
        }
        public Task<int> DeleteItemAsync3(Meta item) {
            return database.DeleteAsync(item);
        }

        public void Clear() {
            database.DropTableAsync<Gendre>();
            database.DropTableAsync<Group>();
            database.DropTableAsync<Meta>();
        }
    }
}
