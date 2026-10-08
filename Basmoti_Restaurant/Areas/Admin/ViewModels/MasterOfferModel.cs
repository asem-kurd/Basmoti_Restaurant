using Basmoti_Restaurant.Models;

namespace Basmoti_Restaurant.Areas.Admin.ViewModels
{
    public class MasterOfferModel : MasterOffer
    {
        public IFormFile? File { get; set; }
    }
}
