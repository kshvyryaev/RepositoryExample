using AutoMapper;

namespace RepositoryExample.Domain.Mapping
{
    public static class MapperFactory
    {
        public static IMapper GetInstance()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<EntitiesProfile>();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
