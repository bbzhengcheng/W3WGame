using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace W3WGame.Services.VoucherAPI.ShengFeng
{
    /// <summary>
    /// 易付通 AES加密解密类库
    /// </summary>
    public class AES
    {
        private string Key = @")O[NB]6,YF}+efcaj{+oESb9d8>Z'e9M";
        private string IV = @"L+\~f4,Ir)b$=pkf";
        /// <summary>
        /// 获取密钥
        /// </summary>
        //private static string Key
        //{
        //    get { return @")O[NB]6,YF}+efcaj{+oESb9d8>Z'e9M"; }
        //}
        /// <summary>
        /// 设置KEY
        /// </summary>
        /// <param name="Key"></param>
        public void setKey(string Key)
        {
            this.Key = Key;
        }
        /// <summary>
        /// 设置IV
        /// </summary>
        /// <param name="IV"></param>
        public void setIV(string IV)
        {
            this.IV = IV;
        }
        /// <summary>
        /// 获取向量
        /// </summary>
        //private static string IV
        //{
        //    get { return @"L+\~f4,Ir)b$=pkf"; }
        //}

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <returns>密文</returns>
        public string AESEncrypt(string plainStr)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key);
            byte[] bIV = Encoding.UTF8.GetBytes(IV);
            byte[] byteArray = Encoding.UTF8.GetBytes(plainStr);

            string encrypt = null;
            Rijndael aes = Rijndael.Create();
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();

            return encrypt;
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <param name="returnNull">加密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>密文</returns>
        public string AESEncrypt(string plainStr, bool returnNull)
        {
            string encrypt = AESEncrypt(plainStr);
            return returnNull ? encrypt : (encrypt == null ? String.Empty : encrypt);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <returns>明文</returns>
        public string AESDecrypt(string encryptStr)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key);
            byte[] bIV = Encoding.UTF8.GetBytes(IV);
            byte[] byteArray = Convert.FromBase64String(encryptStr);

            string decrypt = null;
            Rijndael aes = Rijndael.Create();
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();

            return decrypt;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>明文</returns>
        public string AESDecrypt(string encryptStr, bool returnNull)
        {
            string decrypt = AESDecrypt(encryptStr);
            return returnNull ? decrypt : (decrypt == null ? String.Empty : decrypt);
        }
    }
}

