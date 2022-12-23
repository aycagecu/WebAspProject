using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorizationProject.Models
{
    public class Basvuru
    {
        public int BasvuruId { get; set; }
        public DateTime BasvuruTarihi { get; set; }    
        public Hayvan BasvurulanHayvan { get; set; }
        public string BasvuruDurumu { get; set; }
        public UserDetails BasvuranUser { get; set; }
        public string BasvuruFormu { get; set; }

        [ForeignKey("UserDetails")]
        public string UserName { get; set; }
        [ForeignKey("Hayvan")]
        public int HayvanID { get; set; }
    }
}
