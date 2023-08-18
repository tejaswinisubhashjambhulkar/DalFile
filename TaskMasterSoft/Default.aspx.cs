using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskMasterSoft.DAL;

namespace TaskMasterSoft
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                GetBind();
                btn_update.Visible = false;
            }
        }

        protected void GetBind()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = StudentMaster.GetAll();
                if(dt.Rows.Count > 0)
                {
                    rpt_studlist.DataSource = dt;
                    rpt_studlist.DataBind();
                }
            }
            catch(Exception ex)
            {

            }
        }
        protected void btn_photoupload_Click(object sender, EventArgs e)
        {
            var photo = "";
            var sign = "";
            var document = "";

            try
            {

                HttpFileCollection files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile xfile = files[i];
                    string fileExtenstion = Path.GetExtension(xfile.FileName);
                    Random rnd = new Random();
                    int rno = rnd.Next(123, 999);
                    var xfilenmae = rno + i + fileExtenstion;

                    xfile.SaveAs(Server.MapPath("Uploads") + "/" + xfilenmae);
                    if (i == 0)
                    {
                        photo = "Uploads/" + xfilenmae;
                    }
                    if (i == 1)
                    {
                        sign = "Uploads/" + xfilenmae;
                    }
                    if (i == 2)
                    {
                        document = "Uploads/" + xfilenmae;
                    }
                }
                StudentMaster sm = new StudentMaster();
                sm.studentName = txt_studentname.Value;
                DateTime xdob = Convert.ToDateTime(txt_dob.Value);
                sm.dob = xdob;
                sm.gender = txt_gender.Value;
                sm.mobleNo = txt_mobileNo.Value;
                sm.emailId = txt_EmailId.Value;
                sm.degree = ddlDegree.Value;
                sm.branch = ddlBranch.Value;
                sm.semester = ddlSemester.Value;

                sm.age = Convert.ToInt32(txt_Age.Value);
                sm.photo = photo;
                sm.sign = sign;
                sm.documents = document;
                if (1 == Convert.ToInt32(ddlStatus.Value))
                {
                    sm.status = true;
                }
                else
                {
                    sm.status = false;
                }
                sm.createddate = DateTime.Now;
                sm.Add();
                long studId = sm.studId;

                Clear();

                GetBind();
            }

            catch(Exception ex)
            {

            }
        }

        protected void rpt_studlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if(e.CommandName == "edit")
            {
                btn_photoupload.Visible = false;
                btn_update.Visible = true;

                long xstudId = Convert.ToInt64(e.CommandArgument.ToString());
                hidden_id.Value = xstudId.ToString();

                StudentMaster sm = new StudentMaster();
                sm = StudentMaster.Get(xstudId);
                 txt_Age.Value = sm.age.ToString();
                txt_studentname.Value = sm.studentName;
              //  txt_age.Value = sm.age.ToString();
                txt_mobileNo.Value = sm.mobleNo;
                txt_EmailId.Value = sm.emailId;
                txt_gender.Value = sm.gender;
                ddlDegree.Value = sm.degree;
                ddlBranch.Value = sm.branch;
                ddlSemester.Value = sm.semester;
                var xstatus = sm.status.ToString();
                if(xstatus == "true")
                {
                    ddlStatus.Value = "1";
                }
                else
                {
                    ddlStatus.Value = "0";
                }
                ddlStatus.Value = sm.status.ToString();
                var date = Convert.ToDateTime(sm.dob);
                txt_dob.Value = date.ToString("dd/mm/yyyy");

                
            }
           
            
            if(e.CommandName == "delete")
            {
                long xstudId = Convert.ToInt64(e.CommandArgument.ToString());             
                StudentMaster.Delete(xstudId);
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            if(hidden_id.Value != null)
            {
                long xstudId = Convert.ToInt64(hidden_id.Value);
                var photo = "";
                var sign = "";
                var document = "";

                try
                {

                    HttpFileCollection files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile xfile = files[i];
                        string fileExtenstion = Path.GetExtension(xfile.FileName);
                        Random rnd = new Random();
                        int rno = rnd.Next(123, 999);
                        var xfilenmae = rno + i + fileExtenstion;

                        xfile.SaveAs(Server.MapPath("Uploads") + "/" + xfilenmae);
                        if (i == 0)
                        {
                            photo = "Uploads/" + xfilenmae;
                        }
                        if (i == 1)
                        {
                            sign = "Uploads/" + xfilenmae;
                        }
                        if (i == 2)
                        {
                            document = "Uploads/" + xfilenmae;
                        }
                    }
                    StudentMaster sm = new StudentMaster();
                    sm.studentName = txt_studentname.Value;
                    DateTime xdob = Convert.ToDateTime(txt_dob.Value);
                    sm.dob = xdob;
                    sm.gender = txt_gender.Value;
                    sm.mobleNo = txt_mobileNo.Value;
                    sm.emailId = txt_EmailId.Value;
                    sm.degree = ddlDegree.Value;
                    sm.branch = ddlBranch.Value;
                    sm.semester = ddlSemester.Value;

                    sm.age = Convert.ToInt32(txt_Age.Value);
                    sm.photo = photo;
                    sm.sign = sign;
                    sm.documents = document;
                    if (1 == Convert.ToInt32(ddlStatus.Value))
                    {
                        sm.status = true;
                    }
                    else
                    {
                        sm.status = false;
                    }

                    sm.studId = xstudId;
                    sm.Update();
                    long studId = sm.studId;

                    GetBind();

                    btn_photoupload.Visible = true;
                    btn_update.Visible = false;
                    Clear();
                }

                catch (Exception ex)
                {

                }

            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            Clear();


        }  
        protected void Clear()
        {
            txt_studentname.Value = "";
            txt_dob.Value = "";
            txt_mobileNo.Value = "";
            txt_EmailId.Value = "";
            ddlDegree.Value = "Select";
            ddlBranch.Value = "Select";
            ddlSemester.Value = "Select";
            txt_Age.Value = "";
        }
    }
}