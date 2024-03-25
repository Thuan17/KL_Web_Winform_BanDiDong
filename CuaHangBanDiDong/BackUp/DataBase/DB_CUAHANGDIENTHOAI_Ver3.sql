Create database CUAHANGDIENTHOAI_Ver3
go

use CUAHANGDIENTHOAI_Ver3
go


----------------------Sản Phẩm
--Loại Sản Phẩm vd điện thoại & LapTop
create table tb_ProductCategory(
	ProductCategoryId int IDENTITY(1,1) NOT NULL primary key ,
	Title nvarchar(150) NOT NULL,
	Description nvarchar(max) NULL,
	Icon nvarchar(250) NULL,
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime  NULL,
	Modifiedby nvarchar(max) NULL,
	Alias nvarchar(150) NOT NULL,
)
go



--Hang San Phấm
create table tb_ProductCompany(
	ProductCompanyId int IDENTITY(1,1) not null primary key ,
	Title nvarchar(max),
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime ,
	Modifeby nvarchar(max),
	Alias nvarchar(250)Null,

)
go


--Sản phẩm gì vd : iphone 11 & iphone 12
create table tb_ProductDetail(
	ProductDetaiId int IDENTITY(1,1) not null primary key ,
	Title nvarchar(max),
	
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime ,
	Modifeby nvarchar(max),
	Alias nvarchar(250)Null,
	IsActive bit,
	IsHome bit ,
	IsSale bit ,
	IsFeature bit,
	IsHot bit ,
	SeoTitle nvarchar(250),
	SeoDescription nvarchar(250),


	ProductCode nvarchar(50),
	Price decimal(18,2),
	PriceSale decimal(18,2),
	OrigianlPrice decimal(18,2),
	--Quantity int ,
	Color int ,

	TypeProduct bit ,
	ProductCategoryId int,
	ProductCompanyId int,
	Image nvarchar(250)
)
go


--Hệ điều hành & CPU Sản phẩm
create table tb_ProductDetailProcessor(
	ProductDetailProcessorId int IDENTITY(1,1) not null primary key ,
	HeDieuHanh nvarchar(250),
	CPU char(100),
	TocDoCPU nvarchar(300),	
	GPU char (100),
	TocDoGPU nvarchar(300),
	ProductDetaiId int 
)
go


--Bộ nhớ & Lưu trữ
create table tb_ProductDetailMemory(
	ProductDetailMemoryId int IDENTITY(1,1) not null primary key ,
	Ram int ,
	DungLuong char(15) ,
	ProductDetaiId int 
)
go

--Kết nối của điện thoại
create table tb_ProductDetailConnect(
	ProductDetailConnectId int IDENTITY(1,1) not null primary key ,
	MangDiDong nvarchar(200) ,
	Sim char(15) ,
	Wifi  nvarchar(max) ,
	GPS char(70),
	Bluetooth char(20),
	CongKetNoi char(30),
	JackTaiNghe char(30),
 
	ProductDetaiId int 
)
go


--Chi tiết Pin Điện Thoaaij
create table tb_ProductDetailPin(
	ProductDetailPinId int IDENTITY(1,1) not null primary key ,
	DungLuongPin nvarchar(50) ,
	LoaiPin char(15) ,
	HoTroSac  char(15) ,
	CongNghePin nvarchar(250) ,
	ProductDetaiId int 
)
go

--Hình sản phẩm mới
Create table tb_ProductImage(
	ProductImageId int IDENTITY(1,1) NOT NULL  primary key ,
	ProductDetaiId int NOT NULL,
	Image nvarchar(max) NULL,
	IsDefault bit NOT NULL,
	
)
go





-----------------------------------Nhan Viewn
--Thông tin nhân viên
create  TABLE tb_Staff(
	NhanVienId int IDENTITY(1,1) NOT NULL  primary key ,
	MSNV varchar(10) Not null,
	SDT VARCHAR(15)  Not null,
    TenNhanVien NVARCHAR(max) not null,
	CCCD char(12)not null,
    Email VARCHAR(100)not null,
    Password  varchar(100) not null,
	Image nvarchar(250) null,
	Birthday Date not null ,
	DiaChi nvarchar(max)not null,
	NgayVaoLam date ,
	Luong decimal(18,2)NOT NULL,
	GioiTinh nvarchar(7),
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedBy nvarchar(max) NULL,
	ModifiedDate datetime NOT NULL,
	Clock bit,
	IdChucNang int
)
go


--Hinh anh Nhan vien
Create table tb_StaffImage(
	Id int IDENTITY(1,1) NOT NULL  primary key ,
	Image nvarchar(max) NULL,
	IsDefault bit NOT NULL,
	NhanVienId int  NOT NULL,
	
)
go


--Chuc Nang Nhân viên
create  table tb_Function (
	IdChucNang int IDENTITY(1,1) NOT NULL primary key ,
	TenChucNang nvarchar (max),
	MaChucNang nvarchar(max),
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime,
	Modifeby nvarchar(max)
)
go

