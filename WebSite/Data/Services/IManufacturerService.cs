using WebSite.Data.Base;
using WebSite.Models;

namespace WebSite.Data.Services
{
    public interface IManufacturerService: IEntityBaseRepository<Manufacturer>
    {
       IEnumerable<Manufacturer> manufacturers { get; }
    }
}
