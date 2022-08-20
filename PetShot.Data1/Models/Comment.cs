using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Data.Models
{
    public class Comment
    {
        public Comment() => Animal = new Animal();
        [Key]
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        [StringLength(300)]
        public string Content { get; set; } = null!;

        [ForeignKey("AnimalId")]
        public virtual Animal Animal { get; set; }
    }
}
