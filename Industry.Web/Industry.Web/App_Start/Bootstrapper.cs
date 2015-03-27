using Industry.Web.Mapping;

namespace Industry.Web
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