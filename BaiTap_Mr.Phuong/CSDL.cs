using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap_Mr.Phuong
{
    class CSDL
    {
        public DataTable DTSV { get; set; }
        public DataTable DTLSH { get; set; }
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new CSDL();
                return _Instance;
            }
            set
            {

            }
        }
        private static CSDL _Instance;

        private CSDL()
        {
            DTSV = new DataTable();
            DTSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV"),
                new DataColumn("NameSV"),
                new DataColumn("Gender", typeof(bool)),
                new DataColumn("NS", typeof(DateTime)),
                new DataColumn("ID_Lop", typeof(int))
            });

            DataRow dr1 = DTSV.NewRow();
            dr1["MSSV"] = "101";
            dr1["NameSV"] = "NVA";
            dr1["Gender"] = true;
            dr1["NS"] = DateTime.Now;
            dr1["ID_Lop"] = 1;
            DTSV.Rows.Add(dr1);

            DataRow dr2 = DTSV.NewRow();
            dr2["MSSV"] = "102";
            dr2["NameSV"] = "NVB";
            dr2["Gender"] = true;
            dr2["NS"] = DateTime.Now;
            dr2["ID_Lop"] = 2;
            DTSV.Rows.Add(dr2);

            DataRow dr3 = DTSV.NewRow();
            dr3["MSSV"] = "103";
            dr3["NameSV"] = "NTC";
            dr3["Gender"] = false;
            dr3["NS"] = DateTime.Now;
            dr3["ID_Lop"] = 1;
            DTSV.Rows.Add(dr3);

            DataRow dr4 = DTSV.NewRow();
            dr4["MSSV"] = "102190191";
            dr4["NameSV"] = "Tem";
            dr4["Gender"] = true;
            dr4["NS"] = DateTime.Now;
            dr4["ID_Lop"] = 2;
            DTSV.Rows.Add(dr4);

            DTLSH = new DataTable();
            DTLSH.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_Lop", typeof(int)),
                new DataColumn("NameLop")
            });

            DataRow dr5 = DTLSH.NewRow();
            dr5["ID_Lop"] = 1;
            dr5["NameLop"] = "LSH1";
            DTLSH.Rows.Add(dr5);

            DataRow dr6 = DTLSH.NewRow();
            dr6["ID_Lop"] = 2;
            dr6["NameLop"] = "LSH2";
            DTLSH.Rows.Add(dr6);
        }

        public DataTable createDataTable(string value)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
                {
                new DataColumn("MSSV"),
                new DataColumn("NameSV"),
                new DataColumn("Gender", typeof(bool)),
                new DataColumn("NS", typeof(DateTime)),
                new DataColumn("ID_Lop", typeof(int))
            });
            foreach(DataRow dr in DTSV.Rows)
            {
                if (dr["ID_Lop"].ToString() == value || dr["NameSV"].ToString().Contains(value)) dt.Rows.Add(dr.ItemArray);
            }
            return dt;
        }

        public void setDataTable(object[] SV)
        {
            DataRow dr = DTSV.NewRow();
            dr.ItemArray = SV;
            DTSV.Rows.Add(dr);
        }
        public object[] getDataTable(object[] SV, int index)
        {
            SV = DTSV.Rows[index].ItemArray;
            return SV;
        }
        public void changeDataTable(object[] SV, int index)
        {
            DTSV.Rows[index].ItemArray = SV;
        }
        public void deleteDataTable(int index)
        {
            DTSV.Rows.Remove(DTSV.Rows[index]);
        }
        public DataTable cloneDataTable(DataTable temp)
        {
            temp.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV"),
                new DataColumn("NameSV"),
                new DataColumn("Gender", typeof(bool)),
                new DataColumn("NS", typeof(DateTime)),
                new DataColumn("ID_Lop", typeof(int))
            });
            foreach(DataRow dr in DTSV.Rows)
            {
                temp.Rows.Add(dr.ItemArray);
            }
            return temp;
        }
        public DataTable sortDataTable(DataTable temp, string value)
        {
            temp.DefaultView.Sort = value + " DESC";
            temp = temp.DefaultView.ToTable();
            return temp;
        }

        public int getRealIndex(string value)
        {
            int index = 0;
            foreach (DataRow dr in DTSV.Rows)
            {
                if (dr["MSSV"].ToString() == value) return index;
                index++;
            }
            return 0;
        }
        public bool isPrimaryKey(string value)
        {
            foreach (DataRow dr in DTSV.Rows)
            {
                if (dr["MSSV"].ToString() == value) return true;
            }
            return false;
        }
    }
}
