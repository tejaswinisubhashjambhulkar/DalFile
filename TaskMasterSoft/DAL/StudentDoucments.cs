using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TaskMasterSoft.DAL
{
    public class StudentDoucments
    {

        public long docId { get; set; }
        public long? studId { get; set; }
        public string photo { get; set; }
        public string sign { get; set; }
        public string documents { get; set; }


        public void Add()
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = @"INSERT INTO StudentDoucments(studId,photo,sign,documents) 
                               Values(@studId,@photo,@sign,@documents)";

                query += "Select SCOPE_IDENTITY()";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@studId", SqlDbType.BigInt, 8).Value = studId == null ? (Object)DBNull.Value : studId;
                    cmd.Parameters.Add("@photo", SqlDbType.NVarChar, 250).Value = photo == null ? (Object)DBNull.Value : photo;
                    cmd.Parameters.Add("@sign", SqlDbType.NVarChar, 250).Value = sign == null ? (Object)DBNull.Value : sign;
                    cmd.Parameters.Add("@documents", SqlDbType.NVarChar, 250).Value = documents == null ? (Object)DBNull.Value : documents;
                    docId = Convert.ToInt64(cmd.ExecuteScalar());
                }
                con.Close();
            }
        }

        public static DataTable getall()
        {
            DataTable dt = new DataTable();
            try
            {
                string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(str))
                {
                    string sql = @" select * from StudentDoucments";
                    using (SqlCommand cmd = new SqlCommand(sql,con))
                    {
                        using (SqlDataReader reder = cmd.ExecuteReader())
                        {
                            dt.Load(reder);
                        }
                    }
                }
            }
            catch ( Exception ex)
            {
            }
            return dt; 
           
        }

        public static StudentDoucments get(long studId)
        {
            StudentDoucments std = new StudentDoucments();
            try
            {
                string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(str))
                {
                    string sql = @"select studId,photo,sign,documents  from StudentDoucments  where studId=@studId   ";

                    using (SqlCommand cmd = new SqlCommand(sql,con))
                    {
                        using (SqlDataReader reder= cmd.ExecuteReader())
                        { if (reder.Read())
                            {
                            

                            }


                        }

                    }

                }

            }
            catch (Exception ex)

            {

            }

            return std;
        }

    }
}