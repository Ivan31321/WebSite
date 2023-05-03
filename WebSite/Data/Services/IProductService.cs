using WebSite.Data.Base;
using WebSite.Data.ViewModels;
using WebSite.Models;

namespace WebSite.Data.Services
{
    public interface IProductService: IEntityBaseRepository<Product>
    {
        IEnumerable<Product> products { get; }
        Task<Product> GetProductByIdAsync(int id);
        Task<NewProductDropdownsVM> GetNewProductDropdownsValues();
        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);
    }
}
