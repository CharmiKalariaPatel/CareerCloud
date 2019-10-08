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
    public class ApplicantWorkHistoryController : ApiController
    {
        private ApplicantWorkHistoryLogic _logic;
        public ApplicantWorkHistoryController()
        {
            EFGenericRepository<ApplicantWorkHistoryPoco> repo =
                new EFGenericRepository<ApplicantWorkHistoryPoco>();
            _logic = new ApplicantWorkHistoryLogic(repo);
        }
        [HttpGet]
        [Route("workhistory/applicantworkId")]
        [ResponseType(typeof(ApplicantWorkHistoryPoco))]
        public IHttpActionResult GetApplicantWorkHistory(Guid applicantworkId)
        {
            ApplicantWorkHistoryPoco appWork = _logic.Get(applicantworkId);
            if (appWork == null)
            {
                return NotFound();
            }
            return Ok(appWork);
        }
        [HttpGet]
        [Route("workhistory")]
        [ResponseType(typeof(List<ApplicantWorkHistoryPoco>))]
        public IHttpActionResult GetAllApplicantWorkHistory()
        {
            var applicants = _logic.GetAll();
            if (applicants == null)
            {
                NotFound();
            }
            return Ok(applicants);
        }

        [HttpPut]
        [Route("workhistory")]
        public IHttpActionResult PutApplicantWorkHistory([FromBody]  ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("workhistory")]

        public IHttpActionResult PostApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("workhistory")]

        public IHttpActionResult DeleteApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
