using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobEducationRepository : IDataRepository<CompanyJobEducationPoco>
    {
        public void Add(params CompanyJobEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection
               (
               ConfigurationManager
               .ConnectionStrings["dbconnection"]
               .ConnectionString
               );


            using (conn)
            {
                foreach(CompanyJobEducationPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                        @"Insert into [dbo].[Company_Job_Educations] ([Id],[Job],[Major],[Importance])
                        values
                        (@Id,@Job,@Major,@Importance)",conn
                        );

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Importance", poco.Importance);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection
               (
               ConfigurationManager
               .ConnectionStrings["dbconnection"]
               .ConnectionString
               );


            using (conn)
            {
                SqlCommand cmd = new SqlCommand("select * from [dbo].[Company_Job_Educations]", conn);
                conn.Open();
                int x = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                CompanyJobEducationPoco[] apppocos = new CompanyJobEducationPoco[10000];

                while (reader.Read())
                {
                    CompanyJobEducationPoco poco
                        = new CompanyJobEducationPoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Job = reader.GetGuid(1);
                    poco.Major = reader.GetString(2);
                    poco.Importance = reader.GetInt16(3);

                    apppocos[x] = poco;
                    x++;
                }
                return apppocos.Where(a => a != null).ToList();
            }


        }

        public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection
                  (
                  ConfigurationManager
                  .ConnectionStrings["dbconnection"]
                  .ConnectionString
                  );
            using (conn)
            {

                foreach (CompanyJobEducationPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                    "Delete from [dbo].[Company_Job_Educations] where Id=@id", conn
                    );
                    cmd.Parameters.AddWithValue("Id", poco.Id);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyJobEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection
                 (
                 ConfigurationManager
                 .ConnectionStrings["dbconnection"]
                 .ConnectionString
                 );


            using (conn)
            {
                foreach (CompanyJobEducationPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                        @"update [dbo].[Company_Job_Educations] set
                        Job=@Job,Major=@Major,Importance=@Importance
                        where Id=@id", conn

                        );

                    cmd.Parameters.AddWithValue("@id", poco.Id);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Importance", poco.Importance);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
