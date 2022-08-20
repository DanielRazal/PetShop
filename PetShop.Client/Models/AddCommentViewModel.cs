using PetShop.Data.Models;

namespace PetShop.Client.Models
{
    public class AddCommentViewModel
    {
        public Comment? Comment { get; set; }

        public Animal? Animal { get; set; }

        public IEnumerable<Comment>? Comments { get; set; }
    }
}
