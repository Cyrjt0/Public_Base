using CommonServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace APIs.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IAccountHandler _IAccountHandler;
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController
        (
            IAccountHandler IAccountHandler,
            ILogger<AccountController> logger,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _IAccountHandler = IAccountHandler;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Tạo tài khoản.
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : application/json
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {        
        ///         "UsersAccount": "admmin",
        ///         "UsersPassword":"123456",
        ///         "FullName":"CuongNH",
        ///         "Address":"Hà Nội",
        ///         "PhoneNumber":"123456",
        ///         "StateIDCard":"123456",
        ///         "Email":"123456@gmail.com",
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        public async Task<Response<bool>> Create(CreateUser entity)
        {
            string clientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return await _IAccountHandler.CreateAccount(entity, clientIpAddress);
        }

    }
}
