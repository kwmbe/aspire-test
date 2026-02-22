using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Database.Infrastructure;

namespace Database.Models;

public class Invite
{
    [Key]
    public Guid Id { get; private set; } = Helper.CreateCryptographicallySecureRandomRFC4122Guid();

    [ForeignKey(nameof(Room))]
    public Guid RoomId { get; set; }

    public DateTime ExpiryDateTime { get; init; } = DateTime.UtcNow + TimeSpan.FromMinutes(15);

    public int MaxUses { get; init; } = 1;
    public int Uses { get; private set; }

    public bool IsActive { get => ExpiryDateTime > DateTime.UtcNow &&  Uses < MaxUses; }
}
