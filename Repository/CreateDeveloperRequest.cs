using System.ComponentModel.DataAnnotations;

public class CreateDeveloperRequest
{
    [Required]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "The 'Email' needs to be supplied in the request body")]
    public string? Email { get; set; }
}