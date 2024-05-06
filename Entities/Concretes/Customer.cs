using Entities.Abstracts;

namespace Entities.Concretes;

public class Customer : User
{
    //nav prop
    public virtual ICollection<Order> Orders { get; set; }
}