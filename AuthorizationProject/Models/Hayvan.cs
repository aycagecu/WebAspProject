using System.ComponentModel.DataAnnotations;

namespace AuthorizationProject.Models
{
    public class Hayvan
    {
        public int HayvanId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Hayvan kategorisi girilmek zorundadır")]

        [Display(Name ="Hayvanın Kategorisi")]
        public string HayvanKategori { get; set; }
       
        [Range(0, 100, ErrorMessage = "Hayvan yaşı 0-100 arası olmalıdır")]
        [Display(Name = "Hayvanın Yaşı")]
        public int HayvanYas { get; set; }
        [Display(Name = "Hayvanın Irkı")]
        public string HayvanIrk { get; set; }
        [Display(Name = "Hayvanın Cinsiyeti")]
        public string HayvanCinsiyet { get; set; }
        [Display(Name = "Hayvanın Bulunduğu Şehir")]
        public string HayvanSehir { get; set; }
        [Display(Name = "Hayvanın Resmi")]
        public string HayvanResim { get; set; }

    }
}
