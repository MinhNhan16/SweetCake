namespace SweetCakeFrontend.Models
{
    public class Category
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
