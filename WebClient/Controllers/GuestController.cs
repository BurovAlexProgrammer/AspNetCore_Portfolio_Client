using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class GuestController : Controller
    {
        // private readonly WebClientContext _context;
        //
        // public GuestController(WebClientContext context)
        // {
        //     _context = context;
        // }
        //
        //
        // // GET: Guest/Details/5
        // public async Task<IActionResult> Details(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var guest = await _context.Guest
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (guest == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return View(guest);
        // }
        //
        // // GET: Guest/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }
        //
        // // POST: Guest/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Name,Password")] Guest guest)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(guest);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(guest);
        // }
        //
        // // GET: Guest/Edit/5
        // public async Task<IActionResult> Edit(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var guest = await _context.Guest.FindAsync(id);
        //     if (guest == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(guest);
        // }
        //
        // // POST: Guest/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Password")] Guest guest)
        // {
        //     if (id != guest.Id)
        //     {
        //         return NotFound();
        //     }
        //
        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(guest);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!GuestExists(guest.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(guest);
        // }
        //
        // // GET: Guest/Delete/5
        // public async Task<IActionResult> Delete(long? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var guest = await _context.Guest
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (guest == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return View(guest);
        // }
        //
        // // POST: Guest/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(long id)
        // {
        //     var guest = await _context.Guest.FindAsync(id);
        //     _context.Guest.Remove(guest);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }
        
        // private bool GuestExists(long id)
        // {
        //     return _context.Guest.Any(e => e.Id == id);
        // }
    }
}
