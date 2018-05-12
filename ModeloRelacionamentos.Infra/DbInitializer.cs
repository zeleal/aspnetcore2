using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ModeloRelacionamentos.Infra
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                ApplicationContext context = serviceScope.ServiceProvider.GetService<ApplicationContext>();
                
                //context.SaveChanges();
            }
        }
    }
}
