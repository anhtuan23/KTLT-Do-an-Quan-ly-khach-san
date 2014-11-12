using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using DT_KHACHTHUE;
using DT_PHONG;

namespace DT_KHACHSAN
{
    public struct KHACHSAN
    {
        public string tenKhachSan;
        public ArrayList dsPhong;
        public ArrayList dsKhachThue;
        //public KHACHSAN()
        //{
        //    tenKhachSan = string.Empty;
        //    dsPhong = new ArrayList();
        //    dsKhachThue = new ArrayList();
        //}
    }
    public class XL_KHACHSAN
    {
        //thanh phan xu ly
        //cac chuc nang ve PHONG
        public static void themPhong(KHACHSAN ks)
        {
            Console.Write("Phong thuong hay phong VIP (t/v)");
            string loaiPhong = Console.ReadLine();
            loaiPhong.ToLower();
            if (loaiPhong == "t")
            {
                PHONGTHUONG p = new PHONGTHUONG();
                p = XL_PHONGTHUONG.nhapPhong("Nhap thong tin phong thuong");
                ks.dsPhong.Add(p);
            }
            else if (loaiPhong == "v")
            {
                PHONGVIP p = new PHONGVIP();
                p = XL_PHONGVIP.nhapPhong("Nhap thong tin phong VIP");
                ks.dsPhong.Add(p);
            }
            else
            {
                Console.WriteLine("Lenh khong hop le");
            }
        }
        public static void lietKePhong(KHACHSAN ks)
        {
            string kq = "Danh sach cac phong trong khach san:\n";
            foreach (PHONGTHUONG p in ks.dsPhong)
            {
                kq += XL_PHONGTHUONG.xuatPhong(p) + '\n';
            }
            foreach (PHONGVIP p in ks.dsPhong)
            {
                kq += XL_PHONGVIP.xuatPhong(p) + '\n';
            }
            Console.WriteLine(kq);
        }
        public static void timPhong(string dieuKienTenPhong,KHACHSAN ks)
        {
            ArrayList kq = new ArrayList();
            foreach (PHONGTHUONG p in ks.dsPhong)
            {
                if (p.tenPhong.Contains(dieuKienTenPhong) == true)
                    kq.Add(p);
            }
            foreach (PHONGVIP p in ks.dsPhong)
            {
                if (p.tenPhong.Contains(dieuKienTenPhong) == true)
                    kq.Add(p);
            }
            //liet ke ket qua tim kiem
            string chuoi = string.Empty;
            if (kq.Count == 0)
            {
                chuoi = "Khong tim thay ket qua.";
            }
            else
            {
                chuoi = "Danh sach phong tim duoc:\n";
                foreach (PHONGTHUONG p in kq)
                {
                    chuoi += XL_PHONGTHUONG.xuatPhong(p) + '\n';
                }
                foreach (PHONGVIP p in kq)
                {
                    chuoi += XL_PHONGVIP.xuatPhong(p) + '\n';
                }
            }
            Console.WriteLine(chuoi);
        }
        public static bool xoaPhong(string dkMaPhong,KHACHSAN ks)
        {
            foreach (PHONGTHUONG p in ks.dsPhong)
            {
                if (p.maPhong == dkMaPhong)
                {
                    ks.dsPhong.Remove(p);
                    return true;
                }
            }
            foreach (PHONGVIP p in ks.dsPhong)
            {
                if (p.maPhong == dkMaPhong)
                {
                    ks.dsPhong.Remove(p);
                    return true;
                }
            }
            return false;
        }
        public static bool capNhatPhong(string dkMaPhong,KHACHSAN ks)
        {
            foreach (PHONGTHUONG p in ks.dsPhong)
            {
                if (p.maPhong == dkMaPhong)
                {
                    XL_PHONGTHUONG.capNhatPhong(p,"Cap nhat thong tin phong: ");
                    return true;
                }
            }
            foreach (PHONGVIP p in ks.dsPhong)
            {
                if (p.maPhong == dkMaPhong)
                {
                    XL_PHONGVIP.capNhatPhong(p);
                    return false;
                }
            }
            return false;
        }
        public static void luuDanhSachPhong(string duongDan,KHACHSAN ks)
        {
            StreamWriter boGhi = new StreamWriter(duongDan);
            boGhi.WriteLine(ks.dsPhong.Count);
            foreach (PHONGTHUONG p in ks.dsPhong)
            {
                XL_PHONGTHUONG.luu(boGhi,p);
            }
            foreach (PHONGVIP p in ks.dsPhong)
            {
                XL_PHONGVIP.luu(boGhi, p);
            }
            boGhi.Close();
        }
        public static ArrayList docDanhSachPhong(string duongDan,KHACHSAN ks)
        {
            StreamReader boDoc = new StreamReader(duongDan);
            int n = int.Parse(boDoc.ReadLine());
            ArrayList dsPhong = new ArrayList();
            for (int i = 0; i < n; i++)
            {
                string docDuoc = boDoc.ReadLine();
                if(docDuoc[0]=='t')
                {
                    PHONGTHUONG p = new PHONGTHUONG(docDuoc);
                    dsPhong.Add(p);
                }
                else
                {
                    PHONGVIP p = new PHONGVIP(docDuoc);
                    dsPhong.Add(p);
                }
            }
            //ks.dsPhong = dsPhong;
            boDoc.Close();
            return dsPhong;
        }

