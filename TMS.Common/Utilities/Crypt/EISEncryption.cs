// ***********************************************************************
// Assembly         : TMS.Common
// Author           : Almas Shabbir
// Created          : 07-09-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-28-2017
// ***********************************************************************
// <copyright file="EISEncryption.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TMS.Common.Utilities.Crypt
{
    /// <summary>
    /// Class EISEncryption.
    /// </summary>
    public class EISEncryption
    {
        /// <summary>
        /// The public key
        /// </summary>
        public string PublicKey;

        /// <summary>
        /// Encrypts the specified message.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <returns>System.String.</returns>
        public string Encrypt(string Message)
        {
            if (this.PublicKey == string.Empty)
            {
                return string.Empty;
            }

            RSACryptoServiceProvider myRSAEncrypter = new RSACryptoServiceProvider();
            myRSAEncrypter.FromXmlString(this.PublicKey);

            byte[] MessageInBytes = Encoding.Default.GetBytes(Message);
            byte[] EncryptedMessage = myRSAEncrypter.Encrypt(MessageInBytes, false);

            return System.Convert.ToBase64String(EncryptedMessage);
        }

        /// <summary>
        /// Method to Encrypt information
        /// </summary>
        /// <param name="TextToBeEncrypted">The text to be encrypted.</param>
        /// <param name="APEncryptionKey">The ap encryption key.</param>
        /// <returns>System.String.</returns>
        public static string EncryptString128Bit(string TextToBeEncrypted, string APEncryptionKey)
        {
            try
            {
                if ((string.IsNullOrEmpty(TextToBeEncrypted)))
                {
                    return TextToBeEncrypted;
                }
                byte[] bytValue = null;
                byte[] bytKey = null;
                byte[] bytEncoded = null;
                byte[] bytIV = { 121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62 };
                int intLength = 0;
                int intRemaining = 0;
                MemoryStream objMemoryStream = new MemoryStream();
                CryptoStream objCryptoStream = default(CryptoStream);
                RijndaelManaged objRijndaelManaged = default(RijndaelManaged);

                //   **********************************************************************
                //   ******  Strip any null character from string to be encrypted    ******
                //   **********************************************************************

                TextToBeEncrypted = StripNullCharacters(TextToBeEncrypted);

                //   **********************************************************************
                //   ******  Value must be within ASCII range (i.e., no DBCS chars)  ******
                //   **********************************************************************

                bytValue = Encoding.ASCII.GetBytes(TextToBeEncrypted.ToCharArray());

                intLength = APEncryptionKey.Length;

                //   ********************************************************************
                //   ******   Encryption Key must be 256 bits long (32 bytes)      ******
                //   ******   If it is longer than 32 bytes it will be truncated.  ******
                //   ******   If it is shorter than 32 bytes it will be padded     ******
                //   ******   with upper-case Xs.                                  ******
                //   ********************************************************************

                if (intLength >= 32)
                {
                    APEncryptionKey = Left(APEncryptionKey, 32);
                }
                else
                {
                    intLength = APEncryptionKey.Length;
                    intRemaining = 32 - intLength;
                    APEncryptionKey = APEncryptionKey.PadRight(intRemaining, 'X');
                }

                bytKey = Encoding.ASCII.GetBytes(APEncryptionKey.ToCharArray());

                objRijndaelManaged = new RijndaelManaged();

                //   ***********************************************************************
                //   ******  Create the encryptor and write value to it after it is   ******
                //   ******  converted into a byte array                              ******
                //   ***********************************************************************

                try
                {
                    objCryptoStream = new CryptoStream(objMemoryStream, objRijndaelManaged.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write);
                    objCryptoStream.Write(bytValue, 0, bytValue.Length);

                    objCryptoStream.FlushFinalBlock();

                    bytEncoded = objMemoryStream.ToArray();
                    objMemoryStream.Close();
                    objCryptoStream.Close();
                }
                catch
                {
                }

                //   ***********************************************************************
                //   ******   Return encryptes value (converted from  byte Array to   ******
                //   ******   a base64 string).  Base64 is MIME encoding)             ******
                //   ***********************************************************************

                return Convert.ToBase64String(bytEncoded);
            }
            catch (Exception ex)
            {
                return TextToBeEncrypted;
            }
        }

        /// <summary>
        /// Method to Decrypt information
        /// </summary>
        /// <param name="vstrStringToBeDecrypted">The VSTR string to be decrypted.</param>
        /// <param name="vstrDecryptionKey">The VSTR decryption key.</param>
        /// <returns>System.String.</returns>
        public static string DecryptString128Bit(string vstrStringToBeDecrypted, string vstrDecryptionKey)
        {
            try
            {
                byte[] bytDataToBeDecrypted = null;
                byte[] bytTemp = null;
                byte[] bytIV = { 121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62 };
                RijndaelManaged objRijndaelManaged = new RijndaelManaged();
                MemoryStream objMemoryStream = default(MemoryStream);
                CryptoStream objCryptoStream = default(CryptoStream);
                byte[] bytDecryptionKey = null;

                int intLength = 0;
                int intRemaining = 0;
                //Dim intCtr As Integer
                string strReturnString = string.Empty;
                //Dim achrCharacterArray() As Char
                //Dim intIndex As Integer

                //   *****************************************************************
                //   ******   Convert base64 encrypted value to byte array      ******
                //   *****************************************************************

                bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted);

                //   ********************************************************************
                //   ******   Encryption Key must be 256 bits long (32 bytes)      ******
                //   ******   If it is longer than 32 bytes it will be truncated.  ******
                //   ******   If it is shorter than 32 bytes it will be padded     ******
                //   ******   with upper-case Xs.                                  ******
                //   ********************************************************************

                intLength = vstrDecryptionKey.Length;

                if (intLength >= 32)
                {
                    vstrDecryptionKey = EISEncryption.Left(vstrDecryptionKey, 32);
                }
                else
                {
                    intLength = vstrDecryptionKey.Length;
                    intRemaining = 32 - intLength;
                    vstrDecryptionKey = vstrDecryptionKey.PadRight(intRemaining, 'X');
                }

                bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray());

                bytTemp = new byte[bytDataToBeDecrypted.Length + 1];

                objMemoryStream = new MemoryStream(bytDataToBeDecrypted);

                //   ***********************************************************************
                //   ******  Create the decryptor and write value to it after it is   ******
                //   ******  converted into a byte array                              ******
                //   ***********************************************************************

                try
                {
                    objCryptoStream = new CryptoStream(objMemoryStream, objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), CryptoStreamMode.Read);

                    objCryptoStream.Read(bytTemp, 0, bytTemp.Length);

                    objCryptoStream.FlushFinalBlock();
                    objMemoryStream.Close();
                    objCryptoStream.Close();
                }
                catch
                {
                }

                //   *****************************************
                //   ******   Return decypted value     ******
                //   *****************************************

                string strRes = StripNullCharacters(Encoding.ASCII.GetString(bytTemp));
                if ((string.IsNullOrEmpty(strRes)))
                {
                    strRes = vstrStringToBeDecrypted;
                }
                return strRes;
            }
            catch (Exception ex)
            {
                return vstrStringToBeDecrypted;
            }
        }

        /// <summary>
        /// Strips the null characters.
        /// </summary>
        /// <param name="vstrStringWithNulls">The VSTR string with nulls.</param>
        /// <returns>System.String.</returns>
        public static string StripNullCharacters(string vstrStringWithNulls)
        {
            string strStringWithOutNulls = null;
            strStringWithOutNulls = vstrStringWithNulls.Replace("\0", "");
            return strStringWithOutNulls;
        }

        /// <summary>
        /// Lefts the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }

        /// <summary>
        /// Rights the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }
    }
}