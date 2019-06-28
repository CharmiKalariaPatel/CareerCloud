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
    public class SecurityLoginRepository : IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            SqlConnection conn = new SqlConnection
                 (
                 ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString
                 );

            using (conn)
            {
                foreach (SecurityLoginPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                        @"Insert into [dbo].[Security_Logins] ([Id],[Login],[Password],[Created_Date],[Password_Update_Date],[Agreement_Accepted_Date],[Is_Locked],[Is_Inactive],[Email_Address],[Phone_Number],[Full_Name],[Force_Change_Password],[Prefferred_Language])
                        values
                        (@Id,@Login,@Password,@Created_Date,@Password_Update_Date,@Agreement_Accepted_Date,@Is_Locked,@Is_Inactive,@Email_Address,@Phone_Number,@Full_Name,@Force_Change_Password,@Prefferred_Language)", conn
                        );

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Password", poco.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);
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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection
                 (
                 ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString
                 );

            using (conn)
            {
                SqlCommand cmd = new SqlCommand("Select * from [dbo].[Security_Logins]  ", conn);

                conn.Open();
                int x = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                SecurityLoginPoco[] apppocos = new SecurityLoginPoco[10000];

                while (reader.Read())
                {
                    SecurityLoginPoco poco = new SecurityLoginPoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetString(1);
                    poco.Password = reader.GetString(2);
                    poco.Created = reader.GetDateTime(3);
                    poco.PasswordUpdate = (DateTime?)(reader.IsDBNull(4) ? null:reader[4]);
                    poco.AgreementAccepted = (DateTime?)(reader.IsDBNull(5) ? null : reader[5]);
                    poco.IsLocked = reader.GetBoolean(6);
                    poco.IsInactive = reader.GetBoolean(7);
                    poco.EmailAddress = (string)(reader.IsDBNull(8) ? null : reader[8]);
                    poco.PhoneNumber= (string)(reader.IsDBNull(9) ? null : reader[9]);
                    poco.FullName= (string)(reader.IsDBNull(10) ? null : reader[10]);
                    poco.ForceChangePassword = reader.GetBoolean(11);
                    poco.PrefferredLanguage= (string)(reader.IsDBNull(12) ? null : reader[12]);
                    poco.TimeStamp = (Byte[])reader[13];
                    apppocos[x] = poco;
                    x++;
                }

                return apppocos.Where(a => a != null).ToList();
            }
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            SqlConnection conn = new SqlConnection
                  (
                  ConfigurationManager
                  .ConnectionStrings["DbConnection"]
                  .ConnectionString
                  );
            using (conn)
            {

                foreach (SecurityLoginPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                    "Delete from [dbo].[Security_Logins] where Id=@id", conn
                    );
                    cmd.Parameters.AddWithValue("Id", poco.Id);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager
                .ConnectionStrings["DbConnection"]
                .ConnectionString
                );


            using (conn)
            {
                foreach (SecurityLoginPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                        @"update [dbo].[Security_Logins] set Login=@Login,Password=@Password,Created_Date=@Created_Date,Password_Update_Date=@Password_Update_Date,Agreement_Accepted_Date=@Agreement_Accepted_Date,Is_Locked=@Is_Locked,Is_Inactive=@Is_Inactive,Email_Address=@Email_Address,Phone_Number=@Phone_Number,Full_Name=@Full_Name,Force_Change_Password=@Force_Change_Password,Prefferred_Language=@Prefferred_Language where Id=@Id", conn
                        );

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Password", poco.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
