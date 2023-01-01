using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationProject.Models
{
    public class Hayvan
    {
        public int HayvanId { get; set; }



        [Required(ErrorMessage = "Hayvan kategorisi girilmek zorundadır")]
        [Display(Name ="Hayvanın Kategorisi")]
        public string HayvanKategori { get; set; }


        [Required(ErrorMessage = "Hayvan yaşı girilmek zorundadır")]
        [Range(0, 100, ErrorMessage = "Hayvan yaşı 0-100 arası olmalıdır")]
        [Display(Name = "Hayvanın Yaşı")]
        public int HayvanYas { get; set; }


        [Required(ErrorMessage ="Hayvan Irkı girilmesi zorunludur")]
        [Display(Name = "Hayvanın Irkı")]
        public string HayvanIrk { get; set; }


        [Required(ErrorMessage = "Hayvan Cinsiyeti girilmesi zorunludur")]
        [Display(Name = "Hayvanın Cinsiyeti")]
        public string HayvanCinsiyet { get; set; }


        [Required(ErrorMessage = "Hayvan bulunduğu şehirin girilmesi zorunludur")]
        [Display(Name = "Hayvanın Bulunduğu Şehir")]
        public string HayvanSehir { get; set; }


        [Required(ErrorMessage = "Hayvan resmi girilmek zorundadır")]
        [Display(Name = "Hayvanın Resmi")]
        public string HayvanResim { get; set; }

    }
}
