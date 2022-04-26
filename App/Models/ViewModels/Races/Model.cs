#nullable disable

using App.Data;
using App.Models.DatabaseModels;

namespace App.Models.ViewModels.Races;

public class Model
{
    public Race Race { get; set; }
    public List<Vehicule.AvailableCategory> AllCategories { get; set; }
    public List<uint> SelectedCategories { get; set; }

    public Model(IRepository repo)
    {
        AllCategories = repo.GetAll<Vehicule.AvailableCategory>().ToList();
    }

    public Model(IRepository repo, Race race)
    {
        AllCategories = repo.GetAll<Vehicule.AvailableCategory>().ToList();
        SelectedCategories = new List<uint>(race.AllowedCategories.Count);
        Race = race;

        foreach (var category in race.AllowedCategories)
            SelectedCategories.Add(category.Id);
    }
}
