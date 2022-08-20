using System.ComponentModel.DataAnnotations;

namespace PetShop.Data.Models
{
    public class Category
    {
        public Category() => Animals = new HashSet<Animal>();

        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        [Display(Name = "Category")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
