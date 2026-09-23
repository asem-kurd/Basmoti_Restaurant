
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbTransactionContactUsRepository : ITransactionRepository<TransactionContactUs>
    {
        public AppDbContext db { get; }

        public dbTransactionContactUsRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Add(TransactionContactUs entity)
        {
            entity.CreateId = "1"; // اليزور الي بعت ايميلو
            entity.CreateDate = DateTime.Now;
            db.TransactionContactUs.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionContactUs entity)
        {
            var data = Find(Id);
            db.TransactionContactUs.Remove(data);
            db.SaveChanges();
        }
        

        public List<TransactionContactUs> ViewAdmin()
        {
            return db.TransactionContactUs.ToList();
        }

        public TransactionContactUs Find(int Id)
        {
            return db.TransactionContactUs.SingleOrDefault(x => x.TransactionContactUsId == Id);
        }
    }
}
