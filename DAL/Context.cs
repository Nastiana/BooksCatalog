using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;

namespace DAL
{
    public class Context : DbContext
    {
        public Context() : base("DataBase")
        { }

        public new IDbSet<TEntity> Set<TEntity>()  where TEntity : BaseEntity
       {
           return base.Set<TEntity>();
       }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        // Отражение таблиц базы данных на свойства с типом DbSet
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<PublisherBook> PublisherBooks { get; set; }


        static void Main(string[] args)
        {
            using (Context db = new Context())
            {
                // создаем два объекта User
                Store store = new Store { Items = "1", Address = "Войкова 2" };
                StoreItem storeitam = new StoreItem { Cost = 198000, Book = "Гарри Поттер", NamePublisher = "Росмен" };
                Publisher publisher = new Publisher { NamePublisher = "Росмен", NameBook = "Гарри Поттер", Description = "Шикарный книги", Cost = 198000 };
                PublisherBook publisherbook = new PublisherBook { NameBook = "Гарри Поттер", Name = "Дж.Роулинг", RecommendedCost = 150000 };
                Book book = new Book { NameBook = "Гарри Поттер", Author = "Дж.Роулинг", PublisherBook = "Росмен" };

                // добавляем их в бд
                db.Stores.Add(store);
                db.SaveChanges();
                db.StoreItems.Add(storeitam);
                db.SaveChanges();
                db.Publishers.Add(publisher);
                db.SaveChanges();
                db.PublisherBooks.Add(publisherbook);
                 db.SaveChanges();
                db.Books.Add(book);
                db.SaveChanges();
            }
        }
    }
}
                