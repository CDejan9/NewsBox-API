﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjekatASP.Application.CommandsProjekat.KategorijaCommands;
using ProjekatASP.Application.CommandsProjekat.KomentarCommand;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands;
using ProjekatASP.Application.CommandsProjekat.UlogaCommands;
using ProjekatASP.Application.CommandsProjekat.VestCommands;
using ProjekatASP.EfCommands.KategorijaCommands;
using ProjekatASP.EfCommands.KomentarCommands;
using ProjekatASP.EfCommands.KorisnikCommands;
using ProjekatASP.EfCommands.UlogaCommands;
using ProjekatASP.EfCommands.VestCommand;

namespace ProjekatAsp.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext <ProjekatASPContext>();
            
            /*Kategorija*/
            services.AddTransient<IAddKategorijaCommand, EFAddKategorijaCommand>();
            services.AddTransient<IGetKategorijeCommand, EFGetKategorijeCommand>();
            services.AddTransient<IGetKategorijaCommand, EFGetKategorijaCommand>();
            services.AddTransient<IDeleteKategorijaCommand, EFDeleteKategorijaCommand>();
            services.AddTransient<IEditKategorijaCommand, EFEditKategorijaCommand>();

            /*Uloga*/
            services.AddTransient<IAddUlogaCommand, EFAddUlogaCommand>();
            services.AddTransient<IGetUlogeCommand, EFGetUlogeCommand>();
            services.AddTransient<IGetUlogaCommand, EFGetUlogaCommand>();
            services.AddTransient<IDeleteUlogaCommand, EFDeleteUlogaCommand>();
            services.AddTransient<IEditUlogaCommand, EFEditUlogaCommand>();

            /*Korisnik*/
            services.AddTransient<IAddKorisnikCommand, EFAddKorisnikCommand>();
            services.AddTransient<IGetKorisniciCommand, EFGetKorisniciCommand>();
           


            /*Vest*/
            services.AddTransient<IAddVestCommand, EFAddVestCommand>();
            services.AddTransient<IGetVestiCommand, EFGetVestiCommand>();
            services.AddTransient<IGetVestCommand, EFGetVestCommand>();

            /*Komentar*/
            services.AddTransient<IAddKomentarCommand, EFAddKomentarCommand>();
            services.AddTransient<IDeleteKomentarCommand, EFDeleteKomentarCommand>();
            services.AddTransient<IEditKomentarCommand, EFEditKomentarCommand>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();
        }
    }
}
