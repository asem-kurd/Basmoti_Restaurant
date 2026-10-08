using Basmoti_Restaurant.Models;
using Basmoti_Restaurant.Models.Repositories;

namespace Basmoti_Restaurant.Areas.Admin.ViewModels
{
    public class MasterItemMenuModel : MasterItemMenu
    {
        public IFormFile? File { get; set; }
    }
}
