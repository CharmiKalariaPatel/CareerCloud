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
    public class CompanyProfileController : ApiController
    {
        private CompanyProfileLogic _logic;
        public CompanyProfileController()
        {
            EFGenericRepository<CompanyProfilePoco> repo =
                new EFGenericRepository<CompanyProfilePoco>();
            _logic = new CompanyProfileLogic(repo);
        }
        [HttpGet]
        [Route("profile/companyprofileId")]
        [ResponseType(typeof(CompanyProfilePoco))]
        public IHttpActionResult GetCompanyProfile(Guid companyprofileId)
        {
            CompanyProfilePoco cp = _logic.Get(companyprofileId);
            if (cp == null)
            {
                return NotFound();
            }
            return Ok(cp);
        }
        [HttpGet]
        [Route("profile")]
        [ResponseType(typeof(List<CompanyProfilePoco>))]
        public IHttpActionResult GetAllCompanyProfile()
        {
            var companies = _logic.GetAll();
            if (companies == null)
            {
                NotFound();
            }
            return Ok(companies);
        }

        [HttpPut]
        [Route("profile")]
        public IHttpActionResult PutCompanyProfile([FromBody]  CompanyProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("profile")]

        public IHttpActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("profile")]

        public IHttpActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
