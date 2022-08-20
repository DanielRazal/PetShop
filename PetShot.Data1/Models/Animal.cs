using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Data.Models
{
    public class Animal
    {
        public Animal() => Comments = new HashSet<Comment>();

        [Key]
        public int AnimalId { get; set; }
        [StringLength(30)]
        public string Name { get; set; } = null!;
        [DataType(DataType.Date)] // MM/dd/yyyy without time
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [StringLength(300)]
        public string? Description { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [StringLength(300)]
        [Display(Name = "Portrait")]
        public string PhotoUrl { get; set; } = null!;

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
