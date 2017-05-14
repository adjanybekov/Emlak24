namespace Wohnungstausch24.Models.ViewModels.Location
{
    public abstract class BaseModelWithId<T>
    {
        public virtual T Id { get; set; }
        public bool Selected { get; set; }
    }
}
