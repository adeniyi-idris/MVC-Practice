using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }

        public int  DisplayOrder { get; set; }

        public DateTime? CreatedDateTime { get; set; } = default(DateTime?);

    }
}
