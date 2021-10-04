using System.ComponentModel.DataAnnotations;

namespace SpiceLandPOCOs
{
    public class Spice : BaseModel
    {
        [Key, Required]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }


        [Required]
        public string PurchaseDate { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        public string LastUsedDate { get; set; }
    }
}