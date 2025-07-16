using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Threading.Tasks;
using System.Linq;




namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        


        

        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
            
        }
        
        public async Task<IActionResult> Index(string SearchString)
        {
            //string SearchString = "i";
            ViewData["CurrentFilter"] = SearchString;

            var users = from u in db.contacts
                        select u;

            if (!string.IsNullOrEmpty(SearchString))
            {
                users = users.Where(s => s.Name.Contains(SearchString) || s.Mail.Contains(SearchString) || s.Number.Contains(SearchString) || s.Addres.Contains(SearchString));
            }
            return View(await users.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Contacts human)
        {
            db.contacts.Add(human);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]

        
        

        public async Task<IActionResult> Delete(int? id)
        {
            if (id!=null)
            {
                Contacts? human = await db.contacts.FirstOrDefaultAsync(p => p.Id == id);
                if (human !=null)
                {
                    db.contacts.Remove(human);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id !=null)
            {
                Contacts? human = await db.contacts.FirstOrDefaultAsync(p => p.Id == id);
                if (human != null) return View(human);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Contacts human)
        {
            db.contacts.Update(human);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
