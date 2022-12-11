using System.ComponentModel.DataAnnotations;

namespace RentME.Models
{
    public class User
    {
        public int userId { get; set; }
        [Required]
        //[Display("First")]
        public string firstName { get; set; }
        public string lastName { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [RegularExpression(@"^\\+?[1-9][0-9]{10}$")]
        public long? mobileNo { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string accessMode { get; set; }
    }
}
