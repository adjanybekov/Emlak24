namespace Wohnungstausch24.Core.TypeMapping
{
    public interface IAutoMapper
    {
        T Map<T>(object objectToMap);

        T2 Map<T1, T2>(T1 objectToMap1, T2 objectToMap2);
    }
}