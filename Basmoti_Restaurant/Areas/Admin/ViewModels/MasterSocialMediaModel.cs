using Basmoti_Restaurant.Models;

namespace Basmoti_Restaurant.Areas.Admin.ViewModels
{
    public class MasterSocialMediaModel: MasterSocialMedia
    {
        public IFormFile? File { get; set; }
    }
}
