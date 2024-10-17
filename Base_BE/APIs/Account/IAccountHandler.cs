#pragma warning disable

using CommonServices;

namespace APIs
{
    public interface IAccountHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Response<bool>> CreateAccount(CreateUser model, string IpConnect);
    }
}
