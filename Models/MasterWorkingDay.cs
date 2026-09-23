using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterWorkingDay : BaseEntity
    {
        [Key]
        public int MasterWorkingDayId { get; set; }

        public DayOfWeek MasterWorkingDayName { get; set; }


        //join
        public int MasterWorkingHoursId { get; set; }
        public MasterWorkingHours MasterWorkingHour { get; set; } = null!;


    }
}
