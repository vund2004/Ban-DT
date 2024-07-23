using System;
using System.Collections.Generic;

namespace NET104_ASM.Models;

public partial class GioHangChiTiet
{
    public int MaGioHangCt { get; set; }

    public int? MaSp { get; set; }

    public int? MaGioHang { get; set; }

    public int? SoLuong { get; set; }

    public virtual GioHang? MaGioHangNavigation { get; set; }

    public virtual SanPham? MaSpNavigation { get; set; }
}
