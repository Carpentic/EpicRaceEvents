#nullable disable
using App.Data;
using App.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class VehiculesController : Controller
{
    private readonly AppDbContext _context;

    public VehiculesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Vehicules
    public async Task<IActionResult> Index()
    {
        return View(await _context.Vehicules.ToListAsync());
    }

    // GET: Vehicules/Details/5
    public async Task<IActionResult> Details(uint? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehicule = await _context.Vehicules
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vehicule == null)
        {
            return NotFound();
        }

        return View(vehicule);
    }

    // GET: Vehicules/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Vehicules/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Vehicule vehicule)
    {
        if (ModelState.IsValid)
        {
            _context.Add(vehicule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(vehicule);
    }

    // GET: Vehicules/Edit/5
    public async Task<IActionResult> Edit(uint? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehicule = await _context.Vehicules.FindAsync(id);
        if (vehicule == null)
        {
            return NotFound();
        }
        return View(vehicule);
    }

    // POST: Vehicules/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(uint id, Vehicule vehicule)
    {
        if (id != vehicule.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(vehicule);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculeExists(vehicule.Id))
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
        return View(vehicule);
    }

    // GET: Vehicules/Delete/5
    public async Task<IActionResult> Delete(uint? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehicule = await _context.Vehicules
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vehicule == null)
        {
            return NotFound();
        }

        return View(vehicule);
    }

    // POST: Vehicules/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(uint id)
    {
        var vehicule = await _context.Vehicules.FindAsync(id);
        _context.Vehicules.Remove(vehicule);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool VehiculeExists(uint id)
    {
        return _context.Vehicules.Any(e => e.Id == id);
    }
}
