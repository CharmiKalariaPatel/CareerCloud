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
    public class CompanyJobController : ApiController
    {
        private CompanyJobLogic _logic;
        public CompanyJobController()
        {
            EFGenericRepository<CompanyJobPoco> repo =
                new EFGenericRepository<CompanyJobPoco>();
            _logic = new CompanyJobLogic(repo);
        }
        [HttpGet]
        [Route("job/companyjobId")]
        [ResponseType(typeof(CompanyJobPoco))]
        public IHttpActionResult GetCompanyJob(Guid companyjobId)
        {
            CompanyJobPoco cj = _logic.Get(companyjobId);
            if (cj == null)
            {
                return NotFound();
            }
            return Ok(cj);
        }
        [HttpGet]
        [Route("job")]
        [ResponseType(typeof(List<CompanyJobPoco>))]
        public IHttpActionResult GetAllCompanyJob()
        {
            var companies = _logic.GetAll();
            if (companies == null)
            {
                NotFound();
            }
            return Ok(companies);
        }

        [HttpPut]
        [Route("job")]
        public IHttpActionResult PutCompanyJob([FromBody]  CompanyJobPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("job")]

        public IHttpActionResult PostCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("job")]

        public IHttpActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
