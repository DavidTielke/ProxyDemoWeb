using Castle.DynamicProxy;

namespace ProxyDemoWeb.Interceptors
{
    public class AppenderInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            if (invocation.ReturnValue is string returnValue)
            {
                invocation.ReturnValue = returnValue + " + Proxy";
            }

        }
    }
}
