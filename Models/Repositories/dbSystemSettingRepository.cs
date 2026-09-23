
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class dbSystemSettingRepository : IRepository<SystemSetting>
    {
        public AppDbContext db { get; }

        public dbSystemSettingRepository(AppDbContext _db)

        {
            db = _db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.UpdateId = 1;//رقم اليوزر الي داخل 
            data.UpdateDate = DateTime.Now;
            db.SystemSettings.Update(data);
            db.SaveChanges();
        }

        public void Add(SystemSetting entity)

        {
            entity.CreateId = 1;
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            entity.IsActive = true;
            db.SystemSettings.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, SystemSetting entity)
        {
            entity = Find(Id);
            entity.IsDelete = true;
            entity.UpdateId = 1;//رقم اليوزر الي داخل 
            entity.UpdateDate = DateTime.Now;
            db.SystemSettings.Update(entity);
            db.SaveChanges();
        }

        public SystemSetting Find(int Id)

        {
            return db.SystemSettings.SingleOrDefault(x => x.SystemSettingId == Id);
        }

        public void Update(int Id, SystemSetting entity)
        {
            var data = Find(Id);
            data.SystemSettingLogoImageUrl = entity.SystemSettingLogoImageUrl;
            data.SystemSettingLogoImageUrl2 = entity.SystemSettingLogoImageUrl2;
            data.SystemSettingCopyright = entity.SystemSettingCopyright;
            data.SystemSettingWelcomeNoteTitle = entity.SystemSettingWelcomeNoteTitle;
            data.SystemSettingWelcomeNoteBreef = entity.SystemSettingWelcomeNoteBreef;
            data.SystemSettingWelcomeNoteDesc = entity.SystemSettingWelcomeNoteDesc;
            data.SystemSettingPhone = entity.SystemSettingPhone;
            data.SystemSettingEmail = entity.SystemSettingEmail;
            data.SystemSettingSocialMediaIcon = entity.SystemSettingSocialMediaIcon;
            data.SystemSettingSocialMediaIconUrl = entity.SystemSettingSocialMediaIconUrl;
            data.SystemSettingWelcomeNoteUrl = entity.SystemSettingWelcomeNoteUrl;
            data.SystemSettingWelcomeNoteImageUrl = entity.SystemSettingWelcomeNoteImageUrl;
            data.SystemSettingMapLocation = entity.SystemSettingMapLocation;
            data.SystemSettingMapLocationUrl = entity.SystemSettingMapLocationUrl;



            entity.UpdateDate = DateTime.Now;
            entity.UpdateId = 1;
            db.SystemSettings.Update(entity);
            db.SaveChanges();
        }

        public List<SystemSetting> ViewAdmin()

        {
            return db.SystemSettings.Where(x => x.IsDelete == false).ToList();
        }

        public List<SystemSetting> ViewClient()
        {
            return db.SystemSettings.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
