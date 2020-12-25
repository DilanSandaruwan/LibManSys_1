﻿using System;
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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
               
        private void AddBookToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AddBookForm abf = new AddBookForm();
            abf.Show();
            this.Close();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Console.WriteLine("Ado na bn");
            ViewBooks vb = new ViewBooks();
            vb.Show();
            this.Close();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {

        }

        private void RegisterStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm asf = new AddStudentForm();
            this.Hide();
            asf.Show();
            this.Close();

        }

        private void StudentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StudentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewStudents vs = new ViewStudents();
            vs.Show();
            this.Close();
        }

        private void IssueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookIssueForm bif = new BookIssueForm();
            bif.Show();
            this.Close();
        }

        private void ToolTip_Popup(object sender, PopupEventArgs e)
        {

        }

        private void PurchaseBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PurchaseBookForm pbf = new PurchaseBookForm();
            pbf.Show();
            this.Close();
        }
    }
}
