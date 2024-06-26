namespace Product_Management_MVC.ViewModels;

public class SellerViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserRole { get; set; }

    public string? Address { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}