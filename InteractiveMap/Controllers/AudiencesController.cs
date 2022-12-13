using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InteractiveMap.Data;
using InteractiveMap.Models;

namespace InteractiveMap.Controllers
{
    public class AudiencesController : Controller
    {
        private readonly InteractiveMapContext _context;

        public AudiencesController(InteractiveMapContext context)
        {
            _context = context;
        }

        // GET: Audiences
        public async Task<IActionResult> Index(string aud)
        {
            if (_context.Audience == null)
            {
                return Problem("Entity set 'InteractiveMapContext.Audience'  is null.");
            }

            var audience = from m in _context.Audience
                         select m;

            if (!String.IsNullOrEmpty(aud))
            {
                audience = audience.Where(s => s.SvgCode!.Contains(aud));
            }

            return View(await audience.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Audience == null)
            {
                return NotFound();
            }

            var audience = await _context.Audience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audience == null)
            {
                return NotFound();
            }

            return View(audience);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SvgCode,aud,imgWay,imgSvg")] Audience audience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(audience);
        }

  
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Audience == null)
            {
                return NotFound();
            }

            var audience = await _context.Audience.FindAsync(id);
            if (audience == null)
            {
                return NotFound();
            }
            return View(audience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SvgCode,aud,imgWay, imgSvg")] Audience audience)
        {
            if (id != audience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AudienceExists(audience.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(audience);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Audience == null)
            {
                return NotFound();
            }

            var audience = await _context.Audience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audience == null)
            {
                return NotFound();
            }

            return View(audience);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Audience == null)
            {
                return Problem("Entity set 'InteractiveMapContext.Audience'  is null.");
            }
            var audience = await _context.Audience.FindAsync(id);
            if (audience != null)
            {
                _context.Audience.Remove(audience);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AudienceExists(int id)
        {
          return (_context.Audience?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
