using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class D_SinhVien
    {
        public static DataTable getData()
        {
            SqlConnection Conn = dbConnectionData.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_GetAllSinhVien", Conn);
            command.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt= new DataTable();
            da.Fill(dt);
            Conn.Close();
            return dt;
        }

        public static void InsertSV(tblSinhVien sv)

        {
            SqlConnection Conn = dbConnectionData.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_InsertSinhVien", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaSV", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@TenSV", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@Tuoi", SqlDbType.Int);
            command.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@Lop", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@SDT", SqlDbType.Int);
            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50);





            command.Parameters["@MaSV"].Value = sv.MaSV1;
            command.Parameters["@TenSV"].Value = sv.TenSV1;
            command.Parameters["@Tuoi"].Value = sv.Tuoi1;
            command.Parameters["@GioiTinh"].Value = sv.Gioitinh1;
            command.Parameters["@Lop"].Value = sv.Lop1;
            command.Parameters["@SDT"].Value = sv.SDT1;
            command.Parameters["@DiaChi"].Value = sv.Diachi1;


            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }

        public static void UpdateSV(tblSinhVien sv)

        {
            SqlConnection Conn = dbConnectionData.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_UpdateSinhVien", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaSV", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@TenSV", SqlDbType.Int);
            command.Parameters.Add("@Tuoi", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@Lop", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@SDT", SqlDbType.Int);
            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50);

            command.Parameters["@MaSV"].Value = sv.MaSV1;
            command.Parameters["@TenSV"].Value = sv.TenSV1;
            command.Parameters["@Tuoi"].Value = sv.Tuoi1;
            command.Parameters["@GioiTinh"].Value = sv.Gioitinh1;
            command.Parameters["@Lop"].Value = sv.Lop1;
            command.Parameters["@SDT"].Value = sv.SDT1;
            command.Parameters["@DiaChi"].Value = sv.Gioitinh1;


            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }

        public static void DeleteSV(string masv)

        {
            SqlConnection Conn = dbConnectionData.HamKetNoi();
            SqlCommand command = new SqlCommand("sp_DeleteSinhVien", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaSV", SqlDbType.NVarChar, 50);
            command.Parameters["@MaSV"].Value = masv;

            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
        }

    }
}
