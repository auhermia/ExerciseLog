using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExerciseLog
{
    public partial class Measurements : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ExerciseLogCS"].ConnectionString;

        /*********************
         *       EVENTS      *
         *********************/

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMeasurements();
        }

        /*********************
        *     FUNCTIONS     *
        *********************/

        // Load Measurements onto table
        public void LoadMeasurements()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string getTable = "SELECT * FROM dbo.Measurements";
                SqlCommand cmd = new SqlCommand(getTable, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                measurementsTable.DataSource = reader;
                measurementsTable.DataBind();
            }
        }
    }
}