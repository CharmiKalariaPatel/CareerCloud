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
    [RoutePrefix("api/careercloud/system/v1")]
    public class SystemCountryCodeController : ApiController
    {
        private SystemCountryCodeLogic _logic;
        public SystemCountryCodeController()
        {
            EFGenericRepository<SystemCountryCodePoco> repo =
                new EFGenericRepository<SystemCountryCodePoco>();
            _logic = new SystemCountryCodeLogic(repo);
        }
        [HttpGet]
        [Route("countrycode/SystemCountryCode")]
        [ResponseType(typeof(SystemCountryCodePoco))]
        public IHttpActionResult GetSystemCountryCode(string SystemCountryCode)
        {
            SystemCountryCodePoco sc = _logic.Get(SystemCountryCode);
            if (sc == null)
            {
                return NotFound();
            }
            return Ok(sc);
        }
        [HttpGet]
        [Route("countrycode")]
        [ResponseType(typeof(List<SystemCountryCodePoco>))]
        public IHttpActionResult GetAllSystemCountryCode()
        {
            var systems = _logic.GetAll();
            if (systems == null)
            {
                NotFound();
            }
            return Ok(systems);
        }

        [HttpPut]
        [Route("countrycode")]
        public IHttpActionResult PutSystemCountryCode([FromBody]  SystemCountryCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("countrycode")]

        public IHttpActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("countrycode")]

        public IHttpActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
