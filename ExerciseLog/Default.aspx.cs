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
    public partial class Default : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ExerciseLogCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadExerciseLogs();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SaveExerciseLogs();
            LoadExerciseLogs();
        }

        public void LoadExerciseLogs()
        {
            // REFRESH TABLE
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //string getTable = "SELECT @Date, @Exercise, @Time FROM dbo.Log";
                string getTable = "SELECT Date, Exercise, TimeSpent FROM dbo.Log";
                SqlCommand cmd = new SqlCommand(getTable, con);
                cmd.Parameters.AddWithValue("@Date", "Date");
                cmd.Parameters.AddWithValue("@Exercise", "Exercise");
                cmd.Parameters.AddWithValue("@Time", "TimeSpent");

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                resultsTable.DataSource = reader;
                resultsTable.DataBind();
            }
        }

        public void SaveExerciseLogs()
        {            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // UPDATE DB
                string insertQuery = "INSERT INTO dbo.Log VALUES (@Date, @Exercise, @Time, 'false')";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@Date", date.Text);
                cmd.Parameters.AddWithValue("@Exercise", exercise.Text);
                cmd.Parameters.AddWithValue("@Time", "00:" + time.Text);
                
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                date.Text = "";
                exercise.Text = "";
                time.Text = "";
            }
        }

        //protected void addBtn_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("AddMeasurement.aspx");
        //}
    }
}