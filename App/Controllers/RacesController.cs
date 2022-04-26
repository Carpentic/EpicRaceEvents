#nullable disable

using App.Data;
using App.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class RacesController : Controller
{
    private readonly IRepository _repository;

    public RacesController(IRepository repo)
    {
        _repository = repo;
    }

    // GET: Races
    public async Task<IActionResult> Index()
    {
        return View(await _repository.GetAll<Race>().ToListAsync());
    }

    // GET: Races/Details/5
    public IActionResult Details(uint? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var race = _repository.GetBy<Race>(m => m.Id == id).FirstOrDefault();
        if (race == null)
        {
            return NotFound();
        }

        return View(race);
    }

    // GET: Races/Create
    public IActionResult Create()
    {
        return View(new Models.ViewModels.Races.Model(_repository));
    }

    // POST: Races/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Race race, List<uint> selectedCategories)
    {
        race.AllowedCategories = new List<Vehicule.AvailableCategory>(selectedCategories.Count);
        foreach (var id in selectedCategories)
            race.AllowedCategories.Add(_repository.GetBy<Vehicule.AvailableCategory>(cat => cat.Id == id).ToList().FirstOrDefault());

        ModelState.ClearValidationState(nameof(Race));
        TryValidateModel(race, nameof(Race));

        if (ModelState.IsValid)
        {
            _repository.Add(race);
            await _repository.UpdateAsync<Race>();
            return RedirectToAction(nameof(Index));
        }
        return View(new Models.ViewModels.Races.Model(_repository, race));
    }

    // GET: Races/Edit/5
    public IActionResult Edit(uint? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Models.ViewModels.Races.Model race = new Models.ViewModels.Races.Model(_repository, _repository.GetBy<Race>(race => race.Id == id).FirstOrDefault());
        if (race == null)
        {
            return NotFound();
        }
        return View(race);
    }

    // POST: Races/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(uint id, Race race, List<int> selectedCategories)
    {
        if (id != race.Id)
        {
            return NotFound();
        }

        race.AllowedCategories = new List<Vehicule.AvailableCategory>(selectedCategories.Count);
        foreach (var categoryId in selectedCategories)
            race.AllowedCategories.Add(_repository.GetBy<Vehicule.AvailableCategory>(cat => cat.Id == categoryId).ToList().FirstOrDefault());

        ModelState.ClearValidationState(nameof(Race));
        TryValidateModel(race, nameof(Race));

        if (ModelState.IsValid)
        {
            try
            {
                _repository.Edit(race);
                await _repository.UpdateAsync<Race>();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(race.Id))
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
        return View(race);
    }

    // GET: Races/Delete/5
    public async Task<IActionResult> Delete(uint? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var race = await _repository.GetBy<Race>(race => race.Id == id).FirstOrDefaultAsync();
        if (race == null)
        {
            return NotFound();
        }

        return View(race);
    }

    // POST: Races/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(uint id)
    {
        _repository.DeleteBy<Race>(race => race.Id == id);
        await _repository.UpdateAsync<Race>();
        return RedirectToAction(nameof(Index));
    }

    private bool RaceExists(uint id)
    {
        return _repository.Any<Race>(Race => Race.Id == id);
    }
}
