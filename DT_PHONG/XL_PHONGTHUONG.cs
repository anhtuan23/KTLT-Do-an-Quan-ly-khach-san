using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using DT_KHACHTHUE;

namespace DT_PHONG
{
    public struct PHONGTHUONG
    {
        public string maPhong;
        public string tenPhong;
        public int donGia;
        public int soGiuong;
        //public PHONGTHUONG() 
        //{
        //    maPhong = string.Empty;
        //    tenPhong = string.Empty;
        //    donGia = 0;
        //    soGiuong = 0;
        //}
        public PHONGTHUONG(string chuoi)
        {
            string[] thongTin = chuoi.Split(',');
            this.maPhong = thongTin[1];
            this.tenPhong = thongTin[2];
            this.donGia = int.Parse(thongTin[3]);
            this.soGiuong = int.Parse(thongTin[4]);
        }
    }
    public class XL_PHONGTHUONG
    {
        public static PHONGTHUONG nhapPhong(string ghiChu = "Nhap thong tin phong: ")
        {
            PHONGTHUONG kq = new PHONGTHUONG();
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
        public static void capNhatPhong(PHONGTHUONG p,string ghiChu = "Cap nhat thong tin phong: ")
        {
            Console.WriteLine(ghiChu);
            Console.Write("Nhap ten phong: ");
            p.tenPhong = Console.ReadLine();
            Console.Write("Nhap don gia phong: ");
            p.donGia = int.Parse(Console.ReadLine());
            Console.Write("Nhap so luong giuong: ");
            p.soGiuong = int.Parse(Console.ReadLine());
        }
        public static string xuatPhong(PHONGTHUONG p)
        {
            return string.Format("Phong thuong\t{0}\t{1}\t{2}\t{3}\n", p.maPhong, p.tenPhong, p.donGia, p.soGiuong);
        }
        public static void luu(StreamWriter boGhi,PHONGTHUONG p)
        {
            boGhi.WriteLine(string.Format("t,{0},{1},{2},{3}", p.maPhong, p.tenPhong, p.donGia, p.soGiuong));
        }
        public static double donGiaNgay(DateTime ngay, ArrayList dsKhachThue,PHONGTHUONG p)
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
            int soNgayTinhTien = soNgay.Days + 1;//tinh tien ca ngay dau
            double giaTrongNgay = 0;
            if(soNgayTinhTien<3)
            {
                giaTrongNgay = p.donGia;
            }
            else
            {
                giaTrongNgay = p.donGia * 0.9;
            }
            return giaTrongNgay;
        }
        public static double tongSoTien(int soNgayTinhTien,PHONGTHUONG p)
        {
            double thanhTien = 0;
            if (soNgayTinhTien < 3)
            {
                thanhTien = soNgayTinhTien * p.donGia;
            }
            else
            {
                thanhTien = (2 * p.donGia) + ((soNgayTinhTien-2)*p.donGia*0.9);
            }
            return thanhTien;
        }
    }
}
