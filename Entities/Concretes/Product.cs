using Entities.Abstracts;

namespace Entities.Concretes;

public class Product : Entity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Double Price { get; set; }
    public string? ImageUrl { get; set; }
    public int Stock { get; set; }
    
    //foreign key
    public int CategoryId { get; set; }
    public int SellerId { get; set; }
    
    //nav prop
    public virtual Category Category { get; set; }
    public virtual Seller Seller { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}