using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MehmetUzunOkulProje.Entities
{
    [Table("Sinif")]
    public class Sinif
    {
     
        [Key]
        public int Id { get; set; }
    
        [Display(Name = "Sınıf Adı"), Required(ErrorMessage = "Lütfen Sınıf Adını Boş Bırakmayınız.")]
        public string SinifAdi { get; set; }
        [Display(Name = "Bölüm Bilgisi"), Required(ErrorMessage ="Lütfen Bölüm Alanını Boş Bırakmayınız.")]
        public int BolumId { get; set; }
        [ForeignKey("BolumId")]
        public virtual Bolum? Bolum { get; set; }
        public List<Ogrenci>? Ogrenciler { get; set; }
    }
}
