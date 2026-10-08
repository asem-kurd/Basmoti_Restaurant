using Basmoti_Restaurant.Models;

namespace Basmoti_Restaurant.Areas.Admin.ViewModels
{
    public class MasterServiceModel : MasterService
    {
        public IFormFile? File { get; set; }
    }
}
