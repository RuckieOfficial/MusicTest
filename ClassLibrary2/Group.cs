using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ClassLibrary2 {
    public class Group {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(4)]
        public int Year { get; set; }
        
    }
}