        //cac chuc nang ve KHACH THUE
        public static void themKhachThue(KHACHSAN ks)
        {
            KHACHTHUE k = new KHACHTHUE();
            k= XL_KHACHTHUE.themKhachThue("Nhap thong tin khach thue: ");
            ks.dsKhachThue.Add(k);
        }
        public static void lietKeKhachThue(KHACHSAN ks)
        {
            string kq = "Danh sach cac khach thue phong trong khach san:\n";
            foreach (KHACHTHUE k in ks.dsKhachThue)
            {
                kq += XL_KHACHTHUE.xuatKhachThue(k) + '\n';
            }
            Console.WriteLine(kq);
        }
        public static void timKhachThue(string dieuKien,KHACHSAN ks)
        {
            ArrayList kq = new ArrayList();
            foreach (KHACHTHUE k in ks.dsKhachThue)
            {
                if (k.hoTen.Contains(dieuKien) == true)
                {
                    kq.Add(k);
                }
            }
            //liet ke ket qua tim kiem
            string chuoi = string.Empty;
            if (kq.Count == 0)
            {
                chuoi = "Khong tim thay ket qua.";
            }
            else
            {
                chuoi = "Danh sach khach thue tim duoc:\n";
                foreach (KHACHTHUE k in kq)
                {
                    chuoi += XL_KHACHTHUE.xuatKhachThue(k) + '\n';
                }
            }
            Console.WriteLine(chuoi);
        }
        public static void xoaKhachThue(string dkCmnd,KHACHSAN ks)
        {
            foreach (KHACHTHUE k in ks.dsKhachThue)
            {
                if (k.cmnd == dkCmnd)
                {
                    ks.dsKhachThue.Remove(k);
                    break;
                }
            }
        }
        public static bool capNhatKhachThue(string dkCmnd,KHACHSAN ks)
        {
            foreach (KHACHTHUE k in ks.dsKhachThue)
            {
                if (k.cmnd == dkCmnd)
                {
                    XL_KHACHTHUE.capNhatKhachThue(k,"Cap nhat thong tin khach thue: ");
                    return true;
                }
            }
            return false;
        }
        public static void luuDanhSachKhachThue(string duongDan,KHACHSAN ks)
        {
            StreamWriter boGhi = new StreamWriter(duongDan);
            boGhi.WriteLine(ks.dsKhachThue.Count);
            foreach (KHACHTHUE k in ks.dsKhachThue)
            {
                XL_KHACHTHUE.luu(boGhi,k);
            }
            boGhi.Close();
        }
        public static ArrayList docDanhSachKhachThue(string duongDan, KHACHSAN ks)
        {
            StreamReader boDoc = new StreamReader(duongDan);
            int n = int.Parse(boDoc.ReadLine());
            ArrayList dsKhachThue = new ArrayList();
            for (int i = 0; i < n; i++)
            {
                string docDuoc = boDoc.ReadLine();
                KHACHTHUE k = new KHACHTHUE(docDuoc);
                dsKhachThue.Add(k);
            }
            boDoc.Close();
            return dsKhachThue;
        }

