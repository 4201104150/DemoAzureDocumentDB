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
        private void LoadData()
        {
            List<ODocument> resultNV = opentDatabase().Query("SELECT * FROM NhanVien");
            foreach (ODocument document in resultNV)
            {
                string s1 = document.GetField<string>("HoTenNV");
                string s2 = document.GetField<string>("DiaChi");
                DateTime s3 = document.GetField<DateTime>("NgaySinh");
                string s4 = document.GetField<string>("GioiTinh");
                int s5 = document.GetField<int>("ID");
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = s1;
                row.Cells[1].Value = s2;
                row.Cells[2].Value = s3;
                row.Cells[3].Value = s4;
                row.Cells[4].Value = s5;
                dataGridView1.Rows.Add(row);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
 //           Connect();
            List<ODocument> resultDSPB = opentDatabase().Query("SELECT * FROM DanhSachPhongBan");

            LoadData();
            
            cbbGioiTinh.SelectedIndex = 0;
            foreach(ODocument d in resultDSPB)
            {
                string s1 = d.GetField<string>("TenPhongBan");                
                cbbPhongBan.Items.Add(s1);
            }
            cbbPhongBan.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ODatabase database = opentDatabase();
            NhanVien nv = new NhanVien(txtHoTen.Text,dtpNgaySinh.Value,txtDiaChi.Text,cbbGioiTinh.Text,int.Parse(txtID.Text));
            database.Command("INSERT INTO NhanVien(HoTenNV,DiaChi,NgaySinh,GioiTinh,ID) VALUES ('"+nv.hoTen + "','"+nv.diaChi + "','"+nv.ngaySinh + "','"+nv.gioiTinh + "','"+txtID.Text+ "')");
            LoadData();
        }
        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            ODatabase database = opentDatabase();
            NhanVien nv = new NhanVien(txtHoTen.Text, dtpNgaySinh.Value, txtDiaChi.Text, cbbGioiTinh.Text, int.Parse(txtID.Text));
            database.Command("DELETE EDGE FROM NhanVien WHERE ID=");
            LoadData();
        }
        /// <summary>
        /// upload cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            ODatabase database = opentDatabase();
            NhanVien nv = new NhanVien(txtHoTen.Text, dtpNgaySinh.Value, txtDiaChi.Text, cbbGioiTinh.Text, int.Parse(txtID.Text));
            database.Command("UPDATE NhanVien SET HoTenNV='" + nv.hoTen + "', DiaChi='" + nv.diaChi + "', NgaySinh='" + nv.ngaySinh + "', GioiTinh='" + nv.gioiTinh + "' WHERE ID=" + int.Parse(txtID.Text));
            LoadData();
        }
    }
}
