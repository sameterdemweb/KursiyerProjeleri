using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MehmetUzunOkulProje.Entities
{
    [Table("Bolum")]
    public class Bolum
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen Bölüm Adını Boş Bırakmayınız."), StringLength(50), Display(Name ="Bölüm Adı")]
        public string BolumAdi { get; set; }

        public virtual List<Sinif>? Siniflar { get; set; }
    }
}
