using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Configuration;
using System.IO;
using System.Collections;

namespace App2
{
    public partial class form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e) // When submit button clicked connects to database and inserts data.
        {
            try
            {
                string id = txtId.Text;
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string email = txtEmail.Text;
                string department = DropDownListDepartment.Text;
                string city = txtCity.Text;
                string securityNum = txtSecurityNum.Text;

                if (id == "" || name == "" || surname == "" || email == "" || department == "" || city == "" || securityNum == "")
                {
                    IbMessage.Text = "<strong style='color:red;'>Please fill all the sections!</strong>";
                }
                
                else
                {
                    if(DropDownListDepartment.SelectedValue == "-1")
                    {
                        IbMessage.Text = "<strong style='color:red;'>Please choose a department!</strong>";
                        return;
                    }
                    List<int> list = new List<int>();
                    using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conStr"].ToString()))
                    {
                        string query = "SELECT PersonalId FROM PersonalList";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            con.Open();
                            var reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                var personalId = (int)reader["PersonalId"];
                                list.Add(personalId);
                            }
                            reader.Close();
                        }
                    }
                    int newId = Convert.ToInt32(id);
                    if (list.Contains(newId))
                    {
                        using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conStr"].ToString()))
                        {
                            var query = "UPDATE PersonalList SET Name = @name, Surname = @surname, Email = @email," +
                                " Department = @department, City = @city WHERE PersonalId = @newId";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                con.Open();
                                cmd.Parameters.Add("@newId", SqlDbType.Int, 50).Value = newId;
                                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name;
                                cmd.Parameters.Add("@Surname", SqlDbType.NVarChar, 50).Value = surname;
                                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
                                cmd.Parameters.Add("@Department", SqlDbType.NVarChar, 50).Value = department;
                                cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = city;
                                cmd.Parameters.Add("@SecurityNum", SqlDbType.Int, 50).Value = Convert.ToInt32(securityNum);

                                cmd.ExecuteNonQuery();
                                con.Close();
                                IbMessage.Text = "<strong style = 'color:green;' > Update succesful!</strong> ";
                            }
                        }
                    }
                            
                    else
                    {
                        using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conStr"].ToString()))
                        {
                            con.Open();
                            string query = "INSERT INTO PersonalList (PersonalId, Name, Surname, Email, Department, City, SecurityNum) VALUES (@PersonalId, @Name, @Surname, @Email, @Department, @City,@SecurityNum)";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.Add("@PersonalId", SqlDbType.Int).Value = id;
                                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name;
                                cmd.Parameters.Add("@Surname", SqlDbType.NVarChar, 50).Value = surname;
                                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
                                cmd.Parameters.Add("@Department", SqlDbType.NVarChar, 50).Value = department;
                                cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = city;
                                cmd.Parameters.Add("@SecurityNum", SqlDbType.Int).Value = securityNum;

                                cmd.ExecuteNonQuery();
                                con.Close();
                                IbMessage.Text = "<strong style = 'color:green;' > Registration succesful!</strong> ";
                            }
                        }
                    }
                }
                gridPersonalList.DataBind();
                ClearForm();
            }
            catch (Exception err)
            {
                IbMessage.Text = "<strong style = 'color:red;' > Error occured!</strong> " + err;
       
            }
        }

        protected void btnClear_Click(object sender, EventArgs e) // Clears all the choices
        {
            ClearForm();
        }

        private void ClearForm()
        {
            btnId.Enabled = true;
            btnSecurity.Enabled = true;
            IbMessage.Text = "";
            txtId.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtEmail.Text = "";
            ListItem listItem = DropDownListDepartment.Items.FindByValue("-1");
            DropDownListDepartment.SelectedValue = listItem.Value;
            txtCity.Text = "";
            txtSecurityNum.Text = "";
            gridPersonalList.Visible = false;
        }
        protected void btnPersonalList_Click(object sender, EventArgs e)
        {
            gridPersonalList.DataBind();
            gridPersonalList.Visible = true;
        }

        protected void btnId_Click(object sender, EventArgs e) // Searches for Personal Ids to create one.
        {
            List<int> list = new List<int>();
            int newId = -1;
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conStr"].ToString()))
            {
                string query = "SELECT PersonalId FROM PersonalList";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var personalId = (int)reader["PersonalId"];
                        list.Add(personalId);
                    }
                    if(list.Count == 0) 
                    {
                        newId = 1;
                        txtId.Text = newId.ToString();
                        reader.Close();
                        return;
                    }
                    else
                    {
                        for(int i=1; i<=list.Count() + 1; i++)
                        {
                            if(!list.Contains(i))
                            {
                                newId = i;
                                txtId.Text = newId.ToString();
                                break;
                            }
                        }
                    }
                    reader.Close();
                }
            }
        }

        protected void btnSecurity_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            int newSec = -1;
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conStr"].ToString()))
            {
                string query = "SELECT SecurityNum FROM PersonalList";
                Random rndm = new Random();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var securityNum = (int)reader["SecurityNum"];
                        list.Add(securityNum);
                    }
                    if (list.Count == 0)
                    {
                        newSec = rndm.Next(100000, 999999);
                        txtSecurityNum.Text = newSec.ToString();
                    }
                    else
                    {
                        do
                        {
                            newSec = rndm.Next(100000, 999999);
                        } while (list.Contains(newSec));
                        txtSecurityNum.Text = newSec.ToString();
                    }
                    reader.Close();
                }
            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridPersonalList, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btnId.Enabled = false;
            btnSecurity.Enabled = false;
            string id = gridPersonalList.SelectedRow.Cells[0].Text;
            string name = gridPersonalList.SelectedRow.Cells[1].Text;
            string surname = gridPersonalList.SelectedRow.Cells[2].Text;
            string email = gridPersonalList.SelectedRow.Cells[3].Text;
            string department = gridPersonalList.SelectedRow.Cells[4].Text;
            string city = gridPersonalList.SelectedRow.Cells[5].Text;
            string securityNum = gridPersonalList.SelectedRow.Cells[6].Text;

            txtId.Text = id;
            txtName.Text = name;
            txtSurname.Text = surname;
            txtEmail.Text = email;
            DropDownListDepartment.Text = department;
            txtCity.Text = city;
            txtSecurityNum.Text = securityNum;
        }

        protected void gridPersonalList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conStr"].ToString()))
                {
                    con.Open();
                    //var data = 
                    var data = (GridView)sender;
                    int id = Convert.ToInt32(e.CommandArgument);

                    var related = data.DataKeys[id].Value;
                    string query = $"DELETE FROM PersonalList WHERE PersonalId=@id";//PersonalId='{sender["Columns"][PersomalId]}'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = related;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            gridPersonalList.DataBind();
        }
      
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename = PersonalList.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite =
            new HtmlTextWriter(stringWrite);
            gridPersonalList.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
    }

}