using Wohnungstausch24.Core.Files;
using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites
{
    public class Wt24File:Entity<int>
    {
        public string RelativePath { get; set; }
        public string Name { get; set; }
        public string Mime { get; set; }
        public int ContentLengthInBytes { get; set; }
        public string ThumbnailPath { get; set; }
        public Wt24FileType Filetype { get; set; }
        public string Extension { get; set; }
    }
}
