namespace Wohnungstausch24.Models.Entites.Base
{
    public abstract class Entity<T> : EntityBase, IEntityBase<T>
    {
        public virtual T Id { get; set; }
    }
}
