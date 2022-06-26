﻿using GetSocial.API.MappingProfiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace GetSocial.API.Registrars
{
    public class MvcRegistrar : IWebAppBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
            builder.Services.AddVersionedApiExplorer(config =>
                {
                    config.GroupNameFormat = "'v'VVV";
                    config.SubstituteApiVersionInUrl = true;
                }
            );
            builder.Services.AddMvc(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
        }
    }
}
