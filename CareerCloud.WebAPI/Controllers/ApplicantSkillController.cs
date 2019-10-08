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
    [RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantSkillController : ApiController
    {
        private ApplicantSkillLogic _logic;
        public ApplicantSkillController()
        {
            EFGenericRepository<ApplicantSkillPoco> repo = new
            EFGenericRepository<ApplicantSkillPoco>();
            _logic = new ApplicantSkillLogic(repo);
        }
        [HttpGet]
        [Route("skill/applicantskillId")]
        [ResponseType(typeof(ApplicantSkillPoco))]
        public IHttpActionResult GetApplicantSkill(Guid applicantskillId)
        {
            ApplicantSkillPoco appskill = _logic.Get(applicantskillId);
            if (appskill == null)
            {
                return NotFound();
            }
            return Ok(appskill);
        }
        [HttpGet]
        [Route("skill")]
        [ResponseType(typeof(List<ApplicantSkillPoco>))]
        public IHttpActionResult GetAllApplicantSkill()
        {
            var applicants = _logic.GetAll();
            if (applicants == null)
            {
                NotFound();
            }
            return Ok(applicants);
        }

        [HttpPut]
        [Route("Skill")]
        public IHttpActionResult PutApplicantSkill([FromBody]  ApplicantSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("skill")]

        public IHttpActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("skill")]

        public IHttpActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
