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
    public partial class BookIssueForm : Form
    {
        

        public BookIssueForm()
        {
            InitializeComponent();
        }
        DataTable dt;
        int new_book1_count;
        int new_book2_count;

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Txt_book_name_TextChanged(object sender, EventArgs e)
        {

            BookSelector();
        }
       
        private void BookIssueForm_Load(object sender, EventArgs e)
        {
            txt_doi.Text = DateTime.Now.ToShortDateString();
            try
            {
                string s = "SELECT issue_id FROM book_issue";
                DataTable dtx = Class_connect.ovd(s);
                int i = -1;
                if (Class_connect.y < 1)
                {
                    txt_issue_id.Text = Convert.ToString(1);
                }
                else
                {
                    DataRow drx;
                    foreach (DataRow dr in dtx.Rows)
                    {

                        i += 1;
                    }
                    drx = dtx.Rows[i];
                    txt_issue_id.Text = Convert.ToString(Convert.ToInt32(drx["issue_id"].ToString()) + 1);
                }


                string s1 = "SELECT book_id,book_name,book_author,count FROM book_det";
                dt = Class_connect.ovd(s1);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                int t = Convert.ToInt32(dataGridView1.SelectedCells[3].Value.ToString());
                lbl_count.Text = t.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void BookSelector()
        {
            //here count in book_det is also included in the data table.Remember to exclude it when further normalization of book_det
            string s2 = "SELECT book_id,book_name,book_author,count FROM book_det WHERE book_name LIKE '%" + txt_book_name.Text + "%'";
            //here count in book_det is also included in the data table.Remember to exclude it when further normalization of book_det
            dt = Class_connect.ovd(s2);
            dataGridView1.DataSource = dt;
            Refresh();
        }

        private void Btn_1_Click(object sender, EventArgs e)
        {            
            int t = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            int book1_id = t;
            txt_book1_id.Text = book1_id.ToString();
            new_book1_count = Convert.ToInt32(lbl_count.Text) - 1;
            lbl_count.Text = Convert.ToString(new_book1_count);
        }

        private void Btn_2_Click(object sender, EventArgs e)
        {
            int t = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            int book2_id = t;
            txt_book2_id.Text = book2_id.ToString();
            new_book2_count = Convert.ToInt32(lbl_count.Text) - 1;
            
            lbl_count.Text = Convert.ToString(new_book2_count);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //lbl_count.Text = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {    
            if(txt_book1_id.Text == dataGridView1.SelectedCells[0].Value.ToString())
            {
                lbl_count.Text = new_book1_count.ToString();
            }
            else if (txt_book2_id.Text == dataGridView1.SelectedCells[0].ToString())
            {
                lbl_count.Text = new_book2_count.ToString();
            }
            else
            {
                int t = Convert.ToInt32(dataGridView1.SelectedCells[3].Value.ToString());
                lbl_count.Text = t.ToString();
            }

        }

        private void Btn_nhome_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MDIParent1().Show();
            this.Close();

        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(this,"Please check the details again.\nAre you sure to issue this books/s","Confirm to proceed",MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string issue = "INSERT INTO book_issue VALUES("
                + txt_issue_id.Text + ","
                + txt_lib_id.Text + ","
                + txt_book1_id.Text + ","
                + txt_book2_id.Text + ",'"
                + txt_doi.Text + "')";
                //string update1 = "UPDATE book_det SET count =" + new_book1_count.ToString() + " WHERE book_id=" + txt_book1_id.Text + "";
                //string update2 = "UPDATE book_det SET count =" + new_book2_count.ToString() + " WHERE book_id=" + txt_book2_id.Text + "";

                string update1 = "UPDATE book_det SET count -=" + Convert.ToString(1) + " WHERE book_id=" + txt_book1_id.Text + "";
                string update2 = "UPDATE book_det SET count -=" + Convert.ToString(1) + " WHERE book_id=" + txt_book2_id.Text + "";

                try
                {
                    if (txt_book2_id.Text == "")
                    {
                        Console.WriteLine("\"empty\" to fuck");
                        /*since book2_id is int and empty => used zero(0) as the passing book2_id.
                         * this may vary and BELOW part would be deleted when the book2_id type is converted to string/varchar in db.
                         */
                        txt_book2_id.Text = Convert.ToString(0);
                        issue = "INSERT INTO book_issue VALUES("
                                    + txt_issue_id.Text + ","
                                    + txt_lib_id.Text + ","
                                    + txt_book1_id.Text + ","
                                    + txt_book2_id.Text + ",'"
                                    + txt_doi.Text + "')";
                        
                        update2 = "UPDATE book_det SET count -=" + Convert.ToString(1) + " WHERE book_id=" + txt_book2_id.Text + "";
                        /*since book2_id is int and empty => used zero(0) as the passing book2_id.
                         * this may vary and ABOVE part would be deleted when the book2_id type is converted to string/varchar in db.
                         */
                    }
                    else
                    {
                        //Console.WriteLine("come to fuck upd2");
                        Class_connect.iud(update2);
                        Console.WriteLine("fucked upd2");
                    }

                    try
                    {
                        //Console.WriteLine("come to fuck issue");
                        Class_connect.iud(issue);
                        Console.WriteLine("fucked issue");
                        try
                        {
                            //Console.WriteLine("come to fuck upd1");
                            Class_connect.iud(update1);
                            Console.WriteLine("fucked upd1");

                            MessageBox.Show("Successfully inserted and updated");
                        }
                        catch (Exception exc3)
                        {
                            MessageBox.Show("update1 string: \n" + exc3.Message);
                        }
                    }
                    catch (Exception exc2)
                    {                        
                        MessageBox.Show("issue string: \n" + exc2.Message);
                    }
                }
                catch (Exception exc1)
                {
                    MessageBox.Show("update2 string: \n" + exc1.Message);
                }
            }
            else
            {

            }
            
            


        }
    }
}
