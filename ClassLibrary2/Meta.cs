using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2 {
    public class Meta {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int GenreID { get; set; }
        public int GroupID { get; set; }
    }
}
