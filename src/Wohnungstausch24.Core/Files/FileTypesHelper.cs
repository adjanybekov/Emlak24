using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Wohnungstausch24.Core.Files
{
    public static class FileTypesHelper
    {
        public static readonly List<string> ImageExtensions = new List<string> {
            ".jpg",
            ".jpe",
            ".bmp",
            ".gif",
            ".png",
            ".jpeg",
            ".pjpeg",
            ".xpng"
        };
        public static readonly List<string> VideoExtensions = new List<string>
        {
            ".avi",
            ".flv",
            ".mpeg",
            ".mp4",
            ".wmv",
            ".mov",
            ".mkv",
            ".h264",
            ".webm",
            ".m4v",
            ".3gp",
            ".mpg4"
        };
        public static readonly List<string> DocumentExtensions = new List<string>
        {
            ".doc",
            ".docx",
            ".odt",
            ".rtf",
            ".pps",
            ".ppt",
            ".pptx",
            ".xlr",
            ".xls",
            ".xlsx",
            ".dwg",
            ".dxf",
            ".7z",
            ".rar",
            ".zip",
            ".zipx"
        };

        public static Wt24FileType FindTypeByExtension(string fullFileName)
        {
            var ext = Path.GetExtension(fullFileName);
            if (!string.IsNullOrEmpty(ext))
            {
                if(ImageExtensions.Any(c => c.ToLower().Equals(ext.ToLower())))
                    return Wt24FileType.Image;
                if(VideoExtensions.Any(c => c.Equals(ext)))
                    return Wt24FileType.Video;
            }
            return Wt24FileType.Document;
        }



        /// <summary>
        /// Gets File mime type
        /// </summary>
        /// <param name="fullFilename"></param>
        /// <returns>mime</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetMimeFromFile(string fullFilename)
        {
            if (!File.Exists(fullFilename))
                throw new FileNotFoundException(fullFilename + " not found");
            string extension = Path.GetExtension(fullFilename)?.ToLower();

            if (extension != null && extension.StartsWith("."))
            {
                extension = extension.ReplaceFirst(".","");
            }

            string mime;

            if (extension != null && KnownFileTypes.MimeTypes.TryGetValue(extension, out mime))
                return mime;
            if (GetWindowsMimeType(extension, out mime))
            {
                if (extension != null) KnownFileTypes.MimeTypes.Add(extension, mime);
                return mime;
            }
            return "application/octet-stream";

        }

        public static bool GetWindowsMimeType(string ext, out string mime)
        {
            mime = "application/octet-stream";
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);

            if (regKey != null)
            {
                object val = regKey.GetValue("Content Type");
                if (val != null)
                {
                    string strval = val.ToString();
                    if (!(string.IsNullOrEmpty(strval) || string.IsNullOrWhiteSpace(strval)))
                    {
                        mime = strval;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
