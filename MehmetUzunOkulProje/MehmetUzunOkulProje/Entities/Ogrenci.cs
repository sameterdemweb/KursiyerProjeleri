using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MehmetUzunOkulProje.Entities
{
    [Table("Ogrenci")]
    public class Ogrenci
    {
    
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Öğrenci Adı Boş bırakılamaz."), Display(Name = "Öğrenci Adı"), StringLength(50)]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Öğrenci Soyadı Boş bırakılamaz."), Display(Name = "Öğrenci Soyadı"), StringLength(50)]
        public string Soyadi { get; set; }
        [StringLength(11), Display(Name ="Telefon Numarası")]
        public string? Telefon { get; set; }

        [Required(ErrorMessage = "Sınıf Seçimi Boş bırakılamaz."), Display(Name = "Sınıf Bilgisi")]
        public int SinifId  { get; set; }
        [ForeignKey("SinifId")]
        public virtual Sinif? Sinif { get; set; }
    }
}
