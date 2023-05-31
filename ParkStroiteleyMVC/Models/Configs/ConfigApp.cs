using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.Configs
{
    public static class ConfigApp
    {
        public static string AppVersion = "1.0.0";
        public static string AppVersionName = "StartDebug";
        #region [ImagesPath]
        public static string AppImageMainDirectory = "/content/img/";
        public static string AppGalleryMainDirectory = "/content/gallery/";
        //Not usage
        public static string AppImageMedium = "medium\\";
        //Not usage
        public static string AppImageLow = "low\\";
        #endregion
    }
}
