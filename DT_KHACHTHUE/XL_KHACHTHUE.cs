using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DT_KHACHTHUE
{
    public struct KHACHTHUE
    {
        public string cmnd;
        public string hoTen;
        public DateTime ngayThue;
        public DateTime ngayTra;
        public string maPhongThue;
        //public KHACHTHUE()
        //{
        //    this.cmnd = string.Empty;
        //    this.hoTen = string.Empty;
        //    this.ngayThue = new DateTime();
        //    this.ngayTra = new DateTime();
        //    this.maPhongThue = string.Empty;
        //}
        public KHACHTHUE(string s)
        {
            this.ngayThue = new DateTime();
            this.ngayTra = new DateTime();
            string[] thongTin = s.Split(',');
            this.cmnd = thongTin[0];
            this.hoTen = thongTin[1];
            this.ngayThue = DateTime.Parse(thongTin[2]);
            this.ngayTra = DateTime.Parse(thongTin[3]);
            this.maPhongThue = thongTin[4];
        }

    }
    public class XL_KHACHTHUE
    {
        public static KHACHTHUE themKhachThue(string ghiChu = "Nhap thong tin khach thue: ")
        {
            KHACHTHUE kq;
            Console.WriteLine(ghiChu);
            Console.Write("Nhap so CMND khach thue: ");
            kq.cmnd = Console.ReadLine();
            Console.Write("Nhap ho ten khach thue: ");
            kq.hoTen = Console.ReadLine();
            Console.Write("Nhap ngay thue: ");
            kq.ngayThue = DateTime.Parse(Console.ReadLine());
            Console.Write("Nhap ngay tra: ");
            kq.ngayTra = DateTime.Parse(Console.ReadLine());
            Console.Write("Nhap ma so phong thue: ");
            kq.maPhongThue = Console.ReadLine();
            return kq;
        }
        public static string xuatKhachThue(KHACHTHUE k)
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\n", k.cmnd, k.hoTen, k.ngayThue.ToShortDateString(), k.ngayTra.ToShortDateString(), k.maPhongThue);
        }
        public static KHACHTHUE capNhatKhachThue(string cmnd,string ghiChu = "Cap nhat thong tin khach thue: ")
        {
            KHACHTHUE k = new KHACHTHUE();
            k.cmnd = cmnd;
            Console.WriteLine(ghiChu);
            Console.Write("Nhap ho ten khach thue: ");
            k.hoTen = Console.ReadLine();
            Console.Write("Nhap ngay thue: ");
            k.ngayThue = DateTime.Parse(Console.ReadLine());
            Console.Write("Nhap ngay tra: ");
            k.ngayTra = DateTime.Parse(Console.ReadLine());
            Console.Write("Nhap ma phong thue: ");
            k.maPhongThue = Console.ReadLine();
            return k;
        }
        public static void luu(StreamWriter boGhi,KHACHTHUE k)
        {
            boGhi.WriteLine(string.Format("{0},{1},{2},{3},{4}", k.cmnd, k.hoTen, k.ngayThue.ToString("yyyy/MM/dd"), k.ngayTra.ToString("yyyy/MM/dd"),k.maPhongThue));
        }
    }
}
