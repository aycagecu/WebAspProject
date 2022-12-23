using AuthorizationProject.Data;
using AuthorizationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationProject.Controllers
{
    [Authorize(Roles ="user")]
    public class UserDetailsController : Controller
    {
       

    }
}
