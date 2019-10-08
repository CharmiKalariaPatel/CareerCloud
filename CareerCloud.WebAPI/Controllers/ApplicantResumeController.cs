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
    public class ApplicantResumeController : ApiController
    {
        private ApplicantResumeLogic _logic;
        public ApplicantResumeController()
        {
            EFGenericRepository<ApplicantResumePoco> repo =
                new EFGenericRepository<ApplicantResumePoco>();
            _logic = new ApplicantResumeLogic(repo);
        }
        [HttpGet]
        [Route("resume/applicantResumeId")]
        [ResponseType(typeof(ApplicantResumePoco))]
        public IHttpActionResult GetApplicantResume(Guid applicantResumeId)
        {
            ApplicantResumePoco appRe = _logic.Get(applicantResumeId);
            if (appRe == null)
            {
                return NotFound();
            }
            return Ok(appRe);
        }
        [HttpGet]
        [Route("resume")]
        [ResponseType(typeof(List<ApplicantResumePoco>))]
        public IHttpActionResult GetAllApplicantResume()
        {
            var applicants = _logic.GetAll();
            if (applicants == null)
            {
                NotFound();
            }
            return Ok(applicants);
        }

        [HttpPut]
        [Route("resume")]
        public IHttpActionResult PutApplicantResume([FromBody]  ApplicantResumePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("resume")]

        public IHttpActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("resume")]

        public IHttpActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
