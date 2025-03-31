using System.ComponentModel.DataAnnotations;

namespace BetabitUserManager.API.Controllers.Resources;

public class UserResource
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [Range(0, 120)]
    public byte Age { get; set; }
}