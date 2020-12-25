using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace LibManSys_1
{
    static class Class_connect
    {
        public static SqlConnection conn = null;
        public static int x = 0, y = 0;//x is #rows passing into the DB; y is #rows in the DataTable, retrieve from the DB.
        public static void My_setConn()
        {
            
            try
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-RC6BRLR\MYSQL2019;Initial Catalog=library_management_system_1;Integrated Security=True;Pooling=False");
                //Console.WriteLine("setconn done");
            }
            catch (Exception e)
            {
                MessageBox.Show("Type 1 Connection faied! Please check the connection to the database." + e, "Connection error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                //Console.WriteLine("setconn done but exceptioned.");
            }
        }

        public static void My_checkConn()
        {
            if (conn.State == ConnectionState.Open)
            {
                //Console.WriteLine("checkconn entered");
                conn.Close();//To have a uni connection only; no more than one connection.
                //Console.WriteLine("checkconn entered conn closed first");
            }
            try
            {
                //Console.WriteLine("checkconn entered try block");
                conn.Open();
                //Console.WriteLine("checkconn entered try block conn opened");
            }
            catch (Exception e)
            {

                MessageBox.Show("Type 2 Connection faied! Please check the connection to the database." + e, "Connection error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                //Console.WriteLine("checkconn entered but exceptioned");
            }


        }
        public static int iud(String s)
        {
            x = 0;
            My_checkConn();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = s;
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                throw exc;
            }

            conn.Close();
            return x;

        }
        public static DataTable ovd(String s)
        {
            y = 0;
            My_checkConn();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = s;

            Console.WriteLine("ovd before execute");
            cmd.ExecuteNonQuery();
            Console.WriteLine("ovd after execute");

            SqlDataAdapter sadp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            sadp.Fill(dt);
            y = Convert.ToInt32(dt.Rows.Count.ToString());
            Console.WriteLine("y is "+y);
            conn.Close();
            return dt ;
        }

    }
}
