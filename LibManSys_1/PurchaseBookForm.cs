using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace LibManSys_1
{
    public partial class PurchaseBookForm : Form
    {
        DataTable dt;
        int lstbx_state = 0;

        public PurchaseBookForm()
        {
            InitializeComponent();
        }

        private void Txt_name_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void BookSelector()
        {
            
            try
            {
                lstbx_book_name.Items.Clear();
                string s1 = "SELECT book_name FROM book_det WHERE book_name LIKE '%" + txt_name.Text + "%'";
                dt = Class_connect.ovd(s1);
                if (Class_connect.y > 0)
                {
                    lstbx_book_name.Visible = true;
                    lstbx_state = 1;

                    foreach (DataRow dr in dt.Rows)
                    {
                        
                        lstbx_book_name.Items.Add(dr["book_name"].ToString());
                        
                    }
                    
                }                    
                /*else
                {
                    MessageBox.Show("No such book registered in the library.");
                }
                */
                                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                //throw exc;
            }                        
        }
        private void FillTextBoxes(string s)
        {
            try
            {
                string s1 = "SELECT book_id,book_name,book_author,book_publication FROM book_det WHERE book_name = '" + s + "'";
                dt = Class_connect.ovd(s1);
                if(Class_connect.y > 0)
                {
                    DataRow dr=dt.Rows[0];
                    
                    txt_id.Text = dr["book_id"].ToString();
                    txt_author.Text = dr["book_author"].ToString();
                    txt_publisher.Text = dr["book_publication"].ToString();

                    txt_qnt.Enabled = true;
                    txt_dop.Enabled = true;
                    txt_qnt.Focus();
                }
                else
                {
                    lstbx_book_name.Visible = false;
                    lstbx_state = 0;
                    txt_name.Focus();
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                //throw exc;
            }


        }

        private void Txt_name_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode != Keys.Enter)
            {
                BookSelector();
            }
        }

        private void Txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (lstbx_state == 1)
                {
                    lstbx_book_name.Focus();
                    lstbx_book_name.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Please enter book name.","Notice",MessageBoxButtons.OK);
                    txt_name.Focus();
                }
                
            }
        }

        private void Lstbx_book_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_name.Text = lstbx_book_name.SelectedItem.ToString();

                lstbx_book_name.Visible = false;
                lstbx_state = 0;
                FillTextBoxes(txt_name.Text);
            }
        }

        private void Lstbx_book_name_MouseClick(object sender, MouseEventArgs e)
        {
            txt_name.Text = lstbx_book_name.SelectedItem.ToString();

            lstbx_book_name.Visible = false;
            lstbx_state = 0;
            FillTextBoxes(txt_name.Text);
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_nhome_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MDIParent1().Show();
            this.Close();
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            /*ClassPurchaseBook cpb = new ClassPurchaseBook();
            cpb.P_book_id = Convert.ToInt32(txt_id.Text);
            cpb.P_quantity = Convert.ToInt32(txt_qnt.Text);
            cpb.P_dop = txt_dop.Text;
            */
            try
            {
                string purchase = "INSERT INTO book_purchase VALUES(" + lbl_purch_id.Text + "," + txt_id.Text + ",'" + txt_dop.Text + "'," + txt_qnt.Text + ")";
                Class_connect.iud(purchase); Console.WriteLine("Ado purchase ekt damma.");
                MessageBox.Show("successfully inserted.");
                try
                {
                    string update = "UPDATE book_det SET count += " + txt_qnt.Text + " WHERE book_id=" + txt_id.Text + "";
                    Class_connect.iud(update); Console.WriteLine("Ado book_det eke count ek wedi kra.");
                    MessageBox.Show("successfully updated.");
                    DialogResult res = MessageBox.Show("Do you want to continue purchasing ?", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        resetForm();
                        purchIdLoader();
                    }
                    else
                    {
                        resetForm();
                        this.Hide();
                        new MDIParent1().Show();
                        this.Close();
                    }
                }catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);

                }
                
               

            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }            
            //resetForm();
            //purchIdLoader();
            Refresh();
        }

        private void Txt_dop_TextChanged(object sender, EventArgs e)
        {

        }

        private void PurchaseBookForm_Load(object sender, EventArgs e)
        {
            //txt_dop.Text = Convert.ToString(DateTime.Today());
            
            purchIdLoader();
            
        }
        private void purchIdLoader()
        {
            txt_dop.Text = DateTime.Now.ToShortDateString();
            lbl_purch_id.Text = null;
            DataTable dtx = Class_connect.ovd("SELECT purchase_id FROM book_purchase");
            if (Class_connect.y < 1)
            {
                lbl_purch_id.Text = "1";

            }
            else
            {
                int i = -1;
                DataRow drxx;
                foreach (DataRow drx in dtx.Rows)
                {
                    i += 1;
                }
                drxx = dtx.Rows[i];
                lbl_purch_id.Text = Convert.ToString(Convert.ToInt32(drxx["purchase_id"]) + 1);
            }
            txt_name.Focus();
        }
        private void resetForm()
        {
            String cl = null;
            txt_id.Text = cl;
            txt_name.Text = cl;
            txt_author.Text = cl;
            txt_publisher.Text = cl;
            txt_qnt.Text = cl;
            txt_dop.Text = cl;
            //lbl_purch_id.Text = cl;
            //pbx_pic.CancelAsync();
            //pbx_pic.Update;
        }
    }
    
}
