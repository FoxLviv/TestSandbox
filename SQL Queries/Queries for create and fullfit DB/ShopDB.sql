Create Table Customers(
	CustomerID int PRIMARY KEY,
	CustomerName varchar(40) not null unique,
	ContactName varchar(100) not null unique,
	Address varchar(100) not null,
	City varchar(100) not null,
	PostalCode varchar(40) not null,
	Country varchar(40) not null
);
Create Table Categories(
	CategoryID int PRIMARY KEY,
	CategoryName varchar(40) not null unique,
	Description varchar(100)
);
Create Table Employees(
	EmployeeID int PRIMARY KEY,
	LastName varchar(40) not null unique,
	FirstName varchar(50) not null unique,
	BirthDate datetime not null,
	Phone varchar(70),
	Notes varchar(300)
);
Create Table Shippers(
	ShipperID int PRIMARY KEY,
	ShipperName varchar(40) not null unique,
	Phone varchar(20) not null unique
);
Create Table Suppliers(
	SupplierID int PRIMARY KEY,
	SupplierName varchar(40) not null unique,
	ContactName varchar(100) not null unique,
	Address varchar(100) not null,
	City varchar(100) not null,
	PostalCode varchar(40) not null,
	Country varchar(56) not null,
	Phone varchar(20) not null unique
);
create table Orders(
	OrderID int PRIMARY KEY,
	CustomerID int not null foreign key references Customers(CustomerID),
	EmployeeID int not null foreign key references Employees(EmployeeID),
	OrderDate datetime not null,
	ShipperID int not null foreign key references Shippers(ShipperID)
);
Create Table Products(
	ProductID int PRIMARY KEY,
	ProductName varchar(80) not null unique,
	SupplierID int not null foreign key references Suppliers(SupplierID),
	CategoryID int not null foreign key references Categories(CategoryID),
	Unit varchar(70),
	Price float
);
Create Table OrderDetails(
	OrderDetailID int PRIMARY KEY,
	OrderID int not null foreign key references Orders(OrderID),
	ProductID int not null foreign key references Products(ProductID),
	Quantity int
);