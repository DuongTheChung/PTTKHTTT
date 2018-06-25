using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class DichVu
    {
        private int maDV;

        public int MaDV
        {
            get { return maDV; }
            set { maDV = value; }
        }
        private string tenDV;

        public string TenDV
        {
            get { return tenDV; }
            set { tenDV = value; }
        }
        private string donVi;

        public string DonVi
        {
            get { return donVi; }
            set { donVi = value; }
        }
        private int soLuongTon;

        public int SoLuongTon
        {
            get { return soLuongTon; }
            set { soLuongTon = value; }
        }
        private DateTime hanSuDung;

        public DateTime HanSuDung
        {
            get { return hanSuDung; }
            set { hanSuDung = value; }
        }
    }
}
