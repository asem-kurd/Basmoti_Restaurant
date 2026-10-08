using Basmoti_Restaurant.Areas.Admin.ViewModels;
using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class PartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartner { get; }
        public IHostingEnvironment Host { get; }

        public PartnerController(IRepository<MasterPartner> _MasterPartner, IHostingEnvironment _Host)
        {
            MasterPartner = _MasterPartner;
            Host = _Host;
        }


        // GET: PartnerController
        public ActionResult Index(int DeleteId, int? toggleId)
        {
            MasterPartner masterPartner = new MasterPartner();

            if (DeleteId != 0)
            {
                MasterPartner.Delete(DeleteId, masterPartner);
                return RedirectToAction(nameof(Index));
            }


            if (toggleId.HasValue)
            {
                MasterPartner.Active(toggleId.Value);
            }


            return View(MasterPartner.ViewAdmin());
        }

        // GET: PartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerModel collection)
        {
            try
            {
                if (collection.File == null)
                {
                    ModelState.AddModelError(nameof(collection.File), "Logo Image is Required");
                }
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var data = new MasterPartner
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerLogoImageUrl = ImageFullName(collection),
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl
                };
                MasterPartner.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterPartner.Find(id);
            MasterPartnerModel obj = new MasterPartnerModel
            {
                MasterPartnerId = data.MasterPartnerId,
                MasterPartnerName = data.MasterPartnerName,
                MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl,
                MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl,
            };
            return View(obj);
        }

        // POST: PartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var data = new MasterPartner
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerLogoImageUrl = ImageFullName(collection),
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl
                };
                MasterPartner.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PartnerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MasterPartner.Find(id));
        }

        // POST: PartnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MasterPartner collection)
        {
            try
            {
                MasterPartner.Delete(id, collection);
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

            List<MasterPartner> data = MasterPartner.ViewAdmin().Where(x => string.IsNullOrWhiteSpace(strName) || (x.MasterPartnerName ?? "").Contains(strName)).ToList();

            List<MasterPartner> newList = new List<MasterPartner>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterPartner obj = new MasterPartner
                {
                    MasterPartnerId = data[i].MasterPartnerId,
                    MasterPartnerName = data[i].MasterPartnerName,
                    MasterPartnerLogoImageUrl = data[i].MasterPartnerLogoImageUrl,
                    MasterPartnerWebsiteUrl = data[i].MasterPartnerWebsiteUrl,

                };
                newList.Add(obj);

            }


            return View("Index", newList);
        }
        public string ImageFullName(MasterPartnerModel collection)
        {
            if (collection.File == null)
            {
                return collection.MasterPartnerLogoImageUrl;
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
