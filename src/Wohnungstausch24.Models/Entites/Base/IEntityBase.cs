namespace Wohnungstausch24.Models.Entites.Base
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
    }
}
