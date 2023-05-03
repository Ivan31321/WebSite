using WebSite.Models;

namespace WebSite.Data.ViewModels
{
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
            Manufacturers = new List<Manufacturer>();
        }

        public List<Manufacturer> Manufacturers { get; set; }
    }
}
