using System;
using System.Collections.Generic;

namespace NET104_ASM.Models;

public partial class HoaDonChiTiet
{
    public int MaHdct { get; set; }

    public int? MaSp { get; set; }

    public int? MaHd { get; set; }

    public int? Soluong { get; set; }

    public virtual HoaDon? MaHdNavigation { get; set; }

    public virtual SanPham? MaSpNavigation { get; set; }
}
