using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/security/v1")]
    public class SecurityLoginController : ApiController
    {
        private SecurityLoginLogic _logic;
        public SecurityLoginController()
        {
            EFGenericRepository<SecurityLoginPoco> repo =
                new EFGenericRepository<SecurityLoginPoco>();
            _logic = new SecurityLoginLogic(repo);
        }
        [HttpGet]
        [Route("login/SecurityLoginId")]
        [ResponseType(typeof(SecurityLoginPoco))]
        public IHttpActionResult GetSecurityLogin(Guid SecurityLoginId)
        {
            SecurityLoginPoco sl = _logic.Get(SecurityLoginId);
            if (sl == null)
            {
                return NotFound();
            }
            return Ok(sl);
        }
        [HttpGet]
        [Route("login")]
        [ResponseType(typeof(List<SecurityLoginPoco>))]
        public IHttpActionResult GetAllSecurityLogin()
        {
            var securities = _logic.GetAll();
            if (securities == null)
            {
                NotFound();
            }
            return Ok(securities);
        }

        [HttpPut]
        [Route("login")]
        public IHttpActionResult PutSecurityLogin([FromBody]  SecurityLoginPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("login")]

        public IHttpActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("login")]

        public IHttpActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