--Quyen Hạng Nhân Viên
create  table tb_Role (
 	NhanVienId int Not null,
	IdChucNang int Not null,
	GhiChu nvarchar(max),
	PRIMARY KEY(NhanVienId,IdChucNang)
)
go
------------------------------------Khách hàng
create  TABLE tb_KhachHang (
	IdKhachHang  int IDENTITY(1,1) NOT NULL primary key ,
    SDT VARCHAR(15)null ,
    TenKhachHang NVARCHAR(max) not null,
    Email VARCHAR(100)null,
    Password  varchar(100) ,
	Image nvarchar(250) null,
	Birthday Date null ,
	DiaChi nvarchar(max)null,
	SoLanMua int, 
	Code char(10),
	Clock bit
)
go


------------------------------------Gio Hàng

create table tb_Cart(
	CartId int IDENTITY(1,1) NOT NULL primary key ,
	IdKhachHang  int,
)
go

create table tb_CartItem (
	CartItem int IDENTITY(1,1) NOT NULL primary key ,
	CartId int NOT NULL,
	Quantity int NOT NULL,
	Price decimal (18,0) Not null,
	PriceTotal decimal (18,0) Not null,
	TemPrice decimal (18,0) not null,	
	ProductDetaiId int NOT NULL,
)
go


------------------------------------Order

create table tb_Order(
	OrderId int IDENTITY(1,1) NOT NULL primary key,
	Code nvarchar(max) NOT NULL,
	CustomerName nvarchar(max) NOT NULL,
	Phone nvarchar(max) NOT NULL,
	Address nvarchar(max) NOT NULL,
	TotalAmount [decimal](18, 2) NOT NULL,
	Quantity int NOT NULL,
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime NOT NULL,
	Modifiedby nvarchar(max) NULL,
	TypePayment int NOT NULL,
	Email nvarchar(max) NULL,
	
	typeOrder bit,
	Confirm bit,
	Status nvarchar(max),
	typeReturn bit,
	Success bit,
	SuccessDate datetime,
	IdKhachHang int 
)
go

create table tb_OrderDetail (
	OrderDetailId int IDENTITY(1,1) NOT NULL primary key ,
	Price decimal(18, 2) NOT NULL,
	Quantity int NOT NULL,
	CartItem int,
	DamagedProduct bit,
	OrderId int ,
	IdKhachHang int ,
	ProductDetaiId int
)
go

-------------------------------------Cưa hàng



create table tb_Store (
	StoreId int IDENTITY(1,1) NOT NULL  primary key ,
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime  NULL,
	Modifiedby nvarchar(max) NULL,
	Alias nvarchar(250)Null,
	DiChi nvarchar(300)
)
go


------------------------------------Kho hàng
--Thông tin kho
Create table tb_Warehouse(--
	WarehouseId int IDENTITY(1,1) NOT NULL  primary key ,
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime ,
	Modifeby nvarchar(max),
	StoreId int -------
)
go


Create table tb_ImportWarehouse(------
	ImportWarehouseId int IDENTITY(1,1) NOT NULL  primary key ,
	CreatedBy nvarchar(250),
	CreateDate DateTime ,
	ModifiedDate datetime ,
	Modifeby nvarchar(max),
	NhanVienId int,
	ProductDetaiId int ,------
	QuanTity int ,
	WarehouseId int
)
go




--Xuất Kho
create table tb_ExportWareHouse(
	ExportWareHouseId int IDENTITY(1,1) NOT NULL  primary key ,
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime ,
	Modifeby nvarchar(max),
	NhanVienId int,
	OrderId int,
	WarehouseId int 
)
go

--Hang trả
create table tb_Return (
	ReturnId int IDENTITY(1,1) not null primary key ,
	Code nvarchar(max) NOT NULL,
	CreatedDate datetime,
	Confirm bit ,
	OrderId int ,
	IdKhachHang int,
	Satus nvarchar(max)
)
go



create table tb_ReturnDetail (
	Id int IDENTITY(1,1) NOT NULL primary key ,
	ReturnId int NOT NULL,
	Price decimal(18, 2) NOT NULL,
	Quantity int NOT NULL,
	ProductDetaiId int
)
go
------------------------------------Voucher
create table tb_Voucher (
	VoucherId int IDENTITY(1,1) NOT NULL primary key ,
	Code char(30),
	PhanTramGiam int , 
	Title nvarchar(250),
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime ,
	Modifeby nvarchar(max),
	UsedBy nvarchar(250),
	UsedDate DateTime ,
	Quantity int ,
	OrderId int 
)
go
------------------------------------Review

create table tb_Review (
	ReviewId int IDENTITY(1,1) NOT NULL primary key ,
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime ,
	Modifeby nvarchar(max),
	ProductDetaiId int 
)
go


create table tb_ReviewDetail (
	ReviewDetailId int IDENTITY(1,1) NOT NULL primary key ,
	CreatedBy nvarchar(max) NULL,
	CreatedDate datetime NOT NULL,
	ModifiedDate datetime ,
	Modifeby nvarchar(max),
	Content nvarchar (350),
	ReviewId int,
	IdKhachHang int 
)
go




