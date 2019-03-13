using NLog;
using SSO.Api.Controllers.Base;
using SSO.Domain.Interfaces.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SSO.Api.Controllers
{
    ///<Summary>
    ///</Summary>
    [RoutePrefix("api/v2")]
    public class TokenController : BaseController
    {
        /// <summary>
        /// Parameter username and password.
        /// </summary>
        /// <remarks>
        /// Return token.
        /// </remarks>
        [AllowAnonymous]
        [Route("get")]
        [HttpGet]
        public Task<HttpResponseMessage> Get(string username, string password)
        {
            var _userService = GetInstance<IUserService>();

            try
            {
                if (_userService.CheckUser(username, password))
                   return CreateResponse(HttpStatusCode.OK, JwtManager.GenerateToken(username));

                return CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized access");
            }
            catch (Exception ex)
            {
               return CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
