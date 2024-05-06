using Entities.Abstracts;

namespace Entities.Concretes;

public class Category : Entity
{
    public string Name { get; set; }

    //nav prop
    public virtual ICollection<Product> Products { get; set; }
}