using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOrientDB
{
    class NhanVien
    {
        public string hoTen { get; set; }
        public DateTime ngaySinh { get; set; }
        public string diaChi { get; set; }
        public string gioiTinh { get; set; }
        public int iD { get; set; }
        public NhanVien(string hoTen, DateTime ngaySinh, string diaChi, string gioiTinh,int iD)
        {
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.gioiTinh = gioiTinh;
            this.iD = iD;
        }

        public NhanVien()
        {
        }
    }
}
