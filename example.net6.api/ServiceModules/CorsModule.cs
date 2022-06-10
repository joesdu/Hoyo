﻿using Hoyo.AutoDependencyInjectionModule.Extensions;
using Hoyo.AutoDependencyInjectionModule.Modules;

namespace example.net6.api;

public class CorsModule : AppModule
{
    //private CorsModule()
    //{
    //    // 使模块在自动注入的时候忽略.
    //    Enable = false;
    //}

    public override void ConfigureServices(ConfigureServicesContext context)
    {
        var config = context.Services.GetConfiguration();
        var allow = config["AllowedHosts"] ?? "*";
        _ = context.Services.AddCors(c => c.AddPolicy("AllowedHosts", s => s.WithOrigins(allow.Split(",")).AllowAnyMethod().AllowAnyHeader()));
    }

    public override void ApplicationInitialization(ApplicationContext context)
    {
        var app = context.GetApplicationBuilder();
        _ = app.UseCors("AllowedHosts");
    }
}