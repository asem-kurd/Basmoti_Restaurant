namespace Restaurant.Models
{
    public class BaseEntity
    {
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public int CreateId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateId { get; set; }
        public DateTime UpdateDate { get; set; }

    }



    public class BaseEntityTransaction
    {
        public int CreateId { get; set; }
        public DateTime CreateDate { get; set; }

    }

}
