<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaskMasterSoft.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div class="row">
                <div class="card mb-5">
                    <div class="col-md-6 offset-3">
                        <asp:HiddenField ID="hidden_id" runat="server" />
                        <div class="col-md-8">
                            <div class="form-group">
                                <lable>Name</lable>
                                <input type="text" runat="server" class="form-control" placeholder="Enter Name" id="txt_studentname" />
                            </div>
                        </div>
                        <br />
                        <div class="col-md-8">
                            <div class="form-group">
                                <lable for="male">Male</lable>
                                <input type="radio" value="male" name="gender" runat="server" id="txt_gender" />
                                <br />
                                <label for="female">Female</label>
                                <input type="radio" value="female" name="gender" runat="server" id="Radio1" />
                            </div>
                        </div>
                          <br />
                        <div class="col-md-8">
                            <lable>Date Of Birth</lable>
                            <input type="date" runat="server" class="form-control" id="txt_dob" />
                        </div>
                          <br />
                        <div class="col-md-8">

                            <lable>Select Degree</lable>
                            <select id="ddlDegree" runat="server" class="form-control">
                                <option value="Select" selected="selected">Select Degree</option>
                                <option value="BE">BE</option>
                                <option value="MBA">MBA</option>
                            </select>

                        </div>
                          <br />
                        <div class="col-md-8">

                            <lable>Select Branch</lable>
                            <select id="ddlBranch" runat="server" class="form-control">
                                <option value="Select" selected="selected">Select Branch</option>
                                <option value="Computer Science">Computer Science</option>
                                <option value="Accountant">Accountant</option>
                            </select>

                        </div>
                          <br />
                        <div class="col-md-8">
                            <lable>Select Semester</lable>
                            <select id="ddlSemester" runat="server" class="form-control">
                                <option value="Select" selected="selected">Select Semester</option>
                                <option value="8th">8th</option>
                                <option value="4th">4th</option>
                            </select>
                        </div>
                          <br />
                        <div class="col-md-8">
                            <lable>EmailId</lable>
                            <input type="text" runat="server" class="form-control" placeholder="Enter Email" id="txt_EmailId" />
                        </div>
                          <br />
                        <div class="col-md-8">
                            <lable>Mobile No.</lable>
                            <input type="text" runat="server" class="form-control" placeholder="Enter MobileNo" id="txt_mobileNo" />
                        </div>
                          <br />
                        <div class="col-md-8">
                            <lable>Age</lable>
                            <input type="text" runat="server" class="form-control" placeholder="Enter Age" id="txt_Age" />
                        </div>
                          <br />
                        <div class="col-md-8">
                            <lable>Photo Upload</lable>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <br />
                            <br />
                        </div>
                          <br />
                        <div class="col-md-8">
                            <lable>Sign Upload</lable>
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                            <br />
                            <br />
                        </div>
                          <br />
                        <div class="col-md-8">
                            <lable>Document Upload</lable>
                            <asp:FileUpload ID="FileUpload3" runat="server" />
                            <br />
                            <br />
                        </div>

                          <br />
                        <div class="col-md-8">
                            <lable>Status</lable>
                            <select id="ddlStatus" runat="server" class="form-control">
                                <option value="Select" selected="selected">Select Status</option>
                                <option value="1">True</option>
                                <option value="0">False</option>
                            </select>

                        </div>
                          <br />

                        <div class="col-md-8 mb-3">
                            <asp:Button ID="btn_photoupload" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btn_photoupload_Click" />
                            &nbsp;  &nbsp;  &nbsp;
            <asp:Button ID="btn_update" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btn_update_Click" />
           &nbsp;  &nbsp;  &nbsp;
                      <asp:Button ID="btn_clear" CssClass="btn btn-primary" runat="server" Text="Clear" OnClick="btn_clear_Click" />


                        </div>
                    </div>
                </div>
                  <br />
            </div>

            <div class="row">
                <div class="col-md-12 mt-5">
                    <table class="table">
                        <thead style="width: 100%;">
                            <tr>
                                <th>Name</th>
                                <th>DOB</th>
                                <th>Age</th>
                                <th>Email</th>
                                <th>Mobile</th>
                                <th>Photo</th>
                                <th>Sign</th>
                                <th>Download</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <asp:Repeater ID="rpt_studlist" runat="server" OnItemCommand="rpt_studlist_ItemCommand">
                                    <ItemTemplate>
                                        <tb><%#Eval("studentName") %></tb>
                                        <tb><%#Eval("dob") %></tb>
                                        <tb><%#Eval("age") %></tb>
                                        <tb><%#Eval("emailId") %></tb>
                                        <tb><%#Eval("mobleNo") %></tb>
                                        <tb>
                                            <img src='<%#Eval("photo") %>' style="width: 50px; height: 50px;" />
                                            <%--<asp:Image ImageUrl='<%#Eval("email") %>' runat="server"/>--%>
                                        </tb>
                                        <tb>
                                            <img src='<%#Eval("sign") %>' style="width: 50px; height: 50px;" />
                                        </tb>
                                        <%--<tb download><%#Eval("document") %></tb>--%>
                                        <td>
                                            <asp:Button ID="btn_edit" CommandArgument='<%#Eval("studId") %>' CommandName="edit" runat="server" Text="Edit" />
                                            <asp:Button ID="btn_delete" CommandArgument='<%#Eval("studId") %>' CommandName="delete" runat="server" Text="delete" />

                                        </td>
                                    </ItemTemplate>

                                </asp:Repeater>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

        </form>
    </div>
</body>
</html>
