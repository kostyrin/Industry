using Industry.Front.Core.Mapping;

namespace Industry.Front.API
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }
    }
}