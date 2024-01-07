using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace CST21C
{
    public partial class customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
                BtnSave.Enabled = true;

            }
        }

      
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE customers set FirstName=@fname,LastName=@lname,Email=@email,Password=@pass where CustomerID = @cid", conn);
                cmd.Parameters.AddWithValue("@cid", DgvCustomer.SelectedRow.Cells[0].Text);
                cmd.Parameters.AddWithValue("@fname", TextFirstName.Text);
                cmd.Parameters.AddWithValue("@lname", TextLastName.Text);
                cmd.Parameters.AddWithValue("@email", TextEmail.Text);
                cmd.Parameters.AddWithValue("@pass", TextPassword.Text);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Data has been Updated successfuly!')</script>");
                DgvCustomer.DataBind();
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
                BtnSave.Enabled = true;
                clear();
            }
        }

        private void clear()
        {
            TextFirstName.Text = "";
            TextLastName.Text = "";
            TextEmail.Text = "";
            TextPassword.Text = "";
        }

        protected void BtnSave_Click1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into customers(FirstName,LastName,Email,Password) VALUES (@fname,@lname,@email,@pass)", conn);
                cmd.Parameters.AddWithValue("@fname", TextFirstName.Text);
                cmd.Parameters.AddWithValue("@lname", TextLastName.Text);
                cmd.Parameters.AddWithValue("@email", TextEmail.Text);
                cmd.Parameters.AddWithValue("@pass", TextPassword.Text);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Data has been saved successfuly!')</script>");
                DgvCustomer.DataBind();
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
                BtnSave.Enabled = true;
                clear();
            }
        }

        protected void DgvCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextFirstName.Text = DgvCustomer.SelectedRow.Cells[1].Text;
            TextLastName.Text = DgvCustomer.SelectedRow.Cells[2].Text;
            TextEmail.Text = DgvCustomer.SelectedRow.Cells[3].Text;
            TextPassword.Text = DgvCustomer.SelectedRow.Cells[4].Text;

            BtnUpdate.Enabled = true;
            BtnDelete.Enabled = true;
            BtnSave.Enabled = false;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM customers WHERE CustomerID = @cid", conn);
                cmd.Parameters.AddWithValue("@cid", DgvCustomer.SelectedRow.Cells[0].Text);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Data has been Deleted successfuly!')</script>");
                DgvCustomer.DataBind();
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
                BtnSave.Enabled = true;
                clear();
            }
        }

    }
}