using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmetSirketProje.Entities
{
    [Table("Kategoriler")]
    public class Kategoriler
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Kategori Adı"), Required(ErrorMessage = "Boş Bırakmayın")]
        public string KategoriAdi { get; set; }
        public virtual List<Isler>? Isler { get; set; }
        public virtual List<Calisanlar>? Calisanlar { get; set; }
    }
}
