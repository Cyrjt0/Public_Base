using System.Security.Cryptography;
using System.Text;

namespace CommonServices
{
    public class AesEncryption
    {
        private readonly static string _key = "%XdJlsNa@GwTUq0$";

        public static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_key);
                aesAlg.GenerateIV(); // Tạo ra IV ngẫu nhiên
                aesAlg.Mode = CipherMode.CBC; // Chế độ mã hóa CBC
                aesAlg.Padding = PaddingMode.PKCS7; // Padding cho dữ liệu không chia hết 16 byte

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // Ghi IV vào đầu stream
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Ghi dữ liệu cần mã hóa
                            swEncrypt.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_key);

                // Đọc IV từ stream (16 byte đầu tiên)
                byte[] iv = new byte[aesAlg.BlockSize / 8];
                Array.Copy(cipherBytes, 0, iv, 0, iv.Length);
                aesAlg.IV = iv;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes, iv.Length, cipherBytes.Length - iv.Length))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Trả về dữ liệu đã giải mã
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }

}
