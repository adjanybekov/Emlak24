namespace Wohnungstausch24.Models.Entites.Base
{
    public class EntityEnumBase<T> : Entity<int> where T : struct
    {
        public T Value { get; set; }

        public string Name { get; set; }
    }
}
