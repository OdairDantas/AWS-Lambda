using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using fipe.Contracts;
using Microsoft.Extensions.DependencyInjection;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace fipe
{
    [ExcludeFromCodeCoverage]
    public class Function
    {
        
        /// <summary>
        /// Simples função para buscar fabricantes automotivos.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<ResponseRequest> FunctionHandler(ILambdaContext context)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            return await serviceProvider.GetService<App>().Run();

        }
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<App>();
        }
    }
}
