#nullable disable
using App.Data;
using App.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class DriversController : Controller
{
    private readonly AppDbContext _context;

    public DriversController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Drivers
    public async Task<IActionResult> Index()
    {
        return View(await _context.Drivers.ToListAsync());
    }

    // GET: Drivers/Details/5
    public async Task<IActionResult> Details(uint? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var driver = await _context.Drivers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (driver == null)
        {
            return NotFound();
        }

        return View(driver);
    }

    // GET: Drivers/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Drivers/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,BirthDate,Email,Password")] Driver driver)
    {
        if (ModelState.IsValid)
        {
            _context.Add(driver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(driver);
    }

    // GET: Drivers/Edit/5
    public async Task<IActionResult> Edit(uint? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null)
        {
            return NotFound();
        }
        return View(driver);
    }

    // POST: Drivers/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(uint id, [Bind("Id,FirstName,LastName,BirthDate,Email,Password")] Driver driver)
    {
        if (id != driver.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(driver);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(driver.Id))
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
        return View(driver);
    }

    // GET: Drivers/Delete/5
    public async Task<IActionResult> Delete(uint? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var driver = await _context.Drivers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (driver == null)
        {
            return NotFound();
        }

        return View(driver);
    }

    // POST: Drivers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(uint id)
    {
        var driver = await _context.Drivers.FindAsync(id);
        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DriverExists(uint id)
    {
        return _context.Drivers.Any(e => e.Id == id);
    }
}
