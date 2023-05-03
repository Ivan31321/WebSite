using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Product product { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
