using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Class1
    {
      //  private Repository<DAL.Model.Book> bookRepository;
        //List<Book> parts = new List<Book>();
        public Repository<Book> bookRepository;
       
        public int SortByName(string name1, string name2)
        {

            return name1.CompareTo(name2);
        }

        // Default comparer for Part type.
       

        public void SortName()
        {
            List<Book> books = bookRepository.Table.ToList();

           books.Sort(delegate (Book x, Book y)
            {
                if (x.NameBook == null && y.NameBook == null) return 0;
                else if (x.NameBook == null) return -1;
                else if (y.NameBook == null) return 1;
                else return x.NameBook.CompareTo(y.NameBook);
            });
        }
        }
}
