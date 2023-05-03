    using System.ComponentModel.DataAnnotations;
    using WebSite.Data.Base;

    namespace WebSite.Models
    {
        public class Manufacturer: IEntityBase
        {
            [Key]
            public int Id { get; set; }
            [Display(Name = "Название производителя")]
            [Required(ErrorMessage = "Необходимо название производителя")]
            public string Name { get; set; }
            [Display(Name = "Лого производителя")]
            [Required(ErrorMessage = "Необходимо лого производителя")]
            public string PictureURL { get; set; }
            [Display(Name = "Адрес производства")]


            [Required(ErrorMessage = "Необходим адрес производства")]
            public string Adress { get; set; }
            [Display(Name = "Телефон")]

            [Required(ErrorMessage = "Необходим телефон")]
            public string Phone { get; set; }

            //relations
            public List<Product> Products { get; set; }
        }
    }
