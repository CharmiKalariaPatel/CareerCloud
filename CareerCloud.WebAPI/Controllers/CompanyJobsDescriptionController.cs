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
    public class CompanyJobsDescriptionController : ApiController
    {
        private CompanyJobDescriptionLogic _logic;
        public CompanyJobsDescriptionController()
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo =
                new EFGenericRepository<CompanyJobDescriptionPoco>();
            _logic = new CompanyJobDescriptionLogic(repo);
        }
        [HttpGet]
        [Route("jobdescription/companyjobdescriptionId")]
        [ResponseType(typeof(CompanyJobDescriptionPoco))]
        public IHttpActionResult GetCompanyJobsDescription(Guid companyjobdescriptionId)
        {
            CompanyJobDescriptionPoco cjd = _logic.Get(companyjobdescriptionId);
            if (cjd == null)
            {
                return NotFound();
            }
            return Ok(cjd);
        }
        [HttpGet]
        [Route("jobdescription")]
        [ResponseType(typeof(List<CompanyJobDescriptionPoco>))]
        public IHttpActionResult GetAllCompanyJobDescription()
        {
            var companies = _logic.GetAll();
            if (companies == null)
            {
                NotFound();
            }
            return Ok(companies);
        }

        [HttpPut]
        [Route("jobdescription")]
        public IHttpActionResult PutCompanyJobsDescription([FromBody]  CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("jobdescription")]

        public IHttpActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobdescription")]

        public IHttpActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
