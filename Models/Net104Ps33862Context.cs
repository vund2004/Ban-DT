using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NET104_ASM.Models;

public partial class Net104Ps33862Context : DbContext
{
    public Net104Ps33862Context()
    {
    }

    public Net104Ps33862Context(DbContextOptions<Net104Ps33862Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-SI8489PB\\NGUYENDINHVU;Initial Catalog=NET104_PS33862;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3214EC27059F386F");

            entity.ToTable("Admin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.MaGioHang).HasName("PK__GioHang__F5001DA3E5A8CBB7");

            entity.ToTable("GioHang");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK__GioHang__MaNguoi__403A8C7D");
        });

        modelBuilder.Entity<GioHangChiTiet>(entity =>
        {
            entity.HasKey(e => e.MaGioHangCt).HasName("PK__GioHangC__DCA9914E78948457");

            entity.ToTable("GioHangChiTiet");

            entity.Property(e => e.MaGioHangCt).HasColumnName("MaGioHangCT");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");

            entity.HasOne(d => d.MaGioHangNavigation).WithMany(p => p.GioHangChiTiets)
                .HasForeignKey(d => d.MaGioHang)
                .HasConstraintName("FK__GioHangCh__MaGio__440B1D61");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.GioHangChiTiets)
                .HasForeignKey(d => d.MaSp)
                .HasConstraintName("FK__GioHangChi__MaSP__4316F928");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__2725A6E00693BABF");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.DiaChiGiaoHang).HasMaxLength(200);
            entity.Property(e => e.Ghichu).HasMaxLength(500);
            entity.Property(e => e.ThoiGianDat).HasColumnType("datetime");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK__HoaDon__MaNguoiD__46E78A0C");
        });

        modelBuilder.Entity<HoaDonChiTiet>(entity =>
        {
            entity.HasKey(e => e.MaHdct).HasName("PK__HoaDonCh__1419C129AE19BB13");

            entity.ToTable("HoaDonChiTiet");

            entity.Property(e => e.MaHdct).HasColumnName("MaHDCT");
            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK__HoaDonChiT__MaHD__4AB81AF0");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.MaSp)
                .HasConstraintName("FK__HoaDonChiT__MaSP__49C3F6B7");
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.MaLoaiSp).HasName("PK__LoaiSanP__1224CA7CA81CB63B");

            entity.ToTable("LoaiSanPham");

            entity.Property(e => e.MaLoaiSp).HasColumnName("MaLoaiSP");
            entity.Property(e => e.TenLoaiSp)
                .HasMaxLength(100)
                .HasColumnName("TenLoaiSP");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK__NguoiDun__C539D7626DD21214");

            entity.ToTable("NguoiDung");

            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725081C8ECBCF62");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.Chip).HasMaxLength(100);
            entity.Property(e => e.GiaSp).HasColumnName("GiaSP");
            entity.Property(e => e.Hdd)
                .HasMaxLength(50)
                .HasColumnName("HDD");
            entity.Property(e => e.HinhSp)
                .HasMaxLength(200)
                .HasColumnName("HinhSP");
            entity.Property(e => e.MaLoaiSp).HasColumnName("MaLoaiSP");
            entity.Property(e => e.ManHinh).HasMaxLength(100);
            entity.Property(e => e.NgaydangSp).HasColumnName("NgaydangSP");
            entity.Property(e => e.Ram).HasMaxLength(50);
            entity.Property(e => e.TenSp)
                .HasMaxLength(100)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaLoaiSpNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoaiSp)
                .HasConstraintName("FK__SanPham__MaLoaiS__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
