using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class PublisherBook : BaseEntity
    {
        public string Name { get; set; }
        public string NameBook { get; set; }
        public int RecommendedCost { get; set; }


        public PublisherBook Book { get; set; }
    }
}
