using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Basmoti_Restaurant.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SystemSettingController : Controller
    {

        public IRepository<SystemSetting> SystemSetting { get; }

        public IHostingEnvironment Host { get; }

        public SystemSettingController(IRepository<SystemSetting> _SystemSetting, IHostingEnvironment _Host)
        {
            SystemSetting = _SystemSetting;
            Host = _Host;
        }


        // GET: SystemSettingController
        public ActionResult Index(int DeleteId, int? toggleId)
        {

            SystemSetting systemSetting = new SystemSetting();

            if (DeleteId != 0)
            {
                SystemSetting.Delete(DeleteId, systemSetting);
                return RedirectToAction(nameof(Index));
            }


            if (toggleId.HasValue)
            {
                SystemSetting.Active(toggleId.Value);
            }


            return View(SystemSetting.ViewAdmin());
        }

        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSettingModel collection)
        {
            if (collection.File1 == null) ModelState.AddModelError(nameof(collection.File1), "Logo1 is Required");
            if (collection.File2 == null) ModelState.AddModelError(nameof(collection.File2), "Logo2 is Required");
            if (collection.File3 == null) ModelState.AddModelError(nameof(collection.File3), "Welcome Note Image is Required");

            if (!ModelState.IsValid)
                return View(collection);

            var data = new SystemSetting
            {
                SystemSettingLogoImageUrl1 = SaveImage(collection.File1!),
                SystemSettingLogoImageUrl2 = SaveImage(collection.File2!),
                SystemSettingWelcomeNoteImageUrl = SaveImage(collection.File3!),
                SystemSettingCopyright = collection.SystemSettingCopyright,
                SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                SystemSettingPhone = collection.SystemSettingPhone,
                SystemSettingEmail = collection.SystemSettingEmail,
                SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                SystemSettingMapLocation = collection.SystemSettingMapLocation,
                SystemSettingMapLocationUrl = collection.SystemSettingMapLocationUrl,
            };

            SystemSetting.Add(data);
            return RedirectToAction(nameof(Index));
        }

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = SystemSetting.Find(id);

            SystemSettingModel obj = new SystemSettingModel
            {
                SystemSettingId = data.SystemSettingId,
                SystemSettingLogoImageUrl1 = data.SystemSettingLogoImageUrl1,
                SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                SystemSettingCopyright = data.SystemSettingCopyright,
                SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                SystemSettingPhone = data.SystemSettingPhone,
                SystemSettingEmail = data.SystemSettingEmail,
                SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,
                SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                SystemSettingMapLocation = data.SystemSettingMapLocation,
                SystemSettingMapLocationUrl = data.SystemSettingMapLocationUrl
            };
            return View(obj);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingModel model)
        {
            if (!ModelState.IsValid)
                return View(model);   // مش View() فاضية

            var data = new SystemSetting
            {
                SystemSettingLogoImageUrl1 = model.File1 != null ? SaveImage(model.File1) : model.SystemSettingLogoImageUrl1,
                SystemSettingLogoImageUrl2 = model.File2 != null ? SaveImage(model.File2) : model.SystemSettingLogoImageUrl2,
                SystemSettingWelcomeNoteImageUrl = model.File3 != null ? SaveImage(model.File3) : model.SystemSettingWelcomeNoteImageUrl,
                SystemSettingCopyright = model.SystemSettingCopyright,
                SystemSettingWelcomeNoteTitle = model.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteBreef = model.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = model.SystemSettingWelcomeNoteDesc,
                SystemSettingPhone = model.SystemSettingPhone,
                SystemSettingEmail = model.SystemSettingEmail,
                SystemSettingWelcomeNoteUrl = model.SystemSettingWelcomeNoteUrl,
                SystemSettingMapLocation = model.SystemSettingMapLocation,
                SystemSettingMapLocationUrl = model.SystemSettingMapLocationUrl,
            };

            SystemSetting.Update(id, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: SystemSettingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(SystemSetting.Find(id));
        }

        // POST: SystemSettingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SystemSetting collection)
        {
            try
            {
                SystemSetting.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Search(string strName)
        {

            //var data = Products.View().Where(x => x.ProductsName.Contains(strName)).ToList();

            List<SystemSetting> data = SystemSetting.ViewAdmin().Where(x => string.IsNullOrWhiteSpace(strName) || (x.SystemSettingWelcomeNoteTitle ?? "").Contains(strName)).ToList();

            List<SystemSetting> newList = new List<SystemSetting>();
            for (int i = 0; i < data.Count; i++)
            {
                SystemSetting obj = new SystemSetting
                {
                    SystemSettingId = data[i].SystemSettingId,
                    SystemSettingLogoImageUrl1 = data[i].SystemSettingLogoImageUrl1,
                    SystemSettingLogoImageUrl2 = data[i].SystemSettingLogoImageUrl2,
                    SystemSettingCopyright = data[i].SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = data[i].SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = data[i].SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = data[i].SystemSettingWelcomeNoteDesc,
                    SystemSettingPhone = data[i].SystemSettingPhone,
                    SystemSettingEmail = data[i].SystemSettingEmail,
                    SystemSettingWelcomeNoteUrl = data[i].SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteImageUrl = data[i].SystemSettingWelcomeNoteImageUrl,
                    SystemSettingMapLocation = data[i].SystemSettingMapLocation,
                    SystemSettingMapLocationUrl = data[i].SystemSettingMapLocationUrl,
                };
                newList.Add(obj);

            }


            return View("Index", newList);
        }




        //public string ImageFullName(SystemSettingModel collection)
        //{
        //    if (collection.File1 == null)
        //    {
        //        return collection.SystemSettingLogoImageUrl1;
        //    }
        //    if (collection.File2 == null)
        //    {
        //        return collection.SystemSettingLogoImageUrl2;
        //    }
        //    if (collection.File3 == null)
        //    {
        //        return collection.SystemSettingWelcomeNoteImageUrl;
        //    }

        //    string ImagePath = Path.Combine(Host.WebRootPath, "images");
        //    FileInfo f1 = new FileInfo(collection.File1.FileName);
        //    FileInfo f2 = new FileInfo(collection.File2.FileName);
        //    FileInfo f3 = new FileInfo(collection.File3.FileName);

        //    string ImageName1 = Guid.NewGuid().ToString() + f1.Name;
        //    string ImageName2 = Guid.NewGuid().ToString() + f2.Name;
        //    string ImageName3 = Guid.NewGuid().ToString() + f3.Name;
        //    string FullPath1 = Path.Combine(ImagePath, ImageName1);
        //    string FullPath2 = Path.Combine(ImagePath, ImageName2);
        //    string FullPath3 = Path.Combine(ImagePath, ImageName3);

        //    collection.File1.CopyTo(new FileStream(FullPath1, FileMode.Create));
        //    collection.File2.CopyTo(new FileStream(FullPath2, FileMode.Create));
        //    collection.File3.CopyTo(new FileStream(FullPath3, FileMode.Create));

        //    return ImageName1 + "," + ImageName2 + "," + ImageName3;
        //}




        private string SaveImage(IFormFile file)
        {
            string folder = Path.Combine(Host.WebRootPath, "images");
            string name = Guid.NewGuid() + Path.GetFileName(file.FileName);

            using var stream = new FileStream(Path.Combine(folder, name), FileMode.Create);
            file.CopyTo(stream);

            return name;
        }


    }
}
