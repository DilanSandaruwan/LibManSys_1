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
    
    public partial class Info_Form : Form
    {
        int b_id;
        String b_name;
        String b_author;
        String b_pub;
        //String b_date;//to be modify with joins in sql
        //int b_quantity;//to be modify with joins in sql

        //public InfoForm(int b_id,String b_name,String b_author,String b_pub,String b_date,int b_quantity)
        public Info_Form()
        {
            Console.WriteLine("DEFAULT CONS");
            InitializeComponent();
        }
        
        public Info_Form(ClassBookInfo cbinfo) : this()
        {
            Console.WriteLine("Parametric cons");
            /*
            this.b_id =b_id;
            this.b_name= b_name;
            this.b_author = b_author;
            this.b_pub = b_pub;
            this.b_date = b_date;
            this.b_quantity = b_quantity;
            */
            this.b_id = cbinfo.Id; //Console.WriteLine("ID : "+cbinfo.Id);
            this.b_name = cbinfo.B_name; //Console.WriteLine("ID : " + cbinfo.B_name);
            this.b_author = cbinfo.B_author; //Console.WriteLine("ID : " + cbinfo.B_author);
            this.b_pub = cbinfo.B_pub; //Console.WriteLine("ID : " + cbinfo.B_pub);
            //this.b_date = cbinfo.B_date; //Console.WriteLine("ID : " + cbinfo.B_date);//to be modify with joins in sql
            //this.b_quantity = cbinfo.B_quantity; //Console.WriteLine("ID : " + cbinfo.B_quantity);//to be modify with joins in sql

            //InitializeComponent();
        }
        private void Lbl_dop_Click(object sender, EventArgs e)
        {

        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void Info_Form_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Loader");
            /*
            cbi.Id = b_id;
            cbi.B_name = b_name;
            cbi.B_author = b_author;
            cbi.B_pub = b_pub;
            cbi.B_date = b_date;
            cbi.B_quantity = b_quantity;
            */

            Console.WriteLine("Wede hari");

            lbl_id.Text = b_id.ToString();
            //Console.WriteLine("iD IS " + b_id);
            lbl_name.Text = b_name.ToString();
            lbl_author.Text = b_author.ToString();
            lbl_pub.Text = b_pub.ToString();
            //lbl_quantity.Text = b_quantity.ToString();//to be modify with joins in sql
            //lbl_dop.Text = b_date.ToString();//to be modify with joins in sql

        }
    }
    public class ClassBookInfo
    {
        int id;
        String b_name;
        String b_author;
        String b_pub;
        int b_count;
        String b_date;
        int b_quantity;

        public int Id { get => id; set => id = value; }
        public string B_name { get => b_name; set => b_name = value; }
        public string B_author { get => b_author; set => b_author = value; }
        public string B_pub { get => b_pub; set => b_pub = value; }
        public string B_date { get => b_date; set => b_date = value; }
        public int B_quantity { get => b_quantity; set => b_quantity = value; }
        public int B_count { get => b_count; set => b_count = value; }
    }
}
