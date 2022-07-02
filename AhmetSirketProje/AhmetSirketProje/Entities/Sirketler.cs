using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmetSirketProje.Entities
{
    [Table("Sirketler")]
    public class Sirketler
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Şirket Adı"), Required(ErrorMessage = "Boş Bırakmayın")]
        public string SirketAdi { get; set; }
        [Display(Name = "Logo"), Required(ErrorMessage = "Boş Bırakmayın")]
        public string Logo { get; set; }

        public virtual List<Isler>? Isler { get; set; }
    }
}
