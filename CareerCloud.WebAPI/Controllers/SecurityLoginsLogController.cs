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
    public class SecurityLoginsLogController : ApiController
    {
        private SecurityLoginsLogLogic _logic;
        public SecurityLoginsLogController()
        {
            EFGenericRepository<SecurityLoginsLogPoco> repo =
                new EFGenericRepository<SecurityLoginsLogPoco>();
            _logic = new SecurityLoginsLogLogic(repo);
        }
        [HttpGet]
        [Route("loginslog/SecurityLoginsLogId")]
        [ResponseType(typeof(SecurityLoginsLogPoco))]
        public IHttpActionResult GetSecurityLoginLog(Guid SecurityLoginsLogId)
        {
            SecurityLoginsLogPoco sl = _logic.Get(SecurityLoginsLogId);
            if (sl == null)
            {
                return NotFound();
            }
            return Ok(sl);
        }
        [HttpGet]
        [Route("loginslog")]
        [ResponseType(typeof(List<SecurityLoginsLogPoco>))]
        public IHttpActionResult GetAllSecurityLogiLog()
        {
            var securities = _logic.GetAll();
            if (securities == null)
            {
                NotFound();
            }
            return Ok(securities);
        }

        [HttpPut]
        [Route("loginslog")]
        public IHttpActionResult PutSecurityLoginLog([FromBody]  SecurityLoginsLogPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("loginslog")]

        public IHttpActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("loginslog")]

        public IHttpActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
