using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Castle.Core.Internal;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = (type.GetMethod(method.Name) ?? throw new InvalidOperationException()).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            classAttributes.Add(new PerformanceAspect(10));
            return classAttributes.OrderBy(i => i.Priority).ToArray();
        }
    }
}