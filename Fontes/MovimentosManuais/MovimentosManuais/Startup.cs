using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovimentosDominio.Interfaces;
using MovimentosInfraestrutura.Contexto;
using MovimentosInfraestrutura.Repositorio;
using MovimentosManuais.Models;
using MovimentosServicos.Servicos;

namespace MovimentosManuais
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var connection = Configuration["ConexaoSql:SqlConnectionString"];
            services.AddDbContext<ContextoAplicacao>(options =>
                options.UseSqlServer(connection)
            );
            //Mapeamentos Inject
            services.AddScoped<IServico<Produto>, BaseServico<Produto>>();
            services.AddScoped<IRepositorio<Produto>, BaseRepositorio<Produto>>();
            services.AddScoped<IServico<ProdutoCosif>, BaseServico<ProdutoCosif>>();
            services.AddScoped<IRepositorio<ProdutoCosif>, BaseRepositorio<ProdutoCosif>>();
            services.AddScoped<IServico<MovimentoManual>, MovimentoManualServico>();
            services.AddScoped<IRepositorio<MovimentoManual>, BaseRepositorio<MovimentoManual>>();
            services.AddScoped<IServico<MovimentoManualProduto>, BaseServico<MovimentoManualProduto>>();
            services.AddScoped<IRepositorio<MovimentoManualProduto>, ListaRepositorio<MovimentoManualProduto>>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/MovimentoManual/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=MovimentoManual}/{action=Incluir}");
            });
        }
    }
}
