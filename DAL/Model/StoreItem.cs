using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class StoreItem :BaseEntity
    {
        public int Cost { get; set; }
        public string Book { get; set; }
        public string NamePublisher { get; set; }

        public Store Store { get; set; }
    }
}
