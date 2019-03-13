using SSO.Api.Controllers.Base;
using SSO.Api.Filters;
using SSO.Domain.Interfaces.Repositories;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SSO.Api.Controllers
{
    ///<Summary>
    ///</Summary>
    [RoutePrefix("api/v1")]
    public class UserController : BaseController
    {
        ///<Summary>
        ///</Summary>
        [JwtAuthentication]
        [Route("getUsers")]       
        public Task<HttpResponseMessage> GetUsers()
        {
            try
            {
                var _userRepository = GetInstance<IUserRepository>();
                return CreateResponse(HttpStatusCode.OK, _userRepository.GetAll());
            }
            catch (Exception ex)
            {
               return CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
                   
        }
    }
}