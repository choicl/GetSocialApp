using GetSocial.API.Options;

namespace GetSocial.API.Registrars
{
    public class SwaggerRegistrars : IWebAppBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
            builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
        }
    }
}
