using AutoMapper;

namespace Wohnungstausch24.Core.TypeMapping
{
    public class AutoMapperAdapter : IAutoMapper
    {
        public T Map<T>(object objectToMap)
        {
            return Mapper.Map<T>(objectToMap);
        }

        public T2 Map<T1, T2>(T1 objectToMap1, T2 objectToMap2)
        {
            return Mapper.Map(objectToMap1, objectToMap2);
        }
    }
}