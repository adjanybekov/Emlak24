namespace Wohnungstausch24.Core.Models
{
    public class RangedInt : Ranged<int>
    {
        public override bool IsMaxSelected => To==Max || To==0;
        public override bool IsMinSelected => From==Min || From==0;
    }
}