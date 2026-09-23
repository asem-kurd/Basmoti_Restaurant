
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbMasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        public AppDbContext db { get; }
        public dbMasterItemMenuRepository(AppDbContext _db)
        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = "1";
            data.UpdateDate = DateTime.Now;
            db.MasterItemMenus.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterItemMenu entity)
        {
            entity.CreateId = "1";
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = "1";
            entity.IsActive = true;
            db.MasterItemMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterItemMenu entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = "1";
            entity.UpdateDate = DateTime.Now;
            db.MasterItemMenus.Update(entity);
            db.SaveChanges();
        }

        public MasterItemMenu Find(int Id)
        {
            return db.MasterItemMenus.SingleOrDefault(x => x.MasterItemMenuId == Id);
        }

        public void Update(int Id, MasterItemMenu entity)
        {
            var data = Find(Id);
            data.MasterItemMenuTitle = entity.MasterItemMenuTitle;
            data.MasterItemMenuBreef = entity.MasterItemMenuBreef;
            data.MasterItemMenuDesc = entity.MasterItemMenuDesc;
            data.MasterItemMenuPrice = entity.MasterItemMenuPrice;
            data.MasterItemMenuImageUrl = entity.MasterItemMenuImageUrl;
            data.MasterItemMenuDate = entity.MasterItemMenuDate;
            data.MasterCategoryMenuId = entity.MasterCategoryMenuId;


            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = "1";
            db.MasterItemMenus.Update(entity);
            db.SaveChanges();
        }

        public List<MasterItemMenu> ViewAdmin()
        {
            return db.MasterItemMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterItemMenu> ViewClient()
        {
            return db.MasterItemMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }







        //عرض عشوائي ل 10 وجبات في HOME PAGE


        public List<MasterItemMenu> ViewTop10()
        {
            return db.MasterItemMenus
                .Where(x => x.IsActive && !x.IsDelete)
                .Take(10)
                .ToList();
        }

    }
}
