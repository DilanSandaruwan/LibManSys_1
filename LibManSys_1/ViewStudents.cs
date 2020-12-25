using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibManSys_1
{
    public partial class ViewStudents : Form
    {
        DataTable dt; Bitmap bmp;
        public ViewStudents()
        {
            InitializeComponent();
        }

        private void ViewStudents_Load(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                dataGridView1.DefaultCellStyle.Font = new Font("MS Reference Sans Serif", 9);
                dt = Class_connect.ovd("SELECT * FROM student_det");
                
                dataGridView1.DataSource = dt;
                //setImageView(i);

               
                DataGridViewImageColumn dgvic = new DataGridViewImageColumn();
                //dgvic.Width = 500;
                dgvic.HeaderText = "Student Image";
                dgvic.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvic.Width = 400;
                dataGridView1.Columns.Add(dgvic);


                foreach (DataRow dr in dt.Rows)
                {
                    bmp = new Bitmap(@"..\..\" + dr["stu_image"].ToString());Console.WriteLine("foreach {0}", i);
                    dataGridView1.Rows[i].Cells[8].Value = bmp;Console.WriteLine("did pic val");
                    dataGridView1.Rows[i].Height = 100; Console.WriteLine("did pic height");
                    i += 1;
                }
               // DataRow drt = dt.Rows[0];
                //bmp = new Bitmap(@"..\..\" + drt["stu_image"].ToString());
                pictureBox1.Image = bmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                //Class_connect.conn.Close();
                //dataGridView1.EndEdit();
                //dataGridView1.Font();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void setImageView(int i)
        {
            

            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int sel_itm = cmbo_search.SelectedIndex;
            String search_str = "";

            switch (sel_itm)
            {
                case 0: search_str = "SELECT * FROM student_det WHERE stu_name LIKE '%" + txt_search.Text + "%'"; Console.WriteLine("line 0"); break;
                case 1: search_str = "SELECT * FROM student_det WHERE stu_id LIKE '%" + txt_search.Text + "%'"; Console.WriteLine("line 1"); break;
                case 2: search_str = "SELECT * FROM student_det WHERE stu_lib_id LIKE '%" + txt_search.Text + "%'"; Console.WriteLine("line 2"); break;
                default:
                    MessageBox.Show("Please select a suitable search type.");
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

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MDIParent1().Show();
            this.Close();

        }

        private void Btn_view_Click(object sender, EventArgs e)
        {
            
             int t = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            string selector = "SELECT * FROM student_det WHERE stu_lib_id = "+t+"";
            dt = Class_connect.ovd(selector);
                              
            
            InfoStu_Form isf = new InfoStu_Form(dt);
            isf.Show();
        }
    }
}
