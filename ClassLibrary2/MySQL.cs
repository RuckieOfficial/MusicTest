using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary2 {
    public class MySQL {
        static TodoItemDatabase database;

        public static TodoItemDatabase Database {
            get {
                if (database == null) {
                    database = new TodoItemDatabase(
                      Path.Combine("../../data.db3"));
                }
                return database;
            }
        }
    }
}
