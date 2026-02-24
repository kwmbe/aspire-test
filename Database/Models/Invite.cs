using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Database.Infrastructure;

namespace Database.Models;

/// <summary>
/// Object for a room invite.
/// The invite will be deleted when the IsActive boolean returns false.
/// </summary>
public class Invite
{
    [Key]
    public Guid Id { get; private set; } = Helper.CreateCryptographicallySecureRandomRFC4122Guid();

    [ForeignKey(nameof(Room))]
    public Guid RoomId { get; init; }

    public DateTime ExpiryDateTime { get; init; } = DateTime.UtcNow + TimeSpan.FromDays(1);

    public int MaxUses { get; init; } = 1;
    public int Uses { get; private set; }

    public bool IsActive { get => ExpiryDateTime > DateTime.UtcNow &&  Uses < MaxUses; }
}
