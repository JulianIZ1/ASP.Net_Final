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
    public class Global : System.Web.HttpApplication
    {


        public SqlClient.SqlConnection connString = new SqlClient.SqlConnection("server=CNSA07E-SVR; initial catalog=REFILL_PROJECT; connect timeout=30;integrated security=SSPI;");
        public SqlClient.SqlCommand cmdString = new SqlClient.SqlCommand();
        public string Reply;
        public SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
        public DataSet aDataSet = new DataSet();
        public string userPassword = "";
        public string hidePassword = "";

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}