
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWebAspNETUdemy.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,1000,ErrorMessage = "Input Value between 1-1000")]
        public int DisplayOrder { get; set; }
    }
}
