﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDLThu4.Object
{
    class LichCongTac
    {
        public DateTime Ngaybatdau;
        public DateTime Ngayketthuc;
        public String DiaDiem;
        public String ID;
        public String NoiDung;
        public String TenCongTac;


        public LichCongTac(String id, String Tencongtac, DateTime ngaybatdau, DateTime ngayketthuc, String diadiem, String noidung)
        {
            Ngaybatdau = ngaybatdau;
            Ngayketthuc = ngayketthuc;
            ID = id;
            DiaDiem = diadiem;
            NoiDung = noidung;
            TenCongTac = Tencongtac;
        }


    }
}
