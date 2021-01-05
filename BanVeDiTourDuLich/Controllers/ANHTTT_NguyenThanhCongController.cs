using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanVeDiTourDuLich.ViewModels;
using PagedList;

namespace BanVeDiTourDuLich.Controllers
{
    public class ANHTTT_NguyenThanhCongController : Controller
    {
        DataContext _context = new DataContext();
        // GET: ANHTTT_NguyenThanhCong

        public ActionResult QuanLyNguoiDung(int? page)
        {
            //thực hiện chức năng phân trang
            //tạo biến số sản phẩm trên trang
            int PageSize = 10;
            //tạo biến số trang hiện tại
            int pagenumber = (page ?? 1);
            QuanLyNguoiDungViewModel data = new QuanLyNguoiDungViewModel();
            foreach (KhachHang khach in _context.KhachHangs.ToList())
            {
                double tongTien = khach.HoaDons.Sum(hoaDon => hoaDon.Ves.Sum(ve => ve.LoaiVe.GiaTien));
                int soVe = khach.HoaDons.Sum(hoaDon => hoaDon.Ves.Count);
                data.ThongTinCacNguoiDung.Add(new NguoiDungViewModel
                {
                    TenNguoiDung = khach.Ten,
                    SoTienMua = tongTien,
                    SoVeMua = soVe,
                    NgayTaoTaiKhoan = khach.ThoiGianDangKi,
                    MaNguoiDung = khach.MaKhachHang
                });
                data.ThongTinCacNguoiDung.OrderBy(n => n.SoTienMua).ToPagedList(pagenumber, PageSize).ToList();
            };

            return View(data);
        }

        public ActionResult InforUser(string id)
        {
            var isCustomerViewing = false;
                var khachHang = _context.KhachHangs.Find(id);
                var thongTin1 = new ThongTinChiTietViewModel
                {
                    KhachHang = khachHang,
                    isCustomer = true,
                    isCustomerViewing = isCustomerViewing
                };
                Session["MaTaiKhoan"] = "ADMIN";
                return View(thongTin1);
        }
    }
}