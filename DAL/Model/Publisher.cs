using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Publisher :BaseEntity
    {
        public string NamePublisher { get; set; }
        public string NameBook { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }

        public StoreItem StoreItem { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
