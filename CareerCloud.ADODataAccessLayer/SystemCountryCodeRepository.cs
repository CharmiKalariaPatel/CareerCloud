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
    public class SystemCountryCodeRepository : IDataRepository<SystemCountryCodePoco>
    {
        public void Add(params SystemCountryCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString
                );

            using (conn)
            {
                foreach (SystemCountryCodePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                        @"Insert into [dbo].[System_Country_Codes] ([Code],[Name])
                        values
(@Code,@Name)", conn
                        );

                    cmd.Parameters.AddWithValue("@Code", poco.Code);
                    cmd.Parameters.AddWithValue("@Name", poco.Name);
                  

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

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString
                );

            using (conn)
            {
                SqlCommand cmd = new SqlCommand("Select * from [dbo].[System_Country_Codes]", conn);
                conn.Open();
                int x = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                SystemCountryCodePoco[] apppocos = new SystemCountryCodePoco[1000];

                while (reader.Read())
                {
                    SystemCountryCodePoco poco = new SystemCountryCodePoco();
                    poco.Code = reader.GetString(0);
                    poco.Name = reader.GetString(1);
                   

                    apppocos[x] = poco;
                    x++;
                }
           
                return apppocos.Where(a => a != null).ToList();

            }
        }

        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString
                );
            using (conn)
            {

                foreach (SystemCountryCodePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                    "Delete from  [dbo].[System_Country_Codes]where Code=@Code", conn
                    );
                    cmd.Parameters.AddWithValue("Code", poco.Code);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection
               (
               ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString
               );
            using (conn)
            {

                foreach (SystemCountryCodePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand("update [dbo].[System_Country_Codes] set [Name]=@Name where Code=@Code", conn);
                    cmd.Parameters.AddWithValue("@Code", poco.Code);
                    cmd.Parameters.AddWithValue("@Name", poco.Name);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
