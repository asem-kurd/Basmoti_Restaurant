using Basmoti_Restaurant.Areas.Admin.ViewModels;
using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace Basmoti_Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public IHostingEnvironment Host { get; }


        public ItemMenuController(IRepository<MasterItemMenu> _MasterItemMenu, IRepository<MasterCategoryMenu> _MasterCategoryMenu, IHostingEnvironment _Host)
        {
            MasterItemMenu = _MasterItemMenu;
            MasterCategoryMenu = _MasterCategoryMenu;
            Host = _Host;
        }


        // GET: ItemMenuController
        public ActionResult Index(int DeleteId, int? toggleId)
        {

            MasterItemMenu masterItemMenu = new MasterItemMenu();

            if (DeleteId != 0)
            {
                MasterItemMenu.Delete(DeleteId, masterItemMenu);
                return RedirectToAction(nameof(Index));
            }


            if (toggleId.HasValue)
            {
                MasterItemMenu.Active(toggleId.Value);
            }


            return View(MasterItemMenu.ViewAdmin());
        }

        // GET: ItemMenuController/Create
        public ActionResult Create()
        {
            ViewBag.ListCategory = MasterCategoryMenu.ViewAdmin();
            return View();
        }

        // POST: ItemMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuModel collection)
        {
            try
            {
                if (collection.File == null)
                {
                    ModelState.AddModelError(nameof(collection.File), "Logo Image is Required");
                }
                if (!ModelState.IsValid)
                {
                    ViewBag.ListCategory = MasterCategoryMenu.ViewAdmin();
                    return View(collection);
                }
                var data = new MasterItemMenu
                {
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = ImageFullName(collection),
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId

                };

                MasterItemMenu.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterItemMenu.Find(id);
            ViewBag.ListCategory = MasterCategoryMenu.ViewAdmin();

            MasterItemMenuModel obj = new MasterItemMenuModel
            {
                MasterItemMenuId = data.MasterItemMenuId,
                MasterItemMenuTitle = data.MasterItemMenuTitle,
                MasterItemMenuBreef = data.MasterItemMenuBreef,
                MasterItemMenuDesc = data.MasterItemMenuDesc,
                MasterItemMenuPrice = data.MasterItemMenuPrice,
                MasterItemMenuDate = data.MasterItemMenuDate,
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterCategoryMenu = MasterCategoryMenu.Find(data.MasterCategoryMenuId),
                MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
            };
            return View(obj);
        }

        // POST: ItemMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuModel collection)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ListCategory = MasterCategoryMenu.ViewAdmin();
                return View();
            }
            try
            {
                var data = new MasterItemMenu
                {
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuImageUrl = ImageFullName(collection),
                };
                MasterItemMenu.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MasterItemMenu.Find(id));
        }

        // POST: ItemMenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MasterCategoryMenu collection)
        {
            try
            {
                MasterCategoryMenu.Delete(id, collection);
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

            List<MasterCategoryMenu> data = MasterCategoryMenu.ViewAdmin().Where(x => string.IsNullOrWhiteSpace(strName) || (x.MasterCategoryMenuName ?? "").Contains(strName)).ToList();

            List<MasterCategoryMenu> newList = new List<MasterCategoryMenu>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterCategoryMenu obj = new MasterCategoryMenu
                {
                    MasterCategoryMenuId = data[i].MasterCategoryMenuId,
                    MasterCategoryMenuName = data[i].MasterCategoryMenuName,
                    MasterItemMenus = data[i].MasterItemMenus,
                };
                newList.Add(obj);

            }


            return View("Index", newList);
        }




        public string ImageFullName(MasterItemMenuModel collection)
        {
            if (collection.File == null)
            {
                return collection.MasterItemMenuImageUrl;
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
