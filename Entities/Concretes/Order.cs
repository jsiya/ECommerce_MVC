using Entities.Abstracts;

namespace Entities.Concretes;

public class Order : Entity
{
    public Double TotalPrice { get; set; }
    //foreign key
    public int CustomerId { get; set; }
    //nav prop
    public virtual ICollection<Product> Products { get; set; }
    public virtual Customer Customer { get; set; }
}