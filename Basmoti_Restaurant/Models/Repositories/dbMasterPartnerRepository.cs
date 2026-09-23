
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbMasterPartnerRepository : IRepository<MasterPartner>
    {

        public AppDbContext db { get; }
        public dbMasterPartnerRepository(AppDbContext _db)
        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = "1";
            data.UpdateDate = DateTime.Now;
            db.MasterPartners.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterPartner entity)
        {
            entity.CreateId = "1";
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = "1";
            entity.IsActive = true;
            db.MasterPartners.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterPartner entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = "1";
            entity.UpdateDate = DateTime.Now;
            db.MasterPartners.Update(entity);
            db.SaveChanges();
        }

        public MasterPartner Find(int Id)
        {
            return db.MasterPartners.SingleOrDefault(x => x.MasterPartnerId == Id);
        }

        public void Update(int Id, MasterPartner entity)
        {
            var data = Find(Id);

            data.MasterPartnerName = entity.MasterPartnerName;
            data.MasterPartnerLogoImageUrl = entity.MasterPartnerLogoImageUrl;
            data.MasterPartnerWebsiteUrl = entity.MasterPartnerWebsiteUrl;

            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = "1";
            db.MasterPartners.Update(entity);
            db.SaveChanges();
        }

        public List<MasterPartner> ViewAdmin()
        {
            return db.MasterPartners.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterPartner> ViewClient()
        {
            return db.MasterPartners.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
