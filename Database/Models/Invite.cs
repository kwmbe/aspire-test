using System.ComponentModel.DataAnnotations;

using Database.Infrastructure;

namespace Database.Models;

public class Invite
{
    [Key]
    public Guid Id { get; private set; } = Helper.CreateCryptographicallySecureRandomRFC4122Guid();
}
