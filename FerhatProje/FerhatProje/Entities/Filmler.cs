using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerhatProje.Entities
{
    [Table("Filmler")]
    public class Filmler
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SalonId { get; set; }
        [Display(Name ="Film Adı")]
        [StringLength(250)]
        [Required]
        public string FilmAdi { get; set; }
        [Display(Name = "Film Konusu")]
        public string FilmKonusu { get; set; }
        [Display(Name = "Film Yönetmeni")]
        public string Yonetmeni { get; set; }
        [ForeignKey("SalonId")]
        public virtual Salonlar Salon { get; set; }

    }
}
