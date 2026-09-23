
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbMasterWorkingDayRepository : IRepository<MasterWorkingDay>
    {
        public AppDbContext db { get; }

        public dbMasterWorkingDayRepository(AppDbContext _db)
        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = 1;//رقم اليوزر الي داخل 
            data.UpdateDate = DateTime.Now;
            db.MasterWorkingDay.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterWorkingDay entity)
        {
            entity.CreateId = 1;
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            entity.IsActive = true;
            db.MasterWorkingDay.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterWorkingDay entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = 1;//رقم اليوزر الي داخل 
            entity.UpdateDate = DateTime.Now;
            db.MasterWorkingDay.Update(entity);
            db.SaveChanges();
        }

        public MasterWorkingDay Find(int Id)
        {
            return db.MasterWorkingDay.SingleOrDefault(x => x.MasterWorkingDayId == Id);
        }

        public void Update(int Id, MasterWorkingDay entity)
        {
            var data = Find(Id);

            data.MasterWorkingDayName = entity.MasterWorkingDayName;
            data.MasterWorkingHoursId = entity.MasterWorkingHoursId;

            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            db.MasterWorkingDay.Update(entity);
            db.SaveChanges();
        }

        public List<MasterWorkingDay> ViewAdmin()
        {
            return db.MasterWorkingDay.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterWorkingDay> ViewClient()
        {
            return db.MasterWorkingDay.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
