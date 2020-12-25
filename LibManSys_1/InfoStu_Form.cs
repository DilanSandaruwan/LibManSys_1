using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LibManSys_1
{
    public partial class InfoStu_Form : Form
    {
        int lib_id, stu_id, status;
        string name, contact, email, dor, img_path;
        Bitmap bm;

        public InfoStu_Form()
        {
            InitializeComponent();
        }
        public InfoStu_Form(DataTable dt) : this ()
        {
            DataRow dr = dt.Rows[0];

            lib_id = Convert.ToInt32(dr["stu_lib_id"].ToString());
            stu_id = Convert.ToInt32(dr["stu_id"].ToString());
            name = dr["stu_name"].ToString();
            contact = dr["stu_contact"].ToString();
            email = dr["stu_email"].ToString();
            dor = dr["stu_dor"].ToString();
            img_path = dr["stu_image"].ToString();
            status = Convert.ToInt32(dr["stu_status"].ToString());
            bm = new Bitmap(@"..\..\" + dr["stu_image"].ToString());
        }
        

        private void Btn_ok_Click(object sender, EventArgs e)
        {            
            this.Hide();
            this.Close();
        }

        private void InfoStu_Form_Load(object sender, EventArgs e)
        {
            
            lbl_lib_id.Text = lib_id.ToString();
            lbl_stu_id.Text = stu_id.ToString();
            lbl_name.Text = name.ToString();
            lbl_contact.Text = contact.ToString();
            lbl_email.Text = email.ToString();
            lbl_status.Text = status.ToString();
            lbl_dor.Text = dor.ToString();

            pbx_pic_info.Image = bm;
            pbx_pic_info.SizeMode = PictureBoxSizeMode.StretchImage;
            //pbx_pic_info.ScaleBitmapLogicalToDevice(bm);

        }
    }
}
