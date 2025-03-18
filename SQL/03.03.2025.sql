-- commenttttt
/*

VERİ TİPLERİ

-- METİNSEL VERİ TİPLERİ

1) char(n) -> n karakter sayısını ifade eder.
unicode desteklemez.
8000 karakter.
belirtilenden az sayıda harf kulanılsa da yine tüm alanını kaplar. (katı)

2) nchar(n) -> unicode destekler.
4000 karakter yer tutabilir.
n kadar yer kaplar.

3) varchar(n) -> univcode desteklemez. 8000. N'den az karakter kullanılırsa, kullanıldığı yer kadar yer kaplar.

4) nvarchar(n) -> unicode destekler, 4000, kullanıldığı kadar yer kaplar.


5) text : unicode desteklemez, 8000 karakterden fazlası için, katı
6) ntext : unicode desteklemez, 8000 karakterden fazlası için, katı


--SAYISAL VERİ TİPLERİ

1) tinyint: 0-255 arası değerleri tutar. 1byte

2) smallint: -32k, +32k, 2 byte

3) int : -2 milyar / +2 milyar arasındaki değerleri tutabilir.	4 byte

4) bigint: +- 2 üssü 63

bit true(1) false(0) futar.
decimal
float


PARASAL VERİ TİPLERİ
smallmoney
money

TARİHSEL VERİ TİPLERİ
date
datetime
time

*/



/*
DML - DATA MANIPULATION LANGUAGE - VERİ TANIMLAMA DİLİ

insert / insert into : veri eklemek 
update : veriyi güncellemek için
delete : veriyi silmek için kullanılır
select : verileri seçmek için kullanılır. (DQL - data query language)

*/

/*
DDL - DATA DEFINITION LANGUAGE

create : veritabanı nesnesi oluşturmak için (table, sp, function, ...)
alter : veritabanı nesnesini güncellemek için kullanılır.
drop : mevcuttaki bir nesneyi silmek için kullanılır. (PK numarası kaldığı yerden devam eder.)
truncate: mevcuttaki tablonun içini boşaltır. (tabloyu silmez) (PK numarası sıfırlanır)
*/



/*
SORU: Bir bilgeadam database'i oluşturunuz. İçerisine öğrenciiler tablosu oluşturunuz. 
Her öğrencinin ad, soyad, mail, dogumtarihi, cinsiyet bilgisi olsun.
id bilgisi 100'den başlasın. cinsiyet bilgisi tek karakter tutulsun. E ya da K ile girilebilsin.
*/

--CEVAP
CREATE DATABASE [Bilge Adam Teknoloji];

CREATE TABLE Personeller
(
ID int primary key identity(100,1),
Ad nvarchar(40) not null,
Soyad nvarchar(50) ,
Mail nvarchar(60) not null,
[Dogum Tarihi] date null,
Cinsiyet char(1) check(Cinsiyet = 'e' or Cinsiyet = 'k')

)


insert Personeller (Soyad,Ad,Mail,Cinsiyet) values ('yılmaz' , 'ali', 'ali@gmail.com', 'e')

insert Personeller (Soyad,Ad,Mail,Cinsiyet) values ('yılmaz' , 'ece', 'ali@gmail.com', 'k')


create database Satis

create table Kategoriler
(
Id int primary key identity(1,1),
Aciklama nvarchar(200) null,
Ad nvarchar(40) not null,
[Olusturma Tarihi] Date null
)

create table Urunler
(
Id int primary key identity(1000,2),
Ad nvarchar(50) not null,
Fiyat money not null,
Stok int not null,
IndirimVarMi bit not null,
KategoriId int not null,
constraint fk_kategori foreign key(KategoriId) references Kategoriler(Id)
)



create database DershaneBilge


create table Kurslar(
Id int primary key identity(1,1),
Ad nvarchar(40) not null,
Kontenjan int not null
)

create table Ogrenciler(
Id int primary key identity(1,1),
Ad nvarchar(40) not null,
Soyad nvarchar(40) not null,
)

create table OgrenciKurs(
OgrenciId int not null,
KursId int not null,
primary key(OgrenciId, KursId),
Constraint fk_kurs foreign key(KursId) references Kurslar(Id),
Constraint fk_ogrenci foreign key(OgrenciId) references Ogrenciler(Id)
) 

/*
üye - kitap - yazar arasında bir ilişki bulunaktadır.
üye bir kitabı ödünç alabilir, bir kitap farklı üyelerce ödünç alınabilir.
bir kitabın birden fazla yazarı olabilir ve tabiki bir yazar birden fazla kitap yazmıpş olabilir.

kitap: id,ad,sayfa sayısı, fiyat, çnsöz, basımevi, isbno bilgilerine sahiptir.
fiyat 500den büyük olmalıdır
basımevini boş geçmek isteyenler olabilir ancak geçildiğinde defaultta "lütfen bilgi giriniz" yazmalıdır.

yazar: id,ad,soyad,mail,tc,dogumtarihi alanları olmalıdır
mail ve tc eşsizdir.
tc boş geçilemez, mail boş geçilebilir.
yazar 18den büyük olmalıdır

üye: id, username, kayıt tarihi, tc, mail bilgileri olmalıdır.
tc boş olamaz. ve 11 karakter olmak zorudadır. eşsizdir.
username eşsizdir ve boş olamaz.
mail eşsiz ve mail formatında olmalıdır. (@ ve . içerme kontrolü)
kayıt tarihi ileri bir tarih olamaz.

*/

create database Kutuphane2

create table Kitaplar(
Id int primary key identity(1,1),
Ad nvarchar(50) not null,
Sayfa_Sayisi int null,
Fiyat int not null check(Fiyat > 500),
Onsoz nvarchar(1000) null,
Basim_Evi nvarchar(100) default 'Lütfen bilgi giriniz.',
ISBNO nvarchar(50) not null
)

create table Yazarkitap(
KitapId int not null,
YazarId int not null,
primary key(KitapId,YazarId),
constraint fk_yazar foreign key(YazarId) references Yazarlar(Id),
constraint fk_kitap foreign key(KitapId) references Kitaplar(Id),
)

create table Yazarlar(
Id int primary key identity(1,1),
Ad nvarchar(50) not null,
Soyad nvarchar(50) not null,
Mail nvarchar(50) null UNIQUE(Mail),
TcNo nvarchar(50) not null UNIQUE(TcNo),
Dogum_Tarihi Datetime Check(GETDATE() - Dogum_Tarihi > 18)
)

create table Uyeler(
Id int primary key identity(1,1),
UserName nvarchar(50) not null UNIQUE(UserName),
Kayit_Tarihi Datetime check(Kayit_Tarihi < getdate()),
TcNo nvarchar(11) not null UNIQUE(TcNo) Check(len(TcNo) = 11),
Mail nvarchar(50) null UNIQUE(Mail) check(Mail LIKE '%@%' and Mail LIKE '%.%' ) ,
KitapId int not null,
constraint fk_kitap_uye foreign key(KitapId) references Kitaplar(Id)

)

