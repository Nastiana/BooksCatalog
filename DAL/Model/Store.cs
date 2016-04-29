using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
  public class Store : BaseEntity
    {
        public string Items { get; set; }
        public string Address { get; set; }

        public virtual List<StoreItem> StoreItems { get; set; }
    }
}
