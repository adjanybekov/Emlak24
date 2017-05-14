using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites
{
    public class Language:Entity<int>
    {

        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }

        public string LanguageCulture { get; set; }
        public LanguageLevel Level { get; set; }
    }
}