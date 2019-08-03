using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StataHelper.Model.Context;
using System.Threading.Tasks;

namespace StataHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContextOptions<AppDbContext> context;

        public HomeController(DbContextOptions<AppDbContext> options) => context = options;

        public async Task<IActionResult> Index()
        {
            await new AppDbContext(context).Database.EnsureCreatedAsync();
            return View();
        }
    }
}