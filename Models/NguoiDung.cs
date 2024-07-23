using System;
using System.Collections.Generic;

namespace NET104_ASM.Models;

public partial class NguoiDung
{
    public int MaNguoiDung { get; set; }

    public string? HoTen { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public string? MatKhau { get; set; }

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
