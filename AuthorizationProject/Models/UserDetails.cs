using Microsoft.AspNetCore.Identity;

namespace AuthorizationProject.Models
{
    public class UserDetails:IdentityUser
    {
        public string UserAd { get; set; }  
        public string UserSoyad { get; set; }   
        public ICollection<Basvuru> UserBasvurular { get; set; }  
    }
}
