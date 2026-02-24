using System.ComponentModel.DataAnnotations;

using Database.Infrastructure;

namespace Database.Models;

public enum MessageType { USER, ROOM }

/// <summary>
/// Object for server-side saved messages.
/// USER type messages have a User-id as DestinationId, and ROOM type messages a Room-id.
/// USER types will be deleted when the User receives the message.
/// </summary>
public class Message
{
    [Key]
    public Guid Id { get; private set; } = Helper.CreateCryptographicallySecureRandomRFC4122Guid();

    // no foreign key since this isn't possible in ef
    public Guid DestinationId { get; init; }
    public MessageType Type { get; init; }

    public required string Body { get; init; }
}
