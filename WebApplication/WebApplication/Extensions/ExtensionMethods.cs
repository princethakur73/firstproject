﻿using System;
using System.Security.Cryptography;
using System.Text;
public static class ExtensionMethods
{
    private const string _securityKey = "waheguru";
    public static string ToEncrypt(this object value)
    {
        //Getting the bytes of Input String.

        byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(value.ToString());



        MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();



        //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.

        byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(_securityKey));



        //De-allocatinng the memory after doing the Job.

        objMD5CryptoService.Clear();



        var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();



        //Assigning the Security key to the TripleDES Service Provider.

        objTripleDESCryptoService.Key = securityKeyArray;



        //Mode of the Crypto service is Electronic Code Book.

        objTripleDESCryptoService.Mode = CipherMode.ECB;



        //Padding Mode is PKCS7 if there is any extra byte is added.

        objTripleDESCryptoService.Padding = PaddingMode.PKCS7;



        var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();



        //Transform the bytes array to resultArray

        byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);



        //Releasing the Memory Occupied by TripleDES Service Provider for Encryption.

        objTripleDESCryptoService.Clear();



        //Convert and return the encrypted data/byte into string format.

        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    public static string ToDecrypt(this object value)
    {


        byte[] toEncryptArray = Convert.FromBase64String(value.ToString());



        MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();



        //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.

        byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(_securityKey));



        //De-allocatinng the memory after doing the Job.

        objMD5CryptoService.Clear();



        var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();



        //Assigning the Security key to the TripleDES Service Provider.

        objTripleDESCryptoService.Key = securityKeyArray;



        //Mode of the Crypto service is Electronic Code Book.

        objTripleDESCryptoService.Mode = CipherMode.ECB;



        //Padding Mode is PKCS7 if there is any extra byte is added.

        objTripleDESCryptoService.Padding = PaddingMode.PKCS7;



        var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();



        //Transform the bytes array to resultArray

        byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);



        //Releasing the Memory Occupied by TripleDES Service Provider for Decryption.

        objTripleDESCryptoService.Clear();



        //Convert and return the decrypted data/byte into string format.

        return UTF8Encoding.UTF8.GetString(resultArray);
    }

}