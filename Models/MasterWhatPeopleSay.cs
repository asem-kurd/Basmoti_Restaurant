using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterWhatPeopleSay : BaseEntity
    {
        [Key]
        public int MasterWhatPeopleSayId { get; set; }
        public string MasterWhatPeopleSayName { get; set; } = null!;
        public string MasterWhatPeopleSayText { get; set; } = null!;
        public string MasterWhatPeopleSayImageUrl { get; set; } = null!;
    }
}
