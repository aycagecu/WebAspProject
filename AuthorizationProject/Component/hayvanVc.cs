using AuthorizationProject.Data;
using AuthorizationProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationProject.Component
{
    public class hayvanVc:ViewComponent
    {
        ApplicationDbContext dbContext;

        public hayvanVc(ApplicationDbContext _dbContext)
        {
            dbContext= _dbContext;
        }

        public IViewComponentResult Invoke(Hayvan h)
        {
            return View(h);
        }
    }
}
