﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanVeDiTourDuLich.Models
{
    public class TaiKhoan
    {
        [StringLength(20)]
        public string MaTaiKhoan { get; set; }

        [StringLength(20)]
        [Required]
        public string TaiKhoanDangNhap { get; set; }

        [StringLength(20)]
        public string MatKhau { get; set; }
        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}