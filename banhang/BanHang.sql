USE [master]
GO
/****** Object:  Database [QLBanhang]    Script Date: 12/03/2015 09:34:46 ******/
CREATE DATABASE [QLBanhang] ON  PRIMARY 
( NAME = N'QLBanhang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\QLBanhang.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLBanhang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\QLBanhang_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLBanhang] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLBanhang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLBanhang] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [QLBanhang] SET ANSI_NULLS OFF
GO
ALTER DATABASE [QLBanhang] SET ANSI_PADDING OFF
GO
ALTER DATABASE [QLBanhang] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [QLBanhang] SET ARITHABORT OFF
GO
ALTER DATABASE [QLBanhang] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [QLBanhang] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [QLBanhang] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [QLBanhang] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [QLBanhang] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [QLBanhang] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [QLBanhang] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [QLBanhang] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [QLBanhang] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [QLBanhang] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [QLBanhang] SET  ENABLE_BROKER
GO
ALTER DATABASE [QLBanhang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [QLBanhang] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [QLBanhang] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [QLBanhang] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [QLBanhang] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [QLBanhang] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [QLBanhang] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [QLBanhang] SET  READ_WRITE
GO
ALTER DATABASE [QLBanhang] SET RECOVERY FULL
GO
ALTER DATABASE [QLBanhang] SET  MULTI_USER
GO
ALTER DATABASE [QLBanhang] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [QLBanhang] SET DB_CHAINING OFF
GO
USE [QLBanhang]
GO
/****** Object:  StoredProcedure [dbo].[SANPHAM_PROCVIEW]    Script Date: 12/03/2015 09:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SANPHAM_PROCVIEW] 
@PageSize int,
@PageNumber int
AS
BEGIN
	declare @From int
	declare @To int
	set @From = @PageSize*(@PageNumber-1) +1
	set @To = @PageSize * @PageNumber
	declare @SQL nvarchar(MAX)
	set @SQL= N'select * from 
		(select sp.* ,lsp.Tenloaisanpham,SUM(lt.Soluong) as Soluong,ncc.Tennhacungcap,ROW_NUMBER()over(
	order by sp.SanphamID ASC) rownum from Sanpham sp
     inner join Loaisanpham lsp on lsp.LoaisanphamID = sp.LoaisanphamID
     inner join Luutru lt on lt.SanphamID = sp.SanphamID
	 inner join Nhacungcap ncc on ncc.NhacungcapID = sp.NhacungcapID
	group by sp.SanphamID,sp.Tensanpham,sp.Donvitinh,sp.Giaban,sp.NhacungcapID,sp.LoaisanphamID,ncc.Tennhacungcap,lsp.Tenloaisanpham
	) x
	where x.rownum >= '+ CONVERT(nchar, @From)+' and x.rownum <= '+CONVERT(nchar, @To)
	Exec SP_ExecuteSQL @SQL	
END
--SANPHAM_PROCVIEW 4,1
GO
/****** Object:  Table [dbo].[Nhacungcap]    Script Date: 12/03/2015 09:35:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nhacungcap](
	[NhacungcapID] [int] IDENTITY(1,1) NOT NULL,
	[Tennhacungcap] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Dienthoai] [varchar](20) NULL,
 CONSTRAINT [PK_Nhacungcap] PRIMARY KEY CLUSTERED 
(
	[NhacungcapID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Nhacungcap] ON
INSERT [dbo].[Nhacungcap] ([NhacungcapID], [Tennhacungcap], [Diachi], [Dienthoai]) VALUES (1, N'NOKIA', N'Hà Nội', NULL)
INSERT [dbo].[Nhacungcap] ([NhacungcapID], [Tennhacungcap], [Diachi], [Dienthoai]) VALUES (2, N'SAMSUNG', N'Hà Nội', NULL)
INSERT [dbo].[Nhacungcap] ([NhacungcapID], [Tennhacungcap], [Diachi], [Dienthoai]) VALUES (3, N'SONY', N'Hà Nội', NULL)
INSERT [dbo].[Nhacungcap] ([NhacungcapID], [Tennhacungcap], [Diachi], [Dienthoai]) VALUES (4, N'APPLE', N'Hà Nội', NULL)
SET IDENTITY_INSERT [dbo].[Nhacungcap] OFF
/****** Object:  Table [dbo].[Khachhang]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khachhang](
	[KhachhangID] [int] IDENTITY(1,1) NOT NULL,
	[Tenkhachhang] [nvarchar](50) NULL,
	[Ngaysinh] [datetime] NULL,
	[Gioitinh] [bit] NULL,
	[Sodienthoai] [nchar](17) NULL,
	[Diachi] [nvarchar](100) NULL,
	[Mucthanthiet] [int] NULL,
 CONSTRAINT [PK_Khachhang] PRIMARY KEY CLUSTERED 
(
	[KhachhangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Khachhang] ON
INSERT [dbo].[Khachhang] ([KhachhangID], [Tenkhachhang], [Ngaysinh], [Gioitinh], [Sodienthoai], [Diachi], [Mucthanthiet]) VALUES (1, N'Khách hàng 1', CAST(0x00009E5E00000000 AS DateTime), 1, N'(+84)963-827-749 ', N'Hà Nội', 1)
INSERT [dbo].[Khachhang] ([KhachhangID], [Tenkhachhang], [Ngaysinh], [Gioitinh], [Sodienthoai], [Diachi], [Mucthanthiet]) VALUES (2, N'Khách hàng 2', CAST(0x0000901A00000000 AS DateTime), 0, N'123456789        ', N'Hà Nội', 1)
INSERT [dbo].[Khachhang] ([KhachhangID], [Tenkhachhang], [Ngaysinh], [Gioitinh], [Sodienthoai], [Diachi], [Mucthanthiet]) VALUES (4, N'a', CAST(0x0000A54D00000000 AS DateTime), 0, N'(+84)165-961-74  ', N'a', 0)
INSERT [dbo].[Khachhang] ([KhachhangID], [Tenkhachhang], [Ngaysinh], [Gioitinh], [Sodienthoai], [Diachi], [Mucthanthiet]) VALUES (5, N'dzunght', CAST(0x0000881000000000 AS DateTime), 1, N'(+84) 988-594-4  ', N'Hà nội', 1)
INSERT [dbo].[Khachhang] ([KhachhangID], [Tenkhachhang], [Ngaysinh], [Gioitinh], [Sodienthoai], [Diachi], [Mucthanthiet]) VALUES (6, N'hue', CAST(0x0000A56200000000 AS DateTime), 0, N'(+84)354-353-5435', N'hnoi', 0)
SET IDENTITY_INSERT [dbo].[Khachhang] OFF
/****** Object:  Table [dbo].[Bophan]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bophan](
	[BophanID] [int] IDENTITY(1,1) NOT NULL,
	[Tenbophan] [nvarchar](50) NULL,
 CONSTRAINT [PK_Bophan] PRIMARY KEY CLUSTERED 
(
	[BophanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bophan] ON
INSERT [dbo].[Bophan] ([BophanID], [Tenbophan]) VALUES (1, N'Bán hàng')
SET IDENTITY_INSERT [dbo].[Bophan] OFF
/****** Object:  Table [dbo].[Loaisanpham]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loaisanpham](
	[LoaisanphamID] [int] IDENTITY(1,1) NOT NULL,
	[Tenloaisanpham] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loaisanpham] PRIMARY KEY CLUSTERED 
(
	[LoaisanphamID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Loaisanpham] ON
INSERT [dbo].[Loaisanpham] ([LoaisanphamID], [Tenloaisanpham]) VALUES (1, N'Máy tính')
INSERT [dbo].[Loaisanpham] ([LoaisanphamID], [Tenloaisanpham]) VALUES (2, N'Điện thoại')
SET IDENTITY_INSERT [dbo].[Loaisanpham] OFF
/****** Object:  Table [dbo].[Kho]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[KhoID] [int] IDENTITY(1,1) NOT NULL,
	[Tenkho] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kho] PRIMARY KEY CLUSTERED 
(
	[KhoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kho] ON
INSERT [dbo].[Kho] ([KhoID], [Tenkho]) VALUES (1, N'Hà Nội')
INSERT [dbo].[Kho] ([KhoID], [Tenkho]) VALUES (2, N'Hồ Chí Minh')
INSERT [dbo].[Kho] ([KhoID], [Tenkho]) VALUES (3, N'Đà Nẵng')
SET IDENTITY_INSERT [dbo].[Kho] OFF
/****** Object:  StoredProcedure [dbo].[Khachhang_Update]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Khachhang_Update]
@KhachhangID int,
@Tenkhachhang nvarchar(50),
@Ngaysinh Datetime,
@Gioitinh bit,
@Sodienthoai nchar(17),
@Diachi nvarchar(100),
@Mucthanthiet int
as
	Update Khachhang set Tenkhachhang=@Tenkhachhang,Ngaysinh=@Ngaysinh,Gioitinh=@Gioitinh,Sodienthoai=@Sodienthoai,Diachi=@Diachi
	where KhachhangID=@KhachhangID
GO
/****** Object:  StoredProcedure [dbo].[Khachhang_Search]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Khachhang_Search]
@Content nvarchar(100)
as
select * from Khachhang where Tenkhachhang like N'%'+@Content+'%'
GO
/****** Object:  StoredProcedure [dbo].[Khachhang_ProcInsert]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Khachhang_ProcInsert]
@Tenkhachhang nvarchar(100),
@Ngaysinh datetime,
@Gioitinh bit,
@Sodienthoai nchar(15),
@Diachi nvarchar(100)
as
	insert into Khachhang values(@Tenkhachhang,@Ngaysinh,@Gioitinh,@Sodienthoai,@Diachi,1)
GO
/****** Object:  StoredProcedure [dbo].[Khachhang_ProcGetKhachhangID]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Khachhang_ProcGetKhachhangID]
@Tenkhachhang nvarchar(100),
@Gioitinh bit,
@Sodienthoai nchar(15),
@Diachi nvarchar(100)
as
	select KhachhangID from Khachhang where
		Tenkhachhang like N'%'+@Tenkhachhang+'%'
		and Gioitinh = @Gioitinh
		and Sodienthoai = @Sodienthoai
		and Diachi like N'%'+@Diachi+'%'
GO
/****** Object:  StoredProcedure [dbo].[Khachhang_Insert]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Khachhang_Insert]
@Tenkhachhang nvarchar(50),
@Ngaysinh Datetime,
@Gioitinh bit,
@Sodienthoai nchar(17),
@Diachi nvarchar(100),
@Mucthanthiet int
as
	insert into Khachhang values(@Tenkhachhang,@Ngaysinh,@Gioitinh,@Sodienthoai,@Diachi,0)
GO
/****** Object:  StoredProcedure [dbo].[Khachhang_GetAllData]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Khachhang_GetAllData]
as
select * from Khachhang
GO
/****** Object:  StoredProcedure [dbo].[Khachhang_DeleteByID]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Khachhang_DeleteByID]
@KhachhangID int
as
	Delete Khachhang where KhachhangID=@KhachhangID
GO
/****** Object:  StoredProcedure [dbo].[Bophan_Update]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bophan_Update]
@BophanID int,
@Tenbophan nvarchar(100)
AS
	Update Bophan set Tenbophan=@Tenbophan where BophanID=@BophanID
GO
/****** Object:  StoredProcedure [dbo].[Bophan_Insert]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bophan_Insert]
@Tenbophan nvarchar(100)
AS
	Insert into Bophan values(@Tenbophan)
GO
/****** Object:  StoredProcedure [dbo].[Bophan_GetAllData]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bophan_GetAllData]
AS
	select * from Bophan
GO
/****** Object:  StoredProcedure [dbo].[Bophan_DeleteByID]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bophan_DeleteByID]
@BophanID int
AS
	Delete Bophan where BophanID=@BophanID
GO
/****** Object:  Table [dbo].[Nhanvien]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nhanvien](
	[NhanvienID] [int] IDENTITY(1,1) NOT NULL,
	[Hoten] [nvarchar](50) NULL,
	[BophanID] [int] NULL,
	[Hesoluong] [real] NULL,
	[Gioitinh] [bit] NULL,
	[Ngaysinh] [datetime] NULL,
	[Diachi] [nvarchar](100) NULL,
	[Password] [varchar](30) NULL,
 CONSTRAINT [PK_Nhanvien] PRIMARY KEY CLUSTERED 
(
	[NhanvienID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Nhanvien] ON
INSERT [dbo].[Nhanvien] ([NhanvienID], [Hoten], [BophanID], [Hesoluong], [Gioitinh], [Ngaysinh], [Diachi], [Password]) VALUES (1, N'Nhân viên bán hàng', 1, 1.5, 1, CAST(0x00009E5E00000000 AS DateTime), N'Hà Nội', N'123')
INSERT [dbo].[Nhanvien] ([NhanvienID], [Hoten], [BophanID], [Hesoluong], [Gioitinh], [Ngaysinh], [Diachi], [Password]) VALUES (2, N'Nhân viên', 1, 3, 1, CAST(0x0000A54E00000000 AS DateTime), N'Hà Nội', N'')
INSERT [dbo].[Nhanvien] ([NhanvienID], [Hoten], [BophanID], [Hesoluong], [Gioitinh], [Ngaysinh], [Diachi], [Password]) VALUES (4, N'sssss1234', 1, 3, 0, CAST(0x0000A54E00000000 AS DateTime), N's', N'')
INSERT [dbo].[Nhanvien] ([NhanvienID], [Hoten], [BophanID], [Hesoluong], [Gioitinh], [Ngaysinh], [Diachi], [Password]) VALUES (5, N's', 1, 2, 0, CAST(0x0000A54E00000000 AS DateTime), N's', N'')
SET IDENTITY_INSERT [dbo].[Nhanvien] OFF
/****** Object:  StoredProcedure [dbo].[Nhacungcap_ViewAll]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Nhacungcap_ViewAll]
as
select * from Nhacungcap
GO
/****** Object:  StoredProcedure [dbo].[Nhacungcap_ProcViewAll]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Nhacungcap_ProcViewAll]
as
select * from Nhacungcap
GO
/****** Object:  Table [dbo].[Sanpham]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sanpham](
	[SanphamID] [int] IDENTITY(1,1) NOT NULL,
	[Tensanpham] [nvarchar](50) NULL,
	[Donvitinh] [nvarchar](10) NULL,
	[Giaban] [real] NULL,
	[NhacungcapID] [int] NULL,
	[LoaisanphamID] [int] NULL,
 CONSTRAINT [PK_Sanpham] PRIMARY KEY CLUSTERED 
(
	[SanphamID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sanpham] ON
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (1, N'Tên sản phẩm', N's', 1, 1, 2)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (2, N'VOSTRO', N'Cái', 10000, 1, 1)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (3, N'HP_v2015', N'Chiếc', 1000, 1, 1)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (4, N'ThinkPad', N'Chiếc', 1000, 1, 1)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (5, N'DELL', N'Chiếc', 500, 2, 1)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (9, N'a', N'a', 1, 2, 1)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (11, N'Điện thoại iphone6', N'Chiếc', 100, 2, 2)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (12, N'test1', N'1', 1, 2, 1)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (13, N'2', N'2', 2, 2, 1)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (14, N'3', N'3', 3, 3, 1)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (16, N'5', N'5', 5, 1, 1)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (17, N'6', N'6', 6, 2, 1)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (18, N'MACBOOK', N'Chiếc', 100, 4, 1)
INSERT [dbo].[Sanpham] ([SanphamID], [Tensanpham], [Donvitinh], [Giaban], [NhacungcapID], [LoaisanphamID]) VALUES (19, N'1102', N'Chiếc', 100, 1, 2)
SET IDENTITY_INSERT [dbo].[Sanpham] OFF
/****** Object:  StoredProcedure [dbo].[Nhasanxuat_ViewAll]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Nhasanxuat_ViewAll]
as
select * from Nhacungcap
GO
/****** Object:  StoredProcedure [dbo].[Loaisanpham_ViewAll]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Loaisanpham_ViewAll]
as
select * from Loaisanpham
GO
/****** Object:  StoredProcedure [dbo].[Loaisanpham_ProcViewAll]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Loaisanpham_ProcViewAll]
as
select * from Loaisanpham
GO
/****** Object:  StoredProcedure [dbo].[Kho_DeleteByID]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Kho_DeleteByID]
@KhoID int
as
	Delete Kho
	where KhoID=@KhoID
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_Delete]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sanpham_Delete]
@SanphamID int
as
 Delete from Sanpham where SanphamID=@SanphamID
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_ProcCountRecord]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sanpham_ProcCountRecord]
as
	select COUNT(SanphamID) from Sanpham
GO
/****** Object:  StoredProcedure [dbo].[Nhanvien_Update]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Nhanvien_Update]
@NhanvienID int,
@Hoten nvarchar(100),
@BophanID int,
@Hesoluong real,
@Gioitinh bit,
@Ngaysinh datetime,
@Diachi nvarchar(100),
@Password nvarchar(30),
@Tenbophan nvarchar(100)
AS
	Update Nhanvien set Hoten=@Hoten,
						BophanID=@BophanID,
						Hesoluong=@Hesoluong,
						Gioitinh=@Gioitinh,
						Ngaysinh=@Ngaysinh,
						Diachi=@Diachi,
						Password=@Password
	where NhanvienID=@NhanvienID
GO
/****** Object:  StoredProcedure [dbo].[Nhanvien_Search]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Nhanvien_Search]
@Content nvarchar(max)
as
select * from Nhanvien nv
		inner join Bophan bp on nv.BophanID=bp.BophanID
		where nv.Hoten like N'%'+@Content+'%'
		or bp.Tenbophan like N'%'+@Content+'%'
GO
/****** Object:  StoredProcedure [dbo].[Nhanvien_ProcView]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Nhanvien_ProcView]
@NhanvienID int
as
	select NhanvienID,Hoten from Nhanvien
	where NhanvienID = @NhanvienID
GO
/****** Object:  StoredProcedure [dbo].[Nhanvien_Insert]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Nhanvien_Insert]
@Hoten nvarchar(100),
@BophanID int,
@Hesoluong real,
@Gioitinh bit,
@Ngaysinh datetime,
@Diachi nvarchar(100),
@Password nvarchar(30),
@Tenbophan nvarchar(30)
AS
	Insert into Nhanvien values(@Hoten,@BophanID,@Hesoluong,@Gioitinh,@Ngaysinh,@Diachi,@Password)
GO
/****** Object:  StoredProcedure [dbo].[Nhanvien_GetAllData]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Nhanvien_GetAllData]
AS
	select nv.*,bp.Tenbophan from Nhanvien nv
		inner join Bophan bp on nv.BophanID=bp.BophanID
GO
/****** Object:  StoredProcedure [dbo].[Nhanvien_DeleteByID]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Nhanvien_DeleteByID]
@NhanvienID int
AS
	Delete Nhanvien
	where NhanvienID=@NhanvienID
GO
/****** Object:  Table [dbo].[Hoadonbanhang]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoadonbanhang](
	[HoadonbanhangID] [int] IDENTITY(1,1) NOT NULL,
	[Ngayviet] [datetime] NULL,
	[KhachhangID] [int] NULL,
	[NhanvienID] [int] NULL,
 CONSTRAINT [PK_Hoadonbanhang] PRIMARY KEY CLUSTERED 
(
	[HoadonbanhangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Hoadonbanhang] ON
INSERT [dbo].[Hoadonbanhang] ([HoadonbanhangID], [Ngayviet], [KhachhangID], [NhanvienID]) VALUES (2, CAST(0x0000A54800000000 AS DateTime), 1, 1)
INSERT [dbo].[Hoadonbanhang] ([HoadonbanhangID], [Ngayviet], [KhachhangID], [NhanvienID]) VALUES (3, CAST(0x0000901A00000000 AS DateTime), 1, 1)
INSERT [dbo].[Hoadonbanhang] ([HoadonbanhangID], [Ngayviet], [KhachhangID], [NhanvienID]) VALUES (4, CAST(0x0000A55400000000 AS DateTime), 1, 1)
INSERT [dbo].[Hoadonbanhang] ([HoadonbanhangID], [Ngayviet], [KhachhangID], [NhanvienID]) VALUES (5, CAST(0x0000A57200000000 AS DateTime), 1, 1)
INSERT [dbo].[Hoadonbanhang] ([HoadonbanhangID], [Ngayviet], [KhachhangID], [NhanvienID]) VALUES (6, CAST(0x0000A56100000000 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Hoadonbanhang] OFF
/****** Object:  Table [dbo].[Hoadonnhaphang]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoadonnhaphang](
	[HoadonnhaphangID] [int] IDENTITY(1,1) NOT NULL,
	[Ngayviet] [datetime] NULL,
	[NhanvienID] [int] NULL,
	[NhacungcapID] [int] NULL,
 CONSTRAINT [PK_Hoadonnhaphang] PRIMARY KEY CLUSTERED 
(
	[HoadonnhaphangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luutru]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luutru](
	[KhoID] [int] NOT NULL,
	[SanphamID] [int] NOT NULL,
	[Soluong] [int] NULL,
 CONSTRAINT [PK_Luutru] PRIMARY KEY CLUSTERED 
(
	[KhoID] ASC,
	[SanphamID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 1, 31)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 2, 100)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 3, 500)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 4, 50)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 9, 98)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 11, 111)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 12, 1)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 13, 1)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 14, 110312)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 16, 2)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 17, 6)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 18, 20)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (1, 19, 15)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (2, 1, 100)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (2, 2, 100)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (3, 3, 500)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (3, 9, 2)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (3, 14, 800)
INSERT [dbo].[Luutru] ([KhoID], [SanphamID], [Soluong]) VALUES (3, 16, 3)
/****** Object:  StoredProcedure [dbo].[Kho_Search]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Kho_Search]
@Content nvarchar(100)
as
	select k.*,SUM(lt.Soluong) as Soluong from Kho k
		inner join Luutru lt on k.KhoID=lt.KhoID
	group by k.KhoID,k.Tenkho
	having k.Tenkho like N'%'+@Content+'%'
GO
/****** Object:  StoredProcedure [dbo].[Kho_GetDataByID]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Kho_GetDataByID]
@KhoID int
as
declare @tb table(KhoID int,TenKho nvarchar(100),Soluong int)
insert into @tb select k.KhoID,k.Tenkho,SUM(lt.Soluong)as Soluong from Kho k
	left join Luutru lt on k.KhoID=lt.KhoID
	group by k.KhoID,k.Tenkho
	having k.KhoID=@KhoID
Update @tb set Soluong=0 where Soluong is NULL
select * from @tb
GO
/****** Object:  StoredProcedure [dbo].[Kho_GetAllData]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Kho_GetAllData]
as
declare @Tbret Table(KhoID int,Tenkho nvarchar(100),Soluong int)
insert into @Tbret select k.*,SUM(lt.Soluong) as Soluong from Kho k
			left join Luutru lt on k.KhoID=lt.KhoID
			group by k.KhoID,k.Tenkho
update @Tbret set Soluong=0 where Soluong is NULL
select * from @Tbret
GO
/****** Object:  Table [dbo].[CTHoadonbanhang]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoadonbanhang](
	[HoadonbanhangID] [int] NOT NULL,
	[SanphamID] [int] NOT NULL,
	[Soluong] [real] NULL,
	[Dongia] [real] NULL,
 CONSTRAINT [PK_CTHoadonbanhang] PRIMARY KEY CLUSTERED 
(
	[HoadonbanhangID] ASC,
	[SanphamID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CTHoadonbanhang] ([HoadonbanhangID], [SanphamID], [Soluong], [Dongia]) VALUES (2, 1, 10, 100)
INSERT [dbo].[CTHoadonbanhang] ([HoadonbanhangID], [SanphamID], [Soluong], [Dongia]) VALUES (2, 2, 10, 100)
INSERT [dbo].[CTHoadonbanhang] ([HoadonbanhangID], [SanphamID], [Soluong], [Dongia]) VALUES (2, 3, 10, 100)
INSERT [dbo].[CTHoadonbanhang] ([HoadonbanhangID], [SanphamID], [Soluong], [Dongia]) VALUES (3, 1, 1, 100)
INSERT [dbo].[CTHoadonbanhang] ([HoadonbanhangID], [SanphamID], [Soluong], [Dongia]) VALUES (3, 2, 100, 1)
INSERT [dbo].[CTHoadonbanhang] ([HoadonbanhangID], [SanphamID], [Soluong], [Dongia]) VALUES (4, 1, 11, 100)
INSERT [dbo].[CTHoadonbanhang] ([HoadonbanhangID], [SanphamID], [Soluong], [Dongia]) VALUES (5, 1, 12, 100)
/****** Object:  StoredProcedure [dbo].[Hoadonbanhang_ProcInsert]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Hoadonbanhang_ProcInsert]
@Ngayviet datetime,
@KhachhangID int,
@NhanvienID int
as
	Insert into Hoadonbanhang values(@Ngayviet,@KhachhangID,@NhanvienID)
GO
/****** Object:  StoredProcedure [dbo].[Hoadonbanhang_ProcGetHoadonID]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Hoadonbanhang_ProcGetHoadonID]
@KhachhangID int,
@NhanvienID int,
@Ngayviet Datetime
as
	select HoadonbanhangID from Hoadonbanhang where
		KhachhangID = @KhachhangID
		and NhanvienID = @NhanvienID 
		and Ngayviet = @Ngayviet
GO
/****** Object:  Table [dbo].[CTHoadonnhaphang]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoadonnhaphang](
	[HoadonnhaphangID] [int] NOT NULL,
	[SanphamID] [int] NOT NULL,
	[Soluong] [real] NULL,
	[Dongia] [real] NULL,
 CONSTRAINT [PK_CTHoadonnhaphang] PRIMARY KEY CLUSTERED 
(
	[HoadonnhaphangID] ASC,
	[SanphamID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Luutru_ProcViewByID]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Luutru_ProcViewByID]
@SanphamID int
as
	select Luutru.KhoID,Kho.Tenkho,Luutru.Soluong from Luutru
	inner join Kho on Kho.KhoID = Luutru.KhoID
	where SanphamID = @SanphamID
GO
/****** Object:  StoredProcedure [dbo].[Luutru_Insert-Update]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Luutru_Insert-Update]
@KhoID int,
@SanphamID int,
@Soluong int
as
if EXISTS(select * from Luutru where KhoID=@KhoID and SanphamID=@SanphamID)
	begin
		update Luutru set Soluong=Soluong+@Soluong where SanphamID=@SanphamID and KhoID=@KhoID
	end
else
	begin
		insert into Luutru values(@KhoID,@SanphamID,@Soluong)
	end
GO
/****** Object:  StoredProcedure [dbo].[Luutru_Delete]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Luutru_Delete]
@KhoID int,
@SanphamID int
as
	delete from Luutru where KhoID=@KhoID and SanphamID=@SanphamID
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_ViewbyLuutru]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_ViewbyLuutru]
@KhoID int,
@SanphamID int
as
select sp.SanphamID,sp.Tensanpham,lt.Soluong from Sanpham sp
inner join Luutru lt on sp.SanphamID=lt.SanphamID and lt.KhoID=@KhoID and lt.SanphamID=@SanphamID
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_ViewByKho]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_ViewByKho]
@KhoID int
as
select sp.SanphamID,sp.Tensanpham,sp.Giaban,sp.Donvitinh,ncc.Tennhacungcap,SUM(lt.Soluong)as Soluong,lsp.Tenloaisanpham,ncc.NhacungcapID,lsp.LoaisanphamID from Sanpham sp
	inner join Loaisanpham lsp on sp.LoaisanphamID=lsp.LoaisanphamID
	inner join Nhacungcap ncc on sp.NhacungcapID=ncc.NhacungcapID
	inner join Luutru lt on sp.SanphamID=lt.SanphamID and lt.KhoID=@KhoID
	group by  sp.SanphamID,sp.Tensanpham,sp.Giaban,sp.Donvitinh,ncc.Tennhacungcap,lsp.Tenloaisanpham,ncc.NhacungcapID,lsp.LoaisanphamID
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_ViewByID]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_ViewByID]
@SanphamID int
as
	select * from Sanpham sp
			inner join Loaisanpham lsp on sp.LoaisanphamID=lsp.LoaisanphamID
			inner join Luutru lt on sp.SanphamID=lt.SanphamID and sp.SanphamID=@SanphamID
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_ViewByFilter]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_ViewByFilter]
@Loaisanpham varchar(max),
@Nhasanxuat nvarchar(max),
@Content nvarchar(100)
as
	select sp.SanphamID,sp.Tensanpham,sp.Giaban,sp.Donvitinh,ncc.Tennhacungcap,SUM(lt.Soluong)as Soluong,lsp.Tenloaisanpham,ncc.NhacungcapID,lsp.LoaisanphamID from Sanpham sp
	inner join Loaisanpham lsp on sp.LoaisanphamID=lsp.LoaisanphamID
	inner join Nhacungcap ncc on sp.NhacungcapID=ncc.NhacungcapID
	inner join Luutru lt on sp.SanphamID=lt.SanphamID
	where sp.Tensanpham like N'%'+@Content+'%' and
		lsp.Tenloaisanpham like N'%'+@Loaisanpham+'%' and
		ncc.Tennhacungcap like N'%'+@Nhasanxuat+'%'
	group by sp.SanphamID,sp.Tensanpham,sp.Giaban,sp.Donvitinh,ncc.Tennhacungcap,lsp.Tenloaisanpham,ncc.NhacungcapID,lsp.LoaisanphamID
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_ViewAll]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_ViewAll]
as
select sp.SanphamID,sp.Tensanpham,sp.Giaban,sp.Donvitinh,ncc.Tennhacungcap,SUM(lt.Soluong)as Soluong,lsp.Tenloaisanpham,ncc.NhacungcapID,lsp.LoaisanphamID from Sanpham sp
	inner join Loaisanpham lsp on sp.LoaisanphamID=lsp.LoaisanphamID
	inner join Nhacungcap ncc on sp.NhacungcapID=ncc.NhacungcapID
	inner join Luutru lt on sp.SanphamID=lt.SanphamID
	group by  sp.SanphamID,sp.Tensanpham,sp.Giaban,sp.Donvitinh,ncc.Tennhacungcap,lsp.Tenloaisanpham,ncc.NhacungcapID,lsp.LoaisanphamID
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_Update]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_Update]
@SanphamID int,
@Tensanpham nvarchar(50),
@Donvitinh nvarchar(10),
@Giaban real,
@NhacungcapID int,
@LoaisanphamID int,
@Soluong int
as
	update Sanpham set Tensanpham=@Tensanpham,
						Donvitinh=@Donvitinh,
						Giaban=@Giaban,
						NhacungcapID=@NhacungcapID,
						LoaisanphamID=@LoaisanphamID
					where SanphamID=@SanphamID
	update Luutru set Soluong=@Soluong where SanphamID=@SanphamID and Luutru.KhoID=1
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_Search]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_Search]
@Content nvarchar(100)
as
select sp.SanphamID,sp.Tensanpham,sp.Giaban,sp.Donvitinh,ncc.Tennhacungcap,SUM(lt.Soluong)as Soluong,lsp.Tenloaisanpham,ncc.NhacungcapID,lsp.LoaisanphamID from Sanpham sp
	inner join Loaisanpham lsp on sp.LoaisanphamID=lsp.LoaisanphamID
	inner join Nhacungcap ncc on sp.NhacungcapID=ncc.NhacungcapID
	inner join Luutru lt on sp.SanphamID=lt.SanphamID
	where sp.Tensanpham like N'%'+@Content+'%' or
		lsp.Tenloaisanpham like N'%'+@Content+'%' or
		ncc.Tennhacungcap like N'%'+@Content+'%'
	group by sp.SanphamID,sp.Tensanpham,sp.Giaban,sp.Donvitinh,ncc.Tennhacungcap,lsp.Tenloaisanpham,ncc.NhacungcapID,lsp.LoaisanphamID
GO
/****** Object:  StoredProcedure [dbo].[SANPHAM_PROCVIEWALL]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SANPHAM_PROCVIEWALL]
AS
	SELECT sp.SanphamID,sp.Tensanpham,sp.Donvitinh,sp.Giaban,sp.NhacungcapID,sp.LoaisanphamID,ncc.Tennhacungcap,lsp.Tenloaisanpham,SUM(lt.Soluong) as Soluong FROM Sanpham sp
	inner join Loaisanpham lsp on lsp.LoaisanphamID = sp.LoaisanphamID
	inner join Luutru lt on lt.SanphamID = sp.SanphamID
	inner join Nhacungcap ncc on ncc.NhacungcapID = sp.NhacungcapID
	group by sp.SanphamID,sp.Tensanpham,sp.Donvitinh,sp.Giaban,sp.NhacungcapID,sp.LoaisanphamID,ncc.Tennhacungcap,lsp.Tenloaisanpham
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_ProcSearch]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_ProcSearch] 
@ContentSearch nvarchar(100),
@Loaisanpham nvarchar(50),
@Nhacungcap nvarchar(50),
@IsNumeric bit
as
BEGIN
	IF(@IsNumeric =0)
	begin
		select sp.*,lsp.Tenloaisanpham,ncc.Tennhacungcap,lt.Soluong from Sanpham sp
		inner join Loaisanpham lsp on lsp.LoaisanphamID = sp.LoaisanphamID
		inner join Nhacungcap ncc on ncc.NhacungcapID = sp.NhacungcapID
		inner join Luutru lt on lt.SanphamID = sp.SanphamID
		where sp.Tensanpham like N'%'+@ContentSearch+'%' 
			and lsp.Tenloaisanpham like N'%'+@Loaisanpham+'%'
			and ncc.Tennhacungcap like N'%'+@Nhacungcap+'%'
	end
	else
	begin
		select sp.*,lsp.Tenloaisanpham,ncc.Tennhacungcap,lt.Soluong from Sanpham sp
			inner join Loaisanpham lsp on lsp.LoaisanphamID = sp.LoaisanphamID
			inner join Nhacungcap ncc on ncc.NhacungcapID = sp.NhacungcapID
			inner join Luutru lt on lt.SanphamID = sp.SanphamID
			where sp.SanphamID =CAST(@ContentSearch as Int)
				and lsp.Tenloaisanpham like N'%'+@Loaisanpham+'%'
				and ncc.Tennhacungcap like N'%'+@Nhacungcap+'%'	
	end
END
--Sanpham_ProcSearch '1','','',1
--select * from Sanpham
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_Insert]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_Insert]
@Tensanpham nvarchar(50),
@Donvitinh nvarchar(10),
@Giaban real,
@NhacungcapID int,
@LoaisanphamID int,
@Soluong int
as
	Insert into Sanpham values(@Tensanpham,@Donvitinh,@Giaban,@NhacungcapID,@LoaisanphamID)

	insert into Luutru values(1,(select top 1 SanphamID from Sanpham order by SanphamID Desc),@Soluong)
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_GetAllData]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sanpham_GetAllData]
as
select sp.SanphamID,sp.Tensanpham,sp.Giaban,sp.Donvitinh,ncc.Tennhacungcap,lt.Soluong,lsp.Tenloaisanpham,ncc.NhacungcapID,lsp.LoaisanphamID from Sanpham sp
	inner join Loaisanpham lsp on sp.LoaisanphamID=lsp.LoaisanphamID
	inner join Nhacungcap ncc on sp.NhacungcapID=ncc.NhacungcapID
	inner join Luutru lt on sp.SanphamID=lt.SanphamID and lt.KhoID=1
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_ViewTopbyMonth]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_ViewTopbyMonth]
@Month int,
@Year int
as
select sp.Tensanpham,Sum(ct.Soluong) as Tong from CTHoadonbanhang ct
		inner join Hoadonbanhang hd on ct.HoadonbanhangID=hd.HoadonbanhangID and Month(hd.Ngayviet)=@Month and year(hd.Ngayviet)=@Year
		inner join Sanpham sp on sp.SanphamID=ct.SanphamID
		group by sp.Tensanpham
		order by Tong DEsc
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_ViewTop]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_ViewTop]
as
select ct.SanphamID,sp.Tensanpham,Sum(ct.Soluong) as Tong from CTHoadonbanhang ct
	inner join Sanpham sp on ct.SanphamID=sp.SanphamID
	group by ct.SanphamID,sp.Tensanpham
	order by Tong Desc
GO
/****** Object:  StoredProcedure [dbo].[Sanpham_ViewDetaibyYear]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sanpham_ViewDetaibyYear] --Sanpham_ViewDetaibyYear 1
@SanphamID int
as
declare @tb table (Tensanpham nvarchar(100),Tong int,Thang int)
declare @Tensanpham nvarchar(100) set @Tensanpham=(select Tensanpham from Sanpham where SanphamID=@SanphamID)
insert @tb
select sub.Tensanpham,Sum(sub.Tong) as Tong,sub.Thang from
(select sp.Tensanpham,ct.Soluong as Tong,Month(hd.Ngayviet) as Thang from CTHoadonbanhang ct
		inner join Hoadonbanhang hd on ct.HoadonbanhangID=hd.HoadonbanhangID and Month(hd.Ngayviet)>0 and year(hd.Ngayviet)=YEAR(GetDate())
		inner join Sanpham sp on sp.SanphamID=ct.SanphamID and sp.SanphamID=@SanphamID) as sub
		group by sub.Thang,sub.Tensanpham
		order by sub.Thang
declare @i int set @i=1

while @i<MONTH(GETDATE())+1
begin
	if not exists(select * from @tb where Thang=@i)
	begin
		insert into @tb values(@Tensanpham,0,@i)
	end
	set @i=@i+1
end
select Thang,Tong from @tb where Thang<MONTH(GETDATE())+1 order by Thang
GO
/****** Object:  StoredProcedure [dbo].[CTHoadonbanhang_ProcInsert]    Script Date: 12/03/2015 09:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CTHoadonbanhang_ProcInsert]
@HoadonbanhangID int,
@SanphamID int,
@Soluong int,
@Dongia real

as
	Insert into CTHoadonbanhang(HoadonbanhangID,SanphamID,Soluong,Dongia) values(@HoadonbanhangID,@SanphamID,@Soluong,@Dongia)
GO
/****** Object:  ForeignKey [FK_Nhanvien_Bophan]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[Nhanvien]  WITH CHECK ADD  CONSTRAINT [FK_Nhanvien_Bophan] FOREIGN KEY([BophanID])
REFERENCES [dbo].[Bophan] ([BophanID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Nhanvien] CHECK CONSTRAINT [FK_Nhanvien_Bophan]
GO
/****** Object:  ForeignKey [FK_Sanpham_Loaisanpham]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_Sanpham_Loaisanpham] FOREIGN KEY([LoaisanphamID])
REFERENCES [dbo].[Loaisanpham] ([LoaisanphamID])
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK_Sanpham_Loaisanpham]
GO
/****** Object:  ForeignKey [FK_Hoadonbanhang_Khachhang]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[Hoadonbanhang]  WITH CHECK ADD  CONSTRAINT [FK_Hoadonbanhang_Khachhang] FOREIGN KEY([KhachhangID])
REFERENCES [dbo].[Khachhang] ([KhachhangID])
GO
ALTER TABLE [dbo].[Hoadonbanhang] CHECK CONSTRAINT [FK_Hoadonbanhang_Khachhang]
GO
/****** Object:  ForeignKey [FK_Hoadonbanhang_Nhanvien]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[Hoadonbanhang]  WITH CHECK ADD  CONSTRAINT [FK_Hoadonbanhang_Nhanvien] FOREIGN KEY([NhanvienID])
REFERENCES [dbo].[Nhanvien] ([NhanvienID])
GO
ALTER TABLE [dbo].[Hoadonbanhang] CHECK CONSTRAINT [FK_Hoadonbanhang_Nhanvien]
GO
/****** Object:  ForeignKey [FK_Hoadonnhaphang_Nhacungcap]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[Hoadonnhaphang]  WITH CHECK ADD  CONSTRAINT [FK_Hoadonnhaphang_Nhacungcap] FOREIGN KEY([NhacungcapID])
REFERENCES [dbo].[Nhacungcap] ([NhacungcapID])
GO
ALTER TABLE [dbo].[Hoadonnhaphang] CHECK CONSTRAINT [FK_Hoadonnhaphang_Nhacungcap]
GO
/****** Object:  ForeignKey [FK_Hoadonnhaphang_Nhanvien]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[Hoadonnhaphang]  WITH CHECK ADD  CONSTRAINT [FK_Hoadonnhaphang_Nhanvien] FOREIGN KEY([NhanvienID])
REFERENCES [dbo].[Nhanvien] ([NhanvienID])
GO
ALTER TABLE [dbo].[Hoadonnhaphang] CHECK CONSTRAINT [FK_Hoadonnhaphang_Nhanvien]
GO
/****** Object:  ForeignKey [FK_Luutru_Kho]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[Luutru]  WITH CHECK ADD  CONSTRAINT [FK_Luutru_Kho] FOREIGN KEY([KhoID])
REFERENCES [dbo].[Kho] ([KhoID])
GO
ALTER TABLE [dbo].[Luutru] CHECK CONSTRAINT [FK_Luutru_Kho]
GO
/****** Object:  ForeignKey [FK_Luutru_Sanpham]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[Luutru]  WITH CHECK ADD  CONSTRAINT [FK_Luutru_Sanpham] FOREIGN KEY([SanphamID])
REFERENCES [dbo].[Sanpham] ([SanphamID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Luutru] CHECK CONSTRAINT [FK_Luutru_Sanpham]
GO
/****** Object:  ForeignKey [FK_CTHoadonbanhang_Hoadonbanhang]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[CTHoadonbanhang]  WITH CHECK ADD  CONSTRAINT [FK_CTHoadonbanhang_Hoadonbanhang] FOREIGN KEY([HoadonbanhangID])
REFERENCES [dbo].[Hoadonbanhang] ([HoadonbanhangID])
GO
ALTER TABLE [dbo].[CTHoadonbanhang] CHECK CONSTRAINT [FK_CTHoadonbanhang_Hoadonbanhang]
GO
/****** Object:  ForeignKey [FK_CTHoadonbanhang_Sanpham]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[CTHoadonbanhang]  WITH CHECK ADD  CONSTRAINT [FK_CTHoadonbanhang_Sanpham] FOREIGN KEY([SanphamID])
REFERENCES [dbo].[Sanpham] ([SanphamID])
GO
ALTER TABLE [dbo].[CTHoadonbanhang] CHECK CONSTRAINT [FK_CTHoadonbanhang_Sanpham]
GO
/****** Object:  ForeignKey [FK_CTHoadonnhaphang_Hoadonnhaphang]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[CTHoadonnhaphang]  WITH CHECK ADD  CONSTRAINT [FK_CTHoadonnhaphang_Hoadonnhaphang] FOREIGN KEY([HoadonnhaphangID])
REFERENCES [dbo].[Hoadonnhaphang] ([HoadonnhaphangID])
GO
ALTER TABLE [dbo].[CTHoadonnhaphang] CHECK CONSTRAINT [FK_CTHoadonnhaphang_Hoadonnhaphang]
GO
/****** Object:  ForeignKey [FK_CTHoadonnhaphang_Sanpham]    Script Date: 12/03/2015 09:35:02 ******/
ALTER TABLE [dbo].[CTHoadonnhaphang]  WITH CHECK ADD  CONSTRAINT [FK_CTHoadonnhaphang_Sanpham] FOREIGN KEY([SanphamID])
REFERENCES [dbo].[Sanpham] ([SanphamID])
GO
ALTER TABLE [dbo].[CTHoadonnhaphang] CHECK CONSTRAINT [FK_CTHoadonnhaphang_Sanpham]
GO
