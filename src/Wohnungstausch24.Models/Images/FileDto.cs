using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Core.Files;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Images
{
    public class FileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Length { get; set; }
        public string FileUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public Wt24FileType Filetype { get; set; }
        public string Mime { get; set; }
        public string Extension { get; set; }
    }
}
