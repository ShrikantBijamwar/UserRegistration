using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistration
{
    public partial class Index : System.Web.UI.Page
    {
        string connectionstring = @"Data Source=ICON-PC;Initial Catalog=UserRegistration;Integrated Security=True;";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                TextBox1.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                Calendar1.Visible = false;
                Clear();

                DataSet years = new DataSet();
                years.ReadXml(Server.MapPath("~/Year.xml"));

                DropDownList1.DataTextField = "Number";
                DropDownList1.DataTextField = "Number";

                DropDownList1.DataSource = years;
                DropDownList1.DataBind();

                DataSet months  = new DataSet();
                months .ReadXml(Server.MapPath("~/month.xml"));

                DropDownList2.DataTextField = "Number";
                DropDownList2.DataTextField = "Number";

                DropDownList2.DataSource = months ;
                DropDownList2.DataBind();


            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

         
            using (SqlConnection sqlCon = new SqlConnection(connectionstring))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit6", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Contact", txtContact .Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue );
                sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@EmailID", txtEmailID.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Qualification", ddmQualificattion.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@Course", dmlCourse .SelectedValue );
                sqlCmd.Parameters.AddWithValue("@DateOfBirth", TextBox1 .Text.Trim());
                sqlCmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                Clear();
            
            }
        }
        void Clear()
        {
            txtFirstName.Text = txtLastName.Text =txtContact .Text=ddlGender .Text =txtAddress.Text =txtEmailID . Text=ddmQualificattion .Text =dmlCourse .
                Text =TextBox1  .Text=txtUserName . Text =txtPassword.Text  ="";
            hfUserID.Value = "";
          
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if(Calendar1 .Visible )
            {

              
                Label1.Visible = false;
                Label2.Visible = false;
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                Calendar1.Visible = false;

            }
            else
            {
               TextBox1.Visible = true;
                Label1.Visible = true;
                Label2.Visible = true;
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                Calendar1.Visible = true;
            }
           TextBox1.Visible = true ;
            Label1.Visible = true;
            Label2.Visible = true;
            DropDownList1.Visible = true;
            DropDownList2.Visible = true;
            Calendar1.Visible = true;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = Convert.ToInt16(DropDownList1.SelectedValue);
            int month= Convert.ToInt16(DropDownList2.SelectedValue);

            Calendar1.VisibleDate = new DateTime(year, month, 1);
            Calendar1.SelectedDate = new DateTime(year, month, 1);
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            int year = Convert.ToInt16(DropDownList1.SelectedValue);
            int month = Convert.ToInt16(DropDownList2.SelectedValue);

            Calendar1.VisibleDate = new DateTime(year, month, 1);
            Calendar1.SelectedDate = new DateTime(year, month, 1);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();

            Label1.Visible = false;
            Label2.Visible = false;
            DropDownList1.Visible = false;
            DropDownList2.Visible = false;
            Calendar1.Visible = false;

        }
    }
}