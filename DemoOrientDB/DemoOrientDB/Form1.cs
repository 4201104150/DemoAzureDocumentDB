using Orient.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orient.Client.API;

namespace DemoOrientDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static string _hostname = "localhost";
        private static int _port = 2424;
        private static string _user = "root";
        private static string _passwd = "anhhailua";
        private static OServer server;
        private static string _DBname = "QuanLyNhanVien";

        public static OServer Connect()
        {
            server = new OServer(_hostname, _port, _user, _passwd);
            return server;
        }
        /// <summary>
        /// kết nối database
        /// </summary>
        /// <returns></returns>
        public static ODatabase opentDatabase()
        {
            ODatabase database = new ODatabase(_hostname, _port, _DBname, ODatabaseType.Graph, _user, _passwd);
            return database;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Connect();
            List<ODocument> resultNV = opentDatabase().Query("SELECT * FROM NhanVien a,DanhSachPhongBan b Where a.IDPhongBan=b.IDPhongBan");
            List<ODocument> resultDSPB = opentDatabase().Query("SELECT * FROM DanhSachPhongBan");

            foreach (ODocument document in resultDSPB)
            {
                string s1 = document.GetField<string>("TenPhongBan");
                dataGridView1.Rows.Add(s1);
            }

        }
    }
}
