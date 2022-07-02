using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlisverisFurkanOzden.Entities
{
    [Table("Urunler")]
    public class Urunler
       
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş Bırakmayınız."), Display(Name = "Ürün Adı")]
        public string UrunAdi { get; set; }
        [Required(ErrorMessage = "Boş Bırakmayınız."), Display(Name = "Ürün Fiyatı"),DataType(DataType.Currency)]
        public decimal Fiyat { get; set; }
        public virtual List<Siparisler>? Siparisler { get; set; }
    }
}
