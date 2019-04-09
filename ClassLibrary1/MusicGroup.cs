using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ClassLibrary1 {
    public class MusicGroup {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(4)]
        public int Year { get; set; }
        
    }
}
