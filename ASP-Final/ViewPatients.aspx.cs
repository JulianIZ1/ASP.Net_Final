using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace WebFinalProject
{
    public partial class ViewPatients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
            else
            {
            }
        }
        public string sortDir
        {
            get
            {
                return System.Convert.ToString(ViewState("sortDir"));
            }
            set
            {
                ViewState("sortDir") = value;
            }
        }
        private void LoadData()
        {
            DBConnection DBConnection = new DBConnection();
            {
                var withBlock = this;
                DataSet adataset = new DataSet();
                adataset = DBConnection.ViewPatients;
                withBlock.grdStudents.DataSource = adataset.Tables(0);
                withBlock.grdStudents.DataBind();
                if (Cache("PatientViewData") == null)
                    Cache.Add("PatientViewData", new DataView(adataset.Tables(0)), null/* TODO Change to default(_) if this is not a reference type */, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, null/* TODO Change to default(_) if this is not a reference type */);
            }
        }
        public void Delete_Click(object sender, CommandEventArgs e)
        {
            try
            {
                CheckBox chk;
                Label lbl;
                string stu_ID;
                DBConnection aDatatier = new DBConnection();
                if (grdStudents.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdStudents.Rows)
                    {
                        chk = (CheckBox)row.FindControl("chkPatID");
                        if (chk.Checked == true)
                        {
                            lbl = (Label)row.Controls(0).FindControl("hidPatID");
                            stu_ID = lbl.Text.ToString;
                            aDatatier.DeleteProcedure(stu_ID, "PATIENT");
                        }
                    }
                    LoadData();
                    StringBuilder cba = new StringBuilder();
                    cba.Append("location.Reload();");
                    ClientScript.RegisterClientScriptBlock(typeof(Page), "CloseReloadScript", cba.ToString(), true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public void NewPatient()
        {
            DBConnection DBConnection = new DBConnection();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script language='javascript'>");
                sb.Append("window.open('AddPatient.aspx),");
                sb.Append("'width=525, height=525, menubar=no, resizable=yes, left=50, top=50, scrollbars=yes');");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(typeof(Page), "PopupScript", sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public void SearchPatient()
        {
            DBConnection DBConnection = new DBConnection();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script language='javascript'>");
                sb.Append("window.open('SearchPatient.aspx),");
                sb.Append("'width=525, height=525, menubar=no, resizable=yes, left=50, top=50, scrollbars=yes');");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(typeof(Page), "PopupScript", sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public void lbtnEdit_Click(object sender, CommandEventArgs e)
        {
            string recordToBeEdited;
            DBConnection DBConnection = new DBConnection();
            try
            {
                recordToBeEdited = Trim(e.CommandArgument);
                StringBuilder sb = new StringBuilder();
                sb.Append("<script language='javascript'>");
                sb.Append("window.open('UpdatePatient.aspx?ID=" + DBConnection.Encrypt(recordToBeEdited, "12345678") + "&type=Edit" + "'  , 'student',"); // StudentDataTier.Encrypt(recordToBeEdited, "12345678")
                sb.Append("'width=525, height=525, menubar=no, resizable=yes, left=50, top=50, scrollbars=yes');");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(typeof(Page), "PopupScript", sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void grdStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.Header))
                (CheckBox)e.Row.FindControl("cbSelectAll").Attributes.Add("onclick", "javascript:SelectAll('" + (CheckBox)e.Row.FindControl("cbSelectAll").ClientID + "')");
        }

        private void grdStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStudents.PageIndex = e.NewPageIndex;
            LoadData();
        }
        private void SortRecords(string sortExpress)
        {
            string oldExpression = grdStudents.SortExpression;
            string newExpression = sortExpress;
            string lastValue, theSortField;
            DataView source;
            string theDirection;
            string wildChar;
            string sortExpression;

            theDirection = " ";
            wildChar = "%";

            try
            {
                lastValue = System.Convert.ToString(ViewState("sortValue"));
                sortExpression = sortExpress;
                theSortField = System.Convert.ToString(ViewState("sortField"));
                if (this.sortDir == "desc")
                    this.sortDir = "asc";
                else
                    this.sortDir = "desc";

                source = Cache("PatientViewData");
                source.Sort = (" " + sortExpression + " " + this.sortDir);

                grdStudents.DataSource = source;
                grdStudents.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void grdStudents_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
        {
             SortRecords(e.SortExpression);
        }

    }
}      