

using System;
using System.Security.Cryptography;
using System.Text;

namespace SCServer.Common.Helpers
{
    public class Encryption
    {
        #region "private credentials"
        private static string configuration_Masterkey = "FHV2/rdZQLarkV8NEXEZZlPQ5aeTt8JW7CkNVqPf2uM=";
        private static TripleDESCryptoServiceProvider des;
        #endregion
        private static MD5CryptoServiceProvider hashmd5;

        public Encryption()
        {
            //
            // TODO: Add constructor logic here
            //

        }


        #region "Encryption/Decryption Methods"

        /// <summary>
        /// Encrypts the given string
        /// </summary>
        /// <param name="strkey">The String to be encrypted</param>
        /// <returns>Encrypted String</returns>
        public static string EncryptStr(string strkey, string configuration_key = "")
        {
            try
            {
                des = new TripleDESCryptoServiceProvider();
                hashmd5 = new MD5CryptoServiceProvider();

                des.Key = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes((configuration_key == "") ? configuration_Masterkey : configuration_key));
                des.Mode = CipherMode.ECB;
                ICryptoTransform desdencrypt = des.CreateEncryptor();
                ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
                byte[] buff = ASCIIEncoding.ASCII.GetBytes(strkey);



                return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }



        #endregion

        public static string DecryptStr(string strKey, string configuration_key = "")
        {
            try
            {
                byte[] keyArray = null;
                byte[] toEncryptArray = Convert.FromBase64String(strKey);




                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes((configuration_key == "") ? configuration_Masterkey : configuration_key));
                hashmd5.Clear();


                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);

            }

            catch (Exception Ex)
            {
                return Ex.Message + " Salt:" + configuration_key + " Key :" + strKey + " Stack Trace : " + Ex.StackTrace;
            }

        }



    }

    }
