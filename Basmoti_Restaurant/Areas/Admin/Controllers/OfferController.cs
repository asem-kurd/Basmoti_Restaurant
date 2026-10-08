using Basmoti_Restaurant.Areas.Admin.ViewModels;
using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferController : Controller
    {
        public IRepository<MasterOffer> MasterOffer { get; }
        public IHostingEnvironment Host { get; }

        public OfferController(IRepository<MasterOffer> _MasterOffer, IHostingEnvironment _Host)
        {
            MasterOffer = _MasterOffer;
            Host = _Host;
        }



        // GET: OfferController
        public ActionResult Index(int DeleteId, int? toggleId)
        {
            MasterOffer masterOffer = new MasterOffer();

            if (DeleteId != 0)
            {
                MasterOffer.Delete(DeleteId, masterOffer);
                return RedirectToAction(nameof(Index));
            }


            if (toggleId.HasValue)
            {
                MasterOffer.Active(toggleId.Value);
            }


            return View(MasterOffer.ViewAdmin());
        }

        // GET: OfferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferModel collection)
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
                var data = new MasterOffer
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferImageUrl = ImageFullName(collection)
                };
                MasterOffer.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OfferController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterOffer.Find(id);
            MasterOfferModel obj = new MasterOfferModel
            {
                MasterOfferId = data.MasterOfferId,
                MasterOfferTitle = data.MasterOfferTitle,
                MasterOfferBreef = data.MasterOfferBreef,
                MasterOfferDesc = data.MasterOfferDesc,
                MasterOfferImageUrl = data.MasterOfferImageUrl
            };
            return View(obj);
        }

        // POST: OfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var data = new MasterOffer 
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferImageUrl = ImageFullName(collection)
                };
                MasterOffer.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OfferController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MasterOffer.Find(id));
        }

        // POST: OfferController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MasterOffer collection)
        {
            try
            {
                MasterOffer.Delete(id, collection);
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

            List<MasterOffer> data = MasterOffer.ViewAdmin().Where(x => string.IsNullOrWhiteSpace(strName) || (x.MasterOfferTitle ?? "").Contains(strName)).ToList();

            List<MasterOffer> newList = new List<MasterOffer>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterOffer obj = new MasterOffer
                {
                    MasterOfferId = data[i].MasterOfferId,
                    MasterOfferTitle = data[i].MasterOfferTitle,
                    MasterOfferBreef = data[i].MasterOfferBreef,
                    MasterOfferDesc = data[i].MasterOfferDesc,

                };
                newList.Add(obj);

            }


            return View("Index", newList);
        }




        public string ImageFullName(MasterOfferModel collection)
        {
            if (collection.File == null)
            {
                return collection.MasterOfferImageUrl;
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
