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

namespace LibManSys_1
{
    public partial class ViewBooks : Form
    {
        DataTable dt;
        public ViewBooks()
        {
            InitializeComponent();
        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DefaultCellStyle.Font = new Font("MS Reference Sans Serif", 9);
                dt = Class_connect.ovd("SELECT * FROM book_det");

                dataGridView1.DataSource = dt;
                //Class_connect.conn.Close();
                //dataGridView1.EndEdit();
                //dataGridView1.Font();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void Btn_nhome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MDIParent1 mdi = new MDIParent1();
            mdi.Show();
            this.Close();

        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void Cmbo_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int sel_itm = cmbo_search.SelectedIndex;
            String search_str = "";

            switch (sel_itm)
            {
                case 0: search_str = "SELECT * FROM book_det WHERE book_name LIKE '%" + txt_search.Text + "%'"; Console.WriteLine("line 0"); break;
                case 1: search_str = "SELECT * FROM book_det WHERE book_author LIKE '%" + txt_search.Text + "%'"; Console.WriteLine("line 1"); break;
                case 2: search_str = "SELECT * FROM book_det WHERE book_publication LIKE '%" + txt_search.Text + "%'"; Console.WriteLine("line 2"); break;
                default:MessageBox.Show("Please select a suitable search type.");
                    return;
            }
            if (search_str.Equals(""))
            {
                MessageBox.Show("Please type a suitable search item.");
            }
            else
            {
                dt = Class_connect.ovd(search_str);

                if (Class_connect.y == 0)
                {
                    MessageBox.Show("No such item.");                    
                }                
                dataGridView1.DataSource = dt;
            }
            
        }

        private void Btn_view_Click(object sender, EventArgs e)
        {
            int b_id;
            String b_name;
            String b_author;
            String b_pub;
            int b_count;

            //String b_date;//to be modify with joins in sql
            //int b_quantity;//to be modify with joins in sql

            int t = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                        
            Console.WriteLine("Row is "+t);
            dt = Class_connect.ovd("SELECT * FROM book_det WHERE book_id="+t+"");

            /*
            foreach (DataRow dr in dt.Rows)
            {
                b_id = Convert.ToInt32(dr["book_id"].ToString());
                b_name = dr["book_name"].ToString();
                b_author = dr["book_author"].ToString();
                b_pub = dr["book_publication"].ToString();
                b_date = Convert.ToString(dr["dof_purchased"].ToString());
                b_quantity = Convert.ToInt32(dr["quantity"].ToString());
            }
            */
            DataRow dr = dt.Rows[0];
            b_id = Convert.ToInt32(dr["book_id"].ToString());
            b_name = dr["book_name"].ToString();
            b_author = dr["book_author"].ToString();
            b_pub = dr["book_publication"].ToString();
            b_count = Convert.ToInt32(dr["count"].ToString());
            //b_date = Convert.ToString(dr["dof_purchased"].ToString());//to be modify with joins in sql
            //b_quantity = Convert.ToInt32(dr["quantity"].ToString());//to be modify with joins in sql


            //InfoForm infor = new InfoForm(b_id, b_name, b_author, b_pub, b_date, b_quantity);
            ClassBookInfo cbi = new ClassBookInfo();
            cbi.Id = b_id;
            cbi.B_name = b_name;
            cbi.B_author = b_author;
            cbi.B_pub = b_pub;
            cbi.B_count = b_count;
            //cbi.B_date = b_date;//to be modify with joins in sql
            //cbi.B_quantity = b_quantity;//to be modify with joins in sql

            Info_Form infor = new Info_Form(cbi);
            infor.Show();

        }
    }
}
