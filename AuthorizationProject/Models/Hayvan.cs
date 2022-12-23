using System.ComponentModel.DataAnnotations;

namespace AuthorizationProject.Models
{
    public class Hayvan
    {
        public int HayvanId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Hayvan kategorisi girilmek zorundadır")]
        public string HayvanKategori { get; set; }
       
        [Range(0, 100, ErrorMessage = "Hayvan yaşı 0-100 arası olmalıdır")]
        public int HayvanYas { get; set; }
        public string HayvanIrk { get; set; }
        public string HayvanCinsiyet { get; set; }
        public string HayvanSehir { get; set; }
        public string HayvanResim { get; set; }
    }
}
