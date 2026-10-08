using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }

        public MasterMenuController(IRepository<MasterMenu> _MasterMenu)
        {
            MasterMenu = _MasterMenu;
        }



        // GET: MasterMenuController
        public ActionResult Index(int DeleteId, int? toggleId)
        {

            MasterMenu masterMenu = new MasterMenu();

            if (DeleteId != 0)
            {
                MasterMenu.Delete(DeleteId, masterMenu);
                return RedirectToAction(nameof(Index));
            }


            if (toggleId.HasValue)
            {
                MasterMenu.Active(toggleId.Value);
            }


            return View(MasterMenu.ViewAdmin());
        }

        // GET: MasterMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenu collection)
        {
            try
            {
                var data = new MasterMenu 
                {
                    MasterMenuId = collection.MasterMenuId,
                    MasterMenuName = collection.MasterMenuName,
                    MasterMenuUrl = collection.MasterMenuUrl
                };

                MasterMenu.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(MasterMenu.Find(id));
        }

        // POST: MasterMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenu collection)
        {
            try
            {
                MasterMenu.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MasterMenu.Find(id));
        }

        // POST: MasterMenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MasterMenu collection)
        {
            try
            {
                MasterMenu.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
