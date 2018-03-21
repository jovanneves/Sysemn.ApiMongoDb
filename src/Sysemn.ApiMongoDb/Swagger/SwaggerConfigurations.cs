using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.DependencyInjection;

namespace Sysemn.ApiMongoDb.Swagger
{
    public static class SwaggerConfigurations
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Sysemn.ApiMongoDb",
                    Description = "Exemplo de uso de MongoDb com AspNet Core WebApi.",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Jovan Oliveira Neves", Email = "jovan_emn@outlook.com", Url = "https://github.com/jovanemn" },
                    License = new License { Name = "MIT", Url = "https://github.com/jovanemn" }
                });
            });

        }
    }
}
