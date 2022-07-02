using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamzeArici.Entities
{
    [Table("Kitaplar")]
    public class Kitaplar
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Kitap Adı")]
        public string KitapAdi { get; set; }

        public int RafId { get; set; }

        [ForeignKey("RafId")]
        public virtual Raflar raf { get; set; }

        public virtual List<Islemler> Islemler { get; set; }
    }
}
