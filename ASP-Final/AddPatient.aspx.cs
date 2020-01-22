using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Final
{
    public partial class AddPatient : System.Web.UI.Page
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
        
            Response.Redirect("ViewPatients.aspx");
            }
    
            catch (Exception ex)
            {
            string script = "<script type='text/javascript'> alert('" + ex.Message + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "AlertBox", script);
            }
        }
        protected void btnHidden_Click(object sender, EventArgs e)
        {
            DBConnection aAddRecordPatient = new DBConnection();
            string Reply;
            var textBoxes = this.Controls.OfType<TextBox>();

            int errCount = 0;
            try
            {
                // Checks for empty textboxes
                try
                {
                    if ((txtStreet.Text == ""))
                        txtStreet.Text = "N/A";
                    if ((txtCity.Text == ""))
                        txtCity.Text = "N/A";
                    if ((txtZIP.Text == ""))
                        txtZIP.Text = "0";
                    if ((txtHomePhone.Text == ""))
                        txtHomePhone.Text = "N/A";
                    if ((txtCellPhone.Text == ""))
                        txtCellPhone.Text = "N/A";
                    if ((txtEmailI.Text == ""))
                        txtEmailI.Text = "N/A";
                    if ((txtEmailII.Text == ""))
                        txtEmailII.Text = "N/A";
                    if ((txtEmailIII.Text == ""))
                        txtEmailIII.Text = "N/A";
                }
                catch (Exception ex)
                {
                    string script = "<script type='text/javascript'> alert('" + ex.Message + "');</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "AlertBox", script);
                }
                // Adds values to database
                try
                {
                    aAddRecordPatient.AddPatient(txtPatID.Text, txtFName.Text, txtMidInit.Text, txtLName.Text, ddlGender.Text, txtStreet.Text, txtCity.Text, ddlState.Text, txtZIP.Text, txtDOB.Text, txtHomePhone.Text, txtCellPhone.Text, txtEmailI.Text, txtEmailII.Text, txtEmailIII.Text);
                    if (aAddRecordPatient.Reply2 == "Fail")
                    {
                        Response.Write("<script language=\"javascript\">alert('Duplicate record');</script>");
                        Reply = "Fail";
                    }
                    else
                        Reply = "Success";
                }
                catch (Exception ex)
                {
                    string script = "<script type='text/javascript'> alert('" + ex.ToString() + "');</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ABox", script);
                    Reply = "Fail";
                }
                aAddRecordPatient.connString.Close();
                btnClose.Text = "Refresh";
                lblDisplay.Text = Reply;
            }
            catch (Exception ex)
            {
                string script = "<script type='text/javascript'> alert('" + ex.Message + "');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "BBox", script);
            }
        }
    }
}