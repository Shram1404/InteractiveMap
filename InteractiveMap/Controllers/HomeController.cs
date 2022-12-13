using InteractiveMap.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using InteractiveMap.Data;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Controllers
{
    public class HomeController : Controller
    {
        private readonly InteractiveMapContext _db;

        public HomeController(InteractiveMapContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (_db.Audience == null)
                return Problem("Entity set InteractiveMapContext.Audience is null.");

            var audienc = from m in _db.Audience
                         select m;

            if (!String.IsNullOrEmpty(searchString))
                audienc = audienc.Where(s => s.aud!.Equals(searchString));
            else
                audienc = audienc.Where(s => s.aud!.Equals("99999")); ;

            return View(await audienc.ToListAsync());
        }
    }
}


