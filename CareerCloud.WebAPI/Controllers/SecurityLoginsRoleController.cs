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
    public class SecurityLoginsRoleController : ApiController
    {

        private SecurityLoginsRoleLogic _logic;
        public SecurityLoginsRoleController()
        {
            EFGenericRepository<SecurityLoginsRolePoco> repo =
                new EFGenericRepository<SecurityLoginsRolePoco>();
            _logic = new SecurityLoginsRoleLogic(repo);
        }
        [HttpGet]
        [Route("loginsrole/SecurityLoginsRoleId")]
        [ResponseType(typeof(SecurityLoginsRolePoco))]
        public IHttpActionResult GetSecurityLoginsRole(Guid SecurityLoginsRoleId)
        {
            SecurityLoginsRolePoco slr = _logic.Get(SecurityLoginsRoleId);
            if (slr == null)
            {
                return NotFound();
            }
            return Ok(slr);
        }
        [HttpGet]
        [Route("loginsrole")]
        [ResponseType(typeof(List<SecurityLoginsRolePoco>))]
        public IHttpActionResult GetAllSecurityLoginsRole()
        {
            var securities = _logic.GetAll();
            if (securities == null)
            {
                NotFound();
            }
            return Ok(securities);
        }

        [HttpPut]
        [Route("loginsrole")]
        public IHttpActionResult PutSecurityLoginsRole([FromBody]  SecurityLoginsRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("loginsrole")]

        public IHttpActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("loginsrole")]

        public IHttpActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
