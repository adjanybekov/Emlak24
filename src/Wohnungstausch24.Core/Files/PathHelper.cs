using System;
using System.IO;
using System.Web;

namespace Wohnungstausch24.Core.Files
{
    public class PathHelper
    {
        private static readonly string RootUploadFolder = Path.Combine(Path.DirectorySeparatorChar.ToString(),"Uploads");
        private static readonly string Files = "Files";
        private static readonly string Thumbs = "Thumbs";

        public static string GetUploadRelativePath(int listingId)
        {
            var userUploadFullPath = Path.Combine(
                RootUploadFolder,
                Files,
                DateTime.Now.Year.ToString(),
                DateTime.Now.Month.ToString(),
                DateTime.Now.Day.ToString(), listingId.ToString());

            CreateDrectoryIfNotExists(userUploadFullPath);
            return userUploadFullPath;
        }
        public static string GetUploadRelativePath(string userId)
        {
            var userUploadFullPath = Path.Combine(RootUploadFolder,Files,DateTime.Now.Year.ToString(),DateTime.Now.Month.ToString(),DateTime.Now.Day.ToString(), userId);
            CreateDrectoryIfNotExists(userUploadFullPath);
            return userUploadFullPath;
        }
        private static void CreateDrectoryIfNotExists(string path)
        {
            var fullPath = HttpContext.Current.Server.MapPath(path);
            if (!Directory.Exists(fullPath)) Directory.CreateDirectory(fullPath);
        }

        public static string GetUploadThumbRelativePath(int listingId)
        {
            var userUploadFullPath = Path.Combine(
                RootUploadFolder,
                Thumbs,
                DateTime.Now.Year.ToString(),
                DateTime.Now.Month.ToString(),
                DateTime.Now.Day.ToString(), listingId.ToString());

            CreateDrectoryIfNotExists(userUploadFullPath);
            return userUploadFullPath;
        }
        public static string GetUploadThumbRelativePath(string userId)
        {
            var userUploadFullPath = Path.Combine(
                RootUploadFolder,
                Thumbs,
                DateTime.Now.Year.ToString(),
                DateTime.Now.Month.ToString(),
                DateTime.Now.Day.ToString(), userId);

            CreateDrectoryIfNotExists(userUploadFullPath);
            return userUploadFullPath;
        }
    }
}
