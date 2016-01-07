﻿using CSDLThu4.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDLThu4.Object
{
    class EmployeeManagement:DBConnect
    {
        public static string UserID;
        //check login
        public int CheckLogin(String ID, String Pass)
        {
            //string setthuoctinh = @"";
            DBConnect cn = new DBConnect();
            cn.conn.Open();
            DataTable dt = new DataTable();
            String query = "select ID,Pass,MaCapQuanLi from NhanVien where ID=@ID and Pass=@Pass";
            // String query1 = "select ID,Pass from NhanVien ";
            SqlCommand command = new SqlCommand(query, cn.conn);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Pass", Pass);
            command.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            cn.conn.Close();
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {

                UserID = dt.Rows[0][1].ToString();
                return Int32.Parse(dt.Rows[0][2].ToString());
            }
        }
        //load data Nhan Vien
        public DataTable LoaddataNV(String ID)
        {
            
                //string setthuoctinh = @"";
            DBConnect cn = new DBConnect();
            cn.conn.Open();
                DataTable dt = new DataTable();
                String query = "select Hoten,SDT,DiaChi,GioiTinh from NhanVien where ID=@ID";
                SqlCommand command = new SqlCommand(query, cn.conn);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                cn.conn.Close();
                return dt;
            
            
        }
        //Update data Nhan Vien
        public void UpdatedataNV(String ID,String Hoten,String SDT,String DC,String GT)
        {

            //string setthuoctinh = @"";
            DBConnect cn = new DBConnect();
            cn.conn.Open();
            //DataTable dt = new DataTable();
            String query = @"update NhanVien set Hoten=@Hoten
                             ,SDT=@SDT,DiaChi=@DiaChi,GioiTinh=@GioiTinh where ID=@ID";
            SqlCommand command = new SqlCommand(query, cn.conn);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Hoten", Hoten);
            command.Parameters.AddWithValue("@SDT", SDT);
            command.Parameters.AddWithValue("@DiaChi", DC);
            command.Parameters.AddWithValue("@GioiTinh", GT);
            command.ExecuteNonQuery();
           // SqlDataAdapter da = new SqlDataAdapter(command);
           // da.Fill(dt);
            cn.conn.Close();
            //return dt;


        }
        //Load data LichCT
        public DataTable LoadDataLich(String ID,List<LichCongTac> ListLich)
        {
            //select TenCongTac,NgayBatDau,NgayKetThuc,NoiDung from LichCongTac l ,
            //NhanVien nv,NhanVien_CongTac nvct
           //where nv.ID='nam' and nv.MaNhanVien=nvct.MaNhanVien and nvct.MaCongTac=l.MaCongTac

            //string setthuoctinh = @"";
            DBConnect cn = new DBConnect();
            cn.conn.Open();
            DataTable dt = new DataTable();
            String query = @"select TenCongTac,NgayBatDau,NgayKetThuc,DiaDiem,NoiDung 
            from LichCongTac l ,NhanVien nv,NhanVien_CongTac nvct   
             where nv.MaNhanVien=nvct.MaNhanVien and nvct.MaCongTac=l.MaCongTac and  ID=@ID";
            SqlCommand command = new SqlCommand(query, cn.conn);
            command.Parameters.AddWithValue("@ID", ID);
                 command.ExecuteNonQuery();
            //lich.
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            cn.conn.Close();
            //return dt;

            for (int i = 0; i<dt.Rows.Count; i++)
            {
            LichCongTac a = new LichCongTac(dt.Rows[i][0].ToString(), DateTime.Parse(dt.Rows[i][1].ToString()),
            DateTime.Parse(dt.Rows[i][2].ToString()), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString());
            ListLich.Add(a);
                
            }
            return dt;
        }
        public DataTable LoadDataLich(String ID)
        {
            //select TenCongTac,NgayBatDau,NgayKetThuc,NoiDung from LichCongTac l ,
            //NhanVien nv,NhanVien_CongTac nvct
            //where nv.ID='nam' and nv.MaNhanVien=nvct.MaNhanVien and nvct.MaCongTac=l.MaCongTac

            //string setthuoctinh = @"";
            DBConnect cn = new DBConnect();
            cn.conn.Open();
            DataTable dt = new DataTable();
            String query = @"select TenCongTac,NgayBatDau,NgayKetThuc,DiaDiem,NoiDung 
            from LichCongTac l ,NhanVien nv,NhanVien_CongTac nvct   
             where nv.MaNhanVien=nvct.MaNhanVien and nvct.MaCongTac=l.MaCongTac and  ID=@ID";
            SqlCommand command = new SqlCommand(query, cn.conn);
            command.Parameters.AddWithValue("@ID", ID);
            command.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            cn.conn.Close();
            return dt;
        }
        public void ThemCongTac(string TenCongTac,string NgayBatDau, string NgayKetThuc,string DiaDiem,string NoiDung,string MaLoaiCongTac)
        {
            DBConnect cn = new DBConnect();
            cn.conn.Open();
            
            String query = @"insert into LichCongTac(TenCongTac,NgayBatDau,NgayKetThuc,DiaDiem,NoiDung,MaLoaiCongTac)
             values(@TenCongTac,@NgayBatDau,@NgayKetThuc,@DiaDiem,@NoiDung,@MaLoaiCongTac)";
            SqlCommand command = new SqlCommand(query, cn.conn);
            command.Parameters.AddWithValue("@TenCongTac", TenCongTac);
            command.Parameters.AddWithValue("@NgayBatDau", NgayBatDau);
            command.Parameters.AddWithValue("@NgayKetThuc", NgayKetThuc);
            command.Parameters.AddWithValue("@DiaDiem", DiaDiem);
            command.Parameters.AddWithValue("@NoiDung", NoiDung);
            command.Parameters.AddWithValue("@MaLoaiCongTac", MaLoaiCongTac);
            command.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(command);
            
            cn.conn.Close();
        }
    }
}