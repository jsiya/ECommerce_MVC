namespace Entities.DTOs;

public record ProductDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Double Price { get; set; }
    public string? ImageUrl { get; set; }
    public int Stock { get; set; }
}