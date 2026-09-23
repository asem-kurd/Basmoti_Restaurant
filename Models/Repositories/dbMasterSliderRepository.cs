
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbMasterSliderRepository : IRepository<MasterSlider>
    {
        public AppDbContext db { get; }

        public dbMasterSliderRepository(AppDbContext _db)
        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = 1;//رقم اليوزر الي داخل 
            data.UpdateDate = DateTime.Now;
            db.MasterSliders.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterSlider entity)
        {
            entity.CreateId = 1;
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            entity.IsActive = true;
            db.MasterSliders.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSlider entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = 1;//رقم اليوزر الي داخل 
            entity.UpdateDate = DateTime.Now;
            db.MasterSliders.Update(entity);
            db.SaveChanges();
        }

        public MasterSlider Find(int Id)
        {
            return db.MasterSliders.SingleOrDefault(x => x.MasterSliderId == Id);
        }

        public void Update(int Id, MasterSlider entity)
        {
            var data = Find(Id);
            data.MasterSliderTitle = entity.MasterSliderTitle;
            data.MasterSliderBreef = entity.MasterSliderBreef;
            data.MasterSliderDesc = entity.MasterSliderDesc;
            data.MasterSliderImageUrl = entity.MasterSliderImageUrl;

            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            db.MasterSliders.Update(entity);
            db.SaveChanges();
        }

        public List<MasterSlider> ViewAdmin()
        {
            return db.MasterSliders.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSlider> ViewClient()
        {
            return db.MasterSliders.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
