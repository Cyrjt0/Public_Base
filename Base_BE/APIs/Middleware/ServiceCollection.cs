#pragma warning disable

using DapperServices.DataProcess;

namespace APIs.Middleware
{
    public static class ServiceCollection
    {
        /// <summary>
        /// Đăng ký các services khi khởi tạo
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void RegisterIoCs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddDataProcessServices();
            services.AddScoped<IAccountHandler, AccountHandler>();

        }
    }
}
