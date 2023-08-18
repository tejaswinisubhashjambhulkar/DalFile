using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TaskMasterSoft.DAL
{
    public class StudentMaster
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


        public void Add()
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = @"INSERT INTO StudentMaster(studentName,gender,dob,degree,branch,semester,emailId,mobleNo,age,status,createddate,photo,sign,documents) 
                               Values(@studentName,@gender,@dob,@degree,@branch,@semester,@emailId,@mobleNo,@age,@status,@createddate,@photo,@sign,@documents)";

                query += "Select SCOPE_IDENTITY()";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@studentName", SqlDbType.NVarChar, 100).Value = studentName == null ? (Object)DBNull.Value : studentName;
                    cmd.Parameters.Add("@gender", SqlDbType.NVarChar, 50).Value = gender == null ? (Object)DBNull.Value : gender;
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime, 8).Value = dob == null ? (Object)DBNull.Value : dob;
                    cmd.Parameters.Add("@degree", SqlDbType.NVarChar, 50).Value = degree == null ? (Object)DBNull.Value : degree;
                    cmd.Parameters.Add("@branch", SqlDbType.NVarChar, 50).Value = branch == null ? (Object)DBNull.Value : branch;
                    cmd.Parameters.Add("@semester", SqlDbType.NVarChar, 50).Value = semester == null ? (Object)DBNull.Value : semester;
                    cmd.Parameters.Add("@emailId", SqlDbType.NVarChar, 100).Value = emailId == null ? (Object)DBNull.Value : emailId;
                    cmd.Parameters.Add("@mobleNo", SqlDbType.NVarChar, 20).Value = mobleNo == null ? (Object)DBNull.Value : mobleNo;
                    cmd.Parameters.Add("@age", SqlDbType.Int, 4).Value = age == null ? (Object)DBNull.Value : age;
                    cmd.Parameters.Add("@status", SqlDbType.Bit, 1).Value = status == null ? (Object)DBNull.Value : status;
                    cmd.Parameters.Add("@createddate", SqlDbType.DateTime, 8).Value = createddate == null ? (Object)DBNull.Value : createddate;
                    cmd.Parameters.Add("@photo", SqlDbType.NVarChar, 250).Value = photo == null ? (Object)DBNull.Value : photo;
                    cmd.Parameters.Add("@sign", SqlDbType.NVarChar, 250).Value = sign == null ? (Object)DBNull.Value : sign;
                    cmd.Parameters.Add("@documents", SqlDbType.NVarChar, 250).Value = documents == null ? (Object)DBNull.Value : documents;

                    studId = Convert.ToInt64(cmd.ExecuteScalar());
                }
                con.Close();
            }
        }

        public void Update()
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = @"UPDATE StudentMaster SET 
                               studentName=@studentName,
                               gender=@gender,
                               dob=@dob,
                               degree=@degree,
                               branch=@branch,
                                semester=@semester,
                               emailId=@emailId,
                               mobleNo=@mobleNo,
                               age=@age,
                               status=@status,
                               photo=@photo,
                              sign=@sign,
                               documents=@documents
                                WHERE studId = @studId;";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@studId", SqlDbType.BigInt, 8).Value = studId;
                    cmd.Parameters.Add("@studentName", SqlDbType.NVarChar, 100).Value = studentName == null ? (Object)DBNull.Value : studentName;
                    cmd.Parameters.Add("@gender", SqlDbType.NVarChar, 50).Value = gender == null ? (Object)DBNull.Value : gender;
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime, 8).Value = dob == null ? (Object)DBNull.Value : dob;
                    cmd.Parameters.Add("@degree", SqlDbType.NVarChar, 50).Value = degree == null ? (Object)DBNull.Value : degree;
                    cmd.Parameters.Add("@branch", SqlDbType.NVarChar, 50).Value = branch == null ? (Object)DBNull.Value : branch;
                    cmd.Parameters.Add("@semester", SqlDbType.NVarChar, 50).Value = semester == null ? (Object)DBNull.Value : semester;
                    cmd.Parameters.Add("@emailId", SqlDbType.NVarChar, 100).Value = emailId == null ? (Object)DBNull.Value : emailId;
                    cmd.Parameters.Add("@mobleNo", SqlDbType.NVarChar, 20).Value = mobleNo == null ? (Object)DBNull.Value : mobleNo;
                    cmd.Parameters.Add("@age", SqlDbType.Int, 4).Value = age == null ? (Object)DBNull.Value : age;
                    cmd.Parameters.Add("@status", SqlDbType.Bit, 1).Value = status == null ? (Object)DBNull.Value : status;
                    cmd.Parameters.Add("@photo", SqlDbType.NVarChar, 250).Value = photo == null ? (Object)DBNull.Value : photo;
                    cmd.Parameters.Add("@sign", SqlDbType.NVarChar, 250).Value = sign == null ? (Object)DBNull.Value : sign;
                    cmd.Parameters.Add("@documents", SqlDbType.NVarChar, 250).Value = documents == null ? (Object)DBNull.Value : documents;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static StudentMaster Get(long studId)
        {
          
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = @"SELECT studId,studentName,gender,dob,degree,branch,semester,emailId,mobleNo,age,status,createddate,photo,sign,documents FROM StudentMaster WHERE studId=@studId";

                StudentMaster studentMaster = new StudentMaster();

                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@studId", SqlDbType.BigInt, 8).Value = studId;
                    using (SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (sdr.Read())
                        {
                            studentMaster.studId = Convert.ToInt64(sdr["studId"]);
                            studentMaster.studentName = sdr["studentName"] == DBNull.Value ? null : sdr["studentName"].ToString();
                            studentMaster.gender = sdr["gender"] == DBNull.Value ? null : sdr["gender"].ToString();
                            studentMaster.dob = sdr["dob"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(sdr["dob"]);
                            studentMaster.degree = sdr["degree"] == DBNull.Value ? null : sdr["degree"].ToString();
                            studentMaster.branch = sdr["branch"] == DBNull.Value ? null : sdr["branch"].ToString();
                            studentMaster.semester = sdr["semester"] == DBNull.Value ? null : sdr["semester"].ToString();
                            studentMaster.emailId = sdr["emailId"] == DBNull.Value ? null : sdr["emailId"].ToString();
                            studentMaster.mobleNo = sdr["mobleNo"] == DBNull.Value ? null : sdr["mobleNo"].ToString();
                            studentMaster.age = sdr["age"] == DBNull.Value ? (int?)null : Convert.ToInt32(sdr["age"]);
                            studentMaster.status = sdr["status"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(sdr["status"]);
                            studentMaster.createddate = sdr["createddate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(sdr["createddate"]);
                            studentMaster.photo = sdr["photo"] == DBNull.Value ? null : sdr["photo"].ToString();
                            studentMaster.sign = sdr["sign"] == DBNull.Value ? null : sdr["sign"].ToString();
                            studentMaster.documents= sdr["documents"] == DBNull.Value ? null : sdr["documents"].ToString();

                        }

                    }
                
                }
                return studentMaster;
            }

        
        }
        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = @"SELECT studId,studentName,gender,dob,degree,branch,semester,emailId,mobleNo,age,status,createddate,photo,sign,documents FROM StudentMaster";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        dt.Load(sdr);
                    }
                }

            }
            return dt;
        }
        public static void Delete(long studId)
        {

            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = @"DELETE FROM StudentMaster Where [studId]=@studId";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@studId", SqlDbType.BigInt, 8).Value = studId;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}