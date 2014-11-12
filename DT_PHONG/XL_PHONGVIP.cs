using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DT_KHACHTHUE;
using System.Collections;

namespace DT_PHONG
{
    public struct PHONGVIP
    {
        public string maPhong;
        public string tenPhong;
        public int donGia;
        public int soGiuong;
        //public PHONGVIP() 
        //{
        //    maPhong = string.Empty;
        //    tenPhong = string.Empty;
        //    donGia = 0;
        //    soGiuong = 0;
        //}
        public PHONGVIP(string chuoi)
        {
            string[] thongTin = chuoi.Split(',');
            this.maPhong = thongTin[0];
            this.tenPhong = thongTin[1];
            this.donGia = int.Parse(thongTin[2]);
            this.soGiuong = int.Parse(thongTin[3]);
        }
    }
    public class XL_PHONGVIP
    {
        public static PHONGVIP nhapPhong(string ghiChu = "Nhap thong tin phong: ")
        {
            PHONGVIP kq = new PHONGVIP();
            Console.WriteLine(ghiChu);
            Console.Write("Nhap ma phong: ");
            kq.maPhong = Console.ReadLine();
            Console.Write("Nhap ten phong: ");
            kq.tenPhong = Console.ReadLine();
            Console.Write("Nhap don gia phong: ");
            kq.donGia = int.Parse(Console.ReadLine());
            Console.Write("Nhap so luong giuong: ");
            kq.soGiuong = int.Parse(Console.ReadLine());
            return kq;
        }
        public static PHONGVIP capNhatPhong(string maPhong, string ghiChu = "Cap nhat thong tin phong: ")
        {
            PHONGVIP p = new PHONGVIP();
            Console.WriteLine(ghiChu);
            p.maPhong = maPhong;
            Console.Write("Nhap ten phong: ");
            p.tenPhong = Console.ReadLine();
            Console.Write("Nhap don gia phong: ");
            p.donGia = int.Parse(Console.ReadLine());
            Console.Write("Nhap so luong giuong: ");
            p.soGiuong = int.Parse(Console.ReadLine());
            return p;
        }
        public static string xuatPhong(PHONGVIP p)
        {
            return string.Format("Phong vip\t{0}\t{1}\t{2}\t{3}\n", p.maPhong, p.tenPhong, p.donGia, p.soGiuong);
        }
        public static void luu(StreamWriter boGhi,PHONGVIP p)
        {
            boGhi.WriteLine(string.Format("{0},{1},{2},{3}", p.maPhong, p.tenPhong, p.donGia, p.soGiuong));
        }
        public static double donGiaNgay(DateTime ngay, ArrayList dsKhachThue,PHONGVIP p)
        {
            TimeSpan soNgay = new TimeSpan();
            KHACHTHUE nguoiThue = new KHACHTHUE();
            foreach (KHACHTHUE k in dsKhachThue)
            {
                if (k.maPhongThue == p.maPhong)
                {
                    nguoiThue = k;
                    break;
                }
            }
            soNgay = ngay - nguoiThue.ngayThue;
            double giaTrongNgay = 0;
            int soNgayTinhTien = soNgay.Days + 1;//tinh tien ca ngay dau
            if (soNgayTinhTien < 2)
            {
                giaTrongNgay = p.donGia;
            }
            else if (soNgayTinhTien<5)
            {
                giaTrongNgay = p.donGia * 0.8;
            }
            else
            {
                giaTrongNgay = p.donGia * 0.7;
            }
            return giaTrongNgay;
        }
        public static double tongSoTien(int soNgayTinhTien,PHONGVIP p)
        {
            double thanhTien = 0;
            if (soNgayTinhTien < 2)
            {
                thanhTien = soNgayTinhTien * p.donGia;
            }
            else if (soNgayTinhTien < 5)
            {
                thanhTien = soNgayTinhTien*p.donGia + ((soNgayTinhTien - 1) * p.donGia * 0.8);
            }
            else
            {
                thanhTien = soNgayTinhTien*p.donGia + (3 * p.donGia * 0.8) + ((soNgayTinhTien - 4)*p.donGia*0.7);
            }
            return thanhTien;
        }

    }
}
