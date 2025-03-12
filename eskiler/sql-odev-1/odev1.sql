create database clothing_store

create table categories(
Id int primary key identity(1,1),
Name nvarchar(30) not null
)

create table sizes(
Id int primary key identity(1,1),
Name nvarchar(30) not null
)

create table products(
Id int primary key identity(1,1),
Name nvarchar(50) not null,
Barcode nvarchar(6) not null unique,
Price money not null,
category_id int not null
constraint fk_categories foreign key(category_id) references categories(Id)
)

drop table products

create table product_variants(
Id int primary key identity(1,1),
Product_id int not null,
Size_id int not null,
Color nvarchar(30) null,
In_stock int null
constraint fk_products foreign key(Product_id) references products(Id),
constraint fk_sizes foreign key(Size_id) references sizes(Id),

)