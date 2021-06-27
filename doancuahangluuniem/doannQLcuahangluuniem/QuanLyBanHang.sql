use master
go

create database QuanLyBanHangLN
go

use QuanLyBanHangLN
go

create table DangNhap(
	TenDangNhap nvarchar(30) constraint pk_DN primary key,
	MatKhau nvarchar(30)
)
go
insert into DangNhap values
	(N'admin',N'admin1')
go
create table NhanVien (
	MaNhanVien nvarchar(10) Not Null constraint pk_NV_MNV primary key,
	TenNhanVien nvarchar(100),
	GioiTinh nvarchar(5) check (GioiTinh in(N'Nam',N'Nữ',N'Khác')),
	DiaChi nvarchar(100),
	DienThoai nvarchar(15),
	NgaySinh datetime

)
go

create table Khach(
	MaKhach nvarchar(10) constraint pk_K_MK primary key,
	TenKhach nvarchar(100),
	DiaChiKH nvarchar(100),
	DienThoaiKH nvarchar(15)

)
go
create table ChatLieu(
	MaChatLieu nvarchar(10) constraint pk_CL_MCL primary key,
	TenChatLieu nvarchar(100)
)
go

create table Hang(
	MaHang nvarchar(10) constraint pk_H_MH primary key,
	TenHang nvarchar(100),
	MaChatLieu nvarchar(10) constraint fk_H_MCL foreign key references ChatLieu(MaChatLieu),
	SoLuong float,
	DonGiaNhap float,
	DonGiaBan float,
	Anh nvarchar(200),
	GhiChu nvarchar(200),
)
go



create table ChiTietHoaDonBan(
	MaHDBan nvarchar(100)constraint pk_CT primary key ,
	MaHang nvarchar(10) constraint fk_CT_MH foreign key references Hang(MaHang),
	SoLuong float,
	DonGia float,
	GiamGia float,
	ThanhTien float,
	
)
go
create table HoaDonBan(
	MaHDBan nvarchar(100)constraint fk_HDB_MHD foreign key references ChiTietHoaDonBan(MaHDBan), 
	MaNhanVien nvarchar(10) constraint fk_HDB_MaNV foreign key references NhanVien(MaNhanVien),
	NgayBan datetime,
	MaKhach nvarchar(10) constraint fk_HDB_MK foreign key references Khach(MaKhach),
	TongTien float,
	constraint pk_HDB primary key(MaHDBan)
)
go
select * from DangNhap