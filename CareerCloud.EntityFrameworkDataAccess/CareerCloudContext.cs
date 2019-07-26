using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext:DbContext
    {
        public CareerCloudContext() : 
            base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {

        }

        DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }

    }
}
