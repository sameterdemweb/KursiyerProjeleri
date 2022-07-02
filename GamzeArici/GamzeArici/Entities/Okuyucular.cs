using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamzeArici.Entities
{
    [Table("Okuyucular")]
    public class Okuyucular
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Adınız Soyadınız")]
        public string AdiSoyadi { get; set; }
        [Display(Name = "Adresiniz")]
        public string Adres { get; set; }

        public virtual List<Islemler> Islemler{ get; set; }
    }
}
