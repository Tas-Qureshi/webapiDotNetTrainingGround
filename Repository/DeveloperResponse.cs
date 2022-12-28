using System.ComponentModel;

public class DeveloperResponse
{
    public int Id { get; set; }
    [DisplayName("Developer Name")]
    public string? Name { get; set; }
    [DisplayName("Developer Email")]
    public string? Email { get; set; }
}