using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites;

namespace Wohnungstausch24.Migrations.Configurations
{
    public class Wt24FileConfiguration:CustomEntityTypeConfiguration<Wt24File>
    {
        public Wt24FileConfiguration()
        {
            this.Property(c => c.Name).IsRequired().HasMaxLength(300);
            this.Property(c => c.ContentLengthInBytes).IsRequired();
            this.Property(c => c.Mime).IsRequired().HasMaxLength(100);
            this.Property(c => c.RelativePath).IsRequired().HasMaxLength(300);
            this.Property(c => c.ThumbnailPath).IsOptional().HasMaxLength(300);
            this.Property(c => c.Extension).IsOptional().HasMaxLength(30);
        }
    }
}
