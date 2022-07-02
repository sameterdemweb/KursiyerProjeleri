using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamzeArici.Entities
{
    [Table("Raflar")]
    public class Raflar
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Raf Adı")]
        public string RafAdi { get; set; }

        public virtual List<Kitaplar> Kitaplar { get; set; }
    }
}
