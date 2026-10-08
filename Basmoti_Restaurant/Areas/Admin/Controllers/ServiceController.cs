using Basmoti_Restaurant.Areas.Admin.ViewModels;
using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        public IRepository<MasterService> MasterService { get; }
        public IHostingEnvironment Host { get; }
        public ServiceController(IRepository<MasterService> _MasterService, IHostingEnvironment _Host)
        {
            MasterService = _MasterService;
            Host = _Host;
        }


        // GET: ServiceController
        public ActionResult Index(int DeleteId, int? toggleId)
        {
            MasterService masterService = new MasterService();

            if (DeleteId != 0)
            {
                MasterService.Delete(DeleteId, masterService);
                return RedirectToAction(nameof(Index));
            }


            if (toggleId.HasValue)
            {
                MasterService.Active(toggleId.Value);
            }


            return View(MasterService.ViewAdmin());
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServiceModel collection)
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
                var data = new MasterService
                {
                    MasterServicesId = collection.MasterServicesId,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesImage = ImageFullName(collection),
                    MasterServicesDesc = collection.MasterServicesDesc
                };
                MasterService.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterService.Find(id);
            MasterServiceModel obj = new MasterServiceModel
            {
                MasterServicesId = data.MasterServicesId,
                MasterServicesTitle = data.MasterServicesTitle,
                MasterServicesDesc = data.MasterServicesDesc,
                MasterServicesImage = data.MasterServicesImage,
            };
            return View(obj);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterServiceModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var data = new MasterService
                {
                    MasterServicesId = collection.MasterServicesId,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesImage = ImageFullName(collection),
                    MasterServicesDesc = collection.MasterServicesDesc
                };
                MasterService.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MasterService.Find(id));
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MasterService collection)
        {
            try
            {
                MasterService.Delete(id, collection);
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

            List<MasterService> data = MasterService.ViewAdmin().Where(x => string.IsNullOrWhiteSpace(strName) || (x.MasterServicesTitle ?? "").Contains(strName)).ToList();

            List<MasterService> newList = new List<MasterService>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterService obj = new MasterService
                {
                    MasterServicesId = data[i].MasterServicesId,
                    MasterServicesTitle = data[i].MasterServicesTitle,
                    MasterServicesDesc = data[i].MasterServicesDesc,
                    MasterServicesImage = data[i].MasterServicesImage

                };
                newList.Add(obj);

            }


            return View("Index", newList);
        }
        public string ImageFullName(MasterServiceModel collection)
        {
            if (collection.File == null)
            {
                return collection.MasterServicesImage;
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
