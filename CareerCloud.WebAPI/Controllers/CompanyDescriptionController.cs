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
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyDescriptionController : ApiController
    {
        private CompanyDescriptionLogic _logic;
        public CompanyDescriptionController()
        {
            EFGenericRepository<CompanyDescriptionPoco> repo =
                new EFGenericRepository<CompanyDescriptionPoco>();
            _logic = new CompanyDescriptionLogic(repo);
        }
        [HttpGet]
        [Route("description/companydescriptionId")]
        [ResponseType(typeof(CompanyDescriptionPoco))]
        public IHttpActionResult GetCompanyDescription(Guid companydescriptionId)
        {
            CompanyDescriptionPoco cd = _logic.Get(companydescriptionId);
            if (cd == null)
            {
                return NotFound();
            }
            return Ok(cd);
        }
        [HttpGet]
        [Route("description")]
        [ResponseType(typeof(List<CompanyDescriptionPoco>))]
        public IHttpActionResult GetAllCompanyDescription()
        {
            var companies = _logic.GetAll();
            if (companies == null)
            {
                NotFound();
            }
            return Ok(companies);
        }

        [HttpPut]
        [Route("description")]
        public IHttpActionResult PutCompanyDescription([FromBody]  CompanyDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("description")]

        public IHttpActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("description")]

        public IHttpActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
