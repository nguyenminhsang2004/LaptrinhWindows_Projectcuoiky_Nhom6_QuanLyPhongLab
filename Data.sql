USE [QUANLYPHONGLAB]
GO
/****** Object:  Table [dbo].[CONGVIEC]    Script Date: 19/06/2020 11:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CONGVIEC](
	[ID] [char](10) NOT NULL,
	[TenCV] [nvarchar](100) NULL,
	[MaDA] [char](10) NULL,
	[TaiLieuCV] [nvarchar](max) NULL,
	[CheckCV] [int] NULL,
	[NgayHoanThanh] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DUAN]    Script Date: 19/06/2020 11:30:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DUAN](
	[ID] [char](10) NOT NULL,
	[TenDuAn] [nvarchar](max) NULL,
	[Nhom] [char](10) NULL,
	[MaNQL] [char](10) NULL,
	[TaiLieuDA] [nvarchar](100) NULL,
	[NgayHoanThanh] [date] NULL,
	[CheckDA] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NGUOIQUANLY]    Script Date: 19/06/2020 11:30:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NGUOIQUANLY](
	[ID] [char](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NULL,
	[DiaChi] [nvarchar](500) NULL,
	[Phone] [char](10) NULL,
	[Email] [nvarchar](50) NULL,
	[ThoiGianLam] [time](7) NULL,
	[ThoiGianNghi] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHANSU]    Script Date: 19/06/2020 11:30:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANSU](
	[MaNhom] [char](10) NOT NULL,
	[MaThanhVien] [char](10) NOT NULL,
	[MaNT] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC,
	[MaThanhVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHOM]    Script Date: 19/06/2020 11:30:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHOM](
	[ID] [char](10) NOT NULL,
	[SoThanhVien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHANCONG]    Script Date: 19/06/2020 11:30:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHANCONG](
	[MaTV] [char](10) NOT NULL,
	[MaCV] [char](10) NOT NULL,
	[NgayHoanThanh] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTV] ASC,
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THANHVIEN]    Script Date: 19/06/2020 11:30:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[THANHVIEN](
	[ID] [char](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [char](3) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[Phone] [char](10) NULL,
	[Email] [nvarchar](50) NULL,
	[ThoiGianLam] [time](7) NULL,
	[ThoiGianNghi] [time](7) NULL,
	[Luong] [float] NULL,
	[Thuong] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV01_04   ', N'Thiet ke du an cafe', N'DA04      ', N'', 0, CAST(N'2020-06-20' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV03_01   ', N'Tạo CSDL', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-10-12' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV03_03   ', N'Tạo CSDL', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-08-16' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV04_01   ', N'Nhập liệu cho CSDL', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-10-13' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV04_03   ', N'Nhập liệu cho CSDL', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-08-20' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV05_01   ', N'Test CSDL', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-10-14' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV05_02   ', N'Test CSDL', N'DA02      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-05-08' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV05_03   ', N'Test CSDL', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-08-24' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV06_01   ', N'Thiết kế giao diện', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-10-15' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV06_02   ', N'Thiết kế giao diện', N'DA02      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-05-10' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV06_03   ', N'Thiết kế giao diện', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-08-25' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV07_01   ', N'Viết code hoàn chỉnh phần mềm theo nghiệp vụ', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-11-05' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV07_02   ', N'Viết code hoàn chỉnh phần mềm theo nghiệp vụ', N'DA02      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-06-03' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV07_03   ', N'Viết code hoàn chỉnh phần mềm theo nghiệp vụ', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-09-20' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV08_01   ', N'Hiển thị dữ liệu thích hợp lên giao diện người dùng', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-11-01' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV08_02   ', N'Hiển thị dữ liệu thích hợp lên giao diện người dùng', N'DA02      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-06-05' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV08_03   ', N'Hiển thị dữ liệu thích hợp lên giao diện người dùng', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-09-25' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV09_01   ', N'Add dữ liệu', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-11-07' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV09_02   ', N'Add dữ liệu', N'DA02      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-06-10' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV09_03   ', N'Add dữ liệu', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-09-28' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV10_01   ', N'Delete dữ liệu', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-11-07' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV10_02   ', N'Delete dữ liệu', N'DA02      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-06-10' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV10_03   ', N'Delete dữ liệu', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-09-28' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV11_01   ', N'Update dữ liệu', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-11-07' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV11_02   ', N'Update dữ liệu', N'DA02      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-06-10' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV11_03   ', N'Update dữ liệu', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-09-28' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV12_01   ', N'Thêm chức năng cho phần mềm', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-11-07' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV12_02   ', N'Thêm chức năng cho phần mềm', N'DA02      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-06-18' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV12_03   ', N'Thêm chức năng cho phần mềm', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-09-30' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV13_01   ', N'Test chương trình', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-11-10' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV13_02   ', N'Test chương trình', N'DA02      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-06-20' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV13_03   ', N'Test chương trình', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 1, CAST(N'2020-10-01' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV14_01   ', N'Đóng gói phần mềm', N'DA01      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-11-10' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV14_02   ', N'Đóng gói phần mềm', N'DA02      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-06-25' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV14_03   ', N'Đóng gói phần mềm', N'DA03      ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', 0, CAST(N'2020-10-01' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV15_01   ', N'Demo khách hàng', N'DA01      ', N'abcdef', 0, CAST(N'2020-07-11' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV15_02   ', N'Demo cho khách hàng', N'DA02      ', N'', 1, CAST(N'2020-06-10' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV15_03   ', N'Cai j do', N'DA03      ', N'', 0, CAST(N'2020-06-19' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV16_02   ', N'Demo khach hang', N'DA02      ', N'', 0, CAST(N'2020-06-12' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV17_02   ', N'Lanh tien', N'DA02      ', N'', 0, CAST(N'2020-06-15' AS Date))
INSERT [dbo].[CONGVIEC] ([ID], [TenCV], [MaDA], [TaiLieuCV], [CheckCV], [NgayHoanThanh]) VALUES (N'CV18_02   ', N'6trjb67n8kn', N'DA02      ', N'', 0, CAST(N'2020-06-13' AS Date))
INSERT [dbo].[DUAN] ([ID], [TenDuAn], [Nhom], [MaNQL], [TaiLieuDA], [NgayHoanThanh], [CheckDA], [MoTa]) VALUES (N'DA01      ', N'Phần mềm quản lý sinh viên', N'5         ', N'QLLAB01   ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', CAST(N'2020-11-20' AS Date), 0, N'Đặc tả chi tiết về dự án')
INSERT [dbo].[DUAN] ([ID], [TenDuAn], [Nhom], [MaNQL], [TaiLieuDA], [NgayHoanThanh], [CheckDA], [MoTa]) VALUES (N'DA02      ', N'Phần mềm quản lý phòng LAB', N'3         ', N'QLLAB01   ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', CAST(N'2020-06-30' AS Date), 64, N'Đặc tả chi tiết về dự án')
INSERT [dbo].[DUAN] ([ID], [TenDuAn], [Nhom], [MaNQL], [TaiLieuDA], [NgayHoanThanh], [CheckDA], [MoTa]) VALUES (N'DA03      ', N'Xây dựng ứng dụng quản lý khách hàng', N'1         ', N'QLLAB01   ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', CAST(N'2020-10-15' AS Date), 61, N'Đặc tả chi tiết về dự án')
INSERT [dbo].[DUAN] ([ID], [TenDuAn], [Nhom], [MaNQL], [TaiLieuDA], [NgayHoanThanh], [CheckDA], [MoTa]) VALUES (N'DA04      ', N'Phần mềm quản lý quản lý quán cafe', N'2         ', N'QLLAB01   ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', CAST(N'2020-07-25' AS Date), 0, N'Đặc tả chi tiết về dự án')
INSERT [dbo].[DUAN] ([ID], [TenDuAn], [Nhom], [MaNQL], [TaiLieuDA], [NgayHoanThanh], [CheckDA], [MoTa]) VALUES (N'DA05      ', N'Xây dựng ứng dụng chatbot', N'4         ', N'QLLAB01   ', N'https://drive.google.com/drive/folders/1VpaMEX-jhNid81Un6xIjgpklytI4yRST?usp=sharing', CAST(N'2020-12-25' AS Date), 0, N'Đặc tả chi tiết về dự án')
INSERT [dbo].[NGUOIQUANLY] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi]) VALUES (N'QLLAB01   ', N'NGUYỄN VĂN THÀNH', CAST(N'1985-01-01' AS Date), 1, N'01 Võ Văn Ngân Thủ Đức', N'0997782819', N'thanhnv@hcmute.edu.vn', CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time))
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'1         ', N'18133003  ', N'18133005  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'1         ', N'18133005  ', NULL)
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'1         ', N'18133007  ', N'18133005  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'1         ', N'18133013  ', N'18133005  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'1         ', N'18133017  ', N'18133005  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'1         ', N'18133022  ', N'18133005  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'1         ', N'18133032  ', N'18133005  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'2         ', N'18133001  ', NULL)
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'2         ', N'18133008  ', N'18133001  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'2         ', N'18133012  ', N'18133001  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'2         ', N'18133021  ', N'18133001  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'2         ', N'18133023  ', N'18133001  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'2         ', N'18133030  ', N'18133001  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'3         ', N'18133002  ', N'18133011  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'3         ', N'18133011  ', NULL)
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'3         ', N'18133014  ', N'18133011  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'3         ', N'18133024  ', N'18133011  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'3         ', N'18133031  ', N'18133011  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'3         ', N'18133033  ', N'18133011  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'3         ', N'18133034  ', N'18133011  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'4         ', N'18133006  ', N'18133018  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'4         ', N'18133015  ', N'18133018  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'4         ', N'18133018  ', NULL)
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'4         ', N'18133021  ', N'18133018  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'4         ', N'18133023  ', N'18133018  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'4         ', N'18133026  ', N'18133018  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'4         ', N'18133030  ', N'18133018  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'5         ', N'18133003  ', N'18133025  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'5         ', N'18133009  ', N'18133025  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'5         ', N'18133017  ', N'18133025  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'5         ', N'18133019  ', N'18133025  ')
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'5         ', N'18133025  ', NULL)
INSERT [dbo].[NHANSU] ([MaNhom], [MaThanhVien], [MaNT]) VALUES (N'5         ', N'18133032  ', N'18133025  ')
INSERT [dbo].[NHOM] ([ID], [SoThanhVien]) VALUES (N'1         ', 5)
INSERT [dbo].[NHOM] ([ID], [SoThanhVien]) VALUES (N'2         ', 6)
INSERT [dbo].[NHOM] ([ID], [SoThanhVien]) VALUES (N'3         ', 7)
INSERT [dbo].[NHOM] ([ID], [SoThanhVien]) VALUES (N'4         ', 9)
INSERT [dbo].[NHOM] ([ID], [SoThanhVien]) VALUES (N'5         ', 7)
INSERT [dbo].[PHANCONG] ([MaTV], [MaCV], [NgayHoanThanh]) VALUES (N'18133002  ', N'CV05_02   ', CAST(N'2020-10-11' AS Date))
INSERT [dbo].[PHANCONG] ([MaTV], [MaCV], [NgayHoanThanh]) VALUES (N'18133002  ', N'CV06_02   ', CAST(N'2020-04-20' AS Date))
INSERT [dbo].[PHANCONG] ([MaTV], [MaCV], [NgayHoanThanh]) VALUES (N'18133002  ', N'CV07_02   ', CAST(N'2020-08-12' AS Date))
INSERT [dbo].[PHANCONG] ([MaTV], [MaCV], [NgayHoanThanh]) VALUES (N'18133002  ', N'CV08_02   ', CAST(N'2020-08-12' AS Date))
INSERT [dbo].[PHANCONG] ([MaTV], [MaCV], [NgayHoanThanh]) VALUES (N'18133002  ', N'CV09_02   ', CAST(N'2020-08-12' AS Date))
INSERT [dbo].[PHANCONG] ([MaTV], [MaCV], [NgayHoanThanh]) VALUES (N'18133011  ', N'CV10_02   ', CAST(N'2020-08-12' AS Date))
INSERT [dbo].[PHANCONG] ([MaTV], [MaCV], [NgayHoanThanh]) VALUES (N'18133011  ', N'CV12_02   ', CAST(N'2020-08-12' AS Date))
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133001  ', N'Trương Hùng Anh', CAST(N'1999-12-17' AS Date), N'1  ', N'Số 2 Đường số 1, Thủ Đức', N'0909554188', N'18133001@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'10:30:00' AS Time), 7000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133002  ', N'Trần Quang Bách', CAST(N'2000-02-05' AS Date), N'1  ', N'Số 3 Đường số 1, Thủ Đức', N'0909156554', N'1813302@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133003  ', N'Trần Hoàng An Bình', CAST(N'2000-01-25' AS Date), N'1  ', N'Số 4 Đường số 1, Thủ Đức', N'0968778577', N'18133003@student.hcmute.edu.vn', CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133004  ', N'Nguyễn Thành Công', CAST(N'2000-10-01' AS Date), N'1  ', N'Số 5 Đường số 1, Thủ Đức', N'0909545421', N'1813304@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133005  ', N'Phan Thành Đạt', CAST(N'2000-09-26' AS Date), N'1  ', N'Số 1 Đường số 1, Thủ Đức', N'0909789666', N'18133005@student.hcmute.edu.vn', CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 7000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133006  ', N'Trần Tiến Đức', CAST(N'2000-07-29' AS Date), N'1  ', N'Số 2 Đường số 2, Thủ Đức', N'0909574569', N'18133006@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'10:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133007  ', N'Lê Nam Hải', CAST(N'2000-08-20' AS Date), N'1  ', N'Số 3 Đường số 2, Thủ Đức', N'0909124528', N'18133007@student.hcmute.edu.vn', CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133008  ', N'Nguyễn Hoàng Đại Hải', CAST(N'2000-09-16' AS Date), N'1  ', N'Số 4 Đường số 2, Thủ Đức', N'0909289541', N'18133008@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'10:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133009  ', N'Nguyễn Huỳnh Phúc Hậu', CAST(N'2000-10-14' AS Date), N'1  ', N'Số 6 Đường số 2, Thủ Đức', N'0909287894', N'18133009@student.hcmute.edu.vn', CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133010  ', N'Lê Chí Hiếu', CAST(N'2000-02-14' AS Date), N'1  ', N'Số 5 Đường số 2, Thủ Đức', N'0909578124', N'1813310@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133011  ', N'Nguyễn Xuân Hiệu', CAST(N'2000-07-16' AS Date), N'1  ', N'Số 2 Đường số 3, Thủ Đức', N'0903121457', N'18133011@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 7000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133012  ', N'Nguyễn Ngọc Hòa', CAST(N'2000-03-10' AS Date), N'1  ', N'Số 3 Đường số 3, Thủ Đức', N'0903178945', N'1813312@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'10:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133013  ', N'Ngô Trí Huy', CAST(N'2000-04-02' AS Date), N'1  ', N'Số 4 Đường số 3, Thủ Đức', N'0909784514', N'18133013@student.hcmute.edu.vn', CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133014  ', N'Nguyễn Quang Hùng', CAST(N'2000-07-27' AS Date), N'1  ', N'Số 1 Đường số 3, Thủ Đức', N'0909312457', N'18133014@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133015  ', N'Phạm Ngọc Hùng', CAST(N'2000-10-04' AS Date), N'1  ', N'Số 2 Đường số 4, Thủ Đức', N'0909178745', N'1813315@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'10:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133016  ', N'Phạm Văn Hùng', CAST(N'2000-10-29' AS Date), N'1  ', N'Số 3 Đường số 4, Thủ Đức', N'0909178478', N'1813316@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133017  ', N'Đỗ Hải Hưng', CAST(N'2000-01-30' AS Date), N'1  ', N'Số 3 Đường số 4, Thủ Đức', N'0909177813', N'18133017@student.hcmute.edu.vn', CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133018  ', N'Nguyễn Khánh Hưng', CAST(N'2000-04-03' AS Date), N'1  ', N'Số 1 Đường số 4, Thủ Đức', N'0909317857', N'1813318@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'10:30:00' AS Time), 7000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133019  ', N'Lê Đình Khang', CAST(N'2000-03-22' AS Date), N'1  ', N'Số 4 Đường số 4, Thủ Đức', N'0909745178', N'1813319@student.hcmute.edu.vn', CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133020  ', N'Nguyễn Đăng Khoa', CAST(N'2000-06-15' AS Date), N'1  ', N'Số 5 Đường số 4, Thủ Đức', N'0909425715', N'1813320@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'10:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133021  ', N'Lê Thị Thùy Linh', CAST(N'2000-04-29' AS Date), N'0  ', N'Số 6 Đường số 4, Thủ Đức', N'0903415126', N'1813321@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'10:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133022  ', N'Ngô Phi Lít', CAST(N'2000-07-24' AS Date), N'1  ', N'Số 2 Đường số 5, Thủ Đức', N'0909984578', N'18133022@student.hcmute.edu.vn', CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133023  ', N'Huỳnh Thiên Long', CAST(N'2000-04-05' AS Date), N'1  ', N'Số 3 Đường số 5, Thủ Đức', N'0909841452', N'18133023@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'12:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133024  ', N'Lương Uy Long', CAST(N'2000-06-07' AS Date), N'1  ', N'Số 3 Đường số 5, Thủ Đức', N'0909241413', N'18133024@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133025  ', N'Huỳnh Thị Hương Ly', CAST(N'2000-03-07' AS Date), N'0  ', N'Số 1 Đường số 5, Thủ Đức', N'0909658748', N'18133025@student.hcmute.edu.vn', CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 7000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133026  ', N'Lê Đỗ Trà My', CAST(N'2000-02-01' AS Date), N'0  ', N'Số 4 Đường số 5, Thủ Đức', N'0909971497', N'18133026@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'12:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133027  ', N'Nguyễn Duy Nam', CAST(N'2000-01-08' AS Date), N'1  ', N'Số 7 Đường số 5, Thủ Đức', N'0903841497', N'18133027@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133028  ', N'Trương Vạn Nam', CAST(N'2000-12-05' AS Date), N'1  ', N'Số 7 Đường số 5, Thủ Đức', N'0903841444', N'18133028@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 7000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133029  ', N'Võ Thị Thanh Ngân', CAST(N'2000-09-08' AS Date), N'0  ', N'Số 7 Đường số 5, Thủ Đức', N'0903842497', N'18133029@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133030  ', N'Đinh Quang Ngọc', CAST(N'2000-01-01' AS Date), N'1  ', N'Số 7 Đường số 5, Thủ Đức', N'0909841497', N'18133030@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'10:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133031  ', N'Trần Gia Nguyên', CAST(N'2000-04-30' AS Date), N'0  ', N'Số 7 Đường số 5, Thủ Đức', N'0903799444', N'18133031@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133032  ', N'Đào Minh Thy', CAST(N'2000-06-25' AS Date), N'0  ', N'Số 7 Đường số 5, Thủ Đức', N'0903201497', N'18133032@student.hcmute.edu.vn', CAST(N'12:00:00' AS Time), CAST(N'14:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133033  ', N'Nguyễn Thị Như Quỳnh', CAST(N'2000-04-30' AS Date), N'0  ', N'Số 7 Đường số 5, Thủ Đức', N'0902181497', N'18133033@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133034  ', N'Trần Như Thuận', CAST(N'2000-03-30' AS Date), N'1  ', N'Số 7 Đường số 5, Thủ Đức', N'0905581497', N'18133034@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'10:30:00' AS Time), 5000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133035  ', N'Nguyễn Anh Triều', CAST(N'2000-04-30' AS Date), N'1  ', N'Số 7 Đường số 5, Thủ Đức', N'0902781497', N'18133035@student.hcmute.edu.vn', CAST(N'08:00:00' AS Time), CAST(N'10:30:00' AS Time), 7000000, 0)
INSERT [dbo].[THANHVIEN] ([ID], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [Phone], [Email], [ThoiGianLam], [ThoiGianNghi], [Luong], [Thuong]) VALUES (N'18133036  ', N'Nguyễn Tuấn Phi', CAST(N'2000-02-25' AS Date), N'1  ', N'Số 7 Đường số 5, Thủ Đức', N'0903789497', N'18133036@student.hcmute.edu.vn', CAST(N'16:00:00' AS Time), CAST(N'18:00:00' AS Time), 5000000, 0)
ALTER TABLE [dbo].[CONGVIEC]  WITH CHECK ADD FOREIGN KEY([MaDA])
REFERENCES [dbo].[DUAN] ([ID])
GO
ALTER TABLE [dbo].[DUAN]  WITH CHECK ADD FOREIGN KEY([MaNQL])
REFERENCES [dbo].[NGUOIQUANLY] ([ID])
GO
ALTER TABLE [dbo].[DUAN]  WITH CHECK ADD FOREIGN KEY([Nhom])
REFERENCES [dbo].[NHOM] ([ID])
GO
ALTER TABLE [dbo].[NHANSU]  WITH CHECK ADD FOREIGN KEY([MaNhom])
REFERENCES [dbo].[NHOM] ([ID])
GO
ALTER TABLE [dbo].[NHANSU]  WITH CHECK ADD FOREIGN KEY([MaNT])
REFERENCES [dbo].[THANHVIEN] ([ID])
GO
ALTER TABLE [dbo].[NHANSU]  WITH CHECK ADD FOREIGN KEY([MaThanhVien])
REFERENCES [dbo].[THANHVIEN] ([ID])
GO
ALTER TABLE [dbo].[PHANCONG]  WITH CHECK ADD FOREIGN KEY([MaCV])
REFERENCES [dbo].[CONGVIEC] ([ID])
GO
ALTER TABLE [dbo].[PHANCONG]  WITH CHECK ADD FOREIGN KEY([MaTV])
REFERENCES [dbo].[THANHVIEN] ([ID])
GO
