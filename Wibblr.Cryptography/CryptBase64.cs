using System.Security.Cryptography;
using System.Text;

namespace Wibblr.Cryptography
{
    /// <summary>
    /// Minimal version of base-64 encoding that uses a different set of symbols from the default .NET implementation,
    /// and has a different padding mechanism.
    /// </summary>
    class CryptBase64
    {
        static readonly char[] BASE64_SYMBOLS = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        static readonly RandomNumberGenerator random = RandomNumberGenerator.Create();

        public static void b64from24bit(byte b2, byte b1, byte b0, int outLen, StringBuilder builder)
        {
            int w = (b2 << 16) | (b1 << 8) | b0;

            int n = outLen;
            while (n-- > 0)
            {
                builder.Append(BASE64_SYMBOLS[w & 0x3f]);
                w >>= 6;
            }
        }

        public static string GetRandomSymbols(int count)
        {
            var builder = new StringBuilder(count);
            var buf = new byte[count];

            random.GetBytes(buf);

            for (int i = 0; i < count; i++)
            {
                builder.Append(BASE64_SYMBOLS[buf[i] & 0x3f]);
            }

            return builder.ToString();
        }
    }
}