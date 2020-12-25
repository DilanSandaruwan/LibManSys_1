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
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
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

        private void Btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //string query = "INSERT INTO book_det " +
                //           "VALUES (" + txt_id.Text + ",'" + txt_name.Text + "','" + txt_author.Text + "','" + txt_publisher.Text + "','" + txt_dop.Text + "'," + txt_qnt.Text + ")";
                string query = "INSERT INTO book_det(book_id,book_name,book_author,book_publication)" +
                           "VALUES (" + txt_id.Text + ",'" + txt_name.Text + "','" + txt_author.Text + "','" + txt_publisher.Text + "')";
                int x = Class_connect.iud(query);
                
                MessageBox.Show("Successfully Inserted.", "Successfull! ", MessageBoxButtons.OK);
                resetForm();

            }
            catch(Exception exc)
            {
                MessageBox.Show("Incorrect type of input."+exc, "Sorry! ", MessageBoxButtons.RetryCancel);
            }
        }
        private void resetForm()
        {
            String cl = null;
            txt_id.Text = cl;
            txt_name.Text = cl;
            txt_author.Text = cl;
            txt_publisher.Text = cl;
            txt_dop.Text = cl;
            txt_qnt.Text = cl;
        }

        private void Txt_dop_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {            
            txt_dop.Text = DateTime.Now.ToShortDateString();
        }
    }
}
