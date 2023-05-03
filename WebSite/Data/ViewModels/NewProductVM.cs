using System.ComponentModel.DataAnnotations;

namespace WebSite.Data.ViewModels
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Product picture URL")]
        [Required(ErrorMessage = "Product picture URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Select a manufacturer")]
        [Required(ErrorMessage = "Product manufacturer is required")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
    }
}
