#nullable disable

using App.Data;
using App.Models.DatabaseModels;

namespace App.Models.ViewModels.Home;

public class IndexModel
{
    public List<Race> NextRaces;
    public List<Race.Result> LastRaceResult;

    public IndexModel(IRepository repo)
    {
        List<Race> races = repo.GetAll<Race>().ToList();

        // NextRaces
        NextRaces = races.Where(race => race.EventDate > DateTime.Now).OrderBy(race => race.EventDate).Take(3).ToList();

        // LastRaceResult
        Race lastPassedRace = races.Where(race => race.Results.Count != 0).MaxBy(race => race.EventDate);
        if (lastPassedRace is null)
            LastRaceResult = new List<Race.Result>(0);
        else
            LastRaceResult = repo.GetBy<Race.Result>(result => result.Race.Id == lastPassedRace.Id).ToList();
    }
}
