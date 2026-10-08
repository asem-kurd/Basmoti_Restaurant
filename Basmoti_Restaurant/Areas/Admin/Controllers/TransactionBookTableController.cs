using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basmoti_Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionBookTableController : Controller
    {


        public ITransactionRepository<TransactionBookTable> TransactionBookTable { get; }

        public TransactionBookTableController(ITransactionRepository<TransactionBookTable> _TransactionBookTable)
        {
            TransactionBookTable = _TransactionBookTable;
        }


        // GET: TransactionBookTableController
        public ActionResult Index(int DeleteId)
        {
            TransactionBookTable transactionBookTable = new TransactionBookTable();

            if (DeleteId != 0)
            {
                TransactionBookTable.Delete(DeleteId, transactionBookTable);
                return RedirectToAction(nameof(Index));
            }
            return View(TransactionBookTable.ViewAdmin());
        }
    }
}
