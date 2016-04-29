using DAL;
using Logic;
using DAL.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;


namespace BookCatalog.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Book> bookRepository;
        

        public HomeController()
        {
            bookRepository = unitOfWork.Repository<Book>();
        }

        public ActionResult Index(int? page)
        {
            IEnumerable<Book> books = bookRepository.Table.ToList();
            books.Sort();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(books.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CreateEditBook(int? id)
        {
            Book model = new Book();
            if (id.HasValue)
            {
                model = bookRepository.GetById(id.Value);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditBook(Book model)
        {
            if (model.Id == 0)
            {
               // model.IP = Request.UserHostAddress;
                bookRepository.Insert(model);
            }
            else
            {
                var editModel = bookRepository.GetById(model.Id);
                editModel.NameBook = model.NameBook;
                editModel.Author = model.Author;
                editModel.PublisherBook = model.PublisherBook;
                bookRepository.Update(editModel);
            }

            if (model.Id > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult DeleteBook(int id)
        {
            Book model = bookRepository.GetById(id);
            return View(model);
        }

        [HttpPost, ActionName("DeleteBook")]
        public ActionResult ConfirmDeleteBook(int id)
        {
            Book model = bookRepository.GetById(id);
            bookRepository.Delete(model);
            return RedirectToAction("Index");
        }

        public ActionResult DetailBook(int id)
        {
            Book model = bookRepository.GetById(id);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
