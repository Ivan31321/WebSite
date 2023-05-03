using Microsoft.EntityFrameworkCore;
using WebSite.Data.Base;
using WebSite.Data.ViewModels;
using WebSite.Models;

namespace WebSite.Data.Services
{
    public class ProductService: EntityBaseRepository<Product>, IProductService
    {
        private readonly WebDbContext _context;

        public IEnumerable<Product> products => throw new NotImplementedException();

        public ProductService(WebDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                PictureURL = data.ImageURL,
                ManufacturerId = data.ManufacturerId,
                Quantity = data.Quantity,
            };
            if(data.Quantity > 0)
            {
                newProduct.IsAvailable = true; 
            }
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(n => n.Id == id);

            return productDetails;
        }

        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Manufacturers = await _context.Manufacturers.OrderBy(n => n.Name).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduct != null)
            {
                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.PictureURL = data.ImageURL;
                dbProduct.ManufacturerId = data.ManufacturerId;
                dbProduct.Quantity = data.Quantity;
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }
    }
}
