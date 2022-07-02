using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlisverisFurkanOzden.Entities
{
    [Table("KullaniciAdresleri")]
    public class KullaniciAdresleri
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş Bırakmayınız."),Display(Name ="Adres Bilgisi")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Boş Bırakmayınız."), Display(Name = "Adres Açıklama Bilgisi")]
        public string AdresAciklama { get; set; }
        [Display(Name = "Kullanıcı adı")]
        public int? KullaniciId { get; set; }
        public Kullanicilar? Kullanici { get; set; }

    }
}
