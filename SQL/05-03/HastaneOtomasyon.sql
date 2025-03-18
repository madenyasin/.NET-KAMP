create database Hastane4

create table Hastaneler(
	Id int primary key identity(1,1),
	Ad nvarchar(100) not null,
	Adres nvarchar(250) null,
	Telefon nvarchar(15) unique not null,
	Kapasite int check(Kapasite > 0),
	KurulusYili int check((KurulusYili > 1900) and (KurulusYili < year(getdate()))),
	Sehir nvarchar(100) not null check(
		lower(Sehir) = 'istanbul' or
		lower(Sehir) = 'ankara' or
		lower(Sehir) = 'izmir'
	)
)

create table Uzmanliklar(
	Id int primary key identity(1,1),
	Ad nvarchar(100) not null,
	Aciklama nvarchar(250) not null,
)

create table Doktorlar(
	Id int primary key identity(1,1),
	Ad nvarchar(100) not null,
	Soyad nvarchar(100) not null,
	DeneyimYili int check(DeneyimYili > 0),
	Maas int check(70000 > 0),
	Email nvarchar(100) unique null,

	UzmanlikId int not null,
	hastaneId int not null,

	constraint fk_uzmanlik foreign key(UzmanlikId) references Uzmanliklar(Id),
	constraint fk_hastane foreign key(hastaneId) references Hastaneler(Id)
)

create table Hastalar(
	Id int primary key identity(1,1),
	Ad nvarchar(100) not null,
	Soyad nvarchar(100) not null,
	DogumTarihi datetime null,
	Cinsiyet nvarchar(1) check(lower(cinsiyet) = 'e' or lower(cinsiyet) = 'k'),
	EvTelefon nvarchar(10) default 'Belirsiz' null,
	CepTelefon nvarchar(11) not null,
	Email nvarchar(100) unique null,
	SigortaTuru nvarchar(100) not null check(
		lower(SigortaTuru) = 'sgk' or
		lower(SigortaTuru) = 'özel' or
		lower(SigortaTuru) = 'yok'
	)
)

create table Randevular(
	Id int primary key identity(1,1),
	HastaId int not null,
	DoktorId int not null,
	RandevuTarihi datetime check(RandevuTarihi <= getdate()) not null,
	Ucret money check(Ucret > 0),
	Durum nvarchar(100) not null check(
		lower(Durum) = 'beklemede' or
		lower(Durum) = 'ödendi' or
		lower(Durum) = 'iptal'
	),

	unique(HastaId, DoktorId, RandevuTarihi),
	unique(HastaId, RandevuTarihi),
	unique(DoktorId, RandevuTarihi),
	constraint fk_hasta foreign key(HastaId) references Hastalar(Id),
	constraint fk_doktor foreign key(DoktorId) references Doktorlar(Id),
)

create table IlacKategoriler(
	Id int primary key identity(1,1),
	Ad nvarchar(100) unique not null,
)

create table Ilaclar(
	Id int primary key identity(1,1),
	Ad nvarchar(100) unique not null,
	Fiyat int check(fiyat > 0),
	UretimTarihi datetime check(uretimtarihi <= getdate()),
	RafOmru int check(RafOmru > 0),
	KategoriId int not null,

	constraint fk_kategori foreign key(KategoriId) references IlacKategoriler(Id)
)

create table Receteler(
	Id int primary key identity(1,1),
	RandevuId int not null,
	OlusturmaTarihi datetime check (OlusturmaTarihi < getdate())

	constraint fk_randevu foreign key(RandevuId) references Randevular(Id)
)

create table ReceteDetaylar(
	Id int primary key identity(1,1),
	ReceteId int not null,
	IlacId int not null,
	Adet int check(adet> 0),
	GunlukDoz int check(GunlukDoz> 0),
	KullanimAciklamasi nvarchar(360) null,
	constraint fk_recete foreign key(ReceteId) references Receteler(Id),
	constraint fk_ilac foreign key(IlacId) references Ilaclar(Id)
)


-------------------------------------
-- Hastaneler Tablosu
INSERT INTO Hastaneler (Ad, Adres, Telefon, Kapasite, KurulusYili, Sehir) VALUES
('Acıbadem Hastanesi', 'Kadıköy, İstanbul', '02165555555', 500, 1995, 'İstanbul'),
('Memorial Hastanesi', 'Şişli, İstanbul', '02123333333', 350, 2000, 'İstanbul'),
('Başkent Hastanesi', 'Çankaya, Ankara', '03124444444', 600, 1985, 'Ankara'),
('Gazi Hastanesi', 'Çankaya, Ankara', '03122222222', 400, 1978, 'Ankara'),
('Ege Üniversitesi Hastanesi', 'Bornova, İzmir', '02323333333', 800, 1955, 'İzmir');

