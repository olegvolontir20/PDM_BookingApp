﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace BookingApplication.Common
{
    public class CommonMethods
    {
        public static string key = "adef@@kfxcbv@";

        public static string ConvertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += key;
            var passwordBytes= Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);

        }

        public static string ConvertToDecrypt(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData)) return "";
            var base64EncodeBytes= Convert.FromBase64String(base64EncodeData);
            var result= Encoding.UTF8.GetString(base64EncodeBytes);
            result= result.Substring(0, result.Length - key.Length);
            return result;

        }
    }
}
