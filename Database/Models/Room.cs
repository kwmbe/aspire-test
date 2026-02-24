using System.ComponentModel.DataAnnotations;

using Database.Infrastructure;

namespace Database.Models;

/// <summary>
/// Object for asynchronous communication, saved server side.
/// The idea is to use this when it's preferable to have history visible to future room members.
/// </summary>
public class Room
{
    [Key]
    public Guid Id { get; private set; } = Helper.CreateCryptographicallySecureRandomRFC4122Guid();

    public required string Key { get; init; }

    [StringLength(50)]
    public required string Name { get; set; }
}
