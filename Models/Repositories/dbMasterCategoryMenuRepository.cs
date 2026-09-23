
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbMasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {
        public AppDbContext db { get; }

        public dbMasterCategoryMenuRepository(AppDbContext _db)
        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = 1;//رقم اليوزر الي داخل 
            data.UpdateDate = DateTime.Now;
            db.MasterCategoryMenus.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterCategoryMenu entity)
        {
            entity.CreateId = 1;
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.IsActive = true;
            db.MasterCategoryMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterCategoryMenu entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = 1;
            entity.UpdateDate = DateTime.Now;
            db.MasterCategoryMenus.Update(entity);
            db.SaveChanges();

        }

        public MasterCategoryMenu Find(int Id)
        {
            return db.MasterCategoryMenus.SingleOrDefault(x => x.MasterCategoryMenuId == Id);
        }

        public void Update(int Id, MasterCategoryMenu entity)
        {
            var data = Find(Id);

            data.MasterCategoryMenuName = entity.MasterCategoryMenuName;

            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            db.MasterCategoryMenus.Update(entity);
            db.SaveChanges();
        }

        public List<MasterCategoryMenu> ViewAdmin()
        {
            return db.MasterCategoryMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterCategoryMenu> ViewClient()
        {
            return db.MasterCategoryMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
