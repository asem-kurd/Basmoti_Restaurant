
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbTransactionBookTableRepository : ITransactionRepository<TransactionBookTable>
    {
        public AppDbContext db { get; }
        public dbTransactionBookTableRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Add(TransactionBookTable entity)
        {
            entity.CreateId = "1"; // اليزور الي بعت ايميلو
            entity.CreateDate = DateTime.Now;
            db.TransactionBookTables.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionBookTable entity)
        {
            var data = Find(Id);
            db.TransactionBookTables.Remove(data);
            db.SaveChanges();
        }

        public List<TransactionBookTable> ViewAdmin()
        {
            return db.TransactionBookTables.ToList();
        }

        public TransactionBookTable Find(int Id)
        {
            return db.TransactionBookTables.SingleOrDefault(x => x.TransactionBookTableId == Id);
        }
    }
}
