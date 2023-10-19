using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scoring.Core.Interfaces;
using Scoring.Core.Interfaces.CalculatePreScoring;
using Scoring.Core.Services;
using Scoring.Core.Services.CalculatePreScoring;
using Scoring.Core.Services.CalculatePreScoring.ApproveRules;
using Scoring.Core.Services.CalculatePreScoring.DenyRules;
using Scoring.Logger;

namespace Colegiados.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDataProtection();

            //services
            services.AddTransient<ILlamadaService, LlamadaService>();
            services.AddTransient<IPreSolicitudRenting, PreSolicitudRenting>();
            services.AddTransient<IApprovePreRequestProcess, ApprovePreRequestProcess>();
            services.AddTransient<IDenyPreRequestProcess, DenyPreRequestProcess>();
            //Reglas de aprobación
            services.AddTransient<IApproveRule, InvestmentLowerNetIncomeRule>();
            services.AddTransient<IApproveRule, NationalityRule>();
            services.AddTransient<IApproveRule, InvestmentLowerThanLimitRule>();
            
            //Reglas de denegación
            services.AddTransient<IDenyRule, MinimalAgeRule>();


            services.AddTransient<ILogger, LoggerImpl>();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
