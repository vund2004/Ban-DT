using System;
using System.Collections.Generic;

namespace NET104_ASM.Models;

public partial class GioHang
{
    public int MaGioHang { get; set; }

    public int? MaNguoiDung { get; set; }

    public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; } = new List<GioHangChiTiet>();

    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }
}
