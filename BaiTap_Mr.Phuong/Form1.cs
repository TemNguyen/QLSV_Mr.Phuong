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
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = CSDL.Instance.DTSV;
            dataGridView1.Refresh();
            setCBBLopSH();
            setCBBSort();
        }
        public void setCBBLopSH()
        {

            DataTable dt = CSDL.Instance.DTLSH;
            foreach(DataRow dr in dt.Rows)
            {
                cbbLopSH.Items.Add(dr["NameLop"]);
            }
            cbbLopSH.Items.Add("All");
            cbbLopSH.SelectedItem = "All";
        }
        public void setCBBSort()
        {
            DataTable dt = CSDL.Instance.DTSV;
            foreach (DataColumn dc in dt.Columns)
            {
                cbbSort.Items.Add(dc.ColumnName);
            }
            cbbSort.SelectedItem = "MSSV";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //int index = cbbLopSH.SelectedIndex;
            //CBBItems cbb = new CBBItems()
            //{
            //    Text = cbbLopSH.Items[index].ToString(),
            //    Value = Convert.ToInt32(CSDL.Instance.DTLSH.Rows[index]["ID_Lop"])
            //};
            //dataGridView1.DataSource = CSDL.Instance.createDataTable(cbb.Value.ToString());
        }

        private void cbbLopSH_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshByFilter();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Detail d = new Detail();
            d.Sender(dataGridView1.CurrentRow.Index, "add");
            d.ShowDialog();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Detail d = new Detail();
            int index = 0;
            string SVID = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
            index = CSDL.Instance.getRealIndex(SVID);
            d.Sender(index, "edit");
            d.ShowDialog();
            this.Hide();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (d)
            {
                case DialogResult.Yes:
                    string SVID = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
                    int index = CSDL.Instance.getRealIndex(SVID);
                    CSDL.Instance.deleteDataTable(index);
                    refreshByFilter();
                    break;
                case DialogResult.No:
                    break;
            }    
            
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            DataTable temp = new DataTable();
            CSDL.Instance.cloneDataTable(temp);
            CSDL.Instance.sortDataTable(temp, cbbSort.SelectedItem.ToString());
            dataGridView1.DataSource = temp;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {   
            //string DataName = txbSearch.Text;
            //dataGridView1.DataSource = CSDL.Instance.createDataTable(DataName);
            //dataGridView1.Refresh();
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            string DataName = txbSearch.Text;
            dataGridView1.DataSource = CSDL.Instance.createDataTable(DataName);
            dataGridView1.Refresh();
        }
        private void refreshByFilter()
        {
            int index = cbbLopSH.SelectedIndex;
            //All SV
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
            dataGridView1.DataSource = CSDL.Instance.createDataTable(cbb.Value.ToString());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
