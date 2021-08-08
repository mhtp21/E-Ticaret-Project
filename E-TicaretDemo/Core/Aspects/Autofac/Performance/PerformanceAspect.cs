using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Core.Utilities.IoC;
using Core.Utilities.Interceptors;
using Core.Utilities.Email;
using Core.Utilities.Email.Mailkit;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private readonly int _interval;
        private readonly Stopwatch _stopwatch;
        private readonly IEMailService _mailService;
        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _mailService = ServiceTool.ServiceProvider.GetService<IEMailService>();
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} ---------> {_stopwatch.Elapsed.TotalSeconds}");
                _mailService.Send("E-Commerce Performance Issue Dedecte",
                    $"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} -------> {_stopwatch.Elapsed.TotalSeconds}", null);
            }

            _stopwatch.Reset();
        }
    }
}
