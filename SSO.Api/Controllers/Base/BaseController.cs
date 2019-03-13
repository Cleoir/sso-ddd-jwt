using SSO.CrossCutting.Factory;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using NLog;
using Newtonsoft.Json;
using SSO.Domain.Interfaces.Repositories;

namespace SSO.Api.Controllers.Base
{
    /// <summary>
    /// </summary>
    public abstract class BaseController : ApiController
    {
        private HttpResponseMessage responseMessage;
        private Logger log;
        /// <summary>
        /// </summary>
        public BaseController()
        {
           responseMessage = new HttpResponseMessage();
           log = LogManager.GetLogger("fileLogger");
        }

        /// <summary>
        /// </summary>
        [NonAction]
        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            if(code != HttpStatusCode.OK)
                log.Error(JsonConvert.SerializeObject(result), "Error!");

            responseMessage = Request.CreateResponse(code, result);
            return Task.FromResult(responseMessage);
        }
        /// <summary>
        /// </summary>
        public T GetInstance<T>()
        {
            return Factory.GetInstance<T>();
        }

        ///<Summary>
        ///</Summary>
        protected override void Dispose(bool disposing)
        {
            var _userRepository = GetInstance<IUserRepository>();
            _userRepository.Dispose(disposing);
        }
    }
}
