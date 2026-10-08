using Basmoti_Restaurant.Areas.Admin.ViewModels;
using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {

        public IRepository<MasterSlider> MasterSlider { get; }
        public IHostingEnvironment Host { get; }

        public SliderController(IRepository<MasterSlider> _MasterSlider, IHostingEnvironment _Host)
        {
            MasterSlider = _MasterSlider;
            Host = _Host;
        }


        // GET: SliderController
        public ActionResult Index(int DeleteId, int? toggleId)
        {
            MasterSlider masterSlider = new MasterSlider();

            if (DeleteId != 0)
            {
                MasterSlider.Delete(DeleteId, masterSlider);
                return RedirectToAction(nameof(Index));
            }


            if (toggleId.HasValue)
            {
                MasterSlider.Active(toggleId.Value);
            }


            return View(MasterSlider.ViewAdmin());
        }

        // GET: SliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSliderModel collection)
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
                var data = new MasterSlider
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderImageUrl = ImageFullName(collection),
                };
                MasterSlider.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSlider.Find(id);
            MasterSliderModel obj = new MasterSliderModel
            {
                MasterSliderId = data.MasterSliderId,
                MasterSliderTitle = data.MasterSliderTitle,
                MasterSliderBreef = data.MasterSliderBreef,
                MasterSliderDesc = data.MasterSliderDesc,
                MasterSliderImageUrl = data.MasterSliderImageUrl,
            };
            return View(obj);
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSliderModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var data = new MasterSlider
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderImageUrl = ImageFullName(collection),
                };
                MasterSlider.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MasterSlider.Find(id));
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MasterSlider collection)
        {
            try
            {
                MasterSlider.Delete(id, collection);
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

            List<MasterSlider> data = MasterSlider.ViewAdmin().Where(x => string.IsNullOrWhiteSpace(strName) || (x.MasterSliderTitle ?? "").Contains(strName)).ToList();

            List<MasterSlider> newList = new List<MasterSlider>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterSlider obj = new MasterSlider
                {
                    MasterSliderId = data[i].MasterSliderId,
                    MasterSliderTitle = data[i].MasterSliderTitle,
                    MasterSliderBreef = data[i].MasterSliderBreef,
                    MasterSliderDesc = data[i].MasterSliderDesc,
                    MasterSliderImageUrl = data[i].MasterSliderImageUrl,

                };
                newList.Add(obj);
            }


            return View("Index", newList);
        }
        public string ImageFullName(MasterSliderModel collection)
        {
            if (collection.File == null)
            {
                return collection.MasterSliderImageUrl;
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
