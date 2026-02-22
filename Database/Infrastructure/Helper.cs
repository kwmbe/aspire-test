using System.Security.Cryptography;

namespace Database.Infrastructure;

public static class Helper
{
    /// Generates a cryptographically secure random Guid.
    ///
    /// Characteristics
    ///     - Variant: RFC 4122
    ///     - Version: 4
    /// RFC
    ///     https://www.rfc-editor.org/rfc/rfc4122#section-4.1.3
    /// Stackoverflow
    ///     https://stackoverflow.com/a/59437504/10830091
    public static Guid CreateCryptographicallySecureRandomRFC4122Guid()
    {
        using var cryptoProvider = RandomNumberGenerator.Create();

        // byte indices
        var versionByteIndex = BitConverter.IsLittleEndian ? 7 : 6;
        const int VARIANT_BYTE_INDEX = 8;

        // version mask & shift for `Version 4`
        const int VERSION_MASK = 0x0F;
        const int VERSION_SHIFT = 0x40;

        // variant mask & shift for `RFC 4122`
        const int VARIANT_MASK = 0x3F;
        const int VARIANT_SHIFT = 0x80;

        // get bytes of cryptographically-strong random values
        var bytes = new byte[16];
        cryptoProvider.GetBytes(bytes);

        // Set version bits -- 6th or 7th byte according to Endianness, big or little Endian respectively
        bytes[versionByteIndex] = (byte)(bytes[versionByteIndex] & VERSION_MASK | VERSION_SHIFT);

        // Set variant bits -- 9th byte
        bytes[VARIANT_BYTE_INDEX] = (byte)(bytes[VARIANT_BYTE_INDEX] & VARIANT_MASK | VARIANT_SHIFT);

        // Initialize Guid from the modified random bytes
        return new Guid(bytes);
    }
}
