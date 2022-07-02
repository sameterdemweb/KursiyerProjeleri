using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamzeArici.Entities
{
    [Table("Islemler")]
    public class Islemler
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Kitap Seçiniz")]
        public int KitapId { get; set; }
        [Required]
        [Display(Name = "Okuyucu Seçiniz")]
        public int OkuyucuId { get; set; }
        [Display(Name = "Kitap Alınan Tarih"), Required]
       
        public DateTime AlmaTarihi { get; set; }
        [Display(Name = "Kitap Geri Verilen Tarih")]
        public DateTime IadeTarihi { get; set; }
        [ForeignKey("KitapId")]
        public virtual Kitaplar Kitap { get; set; }
        [ForeignKey("OkuyucuId")]
        public virtual Okuyucular Okuyucu { get; set; }
    }
}