-- Uzmanliklar Tablosu
INSERT INTO Uzmanliklar (Ad, Aciklama) VALUES
('Kardiyoloji', 'Kalp ve damar hastalıkları uzmanlık alanı'),
('Nöroloji', 'Sinir sistemi hastalıkları uzmanlık alanı'),
('Ortopedi', 'Kas ve iskelet sistemi hastalıkları uzmanlık alanı'),
('Dahiliye', 'İç hastalıkları uzmanlık alanı'),
('Çocuk Sağlığı ve Hastalıkları', 'Çocukların sağlık sorunları ile ilgilenen uzmanlık alanı');

-- Doktorlar Tablosu
INSERT INTO Doktorlar (Ad, Soyad, DeneyimYili, Maas, Email, UzmanlikId, hastaneId) VALUES
('Ahmet', 'Yılmaz', 15, 65000, 'ahmetyilmaz@example.com', 1, 1),
('Ayşe', 'Demir', 10, 60000, 'aysedemir@example.com', 2, 1),
('Mehmet', 'Çelik', 20, 68000, 'mehmetcelik@example.com', 3, 2),
('Fatma', 'Kaya', 8, 58000, 'fatmakaya@example.com', 4, 2),
('Ali', 'Şahin', 12, 62000, 'alisahin@example.com', 5, 3);

-- Hastalar Tablosu
INSERT INTO Hastalar (Ad, Soyad, DogumTarihi, Cinsiyet, CepTelefon, Email, SigortaTuru) VALUES
('Elif', 'Güneş', '1990-05-15', 'K', '5321111111', 'elifgunes@example.com', 'SGK'),
('Can', 'Yıldırım', '1985-10-20', 'E', '5332222222', 'canyildirim@example.com', 'Özel'),
('Deniz', 'Aydın', '1998-03-08', 'K', '5353333333', 'denizaydin@example.com', 'SGK'),
('Ege', 'Demir', '1980-12-01', 'E', '5364444444', 'egedemir@example.com', 'Yok'),
('Zeynep', 'Kara', '2000-07-25', 'K', '5385555555', 'zeynepkara@example.com', 'Özel');

-- Randevular Tablosu
INSERT INTO Randevular (HastaId, DoktorId, RandevuTarihi, Ucret, Durum) VALUES
(1, 3, '2024-07-29 10:00:00', 300, 'Ödendi'),
(2, 2, '2024-07-29 14:00:00', 250, 'Beklemede'),
(3, 3, '2024-07-30 09:00:00', 400, 'Ödendi'),
(4, 4, '2024-07-30 11:00:00', 200, 'İptal'),
(5, 5, '2024-07-31 13:00:00', 350, 'Beklemede');

-- IlacKategoriler Tablosu
INSERT INTO IlacKategoriler (Ad) VALUES
('Ağrı Kesici'),
('Antibiyotik'),
('Vitamin'),
('Antidepresan'),
('Mide İlacı');

-- Ilaclar Tablosu
INSERT INTO Ilaclar (Ad, Fiyat, UretimTarihi, RafOmru, KategoriId) VALUES
('Parol', 25, '2023-01-15', 24, 1),
('Augmentin', 50, '2023-03-20', 18, 2),
('Supradyn', 75, '2023-05-10', 36, 3),
('Prozac', 100, '2023-02-01', 24, 4),
('Lansor', 40, '2023-04-05', 12, 5);

-- Receteler Tablosu
INSERT INTO Receteler (RandevuId, OlusturmaTarihi) VALUES
(1, '2024-07-29 10:30:00'),
(2, '2024-07-29 14:30:00'),
(3, '2024-07-30 09:30:00'),
(4, '2024-07-30 11:30:00'),
(5, '2024-07-31 13:30:00');

-- ReceteDetaylar Tablosu
INSERT INTO ReceteDetaylar (ReceteId, IlacId, Adet, GunlukDoz, KullanimAciklamasi) VALUES
(1, 1, 1, 2, 'Sabah ve akşam yemeklerden sonra'),
(1, 3, 1, 1, 'Her gün bir tane'),
(2, 2, 1, 2, 'Sabah ve akşam aç karnına'),
(3, 4, 1, 1, 'Sabahları aç karnına'),
(4, 5, 1, 1, 'Akşam yemeğinden sonra');