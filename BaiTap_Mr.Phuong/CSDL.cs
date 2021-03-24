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

            DTLSH = new DataTable();
            DTLSH.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_Lop", typeof(int)),
                new DataColumn("NameLop")
            });

            DataRow dr4 = DTLSH.NewRow();
            dr4["ID_Lop"] = 1;
            dr4["NameLop"] = "LSH1";
            DTLSH.Rows.Add(dr4);

            DataRow dr5 = DTLSH.NewRow();
            dr5["ID_Lop"] = 2;
            dr5["NameLop"] = "LSH2";
            DTLSH.Rows.Add(dr5);
        }

        public DataTable createDataTable(int id_Lop)
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
                if (Convert.ToInt32(dr["ID_Lop"]) == id_Lop) dt.Rows.Add(dr.ItemArray);
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
    }
}
