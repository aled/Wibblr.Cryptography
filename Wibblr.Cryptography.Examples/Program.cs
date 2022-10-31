using static Wibblr.Cryptography.Sha2Crypt;

namespace Wibblr.Cryptography.Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var encryptedPassword1 = Sha256Crypt("MyPassword", "abcdefabcdef");
            Console.WriteLine("Secure hash of a password. The salt is explicitly specified, and the encrypted password will be the same if the salt and password are reused");
            Console.WriteLine(encryptedPassword1);
            Console.WriteLine();

            Console.WriteLine("Check if the password is correct: " + Validate("MyPassword", encryptedPassword1));
            Console.WriteLine();

            var encryptedPassword2 = Sha256Crypt("MyPassword");
            Console.WriteLine("Hashing the same password again produces different output. Because no salt is supplied, it is generated automatically");
            Console.WriteLine(encryptedPassword2);
            Console.WriteLine();

            Console.WriteLine("Check if the password is correct: " + Validate("MyPassword", encryptedPassword2));
            Console.WriteLine();

            var encryptedPassword3 = Sha512Crypt("MyPassword");
            Console.WriteLine("Using Sha512 gives a longer output string");
            Console.WriteLine(encryptedPassword3);
            Console.WriteLine();

            Console.WriteLine("Check if the SHA-512 password is correct: " + Validate("MyPassword", encryptedPassword3));
            Console.WriteLine();

            var encryptedPassword4 = encryptedPassword1.Substring(0, 25) + "00000" + encryptedPassword1.Substring(30);
            Console.WriteLine("Put some invalid characters in the encrypted password");
            Console.WriteLine(encryptedPassword4);
            Console.WriteLine();

            Console.WriteLine("Check if the invalid password is correct: " + Validate("MyPassword", encryptedPassword4));
            Console.WriteLine();
        }
    }
}
