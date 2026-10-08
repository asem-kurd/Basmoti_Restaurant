using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Basmoti_Restaurant.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkingHoursController : Controller
    {
        public IRepository<MasterWorkingHours> MasterWorkingHours { get; }

        public WorkingHoursController(IRepository<MasterWorkingHours> _MasterWorkingHours)
        {
            MasterWorkingHours = _MasterWorkingHours;
        }


        // GET: WorkingHoursController
        public ActionResult Index(int DeleteId, int? toggleId)
        {
            MasterWorkingHours masterWorkingHours = new MasterWorkingHours();

            if (DeleteId != 0)
            {
                MasterWorkingHours.Delete(DeleteId, masterWorkingHours);
                return RedirectToAction(nameof(Index));
            }


            if (toggleId.HasValue)
            {
                MasterWorkingHours.Active(toggleId.Value);
            }


            return View(MasterWorkingHours.ViewAdmin());
        }

        // GET: WorkingHoursController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkingHoursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHours collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var data = new MasterWorkingHours
                {
                    MasterWorkingHoursId = collection.MasterWorkingHoursId,
                    MasterWorkingHoursDayName = collection.MasterWorkingHoursDayName,
                    MasterWorkingHoursIsClosed = collection.MasterWorkingHoursIsClosed,
                    MasterWorkingHoursOpenTime = collection.MasterWorkingHoursOpenTime,
                    MasterWorkingHoursCloseTime = collection.MasterWorkingHoursCloseTime
                };
                MasterWorkingHours.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkingHoursController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(MasterWorkingHours.Find(id));
        }

        // POST: WorkingHoursController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHours collection)
        {
            try
            {
                MasterWorkingHours.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkingHoursController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MasterWorkingHours.Find(id));
        }

        // POST: WorkingHoursController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MasterWorkingHours collection)
        {
            try
            {
                MasterWorkingHours.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
