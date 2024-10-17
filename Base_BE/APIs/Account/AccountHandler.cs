#pragma warning disable

using CommonServices;
using CommonServices.CommonServices;
using Dapper;
using DapperServices.DataProcess;

namespace APIs
{
    public class AccountHandler : IAccountHandler
    {
        private readonly ILogger<AccountHandler> _logger;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        ConvertLog cl = new ConvertLog();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dapperUnitOfWork"></param>
        public AccountHandler(ILogger<AccountHandler> logger, IDapperUnitOfWork dapperUnitOfWork)
        {
            _logger = logger;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public async Task<Response<bool>> CreateAccount(CreateUser model, string IpConnect)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                model.UsersPassword = AesEncryption.Encrypt(model.UsersPassword);
                param.Add("@usersAccount", model.UsersAccount);
                param.Add("@Password", model.UsersPassword);
                param.Add("@FullName", model.FullName);
                param.Add("@Address", model.Address);
                param.Add("@PhoneNumber", model.PhoneNumber);
                param.Add("@StateIDCard", model.StateIDCard);
                param.Add("@Email", model.Email);
                param.Add("@IsLock", model.IsLock);
                param.Add("@IsBlock", model.IsBlock);
                param.Add("@IsActive", model.IsActive);
                param.Add("@CreateTime", model.CreateTime);

                int outputResult= await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("CreateAccount", param, null);
                if (outputResult ==  StatusResult.CREATE_SUCCESS_CODE)
                {
                    return new Response<bool>(StatusResult.CREATE_SUCCESS_CODE, StatusResult.CREATE_SUCCESS_MESS, true);
                }
                if (outputResult == StatusResult.DUPPLICATE_USER_CODE)
                {
                    return new Response<bool>(StatusResult.DUPPLICATE_USER_CODE, StatusResult.DUPPLICATE_USER_MESS, true);
                }
                if (outputResult == StatusResult.DUPPLICATE_EMAIL_CODE)
                {
                    return new Response<bool>(StatusResult.DUPPLICATE_EMAIL_CODE, StatusResult.DUPPLICATE_EMAIL_MESS, true);
                }
                if (outputResult == StatusResult.DUPPLICATE_PHONE_CODE)
                {
                    return new Response<bool>(StatusResult.DUPPLICATE_PHONE_CODE, StatusResult.DUPPLICATE_PHONE_MESS, true);
                }
                if (outputResult == StatusResult.DUPPLICATE_STATEIDCARD_CODE)
                {
                    return new Response<bool>(StatusResult.DUPPLICATE_STATEIDCARD_CODE, StatusResult.DUPPLICATE_STATEIDCARD_MESS, true);
                }
                return new Response<bool>(StatusResult.FAIL_CODE, StatusResult.FAIL_MESS, true);
            }
            catch (Exception ex)
            {
                var error = cl.ReturnLog("CreateAccount", ex.Message, IpConnect);
                _logger.LogCritical(error);
                return new Response<bool>(StatusResult.FAIL_CODE, StatusResult.FAIL_MESS, true);
            }
        }
    }
}
