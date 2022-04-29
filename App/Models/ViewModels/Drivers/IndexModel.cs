using App.Data;
using App.Models.DatabaseModels;

namespace App.Models.ViewModels.Drivers;

public class IndexModel
{
    IRepository _repository;
    public List<Driver> Drivers { get; set; }
    public PagingInfo PagingInfo { get; set; }

    public IndexModel(IRepository repo, int page)
    {
        _repository = repo;
        var local_drivers = _repository.GetAll<Driver>().ToList();

        PagingInfo = new PagingInfo
        {
            CurrentPage = page,
            ItemsPerPage = 25,
            TotalItems = local_drivers.Count
        };
        Drivers = local_drivers.Skip((page - 1) * PagingInfo.ItemsPerPage).Take(PagingInfo.ItemsPerPage).ToList();
    }
}
