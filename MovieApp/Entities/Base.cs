using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Entities
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? Createdby { get; set; }
        public Guid? Updatedby { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
