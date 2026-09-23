namespace Restaurant.Models
{
    public class BaseEntity
    {
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public string CreateId { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateId { get; set; }
        public DateTime UpdateDate { get; set; }

    }



    public class BaseEntityTransaction
    {
        public string CreateId { get; set; }
        public DateTime CreateDate { get; set; }

    }

}
