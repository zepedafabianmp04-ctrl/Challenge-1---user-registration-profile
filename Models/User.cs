using System.ComponentModel.DataAnnotations;

namespace ProductService.Models;

public class User{
    public int Id {get; set;}

    [Required]
    [MaxLength(50)]
    public string Username {get; set;} = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email {get; set;} = string.Empty;

    [Required]
    [MaxLength(255)]
    public string PasswordHash {get; set;} = string.Empty;

    public DateTime RegistrationDate {get; set;} = DateTime.Now;
    public bool IsActive {get; set;} = true;
}