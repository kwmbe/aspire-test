using System.ComponentModel.DataAnnotations;

using Database.Infrastructure;

namespace Database.Models;

/// <summary>
/// Represents a sender or recipient of a message.
/// Each user is represented by an id generated server-side and a public key generated client-side.
/// Communication can happen between two or more users directly, or in a chatroom.
/// </summary>
public class User
{
    [Key]
    public Guid Id { get; private set; } = Helper.CreateCryptographicallySecureRandomRFC4122Guid();
    public required string Key { get; init; }

    /// <summary>
    /// Determines whether to use p2p or to send a message to the server, when messaging other users.
    /// If the recipient is offline, the message will be sent to the server.
    /// If the server can't be reached, keep checking every x minutes if either can be reached.
    /// </summary>
    public bool Online { get; set; }
}
