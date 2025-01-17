USE [QL_KhachSan]
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 01/03/2025 14:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Phong](
	[idphong] [int] IDENTITY(1,1) NOT NULL,
	[sophong] [varchar](250) NOT NULL,
	[loaiphong] [nvarchar](250) NOT NULL,
	[loaigiuong] [nvarchar](250) NOT NULL,
	[gia] [bigint] NOT NULL,
	[dat] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idphong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Phong] ON
INSERT [dbo].[Phong] ([idphong], [sophong], [loaiphong], [loaigiuong], [gia], [dat]) VALUES (1, N'P01', N'Thường', N'Đơn', 300000, N'YES')
INSERT [dbo].[Phong] ([idphong], [sophong], [loaiphong], [loaigiuong], [gia], [dat]) VALUES (2, N'P02', N'Thường', N'Gia Đình', 400000, N'YES')
INSERT [dbo].[Phong] ([idphong], [sophong], [loaiphong], [loaigiuong], [gia], [dat]) VALUES (3, N'P03', N'VIP', N'Đôi', 500000, N'NO')
INSERT [dbo].[Phong] ([idphong], [sophong], [loaiphong], [loaigiuong], [gia], [dat]) VALUES (4, N'P04', N'VIP', N'Gia Đình', 600000, N'NO')
INSERT [dbo].[Phong] ([idphong], [sophong], [loaiphong], [loaigiuong], [gia], [dat]) VALUES (6, N'P05', N'Thường', N'Đôi', 300000, N'NO')
INSERT [dbo].[Phong] ([idphong], [sophong], [loaiphong], [loaigiuong], [gia], [dat]) VALUES (7, N'P06', N'Thường', N'Đơn', 300000, N'YES')
INSERT [dbo].[Phong] ([idphong], [sophong], [loaiphong], [loaigiuong], [gia], [dat]) VALUES (8, N'P07', N'VIP', N'Đôi', 500000, N'NO')
INSERT [dbo].[Phong] ([idphong], [sophong], [loaiphong], [loaigiuong], [gia], [dat]) VALUES (9, N'P08', N'Thường', N'Gia Đình', 400000, N'NO')
INSERT [dbo].[Phong] ([idphong], [sophong], [loaiphong], [loaigiuong], [gia], [dat]) VALUES (10, N'P09', N'VIP', N'Đơn', 400000, N'YES')
INSERT [dbo].[Phong] ([idphong], [sophong], [loaiphong], [loaigiuong], [gia], [dat]) VALUES (11, N'P11', N'VIP', N'Đôi', 500000, N'NO')
INSERT [dbo].[Phong] ([idphong], [sophong], [loaiphong], [loaigiuong], [gia], [dat]) VALUES (12, N'P12', N'VIP', N'Đôi', 300000, N'NO')
SET IDENTITY_INSERT [dbo].[Phong] OFF
/****** Object:  Table [dbo].[NhanVien]    Script Date: 01/03/2025 14:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[idnv] [int] IDENTITY(1,1) NOT NULL,
	[tennv] [nvarchar](250) NOT NULL,
	[sodienthoainv] [varchar](20) NULL,
	[gioitinhnv] [nvarchar](50) NOT NULL,
	[email] [varchar](120) NOT NULL,
	[username] [varchar](150) NOT NULL,
	[pass] [varchar](150) NOT NULL,
	[loainguoidung] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idnv] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON
INSERT [dbo].[NhanVien] ([idnv], [tennv], [sodienthoainv], [gioitinhnv], [email], [username], [pass], [loainguoidung]) VALUES (1, N'Trầm Khôi Nguyên', N'0987769860', N'Nam', N'tramkhoinguyen271@gmail.com', N'tramkhoinguyen', N'69274587eb05d663e402329892dbc6a4898ce9a03df906b68409046bc87861f7', N'Quản Lý')
INSERT [dbo].[NhanVien] ([idnv], [tennv], [sodienthoainv], [gioitinhnv], [email], [username], [pass], [loainguoidung]) VALUES (2, N'Nguyễn Thùy Anh', N'0987763636', N'Nữ', N'ass@gmail.com', N'nhanvien01', N'69274587eb05d663e402329892dbc6a4898ce9a03df906b68409046bc87861f7', N'Nhân Viên')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
/****** Object:  Table [dbo].[KhachHang]    Script Date: 01/03/2025 14:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[idkhach] [int] IDENTITY(1,1) NOT NULL,
	[tenkhach] [nvarchar](250) NOT NULL,
	[sodienthoai] [varchar](20) NULL,
	[quoctich] [nvarchar](250) NOT NULL,
	[gioitinh] [nvarchar](50) NOT NULL,
	[ngaysinh] [varchar](50) NOT NULL,
	[cccd] [varchar](250) NOT NULL,
	[diachi] [nvarchar](350) NOT NULL,
	[checkin] [varchar](250) NOT NULL,
	[checkout] [varchar](250) NULL,
	[thanhtoan] [varchar](250) NULL,
	[idphong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idkhach] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON
INSERT [dbo].[KhachHang] ([idkhach], [tenkhach], [sodienthoai], [quoctich], [gioitinh], [ngaysinh], [cccd], [diachi], [checkin], [checkout], [thanhtoan], [idphong]) VALUES (1, N'Nguyễn Minh Anh', N'038288292', N'Việt Nam', N'Nữ', N'30/12/2024', N'084383839234', N'Phuoc Hung, Tra Cu, Tra Vinh', N'30/12/2024', NULL, N'NO', 1)
INSERT [dbo].[KhachHang] ([idkhach], [tenkhach], [sodienthoai], [quoctich], [gioitinh], [ngaysinh], [cccd], [diachi], [checkin], [checkout], [thanhtoan], [idphong]) VALUES (2, N'Nguyễn Hưng Huy', N'0358872123', N'Việt Nam', N'Nam', N'12/05/1997', N'084728332128', N'Toa nha Waseco, Lau 5, So 10 Pho Quang, Tan Binh, Ho Chi Minh', N'30/12/2024', NULL, N'NO', 7)
INSERT [dbo].[KhachHang] ([idkhach], [tenkhach], [sodienthoai], [quoctich], [gioitinh], [ngaysinh], [cccd], [diachi], [checkin], [checkout], [thanhtoan], [idphong]) VALUES (3, N'Trần Duy', N'0912879098', N'Mỹ', N'Nam', N'21/10/1999', N'084305229382', N'322/5 Minh Phung, Ward 12, Dist.1, Ho Chi Minh City', N'30/12/2024', N'30/12/2024', N'YES', 4)
INSERT [dbo].[KhachHang] ([idkhach], [tenkhach], [sodienthoai], [quoctich], [gioitinh], [ngaysinh], [cccd], [diachi], [checkin], [checkout], [thanhtoan], [idphong]) VALUES (5, N'Nguyễn Anh Khoa', N'0982272626', N'Việt Nam', N'Nam', N'23/06/2007', N'084207883939', N'Cam Pha, My Xuyen, Soc Trang', N'30/12/2024', N'30/12/2024', N'YES', 9)
INSERT [dbo].[KhachHang] ([idkhach], [tenkhach], [sodienthoai], [quoctich], [gioitinh], [ngaysinh], [cccd], [diachi], [checkin], [checkout], [thanhtoan], [idphong]) VALUES (7, N'Phạm Thị Minh', N'0289457581', N'Việt Nam', N'Nam', N'11/11/2003', N'084303229232', N'So nha 28, Quan Binh Thuy, Ho Chi Minh', N'30/12/2024', N'30/12/2024', N'YES', 8)
INSERT [dbo].[KhachHang] ([idkhach], [tenkhach], [sodienthoai], [quoctich], [gioitinh], [ngaysinh], [cccd], [diachi], [checkin], [checkout], [thanhtoan], [idphong]) VALUES (8, N'Nguyễn My', N'0972272838', N'Việt Nam', N'Nữ', N'22/02/1992', N'084092828212', N'276 Xuong Giang, Bac Giang', N'30/12/2024', N'30/12/2024', N'YES', 11)
INSERT [dbo].[KhachHang] ([idkhach], [tenkhach], [sodienthoai], [quoctich], [gioitinh], [ngaysinh], [cccd], [diachi], [checkin], [checkout], [thanhtoan], [idphong]) VALUES (9, N'Trần Văn Nguyên', N'0919762821', N'Việt Nam', N'Nam', N'12/02/2006', N'084209882823', N'Building Chingfong, 53 Quang Trung, District Hai Ba Trung, Ha Noi', N'31/12/2024', NULL, N'NO', 2)
INSERT [dbo].[KhachHang] ([idkhach], [tenkhach], [sodienthoai], [quoctich], [gioitinh], [ngaysinh], [cccd], [diachi], [checkin], [checkout], [thanhtoan], [idphong]) VALUES (10, N'Nguyễn Thị Thu', N'0982281123', N'Việt Nam', N'Nữ', N'03/12/1999', N'084282332312', N'115 Tran Nguyen Han, Tan Lap Ward, Khanh Hoa', N'31/12/2024', NULL, N'NO', 10)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
/****** Object:  Default [DF__KhachHang__cheko__060DEAE8]    Script Date: 01/03/2025 14:59:44 ******/
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ('NO') FOR [thanhtoan]
GO
/****** Object:  Default [DF__Phong__dat__014935CB]    Script Date: 01/03/2025 14:59:44 ******/
ALTER TABLE [dbo].[Phong] ADD  DEFAULT ('NO') FOR [dat]
GO
/****** Object:  ForeignKey [FK__KhachHang__idpho__07020F21]    Script Date: 01/03/2025 14:59:44 ******/
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD FOREIGN KEY([idphong])
REFERENCES [dbo].[Phong] ([idphong])
GO
