using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    class MusicGendre {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
