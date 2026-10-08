using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class TransactionNewsletterController : Controller
    {
        public ITransactionRepository<TransactionNewsletter> TransactionNewsletter { get; }

        public TransactionNewsletterController(ITransactionRepository<TransactionNewsletter> _TransactionNewsletter)
        {
            TransactionNewsletter = _TransactionNewsletter;
        }

        // GET: TransactionNewsletterController
        public ActionResult Index(int DeleteId)
        {
            TransactionNewsletter transactionNewsletter = new TransactionNewsletter();

            if (DeleteId != 0)
            {
                TransactionNewsletter.Delete(DeleteId, transactionNewsletter);
                return RedirectToAction(nameof(Index));
            }
            return View(TransactionNewsletter.ViewAdmin());
        }
    }
}
