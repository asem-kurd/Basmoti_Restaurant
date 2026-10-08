using Basmoti_Restaurant.Areas.Admin.ViewModels;
using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {

        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IHostingEnvironment Host { get; }

        public SocialMediaController(IRepository<MasterSocialMedia> _MasterSocialMedia, IHostingEnvironment _Host)
        {
            MasterSocialMedia = _MasterSocialMedia;
            Host = _Host;
        }


        // GET: SocialMediaController
        public ActionResult Index(int DeleteId, int? toggleId)
        {
            MasterSocialMedia masterSocialMedia = new MasterSocialMedia();

            if (DeleteId != 0)
            {
                MasterSocialMedia.Delete(DeleteId, masterSocialMedia);
                return RedirectToAction(nameof(Index));
            }


            if (toggleId.HasValue)
            {
                MasterSocialMedia.Active(toggleId.Value);
            }


            return View(MasterSocialMedia.ViewAdmin());
        }

        // GET: SocialMediaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialMediaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMediaModel collection)
        {
            try
            {
                if (collection.File == null)
                {
                    ModelState.AddModelError(nameof(collection.File), "Image is Required");
                }
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var data = new MasterSocialMedia
                {
                    MasterSocialMediaId = collection.MasterSocialMediaId,
                    MasterSocialMediaName = collection.MasterSocialMediaName,
                    MasterSocialMediaImageUrl = ImageFullName(collection),
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl
                };
                MasterSocialMedia.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SocialMediaController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSocialMedia.Find(id);
            MasterSocialMediaModel obj = new MasterSocialMediaModel
            {
                MasterSocialMediaId = data.MasterSocialMediaId,
                MasterSocialMediaName = data.MasterSocialMediaName,
                MasterSocialMediaImageUrl = data.MasterSocialMediaImageUrl,
                MasterSocialMediaUrl = data.MasterSocialMediaUrl
            };
            return View(obj);
        }

        // POST: SocialMediaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediaModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var data = new MasterSocialMedia
                {
                    MasterSocialMediaId = collection.MasterSocialMediaId,
                    MasterSocialMediaName = collection.MasterSocialMediaName,
                    MasterSocialMediaImageUrl = ImageFullName(collection),
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl
                };
                MasterSocialMedia.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SocialMediaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MasterSocialMedia.Find(id));
        }

        // POST: SocialMediaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MasterSocialMedia collection)
        {
            try
            {
                MasterSocialMedia.Delete(id, collection);
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

            List<MasterSocialMedia> data = MasterSocialMedia.ViewAdmin().Where(x => string.IsNullOrWhiteSpace(strName) || (x.MasterSocialMediaName ?? "").Contains(strName)).ToList();

            List<MasterSocialMedia> newList = new List<MasterSocialMedia>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterSocialMedia obj = new MasterSocialMedia
                {
                    MasterSocialMediaId = data[i].MasterSocialMediaId,
                    MasterSocialMediaName = data[i].MasterSocialMediaName,
                    MasterSocialMediaImageUrl = data[i].MasterSocialMediaImageUrl,
                    MasterSocialMediaUrl = data[i].MasterSocialMediaUrl
                };
                newList.Add(obj);
            }


            return View("Index", newList);
        }

        public string ImageFullName(MasterSocialMediaModel collection)
        {
            if (collection.File == null)
            {
                return collection.MasterSocialMediaImageUrl;
            }

            string ImagePath = Path.Combine(Host.WebRootPath, "images");
            FileInfo f = new FileInfo(collection.File.FileName);

            string ImageName = Guid.NewGuid().ToString() + f.Name;
            string FullPath = Path.Combine(ImagePath, ImageName);

            collection.File.CopyTo(new FileStream(FullPath, FileMode.Create));

            return ImageName;
        }
    }
}
