USE [master]
GO
/****** Object:  Database [LAMLAI]    Script Date: 12/02/2015 09:27:52 ******/
CREATE DATABASE [LAMLAI] ON  PRIMARY 
( NAME = N'LAMLAI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\LAMLAI.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LAMLAI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\LAMLAI_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LAMLAI] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LAMLAI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LAMLAI] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [LAMLAI] SET ANSI_NULLS OFF
GO
ALTER DATABASE [LAMLAI] SET ANSI_PADDING OFF
GO
ALTER DATABASE [LAMLAI] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [LAMLAI] SET ARITHABORT OFF
GO
ALTER DATABASE [LAMLAI] SET AUTO_CLOSE ON
GO
ALTER DATABASE [LAMLAI] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [LAMLAI] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [LAMLAI] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [LAMLAI] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [LAMLAI] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [LAMLAI] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [LAMLAI] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [LAMLAI] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [LAMLAI] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [LAMLAI] SET  ENABLE_BROKER
GO
ALTER DATABASE [LAMLAI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [LAMLAI] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [LAMLAI] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [LAMLAI] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [LAMLAI] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [LAMLAI] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [LAMLAI] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [LAMLAI] SET  READ_WRITE
GO
ALTER DATABASE [LAMLAI] SET RECOVERY SIMPLE
GO
ALTER DATABASE [LAMLAI] SET  MULTI_USER
GO
ALTER DATABASE [LAMLAI] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [LAMLAI] SET DB_CHAINING OFF
GO
USE [LAMLAI]
GO
/****** Object:  Table [dbo].[tblQuyenSach]    Script Date: 12/02/2015 09:27:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblQuyenSach](
	[MaSach] [varchar](10) NOT NULL,
	[MaDauSach] [varchar](10) NOT NULL,
	[TinhTrang] [nvarchar](10) NULL,
	[TrangThai] [nvarchar](10) NULL,
 CONSTRAINT [PK_QS] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS001', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS002', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS003', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS004', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS005', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS006', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS007', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS008', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS009', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS010', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS011', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS012', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS013', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS014', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS015', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS016', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS017', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS018', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS019', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'DS17QS053', N'DS17', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS001', N'DS01', N'Mới', N'Không')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS002', N'DS01', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS003', N'DS01', N'Cũ', N'Không')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS004', N'DS01', N'Mới', N'Không')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS005', N'DS02', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS006', N'DS02', N'Cũ', N'Không')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS007', N'DS03', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS008', N'DS03', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS009', N'DS03', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS010', N'DS04', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS011', N'DS01', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS012', N'DS01', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS013', N'DS11', N'Cũ', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS014', N'DS11', N'Cũ', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS015', N'DS11', N'Cũ', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS016', N'DS01', N'Cũ', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS017', N'DS01', N'Cũ', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS018', N'DS01', N'Cũ', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS019', N'DS11', N'Mới', N'Không')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS020', N'DS11', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS021', N'DS11', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS022', N'DS11', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS023', N'DS11', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS024', N'DS11', N'Mới', N'Không')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS025', N'DS11', N'Mới', N'Không')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS026', N'DS11', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS027', N'DS14', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS028', N'DS14', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS029', N'DS14', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS030', N'DS15', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS031', N'DS15', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS032', N'DS15', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS033', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS034', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS035', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS036', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS037', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS038', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS039', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS040', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS041', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS042', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS043', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS044', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS045', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS046', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS047', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS048', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS049', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS050', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS051', N'DS16', N'Mới', N'Có')
INSERT [dbo].[tblQuyenSach] ([MaSach], [MaDauSach], [TinhTrang], [TrangThai]) VALUES (N'QS052', N'DS16', N'Mới', N'Có')
/****** Object:  StoredProcedure [dbo].[sp_InserQuyenSach_QL]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_InserQuyenSach_QL]
@MaDauSach varchar(10), @TinhTrang nvarchar(10), @TrangThai nvarchar(10)
as begin
    declare @masach varchar(10)--khai báo mas cần tự động tag
	declare @sott int-- cá
	declare contro CURSOR FORWARD_ONLY FOR SELECT MaSach FROM tblQuyenSach
	SET @sott=0

	OPEN contro
	fetch next from contro into @masach 
	while (@@FETCH_STATUS = 0)
	begin
			if ((CAST(RIGHT(@masach,3)as int)-@sott) = 1)
			begin
			set @sott = CAST(RIGHT(@masach,3)as int)
			end
			else break
			fetch next from contro into @masach 	
	end	
	declare @cdai int
	declare @i int
	set @masach=CAST((@sott+1)as varchar(3))
	set @cdai=LEN(@masach)
	set @i=1
	while (@i<=3-@cdai)
	begin
		set @masach='0'+@masach
		set @i=@i+1
	end
	set @masach = @MaDauSach+'QS'+@masach
	INSERT INTO tblQuyenSach VALUES(@masach,@MaDauSach,@TinhTrang,@TrangThai)
	SELECT @masach
	CLOSE contro
	deallocate contro
end
GO
/****** Object:  Table [dbo].[tblDauSach]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDauSach](
	[MaDauSach] [varchar](10) NOT NULL,
	[TenDauSach] [nvarchar](50) NOT NULL,
	[MaTg] [varchar](10) NULL,
	[MaTl] [varchar](10) NULL,
	[MaNXB] [varchar](10) NULL,
	[NamXb] [date] NULL,
	[Gia] [bigint] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_DS] PRIMARY KEY CLUSTERED 
(
	[MaDauSach] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS01', N'Ngôn ngữ Lập trình 1', N'TG01', N'TL01', N'NXB02', CAST(0x4F280B00 AS Date), 20000, 9)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS02', N'Ngôn ngữ Lập trình 2', N'TG02', N'TL01', N'NXB02', CAST(0xBC290B00 AS Date), 25000, 2)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS03', N'Kĩ thuật vi xử lí và lập trình Asembli', N'TG04', N'TL02', N'NXB03', CAST(0x2A2B0B00 AS Date), 31000, 3)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS04', N'Cấu trúc máy tính', N'TG03', N'TL02', N'NXB01', CAST(0xBC290B00 AS Date), 22000, 1)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS05', N'Phương Pháp nghiên cứu Khoa Học', N'TG05', N'TL04', N'NXB01', CAST(0xDF300B00 AS Date), 35000, NULL)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS06', N'Lập trình hướng đối tượng', N'TG02', N'TL01', N'NXB04', CAST(0x972C0B00 AS Date), 37000, NULL)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS07', N'Tư tưởng Hồ Chí Minh', N'TG09', N'TL06', N'NXB02', CAST(0x2A2B0B00 AS Date), 32000, NULL)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS08', N'Tư Tưởng Hồ Chí Minh', N'TG08', N'TL06', N'NXB05', CAST(0x042E0B00 AS Date), 49000, NULL)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS09', N'Dân tộc học và tôn giáo học', N'TG06', N'TL06', N'NXB02', CAST(0x75250B00 AS Date), 19000, NULL)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS10', N'Sách Toán lớp 1', N'TG05', N'TL09', N'NXB04', CAST(0x4C320B00 AS Date), 24000, NULL)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS11', N'Toán rời rạc', N'TG03', N'TL03', N'NXB01', CAST(0xE1390B00 AS Date), 12300, 11)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS12', N'huế', N'TG01', N'TL03', N'NXB01', CAST(0xE3390B00 AS Date), 350000, 0)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS13', N'hoa', N'TG01', N'TL02', N'NXB01', CAST(0x44240B00 AS Date), 120000, 3)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS14', N'hoathanque', N'TG01', N'TL02', N'NXB01', CAST(0x44240B00 AS Date), 120000, 3)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS15', N'cô giáo', N'TG01', N'TL02', N'NXB01', CAST(0x44240B00 AS Date), 120000, 3)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS16', N'huong', N'TG02', N'TL01', N'NXB01', CAST(0x44240B00 AS Date), 12000, 20)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS17', N'thik', N'TG02', N'TL01', N'NXB01', CAST(0x44240B00 AS Date), 12000, 20)
INSERT [dbo].[tblDauSach] ([MaDauSach], [TenDauSach], [MaTg], [MaTl], [MaNXB], [NamXb], [Gia], [SoLuong]) VALUES (N'DS18', N'a', N'TG05', N'TL02', N'NXB05', CAST(0xCC3A0B00 AS Date), 123, 0)
/****** Object:  StoredProcedure [dbo].[sp_UpdateDauSach_QL]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateDauSach_QL](@madausach varchar(10),@tendausach nvarchar(50), @matg varchar(10),@matl varchar(10),
@manxb varchar(10),@namxb date, @gia bigint, @soluong int)
as begin
update tblDauSach set TenDauSach =@tendausach,MaTg = @matg,MaTL = @matl ,
MaNXb = @manxb ,namXb = @namxb ,Gia= @gia ,SoLuong =  @soluong
where MaDauSach =@madausach
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTDauSach]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TTDauSach]
as begin
select *from tblDauSach
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTCom_MaDauSach]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TTCom_MaDauSach]
as begin
select MaDauSach, TenDauSach
from tblDauSach
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_TenDauSach]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TK_TenDauSach](@TenDauSach nvarchar(50))
as begin
select * 
from tblDauSach
where TenDauSach like N'%'+@TenDauSach+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertDauSach_QL]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_InsertDauSach_QL]
@tendausach nvarchar(50), @matg varchar(10),@matl varchar(10),@manxb varchar(10),
@namxb date, @gia bigint, @soluong int
as begin
    declare @madausach varchar(10)--khai báo mas cần tự động tag
	declare @sott int-- cá
	declare contro1 CURSOR FORWARD_ONLY FOR SELECT MaDauSach FROM tblDauSach--lỗi ở đây.đặt tên contro khacsnhau đi
	SET @sott=0

	OPEN contro1
	fetch next from contro1 into @madausach 
	while (@@FETCH_STATUS = 0)
	begin
			if ((CAST(RIGHT(@madausach,2)as int)-@sott) = 1)
			begin
			set @sott = CAST(RIGHT(@madausach,2)as int)
			end
			else break
			fetch next from contro1 into @madausach 	
	end	
	declare @cdai int
	declare @i int
	set @madausach=CAST((@sott+1)as varchar(3))
	set @cdai=LEN(@madausach)
	set @i=1
	while (@i<=2-@cdai)
	begin
		set @madausach='0'+@madausach
		set @i=@i+1
	end
	set @madausach = 'DS'+@madausach
	INSERT INTO tblDauSach VALUES(@madausach ,@tendausach,@matg,@matl,@manxb,@namxb,@gia,@soluong)
	SELECT @madausach
	CLOSE contro1
	deallocate contro1
end
GO
/****** Object:  Table [dbo].[tblMuon]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMuon](
	[MaDG] [varchar](10) NOT NULL,
	[MaSach] [varchar](10) NOT NULL,
	[NgayMuon] [date] NOT NULL,
	[NgayHenTra] [date] NOT NULL,
 CONSTRAINT [PK_MaPhieu] PRIMARY KEY CLUSTERED 
(
	[MaDG] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblMuon] ([MaDG], [MaSach], [NgayMuon], [NgayHenTra]) VALUES (N'DG0001', N'QS001', CAST(0xE3390B00 AS Date), CAST(0xE3390B00 AS Date))
INSERT [dbo].[tblMuon] ([MaDG], [MaSach], [NgayMuon], [NgayHenTra]) VALUES (N'DG0001', N'QS003', CAST(0xE1390B00 AS Date), CAST(0xE5390B00 AS Date))
INSERT [dbo].[tblMuon] ([MaDG], [MaSach], [NgayMuon], [NgayHenTra]) VALUES (N'DG0001', N'QS006', CAST(0xFB390B00 AS Date), CAST(0x573A0B00 AS Date))
INSERT [dbo].[tblMuon] ([MaDG], [MaSach], [NgayMuon], [NgayHenTra]) VALUES (N'DG0001', N'QS019', CAST(0xE1390B00 AS Date), CAST(0xE4390B00 AS Date))
INSERT [dbo].[tblMuon] ([MaDG], [MaSach], [NgayMuon], [NgayHenTra]) VALUES (N'DG0002', N'QS024', CAST(0xFB390B00 AS Date), CAST(0x573A0B00 AS Date))
INSERT [dbo].[tblMuon] ([MaDG], [MaSach], [NgayMuon], [NgayHenTra]) VALUES (N'DG0002', N'QS025', CAST(0xFB390B00 AS Date), CAST(0x1A3A0B00 AS Date))
INSERT [dbo].[tblMuon] ([MaDG], [MaSach], [NgayMuon], [NgayHenTra]) VALUES (N'DG0003', N'QS004', CAST(0xE2390B00 AS Date), CAST(0xE5390B00 AS Date))
/****** Object:  StoredProcedure [dbo].[sp_UpdateMonTra]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_UpdateMonTra]
 @MaDG varchar(10),@MaSach varchar(10), @NgayMuon date, @NgayHenTra date

as begin 
update tblMuon set NgayMuon= @NgayMuon,NgayHenTra=@NgayHenTra
where MaSach=@masach and MaDG = @MaDG
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTMUON]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TTMUON]
as begin
select *from tblMuon
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_MuonST]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TK_MuonST](@MaDG nvarchar(50))
as begin
select * 
from tblMuon
where MaDG like N'%'+@MaDG+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_Muon]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TK_Muon](@MaSach nvarchar(50))
as begin
select * 
from tblMuon
where MaSach like N'%'+@MaSach+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_MaDG_Muon]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TK_MaDG_Muon](@MaDG  varchar(10))
as begin
select * 
from tblMuon
where MaDG like N'%'+@MaDG+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ShowMuon_time]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ShowMuon_time] @date1 datetime, @date2 datetime
as begin
	select *from tblMuon
	where CONVERT(date, NgayMuon) between CONVERT(date,@date1 ) and CONVERT(date, @date2)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertSachMuon]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_InsertSachMuon] 
@MaDG varchar(10),@MaSach varchar(10), @NgayMuon date, @NgayHenTra date
as begin
declare @count int
set @NgayMuon = GETDATE();
	set @NgayHenTra =  DATEADD(month,3,GETDATE());
	if((select COUNT( MaSach) 	from tblMuon where MaSach = @MaSach)<>0)
			print 'đã có mã sách '
	else 
			INSERT INTO tblMuon VALUES(@MaDG,@MaSach,@NgayMuon,@NgayHenTra)	
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletMuon_QL]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DeletMuon_QL](@MaSach varchar(10))
as begin
	delete from tblMuon where MaSach =@MaSach 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateQuyenSach_QL]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateQuyenSach_QL] (@MaSach varchar(10), @MaDauSach varchar(10),
@TinhTrang nvarchar(10),@TrangThai nvarchar(10))
as begin 
update tblQuyenSach set MaDauSach=@MaDauSach,TinhTrang=@TinhTrang, 
TrangThai=@TrangThai
where MaSach=@masach
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTQuyenSach]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TTQuyenSach]
as begin
select *from tblQuyenSach
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_QuyenSach]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TK_QuyenSach](@MaSach nvarchar(50))
as begin
select * 
from tblQuyenSach
where MaSach like N'%'+@MaSach+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteQuyenSach_QL]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DeleteQuyenSach_QL](@MaSach varchar(10))
as begin	
if((select COUNT(MaSach) from tblMuon)=0)

	delete from tblQuyenSach where MaSach = @MaSach

	-- and	MaSach not in (select MaSach from tblMuon)
	--delete from tblMuonTra where MaSach = @MaSach
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteDauSach_QL]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DeleteDauSach_QL](@madausach  varchar(10))
as begin
delete tblQuyenSach where MaDauSach =@madausach
delete tblDauSach where MaDauSach=@madausach
end
GO
/****** Object:  StoredProcedure [dbo].[combo_MaSach]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[combo_MaSach]
as begin
select MaSach from tblQuyenSach where TrangThai = 'Có'
end
GO
/****** Object:  Table [dbo].[tblTheLoai]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTheLoai](
	[MaTL] [varchar](10) NOT NULL,
	[TenTl] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TL] PRIMARY KEY CLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblTheLoai] ([MaTL], [TenTl]) VALUES (N'TL01', N'Truyện Tranh')
INSERT [dbo].[tblTheLoai] ([MaTL], [TenTl]) VALUES (N'TL02', N'Truyện Trinh Thám')
INSERT [dbo].[tblTheLoai] ([MaTL], [TenTl]) VALUES (N'TL03', N'Truyện Kiếm Hiệp')
INSERT [dbo].[tblTheLoai] ([MaTL], [TenTl]) VALUES (N'TL04', N'Tiểu Thuyết')
INSERT [dbo].[tblTheLoai] ([MaTL], [TenTl]) VALUES (N'TL05', N'Khoa Học Đời Sống')
INSERT [dbo].[tblTheLoai] ([MaTL], [TenTl]) VALUES (N'TL06', N'Khoa Học Viễn Tưởng')
INSERT [dbo].[tblTheLoai] ([MaTL], [TenTl]) VALUES (N'TL07', N'Sách Lịch Sử')
INSERT [dbo].[tblTheLoai] ([MaTL], [TenTl]) VALUES (N'TL08', N'Thể Thao Trong Nước')
INSERT [dbo].[tblTheLoai] ([MaTL], [TenTl]) VALUES (N'TL09', N'Thể Thao Nước Ngoài')
INSERT [dbo].[tblTheLoai] ([MaTL], [TenTl]) VALUES (N'TL10', N'Tin Thời Sự')
/****** Object:  Table [dbo].[tblTacGia]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTacGia](
	[MaTg] [varchar](10) NOT NULL,
	[TenTg] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](3) NULL,
 CONSTRAINT [PK_TG] PRIMARY KEY CLUSTERED 
(
	[MaTg] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblTacGia] ([MaTg], [TenTg], [DiaChi], [GioiTinh]) VALUES (N'TG01', N'Nam Cao', N'Hà Nam', N'Nam')
INSERT [dbo].[tblTacGia] ([MaTg], [TenTg], [DiaChi], [GioiTinh]) VALUES (N'TG02', N'Ngô Tất Tố', N'Hà Nội', N'Nam')
INSERT [dbo].[tblTacGia] ([MaTg], [TenTg], [DiaChi], [GioiTinh]) VALUES (N'TG03', N'Kim Lân', N'Bắc Ninh', N'Nam')
INSERT [dbo].[tblTacGia] ([MaTg], [TenTg], [DiaChi], [GioiTinh]) VALUES (N'TG04', N'Nguyễn Quang Sáng', N'An Giang', N'Nam')
INSERT [dbo].[tblTacGia] ([MaTg], [TenTg], [DiaChi], [GioiTinh]) VALUES (N'TG05', N'Nguyên Hồng', N'Nam Định', N'Nam')
INSERT [dbo].[tblTacGia] ([MaTg], [TenTg], [DiaChi], [GioiTinh]) VALUES (N'TG06', N'Vũ Trọng Phụng', N'Hưng Yên', N'Nam')
INSERT [dbo].[tblTacGia] ([MaTg], [TenTg], [DiaChi], [GioiTinh]) VALUES (N'TG07', N'Trần Đăng Khoa', N'Hải Dương', N'Nam')
INSERT [dbo].[tblTacGia] ([MaTg], [TenTg], [DiaChi], [GioiTinh]) VALUES (N'TG08', N'Nguyễn Khoa Điềm', N'Thừa Thiên - Huế', N'Nam')
INSERT [dbo].[tblTacGia] ([MaTg], [TenTg], [DiaChi], [GioiTinh]) VALUES (N'TG09', N'Xuân Diệu', N'Bình Định', N'Nam')
INSERT [dbo].[tblTacGia] ([MaTg], [TenTg], [DiaChi], [GioiTinh]) VALUES (N'TG10', N'Nguyễn Duy', N'Thanh Hóa', N'Nam')
/****** Object:  Table [dbo].[tblNhaXb]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNhaXb](
	[MaNXB] [varchar](10) NOT NULL,
	[TenNXB] [nvarchar](50) NOT NULL,
	[DienThoai] [varchar](15) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Email] [varchar](30) NULL,
 CONSTRAINT [PK_NXB] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblNhaXb] ([MaNXB], [TenNXB], [DienThoai], [DiaChi], [Email]) VALUES (N'NXB01', N'Nhà xuất bản Kim Đồng', N'0436422627', N'10-Cầu Giấy-Hà Nội', N'nguyenhue22694@gmail.com')
INSERT [dbo].[tblNhaXb] ([MaNXB], [TenNXB], [DienThoai], [DiaChi], [Email]) VALUES (N'NXB02', N'Nhà xuất bản Giáo Dục', N'043772334', N'20-Đào Trọng Tấn-Hà Nội', N'nguyenhue22694@gmail.com')
INSERT [dbo].[tblNhaXb] ([MaNXB], [TenNXB], [DienThoai], [DiaChi], [Email]) VALUES (N'NXB03', N'Nhà xuất bản Quân Đội', N'0434528754', N'15-Xuân Diệu-Ba Đình-Hà Nội', N'nguyenhue22694@gmail.com')
INSERT [dbo].[tblNhaXb] ([MaNXB], [TenNXB], [DienThoai], [DiaChi], [Email]) VALUES (N'NXB04', N'Nhà xuất bản Sự Thật', N'0430374837', N'24-Nguyễn Tri Phương-Cầu Giấy-Hà Nội', N'nguyenhue22694@gmail.com')
INSERT [dbo].[tblNhaXb] ([MaNXB], [TenNXB], [DienThoai], [DiaChi], [Email]) VALUES (N'NXB05', N'Nhà xuất bản Khoa Học', N'0436422627', N'50-Cầu Diễn-Từ Liêm-Hà Nội', N'nguyenhue22694@gmail.com')
INSERT [dbo].[tblNhaXb] ([MaNXB], [TenNXB], [DienThoai], [DiaChi], [Email]) VALUES (N'NXB06', N'Nhà xuất bản ĐH Quốc Gia', N'046758395', N'23-Xuân Thuỷ-Cầu Giấy-Hà Nội', N'nguyenhue22694@gmail.com')
INSERT [dbo].[tblNhaXb] ([MaNXB], [TenNXB], [DienThoai], [DiaChi], [Email]) VALUES (N'NXB07', N'Nhà xuất bản ĐH Luật', N'0431237465', N'108-Nguyễn Chí Thanh-Ba Đình-Hà Nội', N'nguyenhue22694@gmail.com')
INSERT [dbo].[tblNhaXb] ([MaNXB], [TenNXB], [DienThoai], [DiaChi], [Email]) VALUES (N'NXB08', N'Nhà xuất bản Chính Trị Quốc Gia', N'043078998', N'47-Hoàng Quốc Việt-Cầu Giấy-Hà Nội', N'nguyenhue22694@gmail.com')
INSERT [dbo].[tblNhaXb] ([MaNXB], [TenNXB], [DienThoai], [DiaChi], [Email]) VALUES (N'NXB09', N'Nhà xuất bản Hồng Đức', N'0373640444', N'35-Đào Duy Từ-tp.Thanh Hoá-Thanh Hoá', N'nguyenhue22694@gmail.com')
INSERT [dbo].[tblNhaXb] ([MaNXB], [TenNXB], [DienThoai], [DiaChi], [Email]) VALUES (N'NXB10', N'Nhà xuất bản Công An Nhân Dân', N'0433847562', N'Xã Cổ Nhuế-Từ Liêm-Hà Nội', N'nguyenhue22694@gmail.com')
/****** Object:  StoredProcedure [dbo].[sp_TTSach_DG]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TTSach_DG]
as
begin
SELECT     tblDauSach.TenDauSach, tblQuyenSach.MaSach, tblTacGia.TenTg, tblTheLoai.TenTl, tblNhaXb.TenNXB, tblQuyenSach.TrangThai
FROM         tblQuyenSach INNER JOIN
                      tblDauSach ON tblQuyenSach.MaDauSach = tblDauSach.MaDauSach INNER JOIN
                      tblTacGia ON tblDauSach.MaTg = tblTacGia.MaTg INNER JOIN
                      tblTheLoai ON tblDauSach.MaTl = tblTheLoai.MaTL INNER JOIN
                      tblNhaXb ON tblDauSach.MaNXB = tblNhaXb.MaNXB
WHERE     (tblQuyenSach.TrangThai = N'Có')
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_TheLoai]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TK_TheLoai](@theloai nvarchar(50))
as begin
SELECT *
from (SELECT     tblDauSach.TenDauSach, tblQuyenSach.MaSach, tblTacGia.TenTg, tblTheLoai.TenTl, tblNhaXb.TenNXB, tblQuyenSach.TrangThai
FROM         tblQuyenSach INNER JOIN
                      tblDauSach ON tblQuyenSach.MaDauSach = tblDauSach.MaDauSach INNER JOIN
                      tblTacGia ON tblDauSach.MaTg = tblTacGia.MaTg INNER JOIN
                      tblTheLoai ON tblDauSach.MaTl = tblTheLoai.MaTL INNER JOIN
                      tblNhaXb ON tblDauSach.MaNXB = tblNhaXb.MaNXB
WHERE     (tblQuyenSach.TrangThai = N'Có')) as B
where B.TenTl like N'%'+@theloai+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_TenTg]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TK_TenTg](@tentg nvarchar(50))
as begin
SELECT *
from (SELECT     tblDauSach.TenDauSach, tblQuyenSach.MaSach, tblTacGia.TenTg, tblTheLoai.TenTl, tblNhaXb.TenNXB, tblQuyenSach.TrangThai
FROM         tblQuyenSach INNER JOIN
                      tblDauSach ON tblQuyenSach.MaDauSach = tblDauSach.MaDauSach INNER JOIN
                      tblTacGia ON tblDauSach.MaTg = tblTacGia.MaTg INNER JOIN
                      tblTheLoai ON tblDauSach.MaTl = tblTheLoai.MaTL INNER JOIN
                      tblNhaXb ON tblDauSach.MaNXB = tblNhaXb.MaNXB
WHERE     (tblQuyenSach.TrangThai = N'Có')) as B
where B.TenTg like N'%'+@tentg+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_DauSach]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TK_DauSach](@TenDauSach nvarchar(50))
as begin
SELECT *
from (SELECT     tblDauSach.TenDauSach, tblQuyenSach.MaSach, tblTacGia.TenTg, tblTheLoai.TenTl, tblNhaXb.TenNXB, tblQuyenSach.TrangThai
FROM         tblQuyenSach INNER JOIN
                      tblDauSach ON tblQuyenSach.MaDauSach = tblDauSach.MaDauSach INNER JOIN
                      tblTacGia ON tblDauSach.MaTg = tblTacGia.MaTg INNER JOIN
                      tblTheLoai ON tblDauSach.MaTl = tblTheLoai.MaTL INNER JOIN
                      tblNhaXb ON tblDauSach.MaNXB = tblNhaXb.MaNXB
WHERE     (tblQuyenSach.TrangThai = N'Có')) as B
where B.TenDauSach like N'%'+@TenDauSach+'%'
end
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 12/02/2015 09:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[ID] [varchar](10) NOT NULL,
	[PASS] [varchar](50) NOT NULL,
	[HOTEN] [nvarchar](50) NULL,
	[QUYEN] [int] NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'admin', N'admin', N'hue', 1)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0001', N'123456', N'Đinh Xuân Trường', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0002', N'123456', N'Đinh Xuân Trường', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0003', N'123456', N'Nguyễn Ngọc hòa', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0004', N'123456', N'Lê Tiến Dũng', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0005', N'123456', N'Đoàn Tiến Đạt', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0006', N'123456', N'Vũ Việt Đoàn', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0007', N'123456', N'Nguyễn Hoàng Hiếu', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0008', N'123456', N'Phạm Văn Lượng', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0009', N'123456', N'Đoàn Quang Long', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0010', N'123456', N'Lê Viết Hoàng Anh', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0011', N'123456', N'Phạm Quý Danh', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0012', N'123456', N'Lê Thành Trung', 0)
INSERT [dbo].[TaiKhoan] ([ID], [PASS], [HOTEN], [QUYEN]) VALUES (N'DG0013', N'123456', N'Đinh Xuân Trường', 0)
/****** Object:  StoredProcedure [dbo].[sp_UpdateTheLoai_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateTheLoai_QL](@MaTL varchar(10), @TenTl nvarchar(50))
as begin
update tblTheLoai set TenTl =@TenTl 
where  MaTL= @MaTL 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTacGia_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateTacGia_QL](@MaTg varchar(10), @TenTg nvarchar(50), @DiaChi nvarchar(50),@GioiTinh nvarchar(3))

as begin
update tblTacGia set TenTg =@TenTg ,DiaChi= @DiaChi ,GioiTinh =@GioiTinh
where  MaTg= @MaTg 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateNXB_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateNXB_QL](@MaNXB varchar(10), @TenNXB nvarchar(50), @DienThoai varchar(15),@DiaChi nvarchar(50),@Email varchar(30)
)
as begin
update tblNhaXb set TenNXB= @TenNXB ,DienThoai =@DienThoai ,DiaChi =@DiaChi ,Email =@Email
where MaNXB =@MaNXB
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTTheLoai]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TTTheLoai]
as begin
select *from tblTheLoai
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTTacGia]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TTTacGia]
as begin
select *from tblTacGia
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTNXB]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TTNXB]
as begin
select *from tblNhaXb
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTMaTG]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TTMaTG]
as begin
select MaTg, TenTg from tblTacGia
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTCom_TLoai]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TTCom_TLoai]
as begin
select TenTl, MaTL
from tblTheLoai
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTCom_NXB]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TTCom_NXB]
as begin
select MaNXB, TenNXB
from tblNhaXb
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_TenNXB]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TK_TenNXB](@TenNXB nvarchar(50))
as begin
select * 
from tblNhaXb
where TenNXB like N'%'+@TenNXB+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_TenTL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  proc [dbo].[sp_TK_TenTL](@TenTl nvarchar(50))
as begin
select *from tblTheLoai
where TenTl like N'%'+@TenTl+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_TenTg_TACGIA]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TK_TenTg_TACGIA](@TenTg nvarchar(50))
as begin
select * 
from tblTacGia
where TenTg like N'%'+@TenTg+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_Email]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TK_Email](@Email nvarchar(30))
as begin
select * 
from tblNhaXb
where Email like N'%'+@Email+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_DiaChiNXB]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TK_DiaChiNXB](@DiaChi nvarchar(50))
as begin
select * 
from tblNhaXb
where DiaChi like N'%'+@DiaChi+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTL_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeleteTL_QL](@MaTL  varchar(10))
as begin
delete tblTheLoai where MaTL= @MaTL 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTG_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeleteTG_QL](@MaTg  varchar(10))
as begin
delete tblTacGia where MaTg= @MaTg 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteNXB_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeleteNXB_QL](@MaNXB  varchar(10))
as begin
delete tblNhaXb where MaNXB =@MaNXB
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertNXB_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_InsertNXB_QL]
@TenNXB nvarchar(50), @DienThoai varchar(15),@DiaChi nvarchar(50),@Email varchar(30)
as begin
    declare @MaNXB  varchar(10)--khai báo mas cần tự động tag
	declare @sott int-- cá
	declare contro CURSOR FORWARD_ONLY FOR SELECT MaNXB FROM tblNhaXb
	SET @sott=0

	OPEN contro
	fetch next from contro into @MaNXB 
	while (@@FETCH_STATUS = 0)
	begin
			if ((CAST(RIGHT(@MaNXB,2)as int)-@sott) = 1)
			begin
			set @sott = CAST(RIGHT(@MaNXB,2)as int)
			end
			else break
			fetch next from contro into @MaNXB 	
	end	
	declare @cdai int
	declare @i int
	set @MaNXB=CAST((@sott+1)as varchar(3))
	set @cdai=LEN(@MaNXB)
	set @i=1
	while (@i<=2-@cdai)
	begin
		set @MaNXB='0'+@MaNXB
		set @i=@i+1
	end
	set @MaNXB = 'NXB'+@MaNXB
	INSERT INTO tblNhaXb VALUES(@MaNXB ,@TenNXB, @DienThoai ,@DiaChi ,@Email )
	SELECT @MaNXB
	CLOSE contro
	deallocate contro
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InserTheLoai_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[sp_InserTheLoai_QL]
@TenTl nvarchar(50)
as begin
    declare @MaTL  varchar(10)--khai báo mas cần tự động tag
	declare @sott int-- cá
	declare contro CURSOR FORWARD_ONLY FOR SELECT MaTL FROM tblTheLoai
	SET @sott=0

	OPEN contro
	fetch next from contro into @MaTL 
	while (@@FETCH_STATUS = 0)
	begin
			if ((CAST(RIGHT(@MaTL,2)as int)-@sott) = 1)
			begin
			set @sott = CAST(RIGHT(@MaTL,2)as int)
			end
			else break
			fetch next from contro into @MaTL 	
	end	
	declare @cdai int
	declare @i int
	set @MaTL=CAST((@sott+1)as varchar(3))
	set @cdai=LEN(@MaTL)
	set @i=1
	while (@i<=2-@cdai)
	begin
		set @MaTL='0'+@MaTL
		set @i=@i+1
	end
	set @MaTL = 'TL'+@MaTL
	INSERT INTO tblTheLoai VALUES(@MaTL ,@TenTl)
	SELECT @MaTL
	CLOSE contro
	deallocate contro
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InserTacGia_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_InserTacGia_QL]
@TenTg nvarchar(50), @DiaChi nvarchar(50),@GioiTinh nvarchar(3)
as begin
    declare @MaTg  varchar(10)--khai báo mas cần tự động tag
	declare @sott int-- cá
	declare contro CURSOR FORWARD_ONLY FOR SELECT MaTg FROM tblTacGia
	SET @sott=0

	OPEN contro
	fetch next from contro into @MaTg 
	while (@@FETCH_STATUS = 0)
	begin
			if ((CAST(RIGHT(@MaTg,2)as int)-@sott) = 1)
			begin
			set @sott = CAST(RIGHT(@MaTg,2)as int)
			end
			else break
			fetch next from contro into @MaTg 	
	end	
	declare @cdai int
	declare @i int
	set @MaTg=CAST((@sott+1)as varchar(3))
	set @cdai=LEN(@MaTg)
	set @i=1
	while (@i<=2-@cdai)
	begin
		set @MaTg='0'+@MaTg
		set @i=@i+1
	end
	set @MaTg = 'TG'+@MaTg
	INSERT INTO tblTacGia VALUES(@MaTg ,@TenTg,@DiaChi ,@GioiTinh )
	SELECT @MaTg
	CLOSE contro
	deallocate contro
end
GO
/****** Object:  Table [dbo].[tblDocGia]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDocGia](
	[MaDG] [varchar](10) NOT NULL,
	[TenDG] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NULL,
	[Lop] [nvarchar](50) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[Sdt] [varchar](15) NULL,
	[GioiTinh] [nvarchar](3) NULL,
 CONSTRAINT [PK_TTV] PRIMARY KEY CLUSTERED 
(
	[MaDG] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0001', N'Đinh Xuân Trường', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nữ')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0002', N'Đinh Xuân Trường', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nữ')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0003', N'Nguyễn Ngọc hòa', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nam')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0004', N'Lê Tiến Dũng', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nữ')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0005', N'Đoàn Tiến Đạt', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nam')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0006', N'Vũ Việt Đoàn', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nam')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0007', N'Nguyễn Hoàng Hiếu', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nữ')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0008', N'Phạm Văn Lượng', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nam')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0009', N'Đoàn Quang Long', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nữ')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0010', N'Lê Viết Hoàng Anh', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nữ')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0011', N'Phạm Quý Danh', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nam')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0012', N'Lê Thành Trung', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nữ')
INSERT [dbo].[tblDocGia] ([MaDG], [TenDG], [NgaySinh], [Lop], [ChucVu], [Sdt], [GioiTinh]) VALUES (N'DG0013', N'Đinh Xuân Trường', CAST(0x161C0B00 AS Date), N'Tin Hoc1', N'Học Viên', N'012333556', N'Nữ')
/****** Object:  StoredProcedure [dbo].[sp_DeleteDocGia_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DeleteDocGia_QL](@MaDG varchar(10))
as begin
	delete from tblDocGia where MaDG =@MaDG and
	MaDG not in (select MaDG from tblMuon)
end
GO
/****** Object:  Table [dbo].[tblTra]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTra](
	[MADG] [varchar](10) NOT NULL,
	[MaSach] [varchar](10) NOT NULL,
	[NgayMuon] [date] NOT NULL,
	[NgayHenTra] [date] NOT NULL,
	[NgayTra] [date] NOT NULL,
	[TienPhat] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblTra] ([MADG], [MaSach], [NgayMuon], [NgayHenTra], [NgayTra], [TienPhat]) VALUES (N'DG0002', N'QS002', CAST(0xE2390B00 AS Date), CAST(0xE5390B00 AS Date), CAST(0xFB390B00 AS Date), 66000)
INSERT [dbo].[tblTra] ([MADG], [MaSach], [NgayMuon], [NgayHenTra], [NgayTra], [TienPhat]) VALUES (N'DG0003', N'QS022', CAST(0xE1390B00 AS Date), CAST(0xE5390B00 AS Date), CAST(0xFB390B00 AS Date), 66000)
INSERT [dbo].[tblTra] ([MADG], [MaSach], [NgayMuon], [NgayHenTra], [NgayTra], [TienPhat]) VALUES (N'DG0002', N'QS002', CAST(0xE2390B00 AS Date), CAST(0xE5390B00 AS Date), CAST(0xFB390B00 AS Date), 66000)
INSERT [dbo].[tblTra] ([MADG], [MaSach], [NgayMuon], [NgayHenTra], [NgayTra], [TienPhat]) VALUES (N'DG0003', N'QS022', CAST(0xE1390B00 AS Date), CAST(0xE5390B00 AS Date), CAST(0xFB390B00 AS Date), 66000)
INSERT [dbo].[tblTra] ([MADG], [MaSach], [NgayMuon], [NgayHenTra], [NgayTra], [TienPhat]) VALUES (N'DG0003', N'QS021', CAST(0xE1390B00 AS Date), CAST(0xE5390B00 AS Date), CAST(0xFB390B00 AS Date), 66000)
INSERT [dbo].[tblTra] ([MADG], [MaSach], [NgayMuon], [NgayHenTra], [NgayTra], [TienPhat]) VALUES (N'DG0003', N'QS021', CAST(0xE1390B00 AS Date), CAST(0xE5390B00 AS Date), CAST(0xFB390B00 AS Date), 66000)
/****** Object:  StoredProcedure [dbo].[sp_InserDocGia_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_InserDocGia_QL]
@TenDG nvarchar(50), @NgaySinh date, @Lop nvarchar(50),@ChucVu nvarchar(50),
@Sdt varchar(15),@GioiTinh nvarchar(3)
as begin
    declare @MaDG varchar(10)--khai báo mas cần tự động tag
	declare @sott int-- cá
	declare contro CURSOR FORWARD_ONLY FOR SELECT MaDG FROM tblDocGia
	SET @sott=0

	OPEN contro
	fetch next from contro into @MaDG
	while (@@FETCH_STATUS = 0)
	begin
			if ((CAST(RIGHT(@MaDG,4)as int)-@sott) = 1)
			begin
			set @sott = CAST(RIGHT(@MaDG,4)as int)
			end
			else break
			fetch next from contro into @MaDG 	
	end	
	declare @cdai int
	declare @i int
	set @MaDG=CAST((@sott+1)as varchar(3))
	set @cdai=LEN(@MaDG)
	set @i=1
	while (@i<=4-@cdai)
	begin
		set @MaDG='0'+@MaDG
		set @i=@i+1
	end
	set @MaDG = 'DG'+@MaDG
	INSERT INTO tblDocGia VALUES(@MaDG,@TenDG,@NgaySinh,@Lop,@ChucVu,@Sdt,@GioiTinh)
	SELECT @MaDG
	CLOSE contro
	deallocate contro
end
GO
/****** Object:  StoredProcedure [dbo].[combo_MaDG]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[combo_MaDG]
as begin
select MaDG from tblDocGia
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_MaDG]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TK_MaDG](@MaDG  varchar(10))
as begin
select * 
from tblDocGia
where MaDG like N'%'+@MaDG+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[spTK_TenDG]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spTK_TenDG](@TenDG nvarchar(50))
as begin
select * 
from tblDocGia
where TenDG like N'%'+@TenDG+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[spTK_MaDocGia]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spTK_MaDocGia](@MaDG nvarchar(50))
as begin
select * 
from tblDocGia
where MaDG like N'%'+@MaDG+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTDocGia_TheoMa]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TTDocGia_TheoMa](@madg varchar(10))
as
begin
select TenDG,NgaySinh,Lop,ChucVu,Sdt,GioiTinh
from tblDocGia where MaDG  = @madg
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTDocGia]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TTDocGia]
as begin
select *from tblDocGia
end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDocGia_QL]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateDocGia_QL] (@MaDG varchar(10),@TenDG nvarchar(50), @NgaySinh date,
 @Lop nvarchar(50),@ChucVu nvarchar(50),
@Sdt varchar(15),@GioiTinh nvarchar(3))
as begin 
update tblDocGia set TenDG=@TenDG,NgaySinh=@NgaySinh,Lop=@Lop,ChucVu=@ChucVu,Sdt=@Sdt,
GioiTinh=@GioiTinh
where MaDG =@MaDG
end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDocGia]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_UpdateDocGia](
 @madg varchar (10),@tendg nvarchar(50),@ngaysinh date,
 @lop nvarchar(50), @chucvu nvarchar(50),@sdt varchar(15), @gioitinh nvarchar(3))
as begin 
update tblDocGia set TenDG=@tendg, NgaySinh = @ngaysinh,Lop=@lop,
ChucVu=@chucvu,Sdt=@sdt,GioiTinh=@gioitinh
where MaDG=@madg
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TTTra]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TTTra]
as begin
select *from tblTra
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_MaSach]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TK_MaSach](@MaSach  varchar(10))
as begin
select * 
from tblTra
where MaSach like N'%'+@MaSach+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TK_MaDG_tra]    Script Date: 12/02/2015 09:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TK_MaDG_tra](@MaDG  varchar(10))
as begin
select * 
from tblTra
where MaDG like N'%'+@MaDG+'%'
end
GO
/****** Object:  Check [CK__tblQuyenS__TinhT__2D27B809]    Script Date: 12/02/2015 09:27:52 ******/
ALTER TABLE [dbo].[tblQuyenSach]  WITH CHECK ADD CHECK  (([TinhTrang]=N'Cũ' OR [TinhTrang]=N'Mới'))
GO
/****** Object:  Check [CK__tblQuyenS__TinhT__76619304]    Script Date: 12/02/2015 09:27:52 ******/
ALTER TABLE [dbo].[tblQuyenSach]  WITH CHECK ADD CHECK  (([TinhTrang]=N'Cũ' OR [TinhTrang]=N'Mới'))
GO
/****** Object:  Check [CK__tblQuyenS__Trang__2E1BDC42]    Script Date: 12/02/2015 09:27:52 ******/
ALTER TABLE [dbo].[tblQuyenSach]  WITH CHECK ADD CHECK  (([TrangThai]=N'Không' OR [TrangThai]=N'Có'))
GO
/****** Object:  Check [CK__tblQuyenS__Trang__7755B73D]    Script Date: 12/02/2015 09:27:52 ******/
ALTER TABLE [dbo].[tblQuyenSach]  WITH CHECK ADD CHECK  (([TrangThai]=N'Không' OR [TrangThai]=N'Có'))
GO
/****** Object:  Check [CK__tblTacGia__GioiT__25869641]    Script Date: 12/02/2015 09:28:09 ******/
ALTER TABLE [dbo].[tblTacGia]  WITH CHECK ADD CHECK  (([GioiTinh]=N'nữ' OR [GioiTinh]=N'nam'))
GO
/****** Object:  Check [CK__tblTacGia__GioiT__7849DB76]    Script Date: 12/02/2015 09:28:09 ******/
ALTER TABLE [dbo].[tblTacGia]  WITH CHECK ADD CHECK  (([GioiTinh]=N'nữ' OR [GioiTinh]=N'nam'))
GO
/****** Object:  Check [CK__tblDocGia__GioiT__29572725]    Script Date: 12/02/2015 09:28:10 ******/
ALTER TABLE [dbo].[tblDocGia]  WITH CHECK ADD CHECK  (([GioiTinh]=N'nữ' OR [GioiTinh]=N'nam'))
GO
/****** Object:  Check [CK__tblDocGia__GioiT__793DFFAF]    Script Date: 12/02/2015 09:28:10 ******/
ALTER TABLE [dbo].[tblDocGia]  WITH CHECK ADD CHECK  (([GioiTinh]=N'nữ' OR [GioiTinh]=N'nam'))
GO
/****** Object:  ForeignKey [FK_QS_DS]    Script Date: 12/02/2015 09:27:52 ******/
ALTER TABLE [dbo].[tblQuyenSach]  WITH CHECK ADD  CONSTRAINT [FK_QS_DS] FOREIGN KEY([MaDauSach])
REFERENCES [dbo].[tblDauSach] ([MaDauSach])
GO
ALTER TABLE [dbo].[tblQuyenSach] CHECK CONSTRAINT [FK_QS_DS]
GO
/****** Object:  ForeignKey [FK_DS_NXB]    Script Date: 12/02/2015 09:28:09 ******/
ALTER TABLE [dbo].[tblDauSach]  WITH CHECK ADD  CONSTRAINT [FK_DS_NXB] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[tblNhaXb] ([MaNXB])
GO
ALTER TABLE [dbo].[tblDauSach] CHECK CONSTRAINT [FK_DS_NXB]
GO
/****** Object:  ForeignKey [FK_DS_TG]    Script Date: 12/02/2015 09:28:09 ******/
ALTER TABLE [dbo].[tblDauSach]  WITH CHECK ADD  CONSTRAINT [FK_DS_TG] FOREIGN KEY([MaTg])
REFERENCES [dbo].[tblTacGia] ([MaTg])
GO
ALTER TABLE [dbo].[tblDauSach] CHECK CONSTRAINT [FK_DS_TG]
GO
/****** Object:  ForeignKey [FK_DS_TL]    Script Date: 12/02/2015 09:28:09 ******/
ALTER TABLE [dbo].[tblDauSach]  WITH CHECK ADD  CONSTRAINT [FK_DS_TL] FOREIGN KEY([MaTl])
REFERENCES [dbo].[tblTheLoai] ([MaTL])
GO
ALTER TABLE [dbo].[tblDauSach] CHECK CONSTRAINT [FK_DS_TL]
GO
/****** Object:  ForeignKey [FK_PM_TTV]    Script Date: 12/02/2015 09:28:09 ******/
ALTER TABLE [dbo].[tblMuon]  WITH CHECK ADD  CONSTRAINT [FK_PM_TTV] FOREIGN KEY([MaDG])
REFERENCES [dbo].[tblDocGia] ([MaDG])
GO
ALTER TABLE [dbo].[tblMuon] CHECK CONSTRAINT [FK_PM_TTV]
GO
/****** Object:  ForeignKey [FK_QS_MS]    Script Date: 12/02/2015 09:28:09 ******/
ALTER TABLE [dbo].[tblMuon]  WITH CHECK ADD  CONSTRAINT [FK_QS_MS] FOREIGN KEY([MaSach])
REFERENCES [dbo].[tblQuyenSach] ([MaSach])
GO
ALTER TABLE [dbo].[tblMuon] CHECK CONSTRAINT [FK_QS_MS]
GO
/****** Object:  ForeignKey [FK_tblTra_tblDocGia]    Script Date: 12/02/2015 09:28:10 ******/
ALTER TABLE [dbo].[tblTra]  WITH CHECK ADD  CONSTRAINT [FK_tblTra_tblDocGia] FOREIGN KEY([MADG])
REFERENCES [dbo].[tblDocGia] ([MaDG])
GO
ALTER TABLE [dbo].[tblTra] CHECK CONSTRAINT [FK_tblTra_tblDocGia]
GO
