using System.ComponentModel.DataAnnotations;

using Database.Infrastructure;

namespace Database.Models;

public class User
{
    [Key]
    public Guid Id { get; private set; } = Helper.CreateCryptographicallySecureRandomRFC4122Guid();
    public required string Password { get; set; }
}
