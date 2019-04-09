using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary2 {
    public class Gendre {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
