using System;
using System.Collections.Generic;

namespace NET104_ASM.Models;

public partial class SanPham
{
    public int MaSp { get; set; }

    public string? TenSp { get; set; }

    public int? GiaSp { get; set; }

    public string? HinhSp { get; set; }

    public string? Chip { get; set; }

    public string? ManHinh { get; set; }

    public string? Ram { get; set; }

    public string? Hdd { get; set; }

    public int? Soluotban { get; set; }

    public DateOnly? NgaydangSp { get; set; }

    public int? MaLoaiSp { get; set; }

    public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; } = new List<GioHangChiTiet>();

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual LoaiSanPham? MaLoaiSpNavigation { get; set; }
}
