using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibManSys_1
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        string pwd;
        string wanted_path;

        private void Btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                
                String img_path = "Student Images\\" + pwd + ".jpg";
                Console.WriteLine(img_path);

                string query = "INSERT INTO student_det " +
                           "VALUES (" + txt_libid.Text + ","
                                    + txt_stuid.Text + ",'"
                                    + txt_name.Text + "','"
                                    + txt_contact.Text + "','"
                                    + txt_email.Text + "','"
                                    + txt_dor.Text + "','"
                                    + img_path.ToString() + "',"
                                    + "0" + ")";

                int x = Class_connect.iud(query);
                File.Copy(openFileDialog1.FileName, wanted_path + "\\Student Images\\" + pwd + ".jpg");

                MessageBox.Show("Successfully Inserted.", "Successfull! ", MessageBoxButtons.OK);

                resetForm();

            }
            catch (Exception exc)
            {
                MessageBox.Show("Incorrect type of input." + exc, "Sorry! ", MessageBoxButtons.RetryCancel);
            }
        }
        private void resetForm()
        {
            String cl = null;
            txt_libid.Text = cl;
            txt_stuid.Text = cl;
            txt_name.Text = cl;
            txt_contact.Text = cl;
            txt_dor.Text = cl;
            txt_email.Text = cl;
            //pbx_pic.CancelAsync();
            //pbx_pic.Update;
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            txt_dor.Text = DateTime.Now.ToShortDateString();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            pwd = Class1.GetRandomPassword(20);

            wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            DialogResult result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png| JPG (*.jpg)|*.jpg| GIF Files (*.gif)|*.gif";
            if(result == DialogResult.OK)
            {
                pbx_pic.ImageLocation = openFileDialog1.FileName ;
                pbx_pic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
