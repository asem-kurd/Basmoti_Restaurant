using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryMenuController : Controller
    {
        public IRepository<MasterCategoryMenu> CategoryMenu { get; }

        public CategoryMenuController(IRepository<MasterCategoryMenu> _CategoryMenu)
        {
            CategoryMenu = _CategoryMenu;
        }
        // GET: CategoryMenuController
        public ActionResult Index(int DeleteId, int? toggleId)
        {
            MasterCategoryMenu categoryMenu = new MasterCategoryMenu();

            if (DeleteId != 0) 
            {
                CategoryMenu.Delete(DeleteId, categoryMenu);
                return RedirectToAction(nameof(Index));
            }

            if (toggleId.HasValue) 
            {
                CategoryMenu.Active(toggleId.Value);
            }


            return View(CategoryMenu.ViewAdmin());
        }

        // GET: CategoryMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCategoryMenu collection)
        {
            try
            {
                var data = new MasterCategoryMenu
                {
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterCategoryMenuName = collection.MasterCategoryMenuName,
                    MasterItemMenus = collection.MasterItemMenus
                };

                CategoryMenu.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(CategoryMenu.Find(id));
        }

        // POST: CategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterCategoryMenu collection)
        {
            try
            {
                CategoryMenu.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(CategoryMenu.Find(id));
        }

        // POST: CategoryMenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MasterCategoryMenu collection)
        {
            try
            {
                CategoryMenu.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
