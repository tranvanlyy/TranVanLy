using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class tblSinhVien
    {
        private String MaSV;
        private String TenSV;
        private String Tuoi;
        private String Gioitinh;
        private String Lop;
        private String SDT;
        private String Diachi;

        public tblSinhVien(string maSV, string tenSV, string tuoi, string gioitinh, string lop, string sDT, string diachi)
        {
            MaSV = maSV;
            TenSV = tenSV;
            Tuoi = tuoi;
            Gioitinh = gioitinh;
            Lop = lop;
            SDT = sDT;
            Diachi = diachi;
        }

        public string MaSV1 { get => MaSV; set => MaSV = value; }
        public string TenSV1 { get => TenSV; set => TenSV = value; }
        public string Tuoi1 { get => Tuoi; set => Tuoi = value; }
        public string Gioitinh1 { get => Gioitinh; set => Gioitinh = value; }
        public string Lop1 { get => Lop; set => Lop = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public string Diachi1 { get => Diachi; set => Diachi = value; }
    }
}
