using Restaurant.Data;
namespace Restaurant.Models.Repositories
{
    public class dbTransactionNewsletterRepository : ITransactionRepository<TransactionNewsletter>
    {

        public AppDbContext db { get; }

        public dbTransactionNewsletterRepository(AppDbContext _db)
        {
            db = _db;
        }


       

        public void Add(TransactionNewsletter entity)
        {
            entity.CreateId = 1; // اليزور الي بعت ايميلو
            entity.CreateDate = DateTime.Now;
            db.TransactionNewsletters.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionNewsletter entity)
        {
            var data = Find(Id);
            db.TransactionNewsletters.Remove(data);
            db.SaveChanges();
        }

      

        public List<TransactionNewsletter> ViewAdmin()
        {
            return db.TransactionNewsletters.ToList();
        }

        public TransactionNewsletter Find(int Id)
        {
            return db.TransactionNewsletters.SingleOrDefault(x => x.TransactionNewsletterId == Id);
        }
    }
}
