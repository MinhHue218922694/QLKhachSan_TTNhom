create database databasekhachsan
go
USE [databasekhachsan]
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user](
	[TenDangNhap] [nvarchar](30) NOT NULL,
	[MatKhau] [nvarchar](20) NULL,
	[QuyenHan] [nvarchar](20) NULL,
	[HoVaTen] [nvarchar](30) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
	[socmnd] [nchar](10) NULL,
	[SDT] [nvarchar](10) NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_user] ([TenDangNhap], [MatKhau], [QuyenHan], [HoVaTen], [DiaChi], [Email], [socmnd], [SDT]) VALUES (N'admin', N'lampard', N'admin', N'nguyễn văn thắng', N'vĩnh phúc', N'nguyenthang5758@gmail.com', NULL, NULL)
INSERT [dbo].[tbl_user] ([TenDangNhap], [MatKhau], [QuyenHan], [HoVaTen], [DiaChi], [Email], [socmnd], [SDT]) VALUES (N'nguyenthang5758', N'lampard', N'admin', N'Nguyễn Văn Thắng', N'Vĩnh Phúc', N'nguyenthang2120@gmail.com', NULL, NULL)
/****** Object:  Table [dbo].[tbl_phong]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_phong](
	[id] [int] NOT NULL,
	[maphong] [nvarchar](50) NULL,
	[tenphong] [nvarchar](50) NULL,
	[gia] [nvarchar](50) NULL,
	[Urlimage] [nvarchar](50) NULL,
	[tinhtrangphong] [nvarchar](50) NULL,
	[soluongphong] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_phong] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_phong] ([id], [maphong], [tenphong], [gia], [Urlimage], [tinhtrangphong], [soluongphong]) VALUES (1, N'P01', N'Phòng Cao Cấp', N'1.365.633 VND/24h', N'images\Room\5.jpg', N'Full', N'0')
INSERT [dbo].[tbl_phong] ([id], [maphong], [tenphong], [gia], [Urlimage], [tinhtrangphong], [soluongphong]) VALUES (2, N'P02', N'Phòng Sang Trọng 2 Giường', N'1.653.135 VND/24h', N'images\Room\10.jpg', N'Full', N'26')
INSERT [dbo].[tbl_phong] ([id], [maphong], [tenphong], [gia], [Urlimage], [tinhtrangphong], [soluongphong]) VALUES (3, N'P03', N'Phòng Tuần Trăng Mật', N'2.097.887 VND/24h', N'images\Room\15.jpg', N'Empty', N'30')
INSERT [dbo].[tbl_phong] ([id], [maphong], [tenphong], [gia], [Urlimage], [tinhtrangphong], [soluongphong]) VALUES (4, N'P04', N'Phòng Gia Đình', N'1.733.037 VND/24h', N'images\Room\20.jpg', N'Empty', N'30')
/****** Object:  Table [dbo].[tbl_nhahang3]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_nhahang3](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mamon] [nvarchar](50) NULL,
	[tenmon] [nvarchar](50) NULL,
	[gia] [nvarchar](50) NULL,
	[ghichu] [nvarchar](50) NULL,
	[anh] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_nhahang3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_nhahang3] ON
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (1, N'3', N'Bánh Mochi', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\Banh-Mochi-tm.jpg')
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (2, N'3', N'Bánh Táo', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\banh tao-tm.JPG')
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (3, N'3', N'Bubur', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\bubur-tm.jpg')
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (4, N'3', N'Caakiri', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\Caakiri.jpg')
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (5, N'3', N'Chè Đậu Xanh', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\chedauxanh.jpg')
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (6, N'3', N'Chè Mứt Kẹo', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\che-mut-keo-tm.jpg')
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (7, N'3', N'Faloodeh', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\Faloodeh.jpg')
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (8, N'3', N'Kẹo Bơ', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\keo-bo-tm.jpg')
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (9, N'3', N'Kolak', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\Kolak-tm.jpg')
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (10, N'3', N'Po''e', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\Po''e-tm.jpg')
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (11, N'3', N'Quimdim', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\Quindim-tm.jpg')
INSERT [dbo].[tbl_nhahang3] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (12, N'3', N'Rau Câu ', N'100.000(VND)', NULL, N'images\nhahang\trangmieng\rau-cau-tm.jpg')
SET IDENTITY_INSERT [dbo].[tbl_nhahang3] OFF
/****** Object:  Table [dbo].[tbl_nhahang2]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_nhahang2](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mamon] [nvarchar](50) NULL,
	[tenmon] [nvarchar](50) NULL,
	[gia] [nvarchar](50) NULL,
	[ghichu] [nvarchar](50) NULL,
	[anh] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_nhahang2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_nhahang2] ON
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (1, N'2', N'Cá Kho Riềng', N'300.000(VND)', NULL, N'images\nhahang\monchinh\Ca kho rieng.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (2, N'2', N'Chả Cá', N'300.000(VND)', NULL, N'images\nhahang\monchinh\cha ca.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (3, N'2', N'Gà Luộc', N'300.000(VND)', NULL, N'images\nhahang\monchinh\ga-nuoc.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (4, N'2', N'Mì Ý', N'300.000(VND)', NULL, N'images\nhahang\monchinh\mi-y.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (5, N'2', N'Mực Rán', N'300.000(VND)', NULL, N'images\nhahang\monchinh\muc-ran.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (6, N'2', N'Nấm Đông Cô', N'300.000(VND)', NULL, N'images\nhahang\monchinh\nam-dong-co.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (7, N'2', N'Ốc Giác', N'300.000(VND)', NULL, N'images\nhahang\monchinh\oc-giac.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (8, N'2', N'Phở', N'50.000(VND)', NULL, N'images\nhahang\monchinh\pho.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (9, N'2', N'Riêu Cá Chép', N'300.000(VND)', NULL, N'images\nhahang\monchinh\rieu-ca-chep.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (10, N'2', N'Tôm Chiên', N'300.000(VND)', NULL, N'images\nhahang\monchinh\tom-chien.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (11, N'2', N'Thịt Cuốn', N'300.000(VND)', NULL, N'images\nhahang\monchinh\thit-cuon.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (12, N'2', N'Thịt Chiên', N'300.000(VND)', NULL, N'images\nhahang\monchinh\thit-lon-chien.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (13, N'2', N'Thịt Đà Điểu', N'300.000(VND)', NULL, N'images\nhahang\monchinh\thit-da-dieu.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (14, N'2', N'Thịt Lợn', N'300.000(VND)', NULL, N'images\nhahang\monchinh\thit.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (15, N'2', N'Vịt Xiêm', N'300.000(VND)', NULL, N'images\nhahang\monchinh\viet-xiem.jpg')
INSERT [dbo].[tbl_nhahang2] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (16, N'2', N'Xào Thập Cẩm', N'300.000(VND)', NULL, N'images\nhahang\monchinh\xao-thap-cam.jpg')
SET IDENTITY_INSERT [dbo].[tbl_nhahang2] OFF
/****** Object:  Table [dbo].[tbl_nhahang]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_nhahang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mamon] [nvarchar](50) NULL,
	[tenmon] [nvarchar](50) NULL,
	[gia] [nvarchar](50) NULL,
	[ghichu] [nvarchar](50) NULL,
	[anh] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_nhahang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_nhahang] ON
INSERT [dbo].[tbl_nhahang] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (2, N'1', N'Bò Cuốn', N'150.000(VND)', NULL, N'images\nhahang\khaivi\bo-cuon-kv.jpg')
INSERT [dbo].[tbl_nhahang] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (3, N'1', N'Bò trộn tía tô', N'150.000(VND)', NULL, N'images\nhahang\khaivi\botron-kv.jpg')
INSERT [dbo].[tbl_nhahang] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (4, N'1', N'Gỏi', N'150.000(VND)', NULL, N'images\nhahang\khaivi\goi-kv.jpg')
INSERT [dbo].[tbl_nhahang] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (5, N'1', N'Hến Xào', N'150.000(VND)', NULL, N'images\nhahang\khaivi\henxao-kv.jpg')
INSERT [dbo].[tbl_nhahang] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (6, N'1', N'Salad', N'150.000(VND)', NULL, N'images\nhahang\khaivi\salad-kv.jpg')
INSERT [dbo].[tbl_nhahang] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (7, N'1', N'Salad hoàng đế', N'150.000(VND)', NULL, N'images\nhahang\khaivi\Saladhoangde.jpg')
INSERT [dbo].[tbl_nhahang] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (8, N'1', N'Tôm trộn', N'150.000(VND)', NULL, N'images\nhahang\khaivi\tom-tron.jpg')
INSERT [dbo].[tbl_nhahang] ([id], [mamon], [tenmon], [gia], [ghichu], [anh]) VALUES (9, N'1', N'Bánh Huế', N'150.000(VND)', NULL, N'images\nhahang\khaivi\banh-hue.jpg')
SET IDENTITY_INSERT [dbo].[tbl_nhahang] OFF
/****** Object:  Table [dbo].[tbl_chitietroom]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_chitietroom](
	[id] [nchar](10) NOT NULL,
	[maphong] [nvarchar](50) NULL,
	[tenphong] [nvarchar](50) NULL,
	[gia] [nvarchar](50) NULL,
	[Urlimage] [nvarchar](50) NULL,
	[ghichu] [nvarchar](50) NULL,
	[anh1] [nvarchar](50) NULL,
	[anh2] [nvarchar](50) NULL,
	[anh3] [nvarchar](50) NULL,
	[anh4] [nvarchar](50) NULL,
	[anh5] [nvarchar](50) NULL,
	[kichthuoc] [nvarchar](50) NULL,
	[dichvu] [nvarchar](max) NULL,
	[dichvu1] [nvarchar](50) NULL,
	[dichvu2] [nvarchar](50) NULL,
	[dichvu3] [nvarchar](50) NULL,
	[dichvu4] [nvarchar](50) NULL,
	[dichvu5] [nvarchar](50) NULL,
	[dichvu6] [nvarchar](50) NULL,
	[dichvu7] [nvarchar](50) NULL,
	[dichvu8] [nvarchar](50) NULL,
	[dichvu9] [nvarchar](50) NULL,
	[dichvu10] [nvarchar](50) NULL,
	[dichvu11] [nvarchar](50) NULL,
	[dichvu12] [nvarchar](50) NULL,
	[dichvu13] [nvarchar](50) NULL,
	[dichvu14] [nvarchar](50) NULL,
	[dichvu15] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_chitietroom] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_chitietroom] ([id], [maphong], [tenphong], [gia], [Urlimage], [ghichu], [anh1], [anh2], [anh3], [anh4], [anh5], [kichthuoc], [dichvu], [dichvu1], [dichvu2], [dichvu3], [dichvu4], [dichvu5], [dichvu6], [dichvu7], [dichvu8], [dichvu9], [dichvu10], [dichvu11], [dichvu12], [dichvu13], [dichvu14], [dichvu15]) VALUES (N'1         ', N'P01', N'Phòng Cao Cấp', N'1.365.633 VND/24h', N'images\Room\5.jpg', N'Bao gồm bữa ăn sáng ', N'images\Room\1.jpg', N'images\Room\2.jpg', N'images\Room\3.jpg', N'images\Room\4.jpg', N'images\Room\5.jpg', N'Size: 19 - 21 m2', N'có sóng wifi', N'két sắt', N'phòng không hút thuốc', N'máy lạnh', N'áo choàng tắm', N'máy sấy tóc', N'thiết bị là ủi', N'tivi LCD/Plasma', N'bồn tắm', N'vòi hoa sen', N'tắm bồn,tắm hoa sen riêng', N'tủ đồ ăn uống nhẹ', N'truyền hình cáp', N'máy pha trà/cà phê', N'nước đóng chai miễn phí', N'tủ lạnh')
INSERT [dbo].[tbl_chitietroom] ([id], [maphong], [tenphong], [gia], [Urlimage], [ghichu], [anh1], [anh2], [anh3], [anh4], [anh5], [kichthuoc], [dichvu], [dichvu1], [dichvu2], [dichvu3], [dichvu4], [dichvu5], [dichvu6], [dichvu7], [dichvu8], [dichvu9], [dichvu10], [dichvu11], [dichvu12], [dichvu13], [dichvu14], [dichvu15]) VALUES (N'2         ', N'P02', N'Phòng Sang Trọng 2 Giường', N'1.653.135 VND/24h', N'images\Room\10.jpg', N'Bao gồm bữa ăn sáng ', N'images\Room\6.jpg', N'images\Room\7.jpg', N'images\Room\8.jpg', N'images\Room\9.jpg', N'images\Room\10.jpg', N'Size: 22 - 29 m2', N'có sóng wifi', N'két sắt', N'phòng không hút thuốc', N'máy lạnh', N'áo choàng tắm', N'máy sấy tóc', N'thiết bị là ủi', N'tivi LCD/Plasma', N'bồn tắm', N'vòi hoa sen', N'tắm bồn,tắm hoa sen riêng', N'tủ đồ ăn uống nhẹ', N'truyền hình cáp', N'máy pha trà/cà phê', N'nước đóng chai miễn phí', N'tủ lạnh')
INSERT [dbo].[tbl_chitietroom] ([id], [maphong], [tenphong], [gia], [Urlimage], [ghichu], [anh1], [anh2], [anh3], [anh4], [anh5], [kichthuoc], [dichvu], [dichvu1], [dichvu2], [dichvu3], [dichvu4], [dichvu5], [dichvu6], [dichvu7], [dichvu8], [dichvu9], [dichvu10], [dichvu11], [dichvu12], [dichvu13], [dichvu14], [dichvu15]) VALUES (N'3         ', N'P03', N'Phòng Tuần Trăng Mật', N'2.097.887 VND/24h', N'images\Room\15.jpg', N'Bao gồm bữa ăn sáng ', N'images\Room\11.jpg', N'images\Room\12.jpg', N'images\Room\13.jpg', N'images\Room\14.jpg', N'images\Room\15.jpg', N'Size: 24 – 31 m2', N'có sóng wifi', N'két sắt', N'phòng không hút thuốc', N'máy lạnh', N'áo choàng tắm', N'máy sấy tóc', N'thiết bị là ủi', N'tivi LCD/Plasma', N'bồn tắm', N'vòi hoa sen', N'tắm bồn,tắm hoa sen riêng', N'tủ đồ ăn uống nhẹ', N'truyền hình cáp', N'máy pha trà/cà phê', N'nước đóng chai miễn phí', N'tủ lạnh')
INSERT [dbo].[tbl_chitietroom] ([id], [maphong], [tenphong], [gia], [Urlimage], [ghichu], [anh1], [anh2], [anh3], [anh4], [anh5], [kichthuoc], [dichvu], [dichvu1], [dichvu2], [dichvu3], [dichvu4], [dichvu5], [dichvu6], [dichvu7], [dichvu8], [dichvu9], [dichvu10], [dichvu11], [dichvu12], [dichvu13], [dichvu14], [dichvu15]) VALUES (N'4         ', N'P04', N'Phòng Gia Đình', N'1.733.037 VND/24h', N'images\Room\20.jpg', N'Bao gồm bữa ăn sáng', N'images\Room\16.jpg', N'images\Room\17.jpg', N'images\Room\18.jpg', N'images\Room\19.jpg', N'images\Room\20.jpg', N'Size: 40 m2', N'có sóng wifi', N'két sắt', N'phòng không hút thuốc', N'máy lạnh', N'áo choàng tắm', N'máy sấy tóc', N'thiết bị là ủi', N'tivi LCD/Plasma', N'bồn tắm', N'vòi hoa sen', N'tắm bồn,tắm hoa sen riêng', N'tủ đồ ăn uống nhẹ', N'truyền hình cáp', N'máy pha trà/cà phê', N'nước đóng chai miễn phí', N'tủ lạnh')
/****** Object:  Table [dbo].[tbl_chitietphong]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_chitietphong](
	[maphong] [nvarchar](50) NULL,
	[tenphong] [nvarchar](50) NULL,
	[gia] [nvarchar](50) NULL,
	[Urlimage] [nvarchar](50) NULL,
	[ghichu] [nvarchar](50) NULL,
	[anh1] [nvarchar](50) NULL,
	[anh2] [nvarchar](50) NULL,
	[anh3] [nvarchar](50) NULL,
	[anh4] [nvarchar](50) NULL,
	[anh5] [nvarchar](50) NULL,
	[kichthuoc] [nvarchar](50) NULL,
	[dichvu] [nvarchar](max) NULL,
	[id] [nchar](10) NULL,
	[dichvu1] [nvarchar](50) NULL,
	[dichvu2] [nvarchar](50) NULL,
	[dichvu3] [nvarchar](50) NULL,
	[dichvu4] [nvarchar](50) NULL,
	[dichvu5] [nvarchar](50) NULL,
	[dichvu6] [nvarchar](50) NULL,
	[dichvu7] [nvarchar](50) NULL,
	[dichvu8] [nvarchar](50) NULL,
	[dichvu9] [nvarchar](50) NULL,
	[dichvu10] [nvarchar](50) NULL,
	[dichvu11] [nvarchar](50) NULL,
	[dichvu12] [nvarchar](50) NULL,
	[dichvu13] [nvarchar](50) NULL,
	[dichvu14] [nvarchar](50) NULL,
	[dichvu15] [nvarchar](50) NULL,
	[dichvu16] [nvarchar](50) NULL,
	[dichvu17] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_chitietphong] ([maphong], [tenphong], [gia], [Urlimage], [ghichu], [anh1], [anh2], [anh3], [anh4], [anh5], [kichthuoc], [dichvu], [id], [dichvu1], [dichvu2], [dichvu3], [dichvu4], [dichvu5], [dichvu6], [dichvu7], [dichvu8], [dichvu9], [dichvu10], [dichvu11], [dichvu12], [dichvu13], [dichvu14], [dichvu15], [dichvu16], [dichvu17]) VALUES (N'P01', N'Phòng Cao Cấp', N'1.365.633 VND/24h', N'images\Room\5.jpg', N'Bao gồm bữa ăn sáng ', N'images\Room\1.jpg', N'images\Room\2.jpg', N'images\Room\3.jpg', N'images\Room\4.jpg', N'images\Room\5.jpg', N'Size: 19 - 21 m2', N'có sóng wifi', N'1         ', N'két sắt', N'phòng không hút thuốc', N'máy lạnh', N'áo choàng tắm', N'máy sấy tóc', N'thiết bị là ủi', N'tivi LCD/Plasma', N'bồn tắm', N'vòi hoa sen', N'tắm bồn,tắm hoa sen riêng', N'tủ đồ ăn uống nhẹ', N'truyền hình cáp', N'máy pha trà/cà phê', N'nước đóng chai miễn phí', N'tủ lạnh', NULL, N'Còn Phòng')
INSERT [dbo].[tbl_chitietphong] ([maphong], [tenphong], [gia], [Urlimage], [ghichu], [anh1], [anh2], [anh3], [anh4], [anh5], [kichthuoc], [dichvu], [id], [dichvu1], [dichvu2], [dichvu3], [dichvu4], [dichvu5], [dichvu6], [dichvu7], [dichvu8], [dichvu9], [dichvu10], [dichvu11], [dichvu12], [dichvu13], [dichvu14], [dichvu15], [dichvu16], [dichvu17]) VALUES (N'P02', N'Phòng Sang Trọng 2 Giường', N'1.653.135 VND/24h', N'images\Room\10.jpg', N'Bao gồm bữa ăn sáng', N'images\Room\6.jpg', N'images\Room\7.jpg', N'images\Room\8.jpg', N'images\Room\9.jpg', N'images\Room\10.jpg', N'Size: 22 - 29 m2', N'có sóng wifi', N'2         ', N'két sắt', N'phòng không hút thuốc', N'máy lạnh', N'áo choàng tắm', N'máy sấy tóc', N'thiết bị là ủi', N'tivi LCD/Plasma', N'bồn tắm', N'vòi hoa sen', N'tắm bồn,tắm hoa sen riêng', N'tủ đồ ăn uống nhẹ', N'truyền hình cáp', N'máy pha trà/cà phê', N'nước đóng chai miễn phí', N'tủ lạnh', NULL, N'Còn Phòng')
INSERT [dbo].[tbl_chitietphong] ([maphong], [tenphong], [gia], [Urlimage], [ghichu], [anh1], [anh2], [anh3], [anh4], [anh5], [kichthuoc], [dichvu], [id], [dichvu1], [dichvu2], [dichvu3], [dichvu4], [dichvu5], [dichvu6], [dichvu7], [dichvu8], [dichvu9], [dichvu10], [dichvu11], [dichvu12], [dichvu13], [dichvu14], [dichvu15], [dichvu16], [dichvu17]) VALUES (N'P03', N'Phòng Tuần Trăng Mật', N'2.097.887 VND/24h', N'images\Room\15.jpg', N'Bao gồm bữa ăn sáng', N'images\Room\11.jpg', N'images\Room\12.jpg', N'images\Room\13.jpg', N'images\Room\14.jpg', N'images\Room\15.jpg', N'Size: 24 – 31 m2', N'có sóng wifi', N'3         ', N'két sắt', N'phòng không hút thuốc', N'máy lạnh', N'áo choàng tắm', N'máy sấy tóc', N'thiết bị là ủi', N'tivi LCD/Plasma', N'bồn tắm', N'vòi hoa sen', N'tắm bồn,tắm hoa sen riêng', N'tủ đồ ăn uống nhẹ', N'truyền hình cáp', N'máy pha trà/cà phê', N'nước đóng chai miễn phí', N'tủ lạnh', NULL, N'Còn Phòng')
INSERT [dbo].[tbl_chitietphong] ([maphong], [tenphong], [gia], [Urlimage], [ghichu], [anh1], [anh2], [anh3], [anh4], [anh5], [kichthuoc], [dichvu], [id], [dichvu1], [dichvu2], [dichvu3], [dichvu4], [dichvu5], [dichvu6], [dichvu7], [dichvu8], [dichvu9], [dichvu10], [dichvu11], [dichvu12], [dichvu13], [dichvu14], [dichvu15], [dichvu16], [dichvu17]) VALUES (N'P04', N'Phòng Gia Đình', N'1.733.037 VND/24h', N'images\Room\20.jpg', N'Bao gồm bữa ăn sáng', N'images\Room\16.jpg', N'images\Room\17.jpg', N'images\Room\18.jpg', N'images\Room\19.jpg', N'images\Room\20.jpg', N'Size: 40 m2', N'có sóng wifi', N'4         ', N'két sắt', N'phòng không hút thuốc', N'máy lạnh', N'áo choàng tắm', N'máy sấy tóc', N'thiết bị là ủi', N'tivi LCD/Plasma', N'bồn tắm', N'vòi hoa sen', N'tắm bồn,tắm hoa sen riêng', N'tủ đồ ăn uống nhẹ', N'truyền hình cáp', N'máy pha trà/cà phê', N'nước đóng chai miễn phí', N'tủ lạnh', NULL, N'Còn Phòng')
/****** Object:  Table [dbo].[khachsan_Hanhlang]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachsan_Hanhlang](
	[id] [int] NOT NULL,
	[anh] [nvarchar](50) NULL,
	[ghichu] [nvarchar](50) NULL,
 CONSTRAINT [PK_khachsan_Hanhlang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[khachsan_Hanhlang] ([id], [anh], [ghichu]) VALUES (1, N'images\Khachsan\Hanhlang\24910HDsing2.jpg', NULL)
INSERT [dbo].[khachsan_Hanhlang] ([id], [anh], [ghichu]) VALUES (2, N'images\Khachsan\Hanhlang\3.jpg', NULL)
INSERT [dbo].[khachsan_Hanhlang] ([id], [anh], [ghichu]) VALUES (3, N'images\Khachsan\Hanhlang\4.jpg', NULL)
INSERT [dbo].[khachsan_Hanhlang] ([id], [anh], [ghichu]) VALUES (4, N'images\Khachsan\Hanhlang\UWVXE.jpg', NULL)
/****** Object:  Table [dbo].[khachsan_Dichvu]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachsan_Dichvu](
	[id] [int] NOT NULL,
	[anh] [nvarchar](50) NULL,
	[ghichu] [nvarchar](50) NULL,
 CONSTRAINT [PK_khachsan_Dichvu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[khachsan_Dichvu] ([id], [anh], [ghichu]) VALUES (1, N'images\Khachsan\Dichvu\beboi5.jpg', NULL)
INSERT [dbo].[khachsan_Dichvu] ([id], [anh], [ghichu]) VALUES (2, N'images\Khachsan\Dichvu\3.jpg', NULL)
INSERT [dbo].[khachsan_Dichvu] ([id], [anh], [ghichu]) VALUES (3, N'images\Khachsan\Dichvu\mas5.jpg', NULL)
INSERT [dbo].[khachsan_Dichvu] ([id], [anh], [ghichu]) VALUES (4, N'images\Khachsan\Dichvu\phonghoithao13.jpg', NULL)
/****** Object:  Table [dbo].[khachsan_Canhquan]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachsan_Canhquan](
	[id] [int] NOT NULL,
	[anh] [nvarchar](50) NULL,
	[ghichu] [nvarchar](50) NULL,
 CONSTRAINT [PK_khachsan_Canhquan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[khachsan_Canhquan] ([id], [anh], [ghichu]) VALUES (1, N'images\Khachsan\Canhquan\20081005231509.jpg', NULL)
INSERT [dbo].[khachsan_Canhquan] ([id], [anh], [ghichu]) VALUES (2, N'images\Khachsan\Canhquan\anh-6.jpg', NULL)
INSERT [dbo].[khachsan_Canhquan] ([id], [anh], [ghichu]) VALUES (3, N'images\Khachsan\Canhquan\2.jpg', NULL)
INSERT [dbo].[khachsan_Canhquan] ([id], [anh], [ghichu]) VALUES (4, N'images\Khachsan\Canhquan\093248.jpg', NULL)
/****** Object:  Table [dbo].[khachsan_Bar]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachsan_Bar](
	[id] [int] NOT NULL,
	[anh] [nvarchar](50) NULL,
	[ghichu] [nvarchar](50) NULL,
 CONSTRAINT [PK_khachsan_Bar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[khachsan_Bar] ([id], [anh], [ghichu]) VALUES (1, N'images\Khachsan\Bar\images.jpg', NULL)
INSERT [dbo].[khachsan_Bar] ([id], [anh], [ghichu]) VALUES (2, N'images\Khachsan\Bar\thiet-ke-quay-bar-dep1.jpg', NULL)
INSERT [dbo].[khachsan_Bar] ([id], [anh], [ghichu]) VALUES (3, N'images\Khachsan\Bar\thiet-ke-quay-bar-dep3.jpg', NULL)
INSERT [dbo].[khachsan_Bar] ([id], [anh], [ghichu]) VALUES (4, N'images\Khachsan\Bar\Thiet_ke_bar1.jpg', NULL)
/****** Object:  Table [dbo].[Info_DatPhong]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info_DatPhong](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenkhachhang] [nvarchar](50) NULL,
	[socm] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[sdt] [nvarchar](50) NULL,
	[nam] [int] NULL,
	[thang] [int] NULL,
	[ngayden] [int] NULL,
	[ngaydi] [int] NULL,
	[tenphong] [nvarchar](50) NULL,
	[soluongphong] [int] NULL,
	[id_phong] [int] NULL,
 CONSTRAINT [PK_Info_DatPhong] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Info_DatPhong] ON
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (47, N'Nguyễn Văn Thắng', N'135622818', N'nguyenthang5758@gmail.com', N'0978695758', 2013, 2, 12, 15, N'Phòng Gia Đình', 3, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (49, N'Nguyễn Văn Thắng', N'135622816', N'nguyenthang5758@gmail.com', N'0978695758', 2013, 2, 26, 28, N'Phòng Cao Cấp', 4, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (50, N'thang', N'135622816', N'nguyenthang5758@gmail.com', N'0978695758', 2013, 8, 12, 17, N'Phòng Cao Cấp', 1, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (51, N'Nguyễn Văn Thắng', N'135622816', N'nguyenthang5758@gmail.com', N'0978695758', 2013, 4, 20, 22, N'Phòng Cao Cấp', 2, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (52, N'Thắng123', N'135622817', N'nguyenthang1518@gmail.com', N'0978695758', 2013, 2, 13, 15, N'Phòng Tuần Trăng Mật', 2, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (53, N'Hà Mạnh', N'135622816', N'nguyenthang12@gmail.com', N'0978695758', 2013, 3, 13, 15, N'phòng2', 2, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (54, N'Thắng', N'135622816', N'nguyenthang5758@gmail.com', N'0978695758', 2013, 1, 10, 17, N'Phòng Cao Cấp', 1, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (55, N'Thắng', N'135622816', N'nguyenthang5758@gmail.com', N'0978695758', 2013, 2, 24, 27, N'Phòng Cao Cấp', 2, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (56, N'Nguyễn Văn Thắng', N'135622816', N'nguyenthang5758@gmail.com', N'0978695758', 2013, 2, 19, 21, N'Phòng Cao Cấp', 1, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (57, N'ancasda', N'212923123', N'liar.hoang@gmail.com', N'0123123813', 2013, 5, 15, 19, N'Phòng Sang Trọng 2 Giường', 2, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (58, N'ádasd', N'123123123', N'liar.hoang@gmail.com', N'0981312312', 2014, 9, 17, 19, N'Phòng Tuần Trăng Mật', 4, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (59, N'Hoàng anh', N'019231231', N'liar.hoang@gmail.com', N'0962608815', 2014, 10, 10, 16, N'Phòng Sang Trọng 2 Giường', 1, 2)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (60, N'anh', N'1231241', N'liar.hoang@gmail.com', N'1231231231', 2013, 2, 23, 24, NULL, NULL, NULL)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (61, N'abc', N'bc', N'de', N'aefw', 1, 2, 3, 4, N'ádf', 1, 2)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (62, N'ábd', N'012345678', N'liar.hoang@gmail.com', N'0962608815', 2014, 9, 12, 16, N'Phòng Sang Trọng 2 Giường', 2, 2)
INSERT [dbo].[Info_DatPhong] ([id], [tenkhachhang], [socm], [email], [sdt], [nam], [thang], [ngayden], [ngaydi], [tenphong], [soluongphong], [id_phong]) VALUES (63, N'Hoàng anh', N'012345678', N'liar.hoang@gmail.com', N'0962608815', 2014, 3, 10, 11, N'Phòng Sang Trọng 2 Giường', 1, 2)
SET IDENTITY_INSERT [dbo].[Info_DatPhong] OFF
/****** Object:  Trigger [tbl_Phong_Update]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[tbl_Phong_Update] 
on [dbo].[Info_DatPhong]
for update
as
if update(soluongphong)
update tbl_phong SET tbl_phong.soluongphong = tbl_phong.soluongphong - (INSERTED.soluongphong - deleted.soluongphong)
from (deleted inner join inserted on deleted.id=inserted.id) inner join tbl_phong on tbl_phong.id=deleted.id_Phong
GO
/****** Object:  Trigger [tbl_Phong_Insert]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[tbl_Phong_Insert]
on [dbo].[Info_DatPhong]
for insert
as
update tbl_phong SET
tbl_phong.soluongphong = tbl_phong.soluongphong - INSERTED.soluongphong
from tbl_phong inner join INSERTED on tbl_phong.id = INSERTED.id_Phong
GO
/****** Object:  Trigger [tbl_Phong_Delete]    Script Date: 05/06/2013 18:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[tbl_Phong_Delete]
on [dbo].[Info_DatPhong]
for delete
as
update tbl_phong SET
tbl_phong.soluongphong = tbl_phong.soluongphong + DELETED.soluongphong
from tbl_phong inner join DELETED on tbl_phong.id = DELETED.id_Phong
GO
/****** Object:  StoredProcedure [dbo].[DatPhong_ThongTin]    Script Date: 05/06/2013 18:16:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DatPhong_ThongTin]
@IdDatPhong int
as
select * from Info_DatPhong
where id = @IdDatPhong
GO
/****** Object:  StoredProcedure [dbo].[DatPhong_Them]    Script Date: 05/06/2013 18:16:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DatPhong_Them]
@id int output,
@tenkhachhang  nvarchar(50),
@socm  nvarchar(50),
@email  nvarchar(50),
@sdt  nvarchar(50),
@nam int,
@thang int, 
@ngayden int,
@ngaydi  int,
@tenphong nvarchar(50),
@soluongphong int,
@idPhong int
as
insert into Info_DatPhong
(
tenkhachhang,
socm,
email,
sdt,
nam, thang, ngayden, ngaydi, tenphong,soluongphong, id_phong
)
values(
@tenkhachhang, @socm, @email, @sdt, @nam, @thang, @ngayden, @ngaydi, @tenphong, @soluongphong ,@idPhong
)
set @id = @@IDENTITY
GO
/****** Object:  ForeignKey [FK_Info_DatPhong_tbl_phong]    Script Date: 05/06/2013 18:16:22 ******/
ALTER TABLE [dbo].[Info_DatPhong]  WITH CHECK ADD  CONSTRAINT [FK_Info_DatPhong_tbl_phong] FOREIGN KEY([id_phong])
REFERENCES [dbo].[tbl_phong] ([id])
GO
ALTER TABLE [dbo].[Info_DatPhong] CHECK CONSTRAINT [FK_Info_DatPhong_tbl_phong]
GO
