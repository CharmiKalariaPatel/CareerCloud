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
    public class CompanyJobEducationController : ApiController
    {
        private CompanyJobEducationLogic _logic;
        public CompanyJobEducationController()
        {
            EFGenericRepository<CompanyJobEducationPoco> repo =
                new EFGenericRepository<CompanyJobEducationPoco>();
            _logic = new CompanyJobEducationLogic(repo);
        }
        [HttpGet]
        [Route("jobeducation/companyjobeducationId")]
        [ResponseType(typeof(CompanyJobEducationPoco))]
        public IHttpActionResult GetCompanyJobEducation(Guid companyjobeducationId)
        {
            CompanyJobEducationPoco cje = _logic.Get(companyjobeducationId);
            if (cje == null)
            {
                return NotFound();
            }
            return Ok(cje);
        }
        [HttpGet]
        [Route("jobeducation")]
        [ResponseType(typeof(List<CompanyJobEducationPoco>))]
        public IHttpActionResult GetAllCompanyJobEducation()
        {
            var companies = _logic.GetAll();
            if (companies == null)
            {
                NotFound();
            }
            return Ok(companies);
        }

        [HttpPut]
        [Route("jobeducation")]
        public IHttpActionResult PutCompanyJobEducation([FromBody]  CompanyJobEducationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("jobeducation")]

        public IHttpActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobeducation")]

        public IHttpActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
