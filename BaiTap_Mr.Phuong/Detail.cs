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

        public Detail()
        {
            InitializeComponent();
            //send = sender;
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string[] dataSV = new string[CSDL.Instance.DTSV.Columns.Count];
            f1.send(dataSV);
            MessageBox.Show(dataSV[1]);
        }
    }
}
