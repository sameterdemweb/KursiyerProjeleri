using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlisverisFurkanOzden.Entities
{
    [Table("Siparisler")]
    public class Siparisler
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Boş Bırakmayınız.")]
        public int KullaniciId { get; set; }
        [Required(ErrorMessage = "Boş Bırakmayınız.")]
        public int UrunId { get; set; }
        [Required(ErrorMessage = "Boş Bırakmayınız."),Display(Name ="Sipariş Tarihiniz"),DataType(DataType.DateTime)]
        public DateTime SiparisTarihi { get; set; }
        public virtual Kullanicilar? Kullanici { get; set; }
        public virtual Urunler? Urun { get; set; }
    }
}
