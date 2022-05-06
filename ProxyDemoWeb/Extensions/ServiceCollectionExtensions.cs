using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using ProxyDemoWeb.Interceptors;

namespace ProxyDemoWeb
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTransientWithProxies<TContract, TImplementation>(this IServiceCollection source)
            where TImplementation : class, TContract
            where TContract : class
        {
            source.AddTransient<TContract>(sp =>
            {
                var service = ActivatorUtilities.CreateInstance<TImplementation>(sp);

                var proxyGenerator = sp.GetService<IProxyGenerator>();

                var proxy = proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TContract), service, new AppenderInterceptor());

                return proxy as TContract;
            });
        }
    }
}