using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmetSirketProje.Entities
{
    [Table("Calisanlar")]
    public class Calisanlar
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Ad Soyad"), Required(ErrorMessage = "Boş Bırakmayın")]
        public string AdSoyad { get; set; }
        [Display(Name = "Saatlik Ucret"), Required(ErrorMessage = "Boş Bırakmayın")]
        public decimal SaatlikUcret { get; set; }
        [Display(Name = "Kategori"), Required(ErrorMessage = "Boş Bırakmayın")]
        public int KategoriId { get; set; }
        public virtual List<Isler>? Isler { get; set; }

        [ForeignKey("KategoriId")]
        public virtual Kategoriler? Kategori { get; set; }
    }
}
