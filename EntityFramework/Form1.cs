using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        Student_DBEntities db = new Student_DBEntities();
        int selectRow;
        void LoadData()
        {


            //var result =db.Students;
            var result = from s in db.Students select new { s.Id, s.Name, s.Address, s.Score, s.Id_class };
            dtgvdata.DataSource = result.ToList();  


        }
        void AddSV()
        {

        }  
        void EditSV() { }
        void DelSV() { 
}
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Student stu = new Student();
             //   stu.Id = int.Parse(txtMa.Text);
                stu.Name = txtname.Text;
                stu.Address = txtaddress.Text;
                stu.Score = int.Parse(txtscore.Text);
                stu.Id_class = int.Parse(txtmalop.Text);
                db.Students.Add(stu);
                db.SaveChanges();
                LoadData();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }


        }
      
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow datagv = dtgvdata.Rows[selectRow];
            datagv.Cells[1].Value =txtname.Text;
            datagv.Cells[2].Value =txtaddress.Text;
            datagv.Cells[3].Value =txtscore.Text;
            datagv.Cells[4].Value =txtmalop.Text;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            selectRow = dtgvdata.CurrentCell.RowIndex;
            dtgvdata.Rows.RemoveAt(selectRow);

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectRow = e.RowIndex;

            DataGridViewRow row = dtgvdata.Rows[selectRow];
            txtname.Text = row.Cells[1].Value.ToString();
            txtaddress.Text = row.Cells[2].Value.ToString();
            txtscore.Text = row.Cells[3].Value.ToString();
            txtmalop.Text = row.Cells[4].Value.ToString();

        }
    }
}
