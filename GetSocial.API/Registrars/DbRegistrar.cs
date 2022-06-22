using GetSocial.DAL;
using Microsoft.EntityFrameworkCore;

namespace GetSocial.API.Registrars
{
    public class DbRegistrar : IWebAppBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(cs));
        }
    }
}
