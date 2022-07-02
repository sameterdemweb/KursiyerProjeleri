using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerhatProje.Entities
{
    [Table("Salonlar")]
    public class Salonlar
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name ="Salon Adı")]
        public string SalonAdi { get; set; }
        public virtual List<Filmler> Filmler { get; set; }
    }
}
