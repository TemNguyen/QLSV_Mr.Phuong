using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap_Mr.Phuong
{
    public partial class Form1 : Form
    {
        public delegate void sendInfor(string[] Data);
        public sendInfor send;
        private string[] sendInforSV(string[] SVData)
        {
            int index = dataGridView1.CurrentRow.Index;

            SVData = new string[CSDL.Instance.DTSV.Columns.Count];
            for (int i = 0; i < CSDL.Instance.DTSV.Columns.Count; i++)
            {
                SVData[i] = dataGridView1.Rows[index].Cells[i].Value.ToString();
                MessageBox.Show(SVData[i]);
            }
            return SVData;
        }


        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = CSDL.Instance.DTSV;
            setCBBLopSH();
        }
        public void setCBBLopSH()
        {

            DataTable dt = CSDL.Instance.DTLSH;
            foreach(DataRow dr in dt.Rows)
            {
                cbbLopSH.Items.Add(dr["NameLop"]);
            }
            cbbLopSH.Items.Add("All");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            int index = cbbLopSH.SelectedIndex;
            CBBItems cbb = new CBBItems()
            {
                Text = cbbLopSH.Items[index].ToString(),
                Value = Convert.ToInt32(CSDL.Instance.DTLSH.Rows[index]["ID_Lop"])
            };
            dataGridView1.DataSource = CSDL.Instance.createDataTable(cbb.Value);
        }

        private void cbbLopSH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbbLopSH.SelectedIndex;
            if (index == cbbLopSH.Items.Count - 1)
            {
                dataGridView1.DataSource = CSDL.Instance.DTSV;
                return;
            }    
            CBBItems cbb = new CBBItems()
            {
                Text = cbbLopSH.Items[index].ToString(),
                Value = Convert.ToInt32(CSDL.Instance.DTLSH.Rows[index]["ID_Lop"])
            };
               
            dataGridView1.DataSource = CSDL.Instance.createDataTable(cbb.Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Detail d = new Detail();

            d.ShowDialog();
            this.Hide();
        }

    }
}
