namespace RentME.Models
{
    public class Rented
    {
        public int rentID { get; set; }
        public int typeID { get; set; }
        public string RentedBy { get; set; }
        public string RentedFrom { get; set; }
        public string rentedDate { get; set; }
    }
}
