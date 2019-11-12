using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolmanagementSystem
{
    class updatecs
    {

        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;

        public string update_std(student s)
        {

            string msg = "";

            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("updatestudents ", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@std_name", SqlDbType.VarChar, 20).Value = s.s_name;

                cmd.Parameters.Add("@std_fname", SqlDbType.VarChar, 20).Value = s.s_fname;
                cmd.Parameters.Add("@gender", SqlDbType.VarChar, 20).Value = s.s_gender;
                cmd.Parameters.Add("@std_address", SqlDbType.VarChar, 50).Value = s.s_address;
                cmd.Parameters.Add("@std_admission_date", SqlDbType.VarChar, 20).Value = s.s_date;
                cmd.Parameters.Add("@std_id_fk_id", SqlDbType.VarChar, 20).Value = s.s_fk;


                conn.Open();
                cmd.ExecuteNonQuery();


                msg = "Data successfully inserted";


            }
            catch (Exception)
            {
                msg = "Data is not successfully inserted";



            }


            finally
            {

                conn.Close();


            }
            return msg;

        }




    }
}
