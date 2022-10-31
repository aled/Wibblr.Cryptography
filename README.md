## Crypt

This is a C# implementation of the unix crypt() algorithm from [https://akkadia.org/drepper/SHA-crypt.txt](https://akkadia.org/drepper/SHA-crypt.txt),
which is used for secure password hashing.

It is mostly a translation of the Java version from Apache commmons codec (sha2crypt.java),
which is itself a translation of the original C version

Only the SHA-256 and SHA-512 encryption algorithms are implemented in this port.

This allows a custom password database to be interoperable between C# and unix/linux.

## Examples
Nothing to it, really.

    var encryptedPassword = Sha256Crypt("MyPassword");
    var isValid = Validate("MyPassword", encryptedPassword)

See the project `Wibblr.Cryptography.Examples` for more.
