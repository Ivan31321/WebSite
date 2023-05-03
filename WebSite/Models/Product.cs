using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebSite.Data.Base;

namespace WebSite.Models
{
    public class Product: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Изображение продукта")]
        public string PictureURL { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]

        public string Description { get; set; }
        [Display(Name = "Цена")]

        public double Price { get; set; }
        [Display(Name = "Количество")]

        public int Quantity { get; set; }
        [Display(Name = "Наличие")]

        public bool IsAvailable { get; set; }

        //relations
        [Display(Name = "Производитель")]
        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }
    }
}
