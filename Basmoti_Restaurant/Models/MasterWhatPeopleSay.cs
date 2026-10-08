using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models
{
    [Area("Admin")]
    public class MasterWhatPeopleSay : BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        public int MasterWhatPeopleSayId { get; set; }

        [Display(Name = "Name")]
        public string MasterWhatPeopleSayName { get; set; } = null!;

        [Display(Name = "Text")]
        public string MasterWhatPeopleSayText { get; set; } = null!;

        [Display(Name = "Image")]
        public string? MasterWhatPeopleSayImageUrl { get; set; }
    }
}
