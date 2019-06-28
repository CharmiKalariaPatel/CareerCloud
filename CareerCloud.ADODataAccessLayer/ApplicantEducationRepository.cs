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
   public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager
                .ConnectionStrings["DbConnection"]
                .ConnectionString
                );
                

            using (conn)

                foreach(ApplicantEducationPoco poco in items)
            {
                SqlCommand cmd = new SqlCommand
                    (
                    @"insert into [dbo].[Applicant_Educations] 
                    ([Id],[Applicant],[Major],[Certificate_Diploma],[Start_Date],[Completion_Date],[Completion_Percent])
                    values
                    (@Id,@Applicant,@Major,@Certificate_Diploma,@Start_Date,@Completion_Date,@Completion_Percent)"
                    , conn);

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);


                    conn.Open();
                    int rowEffected=cmd.ExecuteNonQuery();
                    conn.Close();
                }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection
                 (
                ConfigurationManager
                .ConnectionStrings["DbConnection"]
                .ConnectionString
                );

            using (conn)
            {
                SqlCommand cmd = new SqlCommand("select * from [dbo].[Applicant_Educations]  ", conn);
                conn.Open();
                int x = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                ApplicantEducationPoco[] apppocos = new ApplicantEducationPoco[100];
                

                while (reader.Read())
                {
                    ApplicantEducationPoco poco = new ApplicantEducationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant  = reader.GetGuid(1);
                    poco.Major = reader.GetString(2);
                    poco.CertificateDiploma = (string)(reader.IsDBNull(3)?null:reader[3]);
                    poco.StartDate = (DateTime?)(reader.IsDBNull(4)?null:reader[4]);
                    poco.CompletionDate = (DateTime?)(reader.IsDBNull(5) ? null : reader[5]);
                    poco.CompletionPercent = (byte?)reader[6];
                    poco.TimeStamp = (byte[])reader[7];

                    apppocos[x] = poco;
                    x++;
                }

                return apppocos.Where(a => a != null).ToList();
            }
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection
                 (
                 ConfigurationManager
                 .ConnectionStrings["DbConnection"]
                 .ConnectionString
                 );
            using (conn)
            {
                
                foreach(ApplicantEducationPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                    "Delete from [dbo].[Applicant_Educations] where Id=@id",conn
                    );
                    cmd.Parameters.AddWithValue("Id", poco.Id);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager
                .ConnectionStrings["DbConnection"]
                .ConnectionString
                );


            using (conn)
            {
                foreach (ApplicantEducationPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                        @"update [dbo].[Applicant_Educations] set
                        Applicant=@Applicant,Major=@Major,Certificate_Diploma=@Certificate_Diploma,Start_Date=@Start_Date,Completion_Date=@Completion_Date,Completion_Percent=@Completion_Percent
                    where Id=@id", conn

                        );

                    cmd.Parameters.AddWithValue("@id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }

    
}
