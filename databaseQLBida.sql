USE [master]
GO
/****** Object:  Database [DoAnQuanLyQuanBida]    Script Date: 15/10/2024 2:31:18 AM ******/
CREATE DATABASE [DoAnQuanLyQuanBida]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DoAnQuanLyQuanBida', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DoAnQuanLyQuanBida.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DoAnQuanLyQuanBida_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DoAnQuanLyQuanBida_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DoAnQuanLyQuanBida].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET ARITHABORT OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET  MULTI_USER 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET QUERY_STORE = OFF
GO
USE [DoAnQuanLyQuanBida]
GO
/****** Object:  UserDefinedFunction [dbo].[DemNamNu]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[DemNamNu]()
RETURNS NVARCHAR(100)
AS
BEGIN
    DECLARE @SoLuongNam INT
    DECLARE @SoLuongNu INT
    DECLARE @KetQua NVARCHAR(100)

    SELECT @SoLuongNam = COUNT(*) FROM NHANVIEN WHERE GioiTinh = N'Nam'
    SELECT @SoLuongNu = COUNT(*) FROM NHANVIEN WHERE GioiTinh = N'Nữ'

    SET @KetQua = N'Số lượng nam: ' + CAST(@SoLuongNam AS NVARCHAR(10)) + N' Số lượng nữ: ' + CAST(@SoLuongNu AS NVARCHAR(10))
    RETURN @KetQua
END
GO
/****** Object:  UserDefinedFunction [dbo].[f_DoanhThuTrongNgay]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[f_DoanhThuTrongNgay] (@ngay DATE)
RETURNS INT
AS
BEGIN
    DECLARE @doanhThu INT;

    SELECT @doanhThu = ISNULL(SUM(SOTIENTHANHTOAN), 0)
    FROM HOADON
    WHERE 
        HOADON.NgayXuatHD >= @ngay AND 
        HOADON.NgayXuatHD < DATEADD(DAY, 1, @ngay);

    RETURN @doanhThu;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[f_HoaDonCuaBanHT]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[f_HoaDonCuaBanHT]
(
	@maBan varchar(10)
)
returns int
as
begin
	declare @hdht int
	select @hdht = HDHienTai
	from BAN
	where MaBan = @maBan
	return ISNULL(@hdht, 0)
end
GO
/****** Object:  UserDefinedFunction [dbo].[f_soLuongHD]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[f_soLuongHD] (@tg1 date,@tg2 date)
returns	int
as
begin
	declare @sl int
	if( @tg1 <= @tg2)
	begin
		select @sl = Isnull(count(MaHDBH),0)
		from HOADON
		where @tg1 <NgayXuatHD and @tg2 >= NgayXuatHD
	end
	return @sl
end
GO
/****** Object:  UserDefinedFunction [dbo].[f_TinhThanhTien]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[f_TinhThanhTien] 
(
	@MaHH varchar(10), 
	@SoLuong INT
)
RETURNS INT
AS
BEGIN
    DECLARE @GiaSP INT;
    SELECT @GiaSP = GiaSP FROM HangHoa WHERE MaHH = @MaHH;
    RETURN @GiaSP * @SoLuong;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[f_TinhTongTienHoaDon]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[f_TinhTongTienHoaDon]
(
@MaHDBH INT
)
RETURNS INT
AS
BEGIN
    DECLARE @TongTien INT;

    SELECT @TongTien = SUM(ThanhTien)
    FROM CHITIETHOADON
    WHERE MAHDBH = @MaHDBH;

    RETURN @TongTien;
END;
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MaHDBH] [int] NOT NULL,
	[MaNV] [varchar](10) NULL,
	[MaBan] [varchar](10) NULL,
	[NgayXuatHD] [datetime] NULL,
	[TongTien] [int] NULL,
	[DiemTL] [int] NULL,
	[GiamGia] [float] NULL,
	[MaKH] [varchar](10) NULL,
	[SoTienThanhToan] [int] NULL,
	[ThoiGianVao] [datetime] NULL,
	[ThoiGianRa] [datetime] NULL,
	[ThoiGianDatCoc] [datetime] NULL,
	[TienDatCoc] [int] NULL,
	[ThoiGianKTDatCoc] [datetime] NULL,
	[SoPhutTreToiDa] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHDBH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetLichSuGiaoDich]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetLichSuGiaoDich](@MaKH varchar(10))
RETURNS TABLE
AS
RETURN
(
    SELECT 
        HD.MaHDBH,
        HD.NgayXuatHD,
        HD.TongTien,
        HD.DiemTL,
        HD.GiamGia,
        HD.SoTienThanhToan
    FROM 
        HOADON HD
    WHERE 
        HD.MaKH = @MaKH
);
GO
/****** Object:  Table [dbo].[HANGHOA]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HANGHOA](
	[MaHH] [varchar](10) NOT NULL,
	[MaLH] [varchar](10) NULL,
	[TenHH] [nvarchar](50) NULL,
	[HinhAnh] [nvarchar](50) NULL,
	[GiaSP] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[f_ThucDon]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[f_ThucDon]
(
	@maLoai varchar(10)
)
returns table
as
return (select MaHH,TenHH,GiaSP from HANGHOA where MaLH = @maLoai)
GO
/****** Object:  UserDefinedFunction [dbo].[f_xemDoanhThu]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[f_xemDoanhThu]
(
	@NgayBatDau date,
	@NgayKetThuc date
)
returns table
as
return (
		SELECT CONVERT(date, NgayXuatHD) AS 'NgayXuatHD',  SUM(SoTienThanhToan) AS 'DoanhThu'
                             FROM HOADON
                             WHERE NgayXuatHD >= @NgayBatDau AND NgayXuatHD <= DATEADD(day, 1, @NgayKetThuc) 
                             GROUP BY CONVERT(date, NgayXuatHD)
		)
GO
/****** Object:  Table [dbo].[BAN]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAN](
	[MaBan] [varchar](10) NOT NULL,
	[TenBan] [nvarchar](50) NULL,
	[MaKV] [varchar](10) NULL,
	[TrangThai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bangthongke]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bangthongke](
	[NgayXuatHD] [date] NOT NULL,
	[DoanhThu] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NgayXuatHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[MaHDBH] [int] NOT NULL,
	[MaHH] [varchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHDBH] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietNiemYetBan]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietNiemYetBan](
	[MaBan] [varchar](10) NOT NULL,
	[MaNiemYet] [varchar](10) NOT NULL,
	[GiaTri] [int] NULL,
 CONSTRAINT [PK_ChiTietNiemYetBan] PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC,
	[MaNiemYet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_ManHinh]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_ManHinh](
	[MaManHinh] [char](10) NOT NULL,
	[TenManHinh] [nvarchar](50) NULL,
 CONSTRAINT [PK_DM_ManHinh] PRIMARY KEY CLUSTERED 
(
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [varchar](10) NOT NULL,
	[MaLKH] [varchar](10) NULL,
	[TenKH] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [nvarchar](11) NULL,
	[DiemTichLuy] [int] NULL,
	[MatKhau] [varchar](15) NULL,
	[HoatDong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UN_SDT] UNIQUE NONCLUSTERED 
(
	[SDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHUVUC]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHUVUC](
	[MaKV] [varchar](10) NOT NULL,
	[TenKV] [nvarchar](50) NULL,
	[GiaTien] [int] NOT NULL,
	[MaLoaiBan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiBan]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiBan](
	[maban] [int] NOT NULL,
	[tenloaiban] [nvarchar](255) NOT NULL,
	[GiaGioChoi] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIHH]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIHH](
	[MaLH] [varchar](10) NOT NULL,
	[TenLH] [nvarchar](50) NULL,
	[MoTa] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIKH]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIKH](
	[MaLKH] [varchar](10) NOT NULL,
	[TenLKH] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [varchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](11) NULL,
	[PhanQuyen] [varchar](10) NULL,
	[MatKhau] [varchar](20) NULL,
	[HoatDong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NiemYet]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NiemYet](
	[MaNiemYet] [varchar](10) NOT NULL,
	[TenNiemYet] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNiemYet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QL_NguoiDungNhomNguoiDung]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QL_NguoiDungNhomNguoiDung](
	[TenDangNhap] [varchar](10) NOT NULL,
	[MaNhomNguoiDung] [char](10) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_QL_NguoiDungNhomNguoiDung] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC,
	[MaNhomNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QL_NhomNguoiDung]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QL_NhomNguoiDung](
	[MaNhom] [char](10) NOT NULL,
	[TenNhom] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_QL_NhomNguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QL_PhanQuyen]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QL_PhanQuyen](
	[MaNhomNguoiDung] [char](10) NULL,
	[MaManHinh] [char](10) NULL,
	[CoQuyen] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HOADON] ADD  DEFAULT ((50000)) FOR [TienDatCoc]
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  CONSTRAINT [DF_DiaChi]  DEFAULT (N'TP Hồ Chí Minh') FOR [DiaChi]
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  DEFAULT ((1)) FOR [HoatDong]
GO
ALTER TABLE [dbo].[KHUVUC] ADD  DEFAULT ((0)) FOR [GiaTien]
GO
ALTER TABLE [dbo].[NHANVIEN] ADD  DEFAULT ((1)) FOR [HoatDong]
GO
ALTER TABLE [dbo].[BAN]  WITH CHECK ADD  CONSTRAINT [FK_KV] FOREIGN KEY([MaKV])
REFERENCES [dbo].[KHUVUC] ([MaKV])
GO
ALTER TABLE [dbo].[BAN] CHECK CONSTRAINT [FK_KV]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_HD] FOREIGN KEY([MaHDBH])
REFERENCES [dbo].[HOADON] ([MaHDBH])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CTHD_HD]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_HH] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HANGHOA] ([MaHH])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CTHD_HH]
GO
ALTER TABLE [dbo].[ChiTietNiemYetBan]  WITH CHECK ADD  CONSTRAINT [FK_CT_Ban] FOREIGN KEY([MaBan])
REFERENCES [dbo].[BAN] ([MaBan])
GO
ALTER TABLE [dbo].[ChiTietNiemYetBan] CHECK CONSTRAINT [FK_CT_Ban]
GO
ALTER TABLE [dbo].[ChiTietNiemYetBan]  WITH CHECK ADD  CONSTRAINT [FK_CT_NiemYet] FOREIGN KEY([MaNiemYet])
REFERENCES [dbo].[NiemYet] ([MaNiemYet])
GO
ALTER TABLE [dbo].[ChiTietNiemYetBan] CHECK CONSTRAINT [FK_CT_NiemYet]
GO
ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD  CONSTRAINT [FK_LoaiHH] FOREIGN KEY([MaLH])
REFERENCES [dbo].[LOAIHH] ([MaLH])
GO
ALTER TABLE [dbo].[HANGHOA] CHECK CONSTRAINT [FK_LoaiHH]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_Ban] FOREIGN KEY([MaBan])
REFERENCES [dbo].[BAN] ([MaBan])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HoaDon_Ban]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KH] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HoaDon_KH]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NV] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HoaDon_NV]
GO
ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD  CONSTRAINT [FK_LoaiKH] FOREIGN KEY([MaLKH])
REFERENCES [dbo].[LOAIKH] ([MaLKH])
GO
ALTER TABLE [dbo].[KHACHHANG] CHECK CONSTRAINT [FK_LoaiKH]
GO
ALTER TABLE [dbo].[KHUVUC]  WITH CHECK ADD  CONSTRAINT [FK_KhuVuc_LoaiBan] FOREIGN KEY([MaLoaiBan])
REFERENCES [dbo].[LoaiBan] ([maban])
GO
ALTER TABLE [dbo].[KHUVUC] CHECK CONSTRAINT [FK_KhuVuc_LoaiBan]
GO
ALTER TABLE [dbo].[QL_NguoiDungNhomNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_QL_NguoiDungNhomNguoiDung_QL_NguoiDung] FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[QL_NguoiDungNhomNguoiDung] CHECK CONSTRAINT [FK_QL_NguoiDungNhomNguoiDung_QL_NguoiDung]
GO
ALTER TABLE [dbo].[QL_NguoiDungNhomNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_QL_NguoiDungNhomNguoiDung_QL_NhomNguoiDung] FOREIGN KEY([MaNhomNguoiDung])
REFERENCES [dbo].[QL_NhomNguoiDung] ([MaNhom])
GO
ALTER TABLE [dbo].[QL_NguoiDungNhomNguoiDung] CHECK CONSTRAINT [FK_QL_NguoiDungNhomNguoiDung_QL_NhomNguoiDung]
GO
ALTER TABLE [dbo].[QL_PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_QL_PhanQuyen_DM_ManHinh] FOREIGN KEY([MaManHinh])
REFERENCES [dbo].[DM_ManHinh] ([MaManHinh])
GO
ALTER TABLE [dbo].[QL_PhanQuyen] CHECK CONSTRAINT [FK_QL_PhanQuyen_DM_ManHinh]
GO
ALTER TABLE [dbo].[QL_PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_QL_PhanQuyen_QL_NhomNguoiDung] FOREIGN KEY([MaNhomNguoiDung])
REFERENCES [dbo].[QL_NhomNguoiDung] ([MaNhom])
GO
ALTER TABLE [dbo].[QL_PhanQuyen] CHECK CONSTRAINT [FK_QL_PhanQuyen_QL_NhomNguoiDung]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [CHK_SoLuong_LonHon0] CHECK  (([SoLuong]>=(1)))
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [CHK_SoLuong_LonHon0]
GO
/****** Object:  StoredProcedure [dbo].[LayDSNV]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LayDSNV]
AS
BEGIN

    DECLARE @MaNV VARCHAR(10)
    DECLARE @TenNV NVARCHAR(100)
    DECLARE @SDT NVARCHAR(11)

    
    DECLARE nhanvien_cursor CURSOR FOR
    SELECT MaNV, TenNV, SoDienThoai
    FROM NHANVIEN

    
    OPEN nhanvien_cursor

    
    FETCH NEXT FROM nhanvien_cursor INTO @MaNV, @TenNV, @SDT

    WHILE @@FETCH_STATUS = 0
    BEGIN
        PRINT 'Ma NV: ' + @MaNV + ', Ten: ' + @TenNV + ', SDT: ' + @SDT

        
        FETCH NEXT FROM nhanvien_cursor INTO @MaNV, @TenNV, @SDT
    END

    CLOSE nhanvien_cursor
    DEALLOCATE nhanvien_cursor
END

EXEC LayDSNV
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTongTienHoaDon]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CapNhatTongTienHoaDon]
AS
BEGIN
    UPDATE HoaDon
    SET TongTien = (
        SELECT SUM(ThanhTien)
        FROM ChiTietHoaDon
        WHERE ChiTietHoaDon.MaHDBH = HoaDon.MaHDBH
    )
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTrangThaiBan]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CapNhatTrangThaiBan]
    @MaBan VARCHAR(10)
AS
BEGIN
    UPDATE BAN
    SET TrangThai = N'Đang dùng'
    WHERE MaBan = @MaBan
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTrangThaiBanTrong]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CapNhatTrangThaiBanTrong]
    @MaBan VARCHAR(10)
AS
BEGIN
    UPDATE BAN
    SET TrangThai = N'Trống'
    WHERE MaBan = @MaBan
END
GO
/****** Object:  StoredProcedure [dbo].[sp_KiemTraTonTaiMaNV]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KiemTraTonTaiMaNV] @MaNV varchar(10)
AS
BEGIN
    DECLARE @SoLuong int;

    SELECT @SoLuong = COUNT(*)
    FROM NHANVIEN
    WHERE MaNV = @MaNV;

    IF @SoLuong > 0
        PRINT N'Mã nhân viên tồn tại';
    ELSE
        PRINT N'Mã nhân viên không tồn tại';
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_TaoMaKhuVuc]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TaoMaKhuVuc]
    @MaKhuVuc NVARCHAR(10) OUTPUT
AS
BEGIN

    DECLARE @MaKV NVARCHAR(10)
    DECLARE @Stt INT

    SELECT TOP 1 @MaKV = MaKV
    FROM KHUVUC
    ORDER BY MaKV DESC

    IF @MaKV IS NOT NULL
    BEGIN
        SET @Stt = CAST(RIGHT(@MaKV, 3) AS INT) + 1

        SET @MaKhuVuc = 'KV' + RIGHT('000' + CAST(@Stt AS NVARCHAR(3)), 3)
    END
    ELSE 
    BEGIN
        SET @MaKhuVuc = 'KV001'
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThongKeDSSPBanChayTheoTG]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThongKeDSSPBanChayTheoTG] @tg1 date,@tg2 date
AS
begin
	if( @tg1 <= @tg2)
		select top 5  TenHH,HANGHOA.GiaSP, SUM(SoLuong) As 'Soluong'
		from CHITIETHOADON inner join HANGHOA on HANGHOA.MaHH = CHITIETHOADON.MaHH
		group by TenHH ,HANGHOA.GiaSP
		order by SoLuong desc
	ELSE
		print 'Ngày bắt đầu phải nhỏ hơn ngày kết thúc'
		
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TimKiemNhanVien]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TimKiemNhanVien]
    @TimKiem varchar(20)
AS
BEGIN
	select *
	from NHANVIEN where MaNV = @TimKiem or SoDienThoai like N'%'+@TimKiem+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TinhTongTienKHSD]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TinhTongTienKHSD] (@makh char(10))
AS
begin
	select KHACHHANG.MaKH,TenKH,sum (SOTIENTHANHTOAN) as N'Tổng tiền đã chi'
	from HOADON inner join KHACHHANG on HOADON.MaKH = KHACHHANG.MaKH
	where KHACHHANG.MaKH = @makh
	group by TenKH,KHACHHANG.MaKH

end
GO
/****** Object:  StoredProcedure [dbo].[TinhTongDiemTichLuy]    Script Date: 15/10/2024 2:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TinhTongDiemTichLuy]
AS
BEGIN

    DECLARE @TongDiem INT = 0
    DECLARE @DiemTichLuy INT

    DECLARE diem_cursor CURSOR FOR
    SELECT DiemTichLuy
    FROM KHACHHANG

    OPEN diem_cursor

    FETCH NEXT FROM diem_cursor INTO @DiemTichLuy

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @TongDiem = @TongDiem + @DiemTichLuy

        FETCH NEXT FROM diem_cursor INTO @DiemTichLuy
    END

    CLOSE diem_cursor
    DEALLOCATE diem_cursor

    PRINT 'Tổng điểm tích lũy của tất cả khách hàng: ' + CAST(@TongDiem AS NVARCHAR(10))
END
GO
USE [master]
GO
ALTER DATABASE [DoAnQuanLyQuanBida] SET  READ_WRITE 
GO
