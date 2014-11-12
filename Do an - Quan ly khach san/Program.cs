using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT_PHONG;
using DT_KHACHTHUE;
using DT_KHACHSAN;

namespace Do_an_KTLT_Quan_ly_khach_san
{
    class Program
    {
        static void Main(string[] args)
        {
            KHACHSAN ks = new KHACHSAN();
            //danh sach chuc nang
            string giaoDien = "-----------------------------------\n";
            giaoDien += "1.Nhap thong tin phong\n";
            giaoDien += "2.Xoa phong\n";
            giaoDien += "3.Cap nhat thong tin phong\n";
            giaoDien += "4.Tim kiem phong\n";
            giaoDien += "5.Liet ke phong\n";
            giaoDien += "6.Nhap thong tin khach thue\n";
            giaoDien += "7.Xoa khach thue\n";
            giaoDien += "8.Cap nhat thong tin khach thue\n";
            giaoDien += "9.Tim kiem khach thue\n";
            giaoDien += "10.Liet ke khach thue\n";
            giaoDien += "11.Liet ke phong trong\n";
            giaoDien += "12.Tinh tong so giuong\n";
            giaoDien += "13.Liet ke phong theo gia giam dan\n";
            giaoDien += "14.Tinh doanh thu trong ngay\n";//luu y tinh tien ca ngay dau tien
            giaoDien += "15.Tinh so tien phai tra cua mot khach hang\n";//luu y tinh tien ca ngay dau tien
            giaoDien += "16.Save du lieu\n";
            giaoDien += "17.Load du lieu\n";
            giaoDien += "18.Thoat\n";
            giaoDien += "Chon chuc nang can thuc hien: ";

            bool kt = true;
            while (kt)
            {
                Console.Write(giaoDien);
                int chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1://them phong
                        XL_KHACHSAN.themPhong(ks);
                        break;
                    case 2://xoa phong
                        Console.Write("Nhap ma phong can xoa: ");
                        string dkMaPhong = Console.ReadLine();
                        XL_KHACHSAN.xoaPhong(dkMaPhong,ks);
                        break;
                    case 3://sua thong tin phong
                        Console.Write("Nhap ma phong can sua: ");
                        string dkMaPhong3 = Console.ReadLine();
                        bool kt3 = XL_KHACHSAN.capNhatPhong(dkMaPhong3,ks);
                        if (kt3 == true)
                            Console.WriteLine("Cap nhat thanh cong");
                        else
                            Console.WriteLine("Khong tim thay sach");
                        break;
                    case 4://tim kiem phong
                        Console.Write("Nhap ten phong can tim: ");
                        string dkTenPhong = Console.ReadLine();
                        XL_KHACHSAN.timPhong(dkTenPhong,ks);
                        break;
                    case 5://liet ke phong
                        XL_KHACHSAN.lietKePhong(ks);
                        break;
                    case 6://them khach thue
                        XL_KHACHSAN.themKhachThue(ks);
                        break;
                    case 7://xoa khach thue
                        Console.Write("Nhap cmnd khach thue phong can xoa: ");
                        string dkCmnd = Console.ReadLine();
                        XL_KHACHSAN.xoaPhong(dkCmnd,ks);
                        break;
                    case 8://sua thong tin khach thue
                        Console.Write("Nhap cmnd khach thue phong can sua: ");
                        string dkCmnd8 = Console.ReadLine();
                        bool kt8 = XL_KHACHSAN.capNhatKhachThue(dkCmnd8,ks);
                        if (kt8 == true)
                            Console.WriteLine("Cap nhat thanh cong");
                        else
                            Console.WriteLine("Khong tim thay sach");
                        break;
                    case 9://tim kiem khach thue
                        Console.Write("Nhap ten khach thue phong can tim: ");
                        string dkHoTen = Console.ReadLine();
                        XL_KHACHSAN.timKhachThue(dkHoTen,ks);
                        break;
                    case 10://liet ke khach thue
                        XL_KHACHSAN.lietKeKhachThue(ks);
                        break;
                    case 11://liet ke phong trong
                        Console.Write("Nhap ngay can tim: ");
                        DateTime ngayNhap = DateTime.Parse(Console.ReadLine());
                        XL_KHACHSAN.lietKePhongTrong(ngayNhap,ks);
                        break;
                    case 12://tinh tong so giuong
                        string chuoi = string.Format("Tong so giuong trong khach san la {0}.", XL_KHACHSAN.tinhTongSoGiuong(ks));
                        Console.WriteLine(chuoi);
                        break;
                    case 13://liet ke phong gia giam dan
                        XL_KHACHSAN.lietKePhongGiaGiamDan(ks);
                        break;
                    case 14://tinh doanh thu trong ngay
                        Console.Write("Nhap ngay can tinh: ");
                        DateTime ngayNhap14 = DateTime.Parse(Console.ReadLine());
                        double doanhThu = XL_KHACHSAN.doanhThuTrongNgay(ngayNhap14,ks);
                        Console.WriteLine(string.Format("Doanh thu trong ngay {0} la {1} D", ngayNhap14.ToShortDateString(), doanhThu));
                        break;
                    case 15://tinh so tien phai tra cua mot khach hang
                        Console.Write("Nhap cmnd khach hang: ");
                        string dkCmnd15 = Console.ReadLine();
                        double thanhTien = XL_KHACHSAN.tienPhaiTra(dkCmnd15,ks);
                        if (thanhTien < 0)
                        {
                            Console.WriteLine("Khong tim thay ket qua.");
                        }
                        else
                        {
                            Console.WriteLine(string.Format("So tien phai tra cua khach hang {0} la {1} D", dkCmnd15, thanhTien));
                        }
                        break;
                    case 16://Save "C:\Users\anh\Google Drive\Learning\ĐH Khoa học Tự nhiên\06.Kỹ thuật lập trình\khach thue.txt"
                        string duongDanPhong = "C:\\Users\\anh\\Google Drive\\Learning\\ĐH Khoa học Tự nhiên\\06.Kỹ thuật lập trình\\phong.txt";
                        string duongDanKhach = "C:\\Users\\anh\\Google Drive\\Learning\\ĐH Khoa học Tự nhiên\\06.Kỹ thuật lập trình\\khach thue.txt";
                        XL_KHACHSAN.luuDanhSachPhong(duongDanPhong,ks);
                        XL_KHACHSAN.luuDanhSachKhachThue(duongDanKhach,ks);
                        Console.WriteLine("Da luu");
                        break;
                    case 17://Load
                        string duongDanPhong14 = "C:\\Users\\anh\\Google Drive\\Learning\\ĐH Khoa học Tự nhiên\\06.Kỹ thuật lập trình\\phong.txt";
                        string duongDanKhach14 = "C:\\Users\\anh\\Google Drive\\Learning\\ĐH Khoa học Tự nhiên\\06.Kỹ thuật lập trình\\khach thue.txt";
                        ks.dsPhong = XL_KHACHSAN.docDanhSachPhong(duongDanPhong14,ks);
                        ks.dsKhachThue = XL_KHACHSAN.docDanhSachKhachThue(duongDanKhach14,ks);
                        Console.WriteLine("Da load");
                        break;
                    case 18://thoat
                        kt = false;
                        break;
                    default:
                        Console.WriteLine("Lenh khong hop le");
                        break;
                }
            }
        }
    }
}
