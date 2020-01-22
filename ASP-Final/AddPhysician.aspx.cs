using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Final
{
    public partial class AddPhysician : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            ddlState.DataSource = StateManager.getStates();
            ddlState.DataTextField = "FullAndAbbrev";
            ddlState.DataValueField = "abbreviation";
            ddlState.Text = "PA";
            ddlState.DataBind();
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                
                Response.Redirect("ViewPhysicians.aspx");
            }
            
            catch (Exception ex)
            {
                string script = "<script type='text/javascript'> alert('" + ex.Message + "');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "AlertBox", script);
            }
        }
        protected void btnHidden_Click(object sender, EventArgs e)
        {
            DBConnection DBConnection = new DBConnection();
            string Reply;
            var textBoxes = this.Controls.OfType<TextBox>;
            // Checks for required input (FNAME, LNAME, GENDER, DOB)
            try
            {
                if (txtPhyID.Text.Substring(0, 1) != "D")
                {
                    string script = "<script type='text/javascript'> alert('" + "The ID must begin with 'D'" + "');</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "AlertBox", script);
                    return;
                }
                if (txtStreet.Text == "")
                    txtStreet.Text = "N/A";
                if (txtCity.Text == "")
                    txtCity.Text = "N/A";
                if (txtZIP.Text == "")
                    txtZIP.Text = "0";
                if (txtOfficePhone.Text == "")
                    txtOfficePhone.Text = "N/A";
                if (txtPersonalPhone.Text == "")
                    txtPersonalPhone.Text = "N/A";
                if (txtEmailI.Text == "")
                    txtEmailI.Text = "N/A";
                if (txtEmailII.Text == "")
                    txtEmailII.Text = "N/A";
                if (txtWorkEmail.Text == "")
                    txtWorkEmail.Text = "N/A";
            }
            catch (Exception ex)
            {
                string script = "<script type='text/javascript'> alert('" + ex.Message + "');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "AlertBox", script);
            }
            // Checks for empty textboxes

            // Adds values to database
            try
            {
                DBConnection.AddPhysician(txtPhyID.Text, txtFName.Text, txtMidInit.Text, txtLName.Text, ddlGender.Text, txtStreet.Text, txtCity.Text, ddlState.Text, txtZIP.Text, DateTime.Parse(txtDOB.Text), txtOfficePhone.Text, txtPersonalPhone.Text, txtEmailI.Text, txtEmailII.Text, txtWorkEmail.Text, txtPosition.Text, txtSpecialty.Text, decimal.Parse(txtSalary.Text));
                Reply = "Success";
                btnClose.Text = "Refresh";
            }
            catch (Exception ex)
            {
                string script = "<script type='text/javascript'> alert('" + ex.Message + "');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "AlertBox", script);
                Reply = "Fail";
            }
            DBConnection.connString.Close();
            lblDisplay.Text = Reply;
        }
    }
}