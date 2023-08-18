using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace TaskMasterSoft.DAL
{
    public class sttudentmaster
    {
        public long studId { get; set; }
        public string studentName { get; set; }
        public string gender { get; set; }
        public DateTime? dob { get; set; }
        public string degree { get; set; }
        public string branch { get; set; }
        public string semester { get; set; }
        public string emailId { get; set; }
        public string mobleNo { get; set; }
        public int? age { get; set; }
        public bool? status { get; set; }
        public DateTime? createddate { get; set; }
        public string photo { get; set; }
        public string sign { get; set; }
        public string documents { get; set; }


        public void add()
        {
            string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                string sql = @"insert into StudentMaster ( 
                                                           studentName
                                                          ,gender
                                                          ,dob
                                                          ,degree
                                                          ,branch
                                                          ,semester
                                                          ,emailId
                                                          ,mobleNo
                                                          ,age
                                                          ,status
                                                          ,createddate
                                                          ,photo
                                                          ,sign
                                                          ,documents) values (   
                                                                                @studentName
                                                                               ,@gender
                                                                               ,@dob
                                                                               ,@degree
                                                                               ,@branch
                                                                               ,@semester
                                                                               ,@emailId
                                                                               ,@mobleNo
                                                                               ,@age
                                                                               ,@status
                                                                               ,@createddate
                                                                               ,@photo
                                                                               ,@sign
                                                                               ,@documents)  ";

                con.Open();
                sql = "select scope_Identity()";

                using (SqlCommand cmd  = new SqlCommand(sql,con))
                {
                    cmd.Parameters.Add("studentName", SqlDbType.NVarChar, 50).Value = studentName == null ? (Object)DBNull.Value : studentName;
                    cmd.Parameters.Add("gender", SqlDbType.NVarChar, 50).Value = gender == null ? (Object)DBNull.Value : gender;
                    cmd.Parameters.Add("dob", SqlDbType.NVarChar, 50).Value = dob == null ? (Object)DBNull.Value : dob;
                    cmd.Parameters.Add("degree", SqlDbType.NVarChar, 50).Value = degree == null ? (Object)DBNull.Value : degree;






                }

                


            }



        }

        public static  DataTable  getall()
        {
         
            DataTable dt = new DataTable();
            try
            {
                string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(str))
                {
                    string sql = "select * from StudentMaster";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reder = cmd.ExecuteReader())
                        {
                            if (reder.Read())
                            {
                                dt.Load(reder);
                            }

                        }

                    }




                }
            }
            catch(Exception ex)
            {

            }
            return dt;
        }

        public void delete()
        {
            try
            {
                string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(str))
                {
                    string sql = @"delete from StudentMaster where studId=@studId";
                    using (SqlCommand cmd = new SqlCommand(sql,con))
                    {
                        cmd.Parameters.Add("studId", SqlDbType.BigInt).Value = studId == null ? (object)DBNull.Value : studId;
                        cmd.ExecuteNonQuery();

                    }



                }


            }
            catch (Exception ex)
            {

            }

        }

    }
}