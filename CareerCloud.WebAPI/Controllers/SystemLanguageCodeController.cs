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
    public class SystemLanguageCodeController : ApiController
    {
        private SystemLanguageCodeLogic _logic;
        public SystemLanguageCodeController()
        {
            EFGenericRepository<SystemLanguageCodePoco> repo =
                new EFGenericRepository<SystemLanguageCodePoco>();
            _logic = new SystemLanguageCodeLogic(repo);
        }
        [HttpGet]
        [Route("languagecode/SystemLanguageCode")]
        [ResponseType(typeof(SystemCountryCodePoco))]
        public IHttpActionResult GetSystemLanguageCode(string SystemLanguageCode)
        {
            SystemLanguageCodePoco lc = _logic.Get(SystemLanguageCode);
            if (lc == null)
            {
                return NotFound();
            }
            return Ok(lc);
        }
        [HttpGet]
        [Route("languagecode")]
        [ResponseType(typeof(List<SystemLanguageCodePoco>))]
        public IHttpActionResult GetAllSystemLanguageCode()
        {
            var systems = _logic.GetAll();
            if (systems == null)
            {
                NotFound();
            }
            return Ok(systems);
        }

        [HttpPut]
        [Route("languagecode")]
        public IHttpActionResult PutSystemLanguageCode([FromBody]  SystemLanguageCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("languagecode")]

        public IHttpActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("languagecode")]

        public IHttpActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
