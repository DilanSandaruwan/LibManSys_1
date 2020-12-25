using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

//using LibManSys_1.Properties;

namespace LibManSys_1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Btn_log_Click(object sender, EventArgs e)
        {
            int cou = 0;
            SqlCommand cmd = Class_connect.conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM library_person WHERE u_name='"+txt_uname.Text+"' AND psw='"+txt_psw.Text+"'";
            cmd.ExecuteNonQuery();

            SqlDataAdapter sadp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sadp.Fill(dt);
            cou = Convert.ToInt32(dt.Rows.Count.ToString());                
            
            if (cou == 0)
            {
                MessageBox.Show("Username and Password do not match.","Invalid Accesss",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
                //return;
            }
            else
            {
                MDIParent1 mdi = new MDIParent1();
                mdi.Show();
                this.Hide();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class_connect.My_setConn();
            Console.WriteLine("Done baby");
            Class_connect.My_checkConn();
        }
    }
}
