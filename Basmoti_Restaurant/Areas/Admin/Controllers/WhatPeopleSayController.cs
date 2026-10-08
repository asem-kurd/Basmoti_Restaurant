using Basmoti_Restaurant.Areas.Admin.ViewModels;
using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace Basmoti_Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WhatPeopleSayController : Controller
    {

        public IRepository<MasterWhatPeopleSay> MasterWhatPeopleSay { get; }
        public IHostingEnvironment Host { get; }

        public WhatPeopleSayController(IRepository<MasterWhatPeopleSay> _MasterWhatPeopleSay, IHostingEnvironment _Host)
        {
            MasterWhatPeopleSay = _MasterWhatPeopleSay;
            Host = _Host;
        }


        // GET: WhatPeopleSayController
        public ActionResult Index(int DeleteId, int? toggleId)
        {
            MasterWhatPeopleSay masterWhatPeopleSay = new MasterWhatPeopleSay();

            if (DeleteId != 0)
            {
                MasterWhatPeopleSay.Delete(DeleteId, masterWhatPeopleSay);
                return RedirectToAction(nameof(Index));
            }


            if (toggleId.HasValue)
            {
                MasterWhatPeopleSay.Active(toggleId.Value);
            }


            return View(MasterWhatPeopleSay.ViewAdmin());
        }

        // GET: WhatPeopleSayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WhatPeopleSayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWhatPeopleSayModel collection)
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
                var data = new MasterWhatPeopleSay
                {
                    MasterWhatPeopleSayId = collection.MasterWhatPeopleSayId,
                    MasterWhatPeopleSayName = collection.MasterWhatPeopleSayName,
                    MasterWhatPeopleSayImageUrl = ImageFullName(collection),
                    MasterWhatPeopleSayText = collection.MasterWhatPeopleSayText
                };
                MasterWhatPeopleSay.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WhatPeopleSayController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterWhatPeopleSay.Find(id);
            MasterWhatPeopleSayModel obj = new MasterWhatPeopleSayModel
            {
                MasterWhatPeopleSayId = data.MasterWhatPeopleSayId,
                MasterWhatPeopleSayName = data.MasterWhatPeopleSayName,
                MasterWhatPeopleSayText = data.MasterWhatPeopleSayText,
                MasterWhatPeopleSayImageUrl = data.MasterWhatPeopleSayImageUrl
            };
            return View(obj);
        }

        // POST: WhatPeopleSayController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWhatPeopleSayModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var data = new MasterWhatPeopleSay
                {
                    MasterWhatPeopleSayId = collection.MasterWhatPeopleSayId,
                    MasterWhatPeopleSayName = collection.MasterWhatPeopleSayName,
                    MasterWhatPeopleSayImageUrl = ImageFullName(collection),
                    MasterWhatPeopleSayText = collection.MasterWhatPeopleSayText
                };
                MasterWhatPeopleSay.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WhatPeopleSayController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MasterWhatPeopleSay.Find(id));
        }

        // POST: WhatPeopleSayController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MasterWhatPeopleSay collection)
        {
            try
            {
                MasterWhatPeopleSay.Delete(id, collection);
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

            List<MasterWhatPeopleSay> data = MasterWhatPeopleSay.ViewAdmin().Where(x => string.IsNullOrWhiteSpace(strName) || (x.MasterWhatPeopleSayName ?? "").Contains(strName)).ToList();

            List<MasterWhatPeopleSay> newList = new List<MasterWhatPeopleSay>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterWhatPeopleSay obj = new MasterWhatPeopleSay
                {
                    MasterWhatPeopleSayId = data[i].MasterWhatPeopleSayId,
                    MasterWhatPeopleSayName = data[i].MasterWhatPeopleSayName,
                    MasterWhatPeopleSayImageUrl = data[i].MasterWhatPeopleSayImageUrl,
                    MasterWhatPeopleSayText = data[i].MasterWhatPeopleSayText
                };
                newList.Add(obj);
            }


            return View("Index", newList);
        }

        public string ImageFullName(MasterWhatPeopleSayModel collection)
        {
            if (collection.File == null)
            {
                return collection.MasterWhatPeopleSayImageUrl;
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
