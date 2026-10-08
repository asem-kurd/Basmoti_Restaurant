using Basmoti_Restaurant.Models;

namespace Basmoti_Restaurant.Areas.Admin.ViewModels
{
    public class MasterWhatPeopleSayModel : MasterWhatPeopleSay
    {
        public IFormFile? File { get; set; }
    }
}
