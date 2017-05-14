namespace Wohnungstausch24.Core.Models
{
    public class RangedDecimal : Ranged<decimal>
    {
        public override bool IsMaxSelected => To == Max || To == 0M;
        public override bool IsMinSelected => From == Min || From == 0M;
    }
}