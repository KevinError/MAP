﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SecurityLayer.utility
{
    public class UrlSafeBase64Encoder
    {
        public UrlSafeBase64Encoder()
        {

        }

        public string Encode(Dictionary<string, string> dict)
        {
            string jsonDict = JsonConvert.SerializeObject(dict);
            byte[] byteJsonDict = Encoding.UTF8.GetBytes(jsonDict);
            string base64EncodedDict = ToUrlSafeBase64Str(byteJsonDict);

            return base64EncodedDict;
        }

        public Dictionary<string, string> Decode(
            string urlSafeBase64EncodedStr
        )
        {
            // TODO make this return null if exception is raised.
            string base64Str = FromUrlSafeBase64Str(urlSafeBase64EncodedStr);
            if (base64Str == null)
            {
                // It wasn't a properly encoded string.
                return null;
            }
            byte[] byteDict = null;
            try
            {
                byteDict = System.Convert.FromBase64String(base64Str);
            }
            catch (FormatException)
            {
                // base64Str is not a valid base64 encoded string.
                return null;
            }

            string jsonDict = Encoding.UTF8.GetString(byteDict);
            Dictionary<string, string> resultDict
                = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonDict);
            return resultDict;
        }

        public string ToUrlSafeBase64Str(byte[] byteArray)
        {
            string result = "";
            string temp = System.Convert.ToBase64String(byteArray);
            // Remove ='s at the end that were caused by padding the last
            // group of bytes to be 24 bits long.
            temp = temp.TrimEnd('=');
            // Replace + with - and / with _ to make string URL safe
            result = temp.Replace("+", "-").Replace("/", "_");
            return result;
        }

        public string FromUrlSafeBase64Str(string urlSafeBase64EncodedStr)
        {
            if (urlSafeBase64EncodedStr == null)
            {
                return null;
            }
            string result = "";
            string temp;
            string charPad = "=";
            int length = urlSafeBase64EncodedStr.Length;
            int remainder = urlSafeBase64EncodedStr.Length % 4;
            switch (remainder)
            {
                case 3:
                    temp = urlSafeBase64EncodedStr + charPad;
                    break;
                case 2:
                    temp = urlSafeBase64EncodedStr + charPad + charPad;
                    break;
                case 1:
                    // Remainder of 1 should never occur because a byte group
                    // has a minimum of 8 bits or two base64 characters.
                    return null;
                default:
                    temp = urlSafeBase64EncodedStr;
                    break;
            }
            result = temp.Replace("_", "/").Replace("-", "+");
            return result;
        }
    }
}
