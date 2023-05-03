using WebSite.Data.Base;
using WebSite.Models;

namespace WebSite.Data.Services
{
    public class ManufacturerService: EntityBaseRepository<Manufacturer>, IManufacturerService
    {
        public ManufacturerService(WebDbContext context) : base(context) { }

        public IEnumerable<Manufacturer> manufacturers { get; set; }
    }
}
