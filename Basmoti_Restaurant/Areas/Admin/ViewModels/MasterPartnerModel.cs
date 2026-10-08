using Basmoti_Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Areas.Admin.ViewModels
{
    public class MasterPartnerModel : MasterPartner
    {
        //[Required(ErrorMessage = "File is Required")]
        [Display(Name = "File")]
        public IFormFile? File { get; set; }
    }
}
