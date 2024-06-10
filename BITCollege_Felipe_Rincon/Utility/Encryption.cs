using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
/*
* Name: Felipe Rincon
* Course: COMP-1283 C# Programming 4
* Created: 2024-06-08
* Updated: 2024-06-10
*/
namespace Utility
{
    public static class Encryption
    {
        /// <summary>
        /// Encrypt method implementation
        /// </summary>
        /// <param name="plaintextFileName"></param>
        /// <param name="encryptedFileName"></param>
        /// <param name="key"></param>
        public static void Encrypt(string plaintextFileName, string encryptedFileName, string key)
        {
            // This method will be used encrypt a file. 
            try
            {
                // Create a FileStream object based on the plaintextFileName with an Open FileMode, and a Read FileAccess. 
                FileStream plaintextFileStream = new FileStream(plaintextFileName, FileMode.Open, FileAccess.Read);
                // Create  a second FileStream object based on the (eventual) encryptedFileName 
                FileStream encryptedFileStream = new FileStream(encryptedFileName, FileMode.Create, FileAccess.Write);
                {
                    // Create a DESCryptoServiceProvider object
                    DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
                    // Use the ASCIIEncoding.ASCII.GetBytes method to encode the string Key 
                    byte[] keyBytes = ASCIIEncoding.ASCII.GetBytes("module44");
                    // Set the DESCryptoServiceProvider’s Key property to this sequence of bytes. 
                    desProvider.Key = keyBytes;
                    // Set the DESCryptoServiceProvider’s IV (initialization vector) property to this sequence of bytes. 
                    desProvider.IV = keyBytes;
                    // Define a byte array based on the Length of the plaintext FileStream
                    ICryptoTransform desEncryptor = desProvider.CreateEncryptor();
                    CryptoStream cryptostreamEncr = new CryptoStream(encryptedFileStream, desEncryptor, CryptoStreamMode.Write);
                    {
                        // Read this data into the byte array with no offset using the entire length
                        byte[] bytearray = new byte[plaintextFileName.Length];
                        plaintextFileStream.Read(bytearray, 0, bytearray.Length);
                        // Write the encrypted data using the CryptoStream object. 
                        cryptostreamEncr.Write(bytearray, 0, bytearray.Length);
                        // Close the CryptoStream object. 
                        cryptostreamEncr.Close();
                        // Close the plaintext FileStream. 
                        plaintextFileStream.Close();
                        // Close the encrypted FileStream. 
                        encryptedFileStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("an error has ocurred during encryption: " + ex.Message);
            }
        }
        /// <summary>
        /// Decrypt method implementation
        /// This method will decrypt a file 
        /// </summary>
        /// <param name="encryptedFileName"></param>
        /// <param name="plaintextFileName"></param>
        /// <param name="key"></param>
        public static void Decrypt(string encryptedFileName, string plaintextFileName, string key)
        {
            StreamWriter decryptedStreamWriter = null;
            try
            {
                // Create a StreamWriter object based on the plaintextFileName. 
                decryptedStreamWriter = new StreamWriter(plaintextFileName);
                // Create a FileStream object based on the encryptedFileName with an Open FileMode
                FileStream EncryptedFileStream = new FileStream(encryptedFileName, FileMode.Open, FileAccess.Read);
                {

                    // Create a DESCryptoServiceProvider object 
                    DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
                    // Use the ASCIIEncoding.ASCII.GetBytes method to encode the string Key 
                    byte[] keyBytes = ASCIIEncoding.ASCII.GetBytes("module44");
                    // Set the DESCryptoServiceProvider’s Key property 
                    desProvider.Key = keyBytes;
                    // Set the DESCryptoServiceProvider’s IV (initialization vector) property 
                    desProvider.IV = keyBytes;
                    // Create an ICryptoTransform object using the CreateDecryptor 
                    ICryptoTransform decryptor = desProvider.CreateDecryptor();
                    // Create a CryptoStream object using the encrypted file FileStream
                    CryptoStream cryptostreamDecr = new CryptoStream(EncryptedFileStream, decryptor, CryptoStreamMode.Read);
                    StreamReader swDecrypt = new StreamReader(cryptostreamDecr);
                    // Code commented out, since following route B, the rest of the implementation is done in the batch windows form
                    //// Write a new (decrypted) file based on the CryptoStream object
                    //decryptedStreamWriter.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
                    //// Flush the plaintext StreamWriter object
                    //decryptedStreamWriter.Flush();
                    //// Close the decrypted StreamWriter object’s file
                    //decryptedStreamWriter.Close();
                }
            }
            // If any exceptions occur during this routine: 
            catch (Exception ex)
            {
                // Close the decrypted StreamWriter object’s file.
                if (decryptedStreamWriter != null)
                {
                    decryptedStreamWriter.Close();
                }
                throw new Exception("an error has ocurred during decryption: " + ex.Message);
            }
        }
    }
}
