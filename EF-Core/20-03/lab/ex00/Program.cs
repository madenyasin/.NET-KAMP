/*
 bir sahaf için bir kitap uygulaması geliştirilecektir.
bir kıtabın birden fazla yazarı olabilir.
bir kitabın sadece bir tane kategorisi olabilir.
kitapların; ad, fiyat, isbn, sayfa sayisi, basim tarihi, baski sayisi, özet, kapak resmi
kitabın  tek boyutlu ve iki boyutlu kodu (resim path ) olarak ayrı yerde tutulmalı 

ef core -> code first -> model first
 */


using ex00.Data;

KutuphaneContext kutuphaneContext = new KutuphaneContext();

kutuphaneContext.Database.EnsureDeleted();
kutuphaneContext.Database.EnsureCreated();

