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
    public class SecurityRoleRepository : IDataRepository<SecurityRolePoco>
    {
        public void Add(params SecurityRolePoco[] items)
        {
            SqlConnection conn = new SqlConnection
                 (
                 ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString
                 );

            using (conn)
            {
                foreach (SecurityRolePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                        @"Insert into [dbo].[Security_Roles] ([Id],[Role],[Is_Inactive])
                        values
(@Id,@Role,@Is_Inactive)", conn
                        );

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Role", poco.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);


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

        public IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString
                );

            using (conn)
            {
                SqlCommand cmd = new SqlCommand("Select * from [dbo].[Security_Roles]", conn);
                conn.Open();
                int x = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                SecurityRolePoco[] apppocos = new SecurityRolePoco[1000];

                while (reader.Read())
                {
                    SecurityRolePoco poco = new SecurityRolePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Role = reader.GetString(1);
                    poco.IsInactive = reader.GetBoolean(2);

                    apppocos[x] = poco;
                    x++;
                }
               
                return apppocos.Where(a => a != null).ToList();

            }
        }

        public IList<SecurityRolePoco> GetList(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityRolePoco GetSingle(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityRolePoco[] items)
        {
            SqlConnection conn = new SqlConnection
               (
               ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString
               );
            using (conn)
            {

                foreach (SecurityRolePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                    "Delete from [dbo].[Security_Roles] where Id=@Id", conn
                    );
                    cmd.Parameters.AddWithValue("Id", poco.Id);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params SecurityRolePoco[] items)
        {
            SqlConnection conn = new SqlConnection
              (
              ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString
              );
            using (conn)
            {

                foreach (SecurityRolePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand("update [dbo].[Security_Roles] set [Role]=@Role,Is_Inactive=@Is_Inactive where Id=@Id", conn);

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Role", poco.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
