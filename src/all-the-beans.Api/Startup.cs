using all_the_beans.Data.Extensions;
using all_the_beans.Logic.Extensions;

namespace all_the_beans.Api
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // register db contexts
            services.AddDbCoffeeBeanContext();

            // register repositories
            services.AddCoffeeBeanRepositories();

            // register commands
            services.AddCoffeeBeanCommands();

            // register queries
            services.AddCoffeeBeanQueries();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
