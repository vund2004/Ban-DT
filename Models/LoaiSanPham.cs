using System;
using System.Collections.Generic;

namespace NET104_ASM.Models;

public partial class LoaiSanPham
{
    public int MaLoaiSp { get; set; }

    public string? TenLoaiSp { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
