﻿using CareerCloud.DataAccessLayer;
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
    public class SystemLanguageCodeRepository : IDataRepository<SystemLanguageCodePoco>
    {
        public void Add(params SystemLanguageCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString
                );

            using (conn)
            {
                foreach (SystemLanguageCodePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                        @"Insert into [dbo].[System_Language_Codes] ([LanguageID],[Name],[Native_Name])
                        values
(@LanguageID,@Name,@Native_Name)", conn
                        );

                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", poco.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", poco.NativeName);

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

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString
                );

            using (conn)
            {
                SqlCommand cmd = new SqlCommand("Select * from [dbo].[System_Language_Codes]", conn);
                conn.Open();
                int x = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                SystemLanguageCodePoco[] apppocos = new SystemLanguageCodePoco[1000];

                while (reader.Read())
                {
                    SystemLanguageCodePoco poco = new SystemLanguageCodePoco();
                    poco.LanguageID = reader.GetString(0);
                    poco.Name = reader.GetString(1);
                    poco.NativeName = reader.GetString(2);

                    apppocos[x] = poco;
                    x++;
                }
             
                return apppocos.Where(a => a != null).ToList();

            }

        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString
                );
            using (conn)
            {

                foreach (SystemLanguageCodePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand
                        (
                    "Delete from [dbo].[System_Language_Codes] where LanguageID=@LanguageID", conn
                    );
                    cmd.Parameters.AddWithValue("LanguageID", poco.LanguageID);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {

            SqlConnection conn = new SqlConnection
                (
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString
                );
            using (conn)
            {

                foreach (SystemLanguageCodePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand("update [dbo].[System_Language_Codes] set [Name]=@Name,[Native_Name]=@Native_Name where LanguageID=@LanguageID", conn);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", poco.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", poco.NativeName);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
