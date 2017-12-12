using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
/// <summary>
/// Summary description for SecurityCypher
/// </summary>
public static class SecurityCypher
{
    static byte[] SHA256_GetHash(string str)//
    {
        byte[] byteArr = GetBytes(str);
        SHA256Managed sha256 = new SHA256Managed();
        byte[] hash = sha256.ComputeHash(byteArr);
        return hash;
    }

    static string SHA256_GetBase64String(byte[] hash)
    {
        string result = "";
        result = Convert.ToBase64String(hash);
        return result;
    }

    static byte[] GetBytes(string str)//
    {
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }

    public static string ByteArrayToString(byte[] ba)//
    {
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte b in ba)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();
    }

}