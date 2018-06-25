using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAO
{
    class DataProvider
    {
        SqlConnection connect;
        String sqlConnectionString;
        String _error;

        public DataProvider()
        {
            sqlConnectionString = ConfigurationManager.ConnectionStrings["StringConnect"].ConnectionString;
            connect = new SqlConnection(sqlConnectionString);
        }

        public bool OpenConnect() // Hàm kiểm tra kết nối
        {
            try
            {
                if (connect == null)
                    connect = new SqlConnection(sqlConnectionString);
                if (connect.State == ConnectionState.Open)
                    connect.Close();

                connect.Open();
                return true;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }

        }

        // Hàm kiểm tra update hoặc insert dữ liệu trả về true or false, truyền trực tiếp vào 1 câu truy vấn sql
        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                if (OpenConnect())
                {
                    SqlCommand cmd = connect.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    _error = "";
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }
            finally
            {
                connect.Close();
            }
        }

        //Nap chong phuong thuc
        // Hàm kiểm tra update hoặc insert dữ liệu trả về true or false, truyền vào một proc đã được viết trước dưới dữ liệu. Ví dụ: procCapNhatTenNV có mảng param: @MaNV, @tenNV
        public bool ExecuteNonQuery(string procName, SqlParameter[] param)
        {
            try
            {
                if (OpenConnect())
                {
                    SqlCommand cmd = connect.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    cmd.CommandText = procName;
                    _error = "";
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                throw new Exception(ex.Message.ToString());
                //return false;
            }
            finally
            {
                connect.Close();
            }
        }

        //Hàm trả về một bảng dữ liệu có tham số truyền vào là câu truy vấn trực tiếp
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                if (OpenConnect() == true)
                {
                    SqlCommand cmd = connect.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    _error = "";
                }

            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
            finally
            {
                connect.Close();
            }
            return dt;

        }

        //Hàm trả về một bảng dữ liệu có tham số truyền vào là một proc và mảng param
        public DataTable ExecuteQuery(string proName, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            try
            {
                if (OpenConnect() == true)
                {
                    SqlCommand cmd = connect.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = proName;
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    _error = "";

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
                //_error = ex.Message;
            }
            finally
            {
                connect.Close();
            }
            return dt;
        }

        //Hàm trả về 1 chuỗi duy nhất(1 dòng 1 cột)  có kiểu string có tham số truyền vào 1 câu truy vấn
        public string ExecuteScalar_(string sql)
        {
            string kq = "";
            try
            {
                if (OpenConnect() == true)
                {
                    SqlCommand cmd = connect.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    kq = Convert.ToString(cmd.ExecuteScalar());

                    _error = "";
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
            finally
            {
                connect.Close();
            }
            return kq;
        }
    }
}
