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
    public partial class Detail : Form
    {
        //delegate
        public delegate void getData(int value, string option);
        public getData Sender;
        static int index = 0;
        static string option = "";
        static private void getIndex(int value, string msg)
        {
            index = value;
            option = msg;
        }

        public Detail()
        {
            Sender = new getData(getIndex);
            InitializeComponent();
            setCBBLopSH();
        }
        
        public void setCBBLopSH()
        {

            DataTable dt = CSDL.Instance.DTLSH;
            foreach (DataRow dr in dt.Rows)
            {
                cbbLopSH.Items.Add(dr["NameLop"]);
            }
            cbbLopSH.SelectedIndex = 0;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            switch(option)
            {
                case "add":
                    setFunc();
                    break;
                case "edit":
                    updateFunc();
                    break;
            }
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private int getIDLopSH()
        {
            if (index != -1)
            {
                int index = cbbLopSH.SelectedIndex;
                CBBItems cbb = new CBBItems()
                {
                    Text = cbbLopSH.Items[index].ToString(),
                    Value = Convert.ToInt32(CSDL.Instance.DTLSH.Rows[index]["ID_Lop"])
                };
                return cbb.Value;
            }
            return 0;
            
        }

        //core Function
        private void setFunc()
        {
            object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
            SV[0] = txtMSSV.Text;
            SV[1] = txtName.Text;
            if (radioButton1.Checked) SV[2] = true;
            else SV[2] = false;
            SV[3] = dateTimePicker1.Value;
            SV[4] = getIDLopSH();
            CSDL.Instance.setDataTable(SV);
        }
        private void getFunc()
        {
            object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
            SV = CSDL.Instance.getDataTable(SV, index);
            txtMSSV.Text = SV[0].ToString();
            txtName.Text = SV[1].ToString();
            if (Convert.ToBoolean(SV[2]) == true) radioButton1.Checked = true;
            else radioButton2.Checked = true;
            dateTimePicker1.Value = Convert.ToDateTime(SV[3]);
            CBBItems cbb = new CBBItems()
            {
                //cbbIndex bắt đầu từ 0.
                Text = cbbLopSH.Items[Convert.ToInt32(SV[4]) - 1].ToString()
            };
            cbbLopSH.SelectedItem = cbb.Text;
        }
        private void updateFunc()
        {
            object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
            SV[0] = txtMSSV.Text;
            SV[1] = txtName.Text;
            if (radioButton1.Checked) SV[2] = true;
            else SV[2] = false;
            SV[3] = dateTimePicker1.Value;
            SV[4] = getIDLopSH();
            CSDL.Instance.changeDataTable(SV, index);
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            if (option == "edit") getFunc();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Detail d = new Detail();
            d.Hide();
        }
    }
}
