using WebSite.Data.Base;

namespace WebSite.Models
{
    public interface IManufacturerRepository:IEntityBaseRepository<Manufacturer>
    {
        public List<Manufacturer> manufacturers { get; set; }
    }
}
