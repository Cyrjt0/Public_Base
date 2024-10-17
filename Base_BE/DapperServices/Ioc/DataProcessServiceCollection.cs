using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace DapperServices.DataProcess
{
    public static class DataProcessServiceCollection
    {
        public static void AddDataProcessServices(this IServiceCollection services)
        {
            var appConnection = $@"Server = xxxxxxxx\xxxxx; Database = xxxxx; User Id = sa; Password = xxxxx;Encrypt=True;TrustServerCertificate=True; Min Pool Size=5;Max Pool Size=100;Connection Timeout=30";
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(appConnection));
            services.AddScoped<IDapperUnitOfWork, DapperUnitOfWork>();
        }
    }
}
