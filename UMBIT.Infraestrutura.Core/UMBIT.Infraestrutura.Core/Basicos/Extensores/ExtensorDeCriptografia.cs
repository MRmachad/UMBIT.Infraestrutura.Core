using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UMBIT.Infraestrutura.Core.Basicos.Extensores
{
    public static class ExtensorDeCriptografia
    {
        private static byte[] DEFAULT_SALT = new byte[]
        {
            148, 177, 219, 49, 251, 98, 127, 52, 129,
            41, 239, 89, 238, 187, 154, 239, 10, 25,
            105, 62, 96, 147, 45, 127, 74, 147, 83, 213,
            103, 118, 30, 104
        };

        public static string Criptografe(this string valor)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = DEFAULT_SALT;
                aes.IV = iv;

                ICryptoTransform encriptador = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encriptador, CryptoStreamMode.Write))
                    {
                        using (StreamWriter escritor = new StreamWriter((Stream)cryptoStream))
                        {
                            escritor.Write(valor);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string Descriptografe(this string criptografia)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(criptografia);

            using (Aes aes = Aes.Create())
            {
                aes.Key = DEFAULT_SALT;
                aes.IV = iv;
                ICryptoTransform decriptador = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decriptador, CryptoStreamMode.Read))
                    {
                        using (StreamReader leitor = new StreamReader((Stream)cryptoStream))
                        {
                            return leitor.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string CrieHash(this string valor, byte[] salt)
        {
            var password_bytes = ASCIIEncoding.ASCII.GetBytes(valor);

            byte[] data_input = new byte[password_bytes.Length + salt.Length];

            for (int i = 0; i < password_bytes.Length; i++)
            {
                data_input[i] = password_bytes[i];
            }

            for (int i = 0; i < salt.Length; i++)
            {
                data_input[i + password_bytes.Length] = salt[i];
            }

            return Convert.ToBase64String((new SHA512Managed()).ComputeHash(data_input));
        }
    }
}
