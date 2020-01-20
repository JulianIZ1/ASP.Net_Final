using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinalProject
{
    public partial class AddRefills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string myid, myedit;
            DBConnection DBConnection = new DBConnection();

            lblRefillDate.Text = DateTime.Today;

            try
            {
                if (!Page.IsPostBack)
                {
                    DBConnection.connString.Open();
                    cmdString.Parameters.Clear();
                    cmdString.Connection = DBConnection.connString;
                    cmdString.CommandType = CommandType.StoredProcedure;
                    cmdString.CommandTimeout = 1500;
                    cmdString.CommandText = "VIEWPRESCRIPTIONS";
                    SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
                    aAdapter.SelectCommand = cmdString;
                    DataSet aDataSet = new DataSet();
                    aAdapter.Fill(aDataSet);
                    ddlPrescriptionID.DataSource = cmdString.ExecuteReader();
                    ddlPrescriptionID.DataValueField = "Prescription_ID";
                    ddlPrescriptionID.DataBind();
                    ddlPrescriptionID.Items.Insert(0, new ListItem("--Select Prescription ID--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                DBConnection.connString.Close();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string StoredProcedure;
            DBConnection DBConnection = new DBConnection();
            string str = ddlPrescriptionID.Text;
            try
            {
                try
                {
                    if ((string.IsNullOrEmpty(ddlPrescriptionID.Text)))
                        return;
                    else
                        try
                        {
                            if ((txtAmount.Text.Trim().Length == 0))
                                return;
                            else
                            {
                                switch (ddlAction.Text)
                                {
                                    case "Add":
                                        {
                                            StoredProcedure = "ADDREFILL";
                                            DBConnection.AddDropRefills(ddlPrescriptionID.Text, txtAmount.Text, lblRefillDate.Text, StoredProcedure);
                                            break;
                                        }

                                    case "Remove":
                                        {
                                            StoredProcedure = "REMOVEREFILL";
                                            DBConnection.AddDropRefills(ddlPrescriptionID.Text, txtAmount.Text, lblRefillDate.Text, StoredProcedure);
                                            break;
                                        }
                                }
                                if (DBConnection.Reply != "True")
                                {
                                    string script = "<script type='text/javascript'> alert('" + DBConnection.Reply + "');</script>";
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "AlertBox", script);
                                    lblDisplay.Text = "Success";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ViewPrescriptions.aspx");
            }
            catch (Exception ex)
            {
            }
        }


    }
}