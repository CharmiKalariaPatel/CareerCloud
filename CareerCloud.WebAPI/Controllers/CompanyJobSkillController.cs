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
    public class CompanyJobSkillController : ApiController
    {
        private CompanyJobSkillLogic _logic;
        public CompanyJobSkillController()
        {
            EFGenericRepository<CompanyJobSkillPoco> repo =
                new EFGenericRepository<CompanyJobSkillPoco>();
            _logic = new CompanyJobSkillLogic(repo);
        }
        [HttpGet]
        [Route("jobskill/companyjobskillId")]
        [ResponseType(typeof(CompanyJobSkillPoco))]
        public IHttpActionResult GetCompanyJobSkill(Guid companyjobskillId)
        {
            CompanyJobSkillPoco cjs = _logic.Get(companyjobskillId);
            if (cjs == null)
            {
                return NotFound();
            }
            return Ok(cjs);
        }
        [HttpGet]
        [Route("jobskill")]
        [ResponseType(typeof(List<CompanyJobSkillPoco>))]
        public IHttpActionResult GetAllCompanyJobSkill()
        {
            var companies = _logic.GetAll();
            if (companies == null)
            {
                NotFound();
            }
            return Ok(companies);
        }

        [HttpPut]
        [Route("jobskill")]
        public IHttpActionResult PutCompanyJobSkill([FromBody]  CompanyJobSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("jobskill")]

        public IHttpActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobskill")]

        public IHttpActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