--====================================================================================FK============================================================

--San Pham
alter table tb_ProductDetail
add constraint ProductDetaitoProductCategory
foreign key (ProductCategoryId)
references tb_ProductCategory 






alter table  tb_ProductDetail
add constraint ProductCompanytoProductDetai 
foreign key (ProductCompanyId)
references tb_ProductCompany



alter table  tb_ProductDetailProcessor
add constraint ProductstoProductDetailProcessor
foreign key (ProductDetaiId)
references tb_ProductDetail 

alter table  tb_ProductDetailMemory
add constraint ProductstoProductDetailMemory
foreign key (ProductDetaiId)
references tb_ProductDetail 

alter table  tb_ProductDetailConnect
add constraint ProductstoProductDetailConnect
foreign key (ProductDetaiId)
references tb_ProductDetail 

alter table  tb_ProductDetailPin
add constraint ProductstoProductDetailPin
foreign key (ProductDetaiId)
references tb_ProductDetail 

alter table  tb_ProductImage
add constraint ProductstoProductImage
foreign key (ProductDetaiId)
references tb_ProductDetail 

--alter table tb_ProductNew
--add constraint ProductNewtoProductDetai
--foreign key (ProductDetaiId)
--references tb_ProductDetai 

--alter table tb_ProducOld
--add constraint ProducOldtoProductDetai
--foreign key (ProductDetaiId)
--references tb_ProductDetai 

--alter table tb_ProductOldImage
--add constraint ProductOldImagetoProducOld
--foreign key (ProducOldId)
--references tb_ProducOld 

------------------Nhan Vien

alter table tb_Role
add constraint RoletoStaff
foreign key (NhanVienId)
references tb_Staff 

alter table tb_Role
add constraint RoletoFunction
foreign key (IdChucNang)
references tb_Function 


alter table   tb_Staff
add constraint StafftoFunction
foreign key (IdChucNang)
references tb_Function


alter table   tb_Staff
add constraint StafftoImage
foreign key (NhanVienId)
references tb_StaffImage



------------------Gio Hang

alter table tb_Cart
add constraint GioHangtoKhachHang
foreign key (IdKhachHang)
references tb_KhachHang 


 alter table tb_CartItem
add constraint CartItemtoProducdetai
foreign key (ProductDetaiId)
references tb_ProductDetail


alter table tb_CartItem
add constraint CartItemtoCart
foreign key (CartId)
references tb_Cart 


------------------Order

alter table tb_OrderDetail
add constraint OrderDetailtoOrder 
foreign key (OrderId)
references tb_Order 



alter table tb_OrderDetail
add constraint OrderDetailtKhachHang
foreign key (IdKhachHang)
references tb_KhachHang



alter table tb_OrderDetail
add constraint OrderDetailtoProductDetai
foreign key (ProductDetaiId)
references tb_ProductDetail


------------------ FK_WareHosue

alter table tb_ExportWareHouse
add constraint ExportWareHousetoOrder
foreign key (OrderId)
references tb_Order


alter table tb_ExportWareHouse
add constraint ExportWareHousetoWareHouse
foreign key (WarehouseId)
references tb_WareHouse


alter table tb_ExportWareHouse
add constraint ExportWareHousetoStaff
foreign key (NhanVienId)
references tb_Staff

alter table  tb_Warehouse
add constraint WarehousetoStore
foreign key (StoreId)
references tb_Store


---Nhập hàng

alter table  tb_ImportWarehouse
add constraint ImportWarehousetoWarehouse
foreign key (WarehouseId)
references tb_Warehouse

alter table  tb_ImportWarehouse
add constraint ImportWarehouseToProductDetail
foreign key (ProductDetaiId)
references tb_ProductDetail


alter table  tb_ImportWarehouse
add constraint ImportWarehouseToStaff
foreign key (NhanVienId)
references tb_Staff



------------------ FK_Hàng Trả
alter table tb_ReturnDetail
add constraint ReturnDetailtoReturn
foreign key (ReturnId)
references tb_Return


alter table tb_ReturnDetail
add constraint ReturnDetailtoProductDetai
foreign key (ProductDetaiId)
references tb_ProductDetail


alter table tb_Return
add constraint ReturntoOrder
foreign key (OrderId)
references tb_Order


alter table tb_Return
add constraint ReturntoKhachHang
foreign key (IdKhachHang)
references tb_KhachHang

------------------ FK_Voucher

alter table tb_Voucher
add constraint VouchertoOrder
foreign key (OrderId)
references tb_Order

------------------ FK_Voucher


alter table tb_ReviewDetail
add constraint ReviewDetailtoReview
foreign key (ReviewId)
references tb_Review 

alter table tb_ReviewDetail
add constraint ReviewDetailtoKhachHang
foreign key (IdKhachHang)
references tb_KhachHang

alter table tb_Review
add constraint ReviewDetailtoProductDetai
foreign key (ProductDetaiId)
references tb_ProductDetail



-------------------------------------Cưa hàng



