using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;

namespace ASP_Final
{
    public class Global_asax : System.Web.HttpApplication
    {
        public SqlClient.SqlConnection connString = new SqlClient.SqlConnection("server=TND-SOPH-02; initial catalog=REFILL_PROJECT; connect timeout=30;integrated security=SSPI;");
        public SqlClient.SqlCommand cmdString = new SqlClient.SqlCommand();
        public string Reply;
        public SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
        public DataSet aDataSet = new DataSet();
        public string userPassword = "";
        public string hidePassword = "";
        public void Application_Start(object sender, EventArgs e)
        {
        }

        public void Session_Start(object sender, EventArgs e)
        {
        }

        public void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        public void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        public void Application_Error(object sender, EventArgs e)
        {
        }

        public void Session_End(object sender, EventArgs e)
        {
        }

        public void Application_End(object sender, EventArgs e)
        {
        }
    }