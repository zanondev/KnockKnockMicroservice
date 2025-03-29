using System.Net.Http;

namespace KnockKnockMicroservice
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly string? _helloServiceUrl;

        public Startup(IConfiguration configuration,
            HttpClient httpClient)
        {
            Configuration = configuration;
            _helloServiceUrl = configuration.GetValue<string>("HelloServiceUrl");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddControllers();

            services.AddHttpClient("HelloServiceClient")
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(_helloServiceUrl);
                    client.Timeout = TimeSpan.FromSeconds(30);
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
