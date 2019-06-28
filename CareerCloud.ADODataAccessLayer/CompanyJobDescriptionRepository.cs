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
    public class CompanyJobDescriptionRepository : IDataRepository<CompanyJobDescriptionPoco>
    {
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager
                .ConnectionStrings["DbConnection"]
                .ConnectionString
                );


            using (conn)

                foreach (CompanyJobDescriptionPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                        @"insert into [dbo].[Company_Jobs_Descriptions]
                    ([Id],[Job],[Job_Name],[Job_Descriptions])
                    values
                    (@Id,@Job,@Job_Name,@Job_Descriptions)"
                        , conn);

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Job_Name", poco.JobName);
                    cmd.Parameters.AddWithValue("@Job_Descriptions", poco.JobDescriptions);
                  

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection
                 (
                ConfigurationManager
                .ConnectionStrings["DbConnection"]
                .ConnectionString
                );

            using (conn)
            {
                SqlCommand cmd = new SqlCommand("select * from [dbo].[Company_Jobs_Descriptions]  ", conn);


                conn.Open();
                int x = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                CompanyJobDescriptionPoco[] apppocos = new CompanyJobDescriptionPoco[10000];


                while (reader.Read())
                {
                    CompanyJobDescriptionPoco poco = new CompanyJobDescriptionPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Job = reader.GetGuid(1);
                    poco.JobName = reader.GetString(2);
                    poco.JobDescriptions = reader.GetString(3);
     
                    poco.TimeStamp = (byte[])reader[4];

                    apppocos[x] = poco;
                    x++;
                }

                return apppocos.Where(a => a != null).ToList();
            }
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            SqlConnection conn = new SqlConnection
                  (
                  ConfigurationManager
                  .ConnectionStrings["DbConnection"]
                  .ConnectionString
                  );
            using (conn)
            {

                foreach (CompanyJobDescriptionPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                    "Delete from [dbo].[Company_Jobs_Descriptions] where Id=@id", conn
                    );
                    cmd.Parameters.AddWithValue("Id", poco.Id);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            SqlConnection conn = new SqlConnection
                 (
                 ConfigurationManager
                 .ConnectionStrings["DbConnection"]
                 .ConnectionString
                 );


            using (conn)
            {
                foreach (CompanyJobDescriptionPoco
                    poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                        @"update [dbo].[Company_Jobs_Descriptions] set
                        job=@job,Job_Name=@Job_Name,Job_Descriptions=@Job_Descriptions
                    where Id=@id", conn

                        );

                    cmd.Parameters.AddWithValue("@id", poco.Id);
                    cmd.Parameters.AddWithValue("@job", poco.Job);
                    cmd.Parameters.AddWithValue("@Job_Name", poco.JobName);
                    cmd.Parameters.AddWithValue("@Job_Descriptions", poco.JobDescriptions);
                  

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}

