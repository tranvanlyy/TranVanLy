using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.IO;
using OfficeOpenXml;
using xlss = Microsoft.Office.Interop.Excel;

namespace TranVanLy
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        
       // List<Employee> lst;

        private void btChonAnh_Click(object sender, EventArgs e)
        {

           // string filepath = null;
           // OpenFileDialog ofdImages = new OpenFileDialog(); PictureBox objpt = new PictureBox();
           // if (ofdImages.ShowDialog() == DialogResult.OK) { filepath = ofdImages.FileName; }
            //MessageBox.Show(filepath);
            //pictureBox1.Image = System.Drawing.Image.FromFile(filepath.ToString());
           // this.pictureBox1.Name = "pictureBox";
        }


        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            tbMaNhanVien.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
            tbTenNhanVien.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
            tbTuoi.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();
            tbGioiTinh.Text = dgvEmployee.Rows[idx].Cells[3].Value.ToString();
            tbLop.Text = dgvEmployee.Rows[idx].Cells[4].Value.ToString();
            tbSDT.Text = dgvEmployee.Rows[idx].Cells[5].Value.ToString();
            tbDiaChi.Text = dgvEmployee.Rows[idx].Cells[6].Value.ToString();
        }



        private void btDangXuat_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn đăng xuất", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    this.Close();
        }

        

        private void ckGioiTinh1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbTenNhanVien_TextChanged(object sender, EventArgs e)
        {

        }






        private void Form2_Load(object sender, EventArgs e)
        {
            dgvEmployee.DataSource = B_SinhVien.GetAllSinhVien();
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            try
            {
                string masv = tbMaNhanVien.Text;
                string tensv = tbTenNhanVien.Text;
                string tuoi = tbTuoi.Text;
                string gioitinh= tbGioiTinh.Text;
                string lop = tbLop.Text;
                string sdt = tbSDT.Text;
                string diachi = tbDiaChi.Text;
                tblSinhVien sinhvien = new tblSinhVien(masv, tensv, tuoi,gioitinh,lop,sdt, diachi);
                B_SinhVien.DeleteSinhVien(masv);
                MessageBox.Show("Bạn đã Xóa " + tensv + "Thành công");
                dgvEmployee.DataSource = B_SinhVien.GetAllSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
             try
            {
             string masv = tbMaNhanVien.Text;
             string tensv = tbTenNhanVien.Text;
             string tuoi = tbTuoi.Text;
             string gioitinh = tbGioiTinh.Text;
             string lop = tbLop.Text;
             string sdt = tbSDT.Text;
             string diachi = tbDiaChi.Text;

              tblSinhVien SinhVien = new tblSinhVien(masv, tensv, tuoi,gioitinh,lop,sdt, diachi);
              B_SinhVien.InsertSinhVien(SinhVien);
              MessageBox.Show("Bạn đã thêm " + tensv + "Thành công");
              dgvEmployee.DataSource = B_SinhVien.GetAllSinhVien();
             }
               catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvEmployee.Rows[e.RowIndex];
                tbMaNhanVien.Text = row.Cells[0].Value.ToString();
                tbTenNhanVien.Text = row.Cells[1].Value.ToString();
                tbTuoi.Text = row.Cells[2].Value.ToString();
                tbGioiTinh.Text = row.Cells[3].Value.ToString();
                tbLop.Text = row.Cells[4].Value.ToString();
                tbSDT.Text = row.Cells[5].Value.ToString();
                tbDiaChi.Text = row.Cells[5].Value.ToString();
            }
            catch
            {

            }
        }


        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                string masv = tbMaNhanVien.Text;
                string tensv = tbTenNhanVien.Text;
                string tuoi = tbTuoi.Text;
                string gioitinh = tbGioiTinh.Text;
                string lop = tbLop.Text;
                string sdt = tbSDT.Text;
                string diachi = tbDiaChi.Text;


                tblSinhVien sinhvien = new tblSinhVien(masv, tensv, tuoi,gioitinh,lop,sdt,diachi);
                B_SinhVien.UpdateSinhVien(sinhvien);
                MessageBox.Show("Bạn đã sửa " + tensv + "Thành công");
                dgvEmployee.DataSource = B_SinhVien.GetAllSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btnexport_Click(object sender, EventArgs e)
        {
            dgvEmployee.SelectAll();
            DataObject copydata = dgvEmployee.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWbook;
            Microsoft.Office.Interop.Excel.Worksheet xlssheet;
            object miseddata = System.Reflection.Missing.Value;
            xlWbook = xlapp.Workbooks.Add(miseddata);

            xlssheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlssheet.Cells[1, 1];
            xlr.Select();
            xlssheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
        private DataTable oTbl;

        private string filename;
        private void readExcel()
        {

            filename = txtFile.Text;
            if (filename == null)
            {
                MessageBox.Show("chưa chọn file excel");
            }
            else
            {
                xlss.Application ExcelApp = new xlss.Application();

                try
                {
                    ExcelApp.Workbooks.Open(filename);
                }
                catch
                {
                    MessageBox.Show("không thể mở file dữ liệu");
                }

                oTbl = new DataTable();
                oTbl.Columns.Add("A", typeof(string));
                oTbl.Columns.Add("B", typeof(string));
                oTbl.Columns.Add("C", typeof(string));
                oTbl.Columns.Add("D", typeof(string));
                oTbl.Columns.Add("E", typeof(string));
                oTbl.Columns.Add("F", typeof(string));
                oTbl.Columns.Add("G", typeof(string));


                foreach (xlss.Worksheet WSheet in ExcelApp.Worksheets)
                {
                    DataRow dr;
                    long i = 1;
                    try
                    {
                        do
                        {
                            if (WSheet.Range["A" + i].Value == null && WSheet.Range["B" + i].Value == null && WSheet.Range["C" + i].Value == null && WSheet.Range["D" + i].Value == null && WSheet.Range["E" + i].Value == null && WSheet.Range["F" + i].Value == null && WSheet.Range["G" + i].Value == null)
                            {
                                break;
                            }
                            dr = oTbl.NewRow();
                            dr["A"] = WSheet.Range["A" + i].Value;
                            dr["B"] = WSheet.Range["B" + i].Value;
                            dr["C"] = WSheet.Range["C" + i].Value;
                            dr["D"] = WSheet.Range["D" + i].Value;
                            dr["E"] = WSheet.Range["E" + i].Value;
                            dr["F"] = WSheet.Range["F" + i].Value;
                            dr["G"] = WSheet.Range["G" + i].Value;
                            oTbl.Rows.Add(dr);
                            i++;
                        }
                        while (true);
                    }
                    catch
                    {
                        MessageBox.Show("có lỗi khi thực hiện");
                    }
                }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "excel file |*.xls;*.xlsx";
            fDialog.FilterIndex = 1;
            fDialog.RestoreDirectory = true;
            fDialog.Multiselect = false;
            fDialog.Title = "Chọn file excel";


            if (fDialog.ShowDialog() == DialogResult.OK)
            {

                txtFile.Text = fDialog.FileName;
                readExcel();
                if (oTbl != null)
                {
                    dgvEmployee.DataSource = oTbl;
                }
                else
                {
                    MessageBox.Show("không có dữ liệu");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
