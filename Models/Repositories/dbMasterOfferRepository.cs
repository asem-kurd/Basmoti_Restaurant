using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbMasterOfferRepository:IRepository<MasterOffer>
    {
        public AppDbContext db { get; }
        public dbMasterOfferRepository(AppDbContext _db)
        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = 1;
            data.UpdateDate = DateTime.Now;
            db.MasterOffers.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterOffer entity)
        {
            entity.CreateId = 1;
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.IsActive = true;
            db.MasterOffers.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterOffer entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = 1;
            entity.UpdateDate = DateTime.Now;
            db.MasterOffers.Update(entity);
            db.SaveChanges();
        }

        public MasterOffer Find(int Id)
        {
            return db.MasterOffers.SingleOrDefault(x => x.MasterOfferId == Id);
        }

        public void Update(int Id, MasterOffer entity)
        {
            var data = Find(Id);

            data.MasterOfferTitle = entity.MasterOfferTitle;
            data.MasterOfferBreef = entity.MasterOfferBreef;
            data.MasterOfferDesc = entity.MasterOfferDesc;
            data.MasterOfferImageUrl = entity.MasterOfferImageUrl;


            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            db.MasterOffers.Update(entity);
            db.SaveChanges();
        }

        public List<MasterOffer> ViewAdmin()
        {
            return db.MasterOffers.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterOffer> ViewClient()
        {
            return db.MasterOffers.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
