﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Core.Utilities.Email;
using Core.Utilities.Email.Mailkit;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IEMailService, EMailService>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
