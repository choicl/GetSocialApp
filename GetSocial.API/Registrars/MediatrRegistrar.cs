using GetSocial.Application.UserProfiles.Queries;
using MediatR;

namespace GetSocial.API.Registrars
{
    public class MediatrRegistrar : IWebAppBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program),typeof(GetAllUserProfilesQuery));
            builder.Services.AddMediatR(typeof(GetAllUserProfilesQuery));
        }
    }
}
