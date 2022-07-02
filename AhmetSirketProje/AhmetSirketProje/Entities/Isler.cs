using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmetSirketProje.Entities
{
    [Table("Isler")]
    public class Isler
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Adı"),Required(ErrorMessage ="Boş Bırakmayın")]
        public string Adi { get; set; }
        [Display(Name="Toplam İş Saati"),Required(ErrorMessage = "Boş Bırakmayın")]
        public int Saat { get; set; }
        [Display(Name="Şirket Adı"),Required(ErrorMessage = "Boş Bırakmayın")]
        public int SirketId { get; set; }

        [Display(Name = "Çalışan")]
        public int? CalisanId { get; set; }
        [Display(Name="Açıklama"),Required(ErrorMessage = "Boş Bırakmayın")]
        public string Aciklama { get; set; }
        [Display(Name="Kategori"),Required(ErrorMessage = "Boş Bırakmayın")]
        public int KategoriId { get; set; }
        [ForeignKey("SirketId")]
        public virtual Sirketler? Sirket { get; set; }
        [ForeignKey("KategoriId")]
        public virtual Kategoriler? Kategori { get; set; }
        [ForeignKey("CalisanId")]
        public virtual Calisanlar? Calisan { get; set; }
    }
}
