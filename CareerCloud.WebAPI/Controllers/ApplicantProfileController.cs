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
    public class ApplicantProfileController : ApiController
    {

        private ApplicantProfileLogic _logic;
        public ApplicantProfileController()
        {
            EFGenericRepository<ApplicantProfilePoco> repo =
                new EFGenericRepository<ApplicantProfilePoco>();
            _logic = new ApplicantProfileLogic(repo);
        }
        [HttpGet]
        [Route("profile/applicantprofileId")]
        [ResponseType(typeof(ApplicantProfilePoco))]
        public IHttpActionResult GetApplicantProfile(Guid applicantprofileId)
        {
            ApplicantProfilePoco apppro = _logic.Get(applicantprofileId);
            if (apppro == null)
            {
                return NotFound();
            }
            return Ok(apppro);
        }
        [HttpGet]
        [Route("profile")]
        [ResponseType(typeof(List<ApplicantProfilePoco>))]
        public IHttpActionResult GetAllApplicantProfile()
        {
            var applicants = _logic.GetAll();
            if (applicants == null)
            {
                NotFound();
            }
            return Ok(applicants);
        }

        [HttpPut]
        [Route("profile")]
        public IHttpActionResult PutApplicantProfile([FromBody]  ApplicantProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("profile")]

        public IHttpActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("profile")]

        public IHttpActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
