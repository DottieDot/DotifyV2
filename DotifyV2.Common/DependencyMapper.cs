using System;
using System.Linq;

namespace DotifyV2.Common
{
    public class DependencyMapper
    {
        IServiceProvider _serviceProvider;

        public DependencyMapper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Construct<T> (params object[] parameters) where T : class
        {
            var constructor = typeof(T).GetConstructors()[0];
            var services = constructor.GetParameters()
                .Skip(parameters.Length)
                .Select(param => _serviceProvider.GetService(param.GetType()));

            return constructor.Invoke(parameters.Concat(services).ToArray()) as T;
        }
    }
}