        //cac chuc nang khac
        public static void lietKePhongTrong(DateTime ngay,KHACHSAN ks)
        {
            string kq = "Danh sach cac phong trong hien tai:\n";
            //lap danh sach cac phong da duoc thue
            string phongCoKhach = string.Empty;
            foreach (KHACHTHUE k in ks.dsKhachThue)
            {
                if (k.ngayThue<=ngay && k.ngayTra>=ngay)
                {
                    phongCoKhach += k.maPhongThue + ',';
                }
            }
            foreach(PHONGTHUONG p in ks.dsPhong)
            {
                if (phongCoKhach.Contains(p.maPhong) == false)
                {
                    kq += XL_PHONGTHUONG.xuatPhong(p) + '\n';
                }
            }
            foreach (PHONGVIP p in ks.dsPhong)
            {
                if (phongCoKhach.Contains(p.maPhong) == false)
                {
                    kq += XL_PHONGVIP.xuatPhong(p) + '\n';
                }
            }
            Console.WriteLine(kq);
        }
        public static int tinhTongSoGiuong(KHACHSAN ks)
        {
            int kq = 0;
            foreach(PHONGTHUONG p in ks.dsPhong)
            {
                kq += p.soGiuong;
            }
            foreach (PHONGVIP p in ks.dsPhong)
            {
                kq += p.soGiuong;
            }
            return kq;
        }
        public static void lietKePhongGiaGiamDan(KHACHSAN ks)
        {
            string kq = "Danh sach cac phong theo thu tu gia giam dan:\n";
            List<PHONGVIP> lPhongVip = new List<PHONGVIP>();
            foreach(PHONGVIP p in ks.dsPhong)
            {
                lPhongVip.Add(p);
            }
            List<PHONGVIP> daXep = lPhongVip.OrderBy(a => -a.donGia).ToList();

            List<PHONGTHUONG> lPhongThuong = new List<PHONGTHUONG>();
            foreach (PHONGTHUONG p in ks.dsPhong)
            {
                lPhongThuong.Add(p);
            }
            List<PHONGTHUONG> daXep2 = lPhongThuong.OrderBy(a => -a.donGia).ToList();
          
            foreach(PHONGVIP p in daXep)
            {
                kq += XL_PHONGVIP.xuatPhong(p) + "\n";
            }
            foreach (PHONGTHUONG p in daXep2)
            {
                kq += XL_PHONGTHUONG.xuatPhong(p) + "\n";
            }

            Console.WriteLine(kq);
        }
        public static double doanhThuTrongNgay(DateTime ngay,KHACHSAN ks)
        {
            double doanhThu = 0;
            string phongCoKhach = string.Empty;
            foreach (KHACHTHUE k in ks.dsKhachThue)
            {
                if (k.ngayThue <= ngay && k.ngayTra >= ngay)
                {
                    phongCoKhach += k.maPhongThue + ',';
                }
            }
            foreach (PHONGTHUONG p in ks.dsPhong)
            {
                if (phongCoKhach.Contains(p.maPhong) == true)
                {
                    doanhThu += XL_PHONGTHUONG.donGiaNgay(ngay,ks.dsKhachThue,p);
                }
            }
            foreach (PHONGVIP p in ks.dsPhong)
            {
                if (phongCoKhach.Contains(p.maPhong) == true)
                {
                    doanhThu += XL_PHONGVIP.donGiaNgay(ngay, ks.dsKhachThue, p);
                }
            }
            return doanhThu;
        }
        public static double tienPhaiTra(string dkCmnd,KHACHSAN ks)
        {
            KHACHTHUE k = new KHACHTHUE();
            bool timThay = false;
            foreach(KHACHTHUE t in ks.dsKhachThue)
            {
                if (t.cmnd == dkCmnd)
                {
                    k = t;
                    timThay = true;
                    break;
                }
            }
            if (timThay == false)
            {
                return -1;
            }

            double kq = 0;
            TimeSpan soNgayThue = k.ngayTra - k.ngayThue;
            foreach (PHONGTHUONG p in ks.dsPhong)
            {
                if (p.maPhong == k.maPhongThue)
                {
                    kq = XL_PHONGTHUONG.tongSoTien(soNgayThue.Days+1,p);//tinh tien ca ngay dau tien
                    return kq;
                }
            }
            foreach (PHONGVIP p in ks.dsPhong)
            {
                if (p.maPhong == k.maPhongThue)
                {
                    kq = XL_PHONGVIP.tongSoTien(soNgayThue.Days + 1, p);//tinh tien ca ngay dau tien
                    break;
                }
            }
            return kq;
        }
    }
}
