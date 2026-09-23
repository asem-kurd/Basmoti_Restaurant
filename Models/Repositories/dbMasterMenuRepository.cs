using Restaurant.Data;
using System;

namespace Restaurant.Models.Repositories
{
    public class dbMasterMenuRepository : IRepository<MasterMenu>
    {
        public AppDbContext db { get; }

        public dbMasterMenuRepository(AppDbContext _db)
        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = 1;//رقم اليوزر الي داخل 
            data.UpdateDate = DateTime.Now;
            db.MasterMenus.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterMenu entity)
        {
            entity.CreateId = 1;
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            entity.IsActive = true;
            db.MasterMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterMenu entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = 1;//رقم اليوزر الي داخل 
            entity.UpdateDate = DateTime.Now;
            db.MasterMenus.Update(entity);
            db.SaveChanges();
        }

        public MasterMenu Find(int Id)
        {
            return db.MasterMenus.SingleOrDefault(x => x.MasterMenuId == Id);
        }

        public void Update(int Id, MasterMenu entity)
        {
            var data = Find(Id);

            data.MasterMenuName = entity.MasterMenuName;
            data.MasterMenuUrl = entity.MasterMenuUrl;


            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            db.MasterMenus.Update(entity);
            db.SaveChanges();
        }

        public List<MasterMenu> ViewAdmin()
        {
            return db.MasterMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterMenu> ViewClient()
        {
            return db.MasterMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
