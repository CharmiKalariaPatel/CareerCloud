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
    public class CompanyLocationController : ApiController
    {
        private CompanyLocationLogic _logic;
        public CompanyLocationController()
        {
            EFGenericRepository<CompanyLocationPoco> repo =
                new EFGenericRepository<CompanyLocationPoco>();
            _logic = new CompanyLocationLogic(repo);
        }
        [HttpGet]
        [Route("location/companylocationId")]
        [ResponseType(typeof(CompanyLocationPoco))]
        public IHttpActionResult GetCompanyLocation(Guid companylocationId)
        {
            CompanyLocationPoco cl = _logic.Get(companylocationId);
            if (cl == null)
            {
                return NotFound();
            }
            return Ok(cl);
        }
        [HttpGet]
        [Route("location")]
        [ResponseType(typeof(List<CompanyLocationPoco>))]
        public IHttpActionResult GetAllCompanyLocation()
        {
            var companies = _logic.GetAll();
            if (companies == null)
            {
                NotFound();
            }
            return Ok(companies);
        }

        [HttpPut]
        [Route("location")]
        public IHttpActionResult PutCompanyLocation([FromBody]  CompanyLocationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpPost]
        [Route("location")]

        public IHttpActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("location")]

        public IHttpActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
