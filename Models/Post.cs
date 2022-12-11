using System.ComponentModel.DataAnnotations;

namespace RentME.Models
{
    public class Post
    {
        public int postID { get; set; }
        public string imageURL { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        [MaxLength(100)]
        public string description { get; set; }
        public string postType { get;set; }
        public DateTime addedDate { get; set; }
        public int addedBy { get; set; }
        public int typeid { get; set; }
    }
}
