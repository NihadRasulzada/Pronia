using System.ComponentModel;

namespace Pronia.MVC.Models.Commons
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
