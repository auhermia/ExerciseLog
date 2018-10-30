using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExerciseLog
{
    public partial class AddMeasurement : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ExerciseLogCS"].ConnectionString;

        /*********************
         *       EVENTS      *
         *********************/

        // 1).  PAGE LOAD

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDateDDL();
            }
        }

        // 2). LOAD ENUMERATIONS

        // Load Exercise (based on selected date)
        protected void dateDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dateDDL.SelectedIndex == 0) { } // do nothing
            else
            {
                exerciseDDL.Enabled = true;
                SqlParameter param = new SqlParameter("@Date", dateDDL.SelectedItem.Text);
                //SqlParameter param = new SqlParameter("@Date", "2018-09-21");

                DataSet ds = GetData("spGetExerciseByDate", param);

                exerciseDDL.DataSource = ds;
                exerciseDDL.DataTextField = "Exercise";
                exerciseDDL.DataValueField = "LogId";
                exerciseDDL.DataBind();

                ListItem LIExercise = new ListItem("Select Activity", "-1");
                exerciseDDL.Items.Insert(0, LIExercise);
            }
        }

        //  3).  ADD MEASUREMENT TO DB
        protected void AddMeasurement_Click(object sender, EventArgs e)
        {
            SaveMeasurements();
            Server.Transfer("Measurements.aspx");
        }

        /*********************
         *     FUNCTIONS     *
         *********************/

        // 1.  Save Measurements

        public void SaveMeasurements()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // UPDATE DB
                string insertQuery = "INSERT INTO dbo.Measurements VALUES " +
                    "(@Date, @Weight, @Chest, @Waist, @Hips, @UpperArm, @Thigh, @Calf)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@Date", dateDDL.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Weight", weight.Text);
                cmd.Parameters.AddWithValue("@Chest", chest.Text);
                cmd.Parameters.AddWithValue("@Waist", waist.Text);
                cmd.Parameters.AddWithValue("@Hips", hips.Text);
                cmd.Parameters.AddWithValue("@UpperArm", upperArm.Text);
                cmd.Parameters.AddWithValue("@Thigh", thigh.Text);
                cmd.Parameters.AddWithValue("@Calf", calf.Text);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
            }
        }

        // 2.  LOAD ENUMERATIONS

        // generic method to call/execute stored procedures
        private DataSet GetData(string SPName, SqlParameter SPParameter)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(SPName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if(SPParameter != null)
            {
                da.SelectCommand.Parameters.Add(SPParameter);
            }
            DataSet DS = new DataSet();
            da.Fill(DS);

            return DS;
        }

        private void LoadDateDDL()
        {
            // Load enumeration values - Date
            if (!IsPostBack)
            {
                // Call StoreProcedure and pull Dates
                dateDDL.DataSource = GetData("spGetDates", null);
                dateDDL.DataTextField = "Date";
                dateDDL.DataValueField = "LogId";
                dateDDL.DataBind();

                // SET ENUMERATION DEFAULT VALUES
                ListItem LIDate = new ListItem("Select Date", "-1");
                dateDDL.Items.Insert(0, LIDate);

                ListItem LIExercise = new ListItem("Select Activity", "-1");
                exerciseDDL.Items.Insert(0, LIExercise);

                // Grayout child dropdown by default
                exerciseDDL.Enabled = false;
            }
        }
    }
}




/* graveyard
 * 
 *         //public void LoadDDL()
        //{
        //    // default value
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        string getDates = "SELECT LogId, Date FROM dbo.Log";
        //        SqlCommand cmd = new SqlCommand(getDates, con);

        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        dateDDL.DataSource = reader;
        //        dateDDL.DataTextField = "Date";
        //        dateDDL.DataValueField = "LogId";
        //        dateDDL.DataBind();
        //    }
        //}

            //[WebMethod]
        //[ScriptMethod(UseHttpGet=true)]
        ////[System.Web.Services.WebMethod]
        //public void LoadExercise()
        //{
        //    Test.Text = "This is loading";
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        string selectedDate = dateDDL.SelectedItem.Text;
        //        string getDates = "SELECT LogId, Exercise FROM dbo.Log " +
        //            "WHERE Date =  '" + selectedDate + "'";
        //        SqlCommand cmd = new SqlCommand(getDates, con);

        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        exerciseDDL.DataSource = reader;
        //        exerciseDDL.DataTextField = "Exercise";
        //        exerciseDDL.DataValueField = "LogId";
        //        exerciseDDL.DataBind();                
        //    }
        //}

    */
