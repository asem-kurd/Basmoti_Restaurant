
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbMasterSocialMediaRepository : IRepository<MasterSocialMedia>
    {
        public AppDbContext db { get; }

        public dbMasterSocialMediaRepository(AppDbContext _db)
        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = "1";//رقم اليوزر الي داخل 
            data.UpdateDate = DateTime.Now;
            db.MasterSocialMedia.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterSocialMedia entity)
        {
            entity.CreateId = "1";
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = "1";
            entity.IsActive = true;
            db.MasterSocialMedia.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSocialMedia entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = "1";//رقم اليوزر الي داخل 
            entity.UpdateDate = DateTime.Now;
            db.MasterSocialMedia.Update(entity);
            db.SaveChanges();
        }

        public MasterSocialMedia Find(int Id)
        {
            return db.MasterSocialMedia.SingleOrDefault(x => x.MasterSocialMediaId == Id);
        }

        public void Update(int Id, MasterSocialMedia entity)
        {
            var data = Find(Id);

            data.MasterSocialMediaImageUrl = entity.MasterSocialMediaImageUrl;
            data.MasterSocialMediaUrl = entity.MasterSocialMediaUrl;

            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = "1";
            db.MasterSocialMedia.Update(entity);
            db.SaveChanges();
        }

        public List<MasterSocialMedia> ViewAdmin()
        {
            return db.MasterSocialMedia.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSocialMedia> ViewClient()
        {
            return db.MasterSocialMedia.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
