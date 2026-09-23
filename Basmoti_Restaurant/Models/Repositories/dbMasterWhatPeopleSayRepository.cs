
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbMasterWhatPeopleSayRepository : IRepository<MasterWhatPeopleSay>
    {
        public AppDbContext db { get; }

        public dbMasterWhatPeopleSayRepository(AppDbContext _db)
        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = "1";//رقم اليوزر الي داخل 
            data.UpdateDate = DateTime.Now;
            db.MasterWhatPeopleSay.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterWhatPeopleSay entity)
        {
            entity.CreateId = "1";
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = "1";
            entity.IsActive = true;
            db.MasterWhatPeopleSay.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterWhatPeopleSay entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = "1";//رقم اليوزر الي داخل 
            entity.UpdateDate = DateTime.Now;
            db.MasterWhatPeopleSay.Update(entity);
            db.SaveChanges();
        }

        public MasterWhatPeopleSay Find(int Id)
        {
            return db.MasterWhatPeopleSay.SingleOrDefault(x => x.MasterWhatPeopleSayId == Id);
        }

        public void Update(int Id, MasterWhatPeopleSay entity)
        {
            var data = Find(Id);

            data.MasterWhatPeopleSayName = entity.MasterWhatPeopleSayName;
            data.MasterWhatPeopleSayText = entity.MasterWhatPeopleSayText;
            data.MasterWhatPeopleSayImageUrl = entity.MasterWhatPeopleSayImageUrl;

            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = "1";
            db.MasterWhatPeopleSay.Update(entity);
            db.SaveChanges();
        }

        public List<MasterWhatPeopleSay> ViewAdmin()
        {
            return db.MasterWhatPeopleSay.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterWhatPeopleSay> ViewClient()
        {
            return db.MasterWhatPeopleSay.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
