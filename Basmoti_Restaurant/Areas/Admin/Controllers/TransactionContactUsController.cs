using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionContactUsController : Controller
    {
        public ITransactionRepository<TransactionContactUs> TransactionContactUs { get; }

        public TransactionContactUsController(ITransactionRepository<TransactionContactUs> _TransactionContactUs)
        {
            TransactionContactUs = _TransactionContactUs;
        }

        // GET: TransactionContactUsController
        public ActionResult Index(int DeleteId)
        {
            TransactionContactUs transactionContactUs = new TransactionContactUs();

            if (DeleteId != 0)
            {
                TransactionContactUs.Delete(DeleteId, transactionContactUs);
                return RedirectToAction(nameof(Index));
            }
            return View(TransactionContactUs.ViewAdmin());
        }
    }
}
