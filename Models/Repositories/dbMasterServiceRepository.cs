
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbMasterServiceRepository : IRepository<MasterService>
    {

        public AppDbContext db { get; }
        public dbMasterServiceRepository(AppDbContext _db)
        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = 1;//رقم اليوزر الي داخل 
            data.UpdateDate = DateTime.Now;
            db.MasterServices.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterService entity)
        {
            entity.CreateId = 1;
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            entity.IsActive = true;
            db.MasterServices.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterService entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = 1;//رقم اليوزر الي داخل 
            entity.UpdateDate = DateTime.Now;
            db.MasterServices.Update(entity);
            db.SaveChanges();
        }

        public MasterService Find(int Id)
        {
            return db.MasterServices.SingleOrDefault(x => x.MasterServicesId == Id);
        }

        public void Update(int Id, MasterService entity)
        {
            var data = Find(Id);

            data.MasterServicesTitle = entity.MasterServicesTitle;
            data.MasterServicesDesc = entity.MasterServicesDesc;
            data.MasterServicesImage = entity.MasterServicesImage;

            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            db.MasterServices.Update(entity);
            db.SaveChanges();
        }

        public List<MasterService> ViewAdmin()
        {
            return db.MasterServices.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterService> ViewClient()
        {
            return db.MasterServices.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
