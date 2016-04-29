using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Book :BaseEntity
    {
        public string NameBook { get; set; }
        public string Author { get; set; }
        public string PublisherBook { get; set; }


        public Publisher Publisher { get; set; }
    }
}
