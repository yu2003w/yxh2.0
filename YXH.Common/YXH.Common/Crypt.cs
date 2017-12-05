using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace YXH.Common
{
    /// <summary>
    /// 加密类
    /// </summary>
    public static class Crypt
    {
        /// <summary>
        /// 将字符串进行DES加密
        /// </summary>
        /// <param name="pToEncrypt">需要加密的字符串</param>
        /// <param name="sKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string pToEncrypt, string sKey)
        {
            if (sKey.Length != 8)
            {
                throw new ArgumentException("Des解密异常,密钥位数需为八位");
            }

            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();


            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);

            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();

            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = memoryStream.ToArray();

            foreach (byte b in array)
            {
                stringBuilder.AppendFormat("{0:X2}", b);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 将字符串进行DES解密
        /// </summary>
        /// <param name="pToDecrypt">需要解密的字符串</param>
        /// <param name="sKey">密钥</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(string pToDecrypt, string sKey)
        {
            if (sKey.Length != 8)
            {
                throw new ArgumentException("DES解密异常,密钥位数需为八位");
            }

            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] array = new byte[pToDecrypt.Length / 2];
            
            for (int i = 0; i < pToDecrypt.Length / 2; i++)
            {
                int num = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 16);

                array[i] = (byte)num;
            }

            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);

            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.FlushFinalBlock();

            return Encoding.Default.GetString(memoryStream.ToArray());
        }

        /// <summary>
        /// 将字符串进行MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <returns>返回加密后的字符串（16进制单位）</returns>
        public static string GetMd5Hash(string input)
        {
            MD5 mD = MD5.Create();
            byte[] array = mD.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
