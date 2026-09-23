
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbMasterWorkingHoursRepository : IRepository<MasterWorkingHours>
    {
        public AppDbContext db { get; }

        public dbMasterWorkingHoursRepository(AppDbContext _db)
        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = 1;//رقم اليوزر الي داخل 
            data.UpdateDate = DateTime.Now;
            db.MasterWorkingHours.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterWorkingHours entity)
        {
            entity.CreateId = 1;
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            entity.IsActive = true;
            db.MasterWorkingHours.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterWorkingHours entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = 1;//رقم اليوزر الي داخل 
            entity.UpdateDate = DateTime.Now;
            db.MasterWorkingHours.Update(entity);
            db.SaveChanges();
        }

        public MasterWorkingHours Find(int Id)
        {
            return db.MasterWorkingHours.SingleOrDefault(x => x.MasterWorkingHoursId == Id);
        }

        public void Update(int Id, MasterWorkingHours entity)
        {
            var data = Find(Id);

            data.MasterWorkingHoursName = entity.MasterWorkingHoursName;
            data.MasterWorkingHoursTimeFormTo = entity.MasterWorkingHoursTimeFormTo;

            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            db.MasterWorkingHours.Update(entity);
            db.SaveChanges();
        }

        public List<MasterWorkingHours> ViewAdmin()
        {
            return db.MasterWorkingHours.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterWorkingHours> ViewClient()
        {
            return db.MasterWorkingHours.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
