using ParkStroiteleyMVC.Models.Configs;
using ParkStroiteleyMVC.Models.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.Extensions
{
    public static class StringExtension
    {
        public static string ToPreview(this string str)
        {
            if (str.Length > 95)
            {
                str = str.Substring(0, 98) + ". . .";
                return str;
            }
            else
            {
                return str + ". . .";
            }
        }
        public static int ToInt(this string str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(this string str)
        {
            try
            {
                return Convert.ToDouble(str.Replace(".", ","));
            }
            catch
            {
                return 0;
            }
        }

        public static string GetFullPathImg(this string nameImg, ImageSizeType sizeType)
        {
            return $"{ConfigApp.AppImageMainDirectory}{sizeType.GetEnumMemberAttributeValue()}/{nameImg}";
        }
        public static string GetFullPathGallery(this string nameImg, ImageSizeType sizeType)
        {
            return $"{ConfigApp.AppGalleryMainDirectory}{sizeType.GetEnumMemberAttributeValue()}/{nameImg}";
        }
    }
}
