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
    public class ApplicantJobApplicationController : ApiController
    {
        private ApplicantJobApplicationLogic _logic;
        public ApplicantJobApplicationController()
        {
            EFGenericRepository<ApplicantJobApplicationPoco> repo =
               new EFGenericRepository<ApplicantJobApplicationPoco>();
            _logic = new ApplicantJobApplicationLogic(repo);
        }

        [HttpGet]
        [Route("jobapplication/applicantjobapplicationId")]
        [ResponseType(typeof(ApplicantJobApplicationPoco))]
        public IHttpActionResult GetApplicantJobApplication(Guid applicantjobapplicationId)
        {
            ApplicantJobApplicationPoco appjob = _logic.Get(applicantjobapplicationId);
            if (appjob == null)
            {
                return NotFound();
            }
            return Ok(appjob);
        }
        [HttpGet]
        [Route("jobapplication")]
        [ResponseType(typeof(List<ApplicantJobApplicationPoco>))]
        public IHttpActionResult GetAllApplicantJobApplication()
        {
            var applicants = _logic.GetAll();
            if (applicants == null)
            {
                NotFound();
            }
            return Ok(applicants);
        }

        [HttpPut]
        [Route("jobapplication")]
        public IHttpActionResult PutApplicantJobApplication([FromBody]  ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("jobapplication")]

        public IHttpActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobapplication")]

        public IHttpActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
