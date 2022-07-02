using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlisverisFurkanOzden.Entities
{
    [Table("Kullanicilar")]
    public class Kullanicilar
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş Bırakmayınız."),Display(Name ="Adı Soyadı"),StringLength(50)]
        public string AdiSoyadi { get; set; }
        [Required(ErrorMessage = "Boş Bırakmayınız."), Display(Name = "Yaş")]
        public int Yas { get; set; }
        [Required(ErrorMessage = "Boş Bırakmayınız."), Display(Name = "Telefon Numarası"),DataType(DataType.PhoneNumber)]
        public string TelefonNumarasi { get; set; }
        [Required(ErrorMessage = "Boş Bırakmayınız."), Display(Name = "Mail"),DataType(DataType.EmailAddress,ErrorMessage ="Geçerli Bir Mail adresi giriniz.")]
        public string Mail { get; set; }
        public virtual List<KullaniciAdresleri>? KullaniciAdresleri { get; set; }
        public virtual List<Siparisler>? Siparisler { get; set; }
       

    }
}
