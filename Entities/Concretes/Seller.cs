using Entities.Abstracts;

namespace Entities.Concretes;

public class Seller : User
{
    //nav prop
    public virtual ICollection<Product> Products { get; set; }
}