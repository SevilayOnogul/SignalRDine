# SignalRDine - Real-Time Restoran Yönetim Sistemi

Bu proje, modern .NET teknolojileri kullanılarak geliştirilmiş, anlık veri iletişimi (Real-Time) sağlayan kapsamlı bir restoran yönetim ve dashboard sistemidir.

## 🛠️ Yapılan Geliştirmeler
* **Mimari Kurulum:** Proje, profesyonel standartlara uygun olarak **6 katmanlı (N-Tier)** yapıda kurgulandı.
* **Veritabanı Tasarımı:** EF Core kullanılarak ilişkisel bir yapı oluşturuldu; Products ve Categories arasında bire-çok ilişki sağlandı.
* **SignalR & Real-Time Dashboard:** * Dashboard üzerindeki tüm veriler (Anlık Kasa, Sipariş Sayısı, Ortalama Fiyatlar vb.) sayfa yenilenmeden anlık olarak güncellenmektedir.
    * **Progress Bar Entegrasyonu:** Restoran doluluk oranları, aktif siparişler ve kapasite verileri anlık olarak dolan ilerleme çubukları ile görselleştirildi.
    * İstatistikler için optimize edilmiş kompleks **LINQ** sorguları geliştirildi.
* **Finansal Mantık & Kasa Yönetimi:** * **Automated Case Tracking:** SQL Trigger kullanılarak, sipariş tamamlandığında kasa (`MoneyCase`) toplamının otomatik güncellenmesi sağlandı.
    * **Precise Date Reporting:** Günlük ciroyu (TodayCash) hatasız hesaplamak için SQL ve .NET tarafındaki tarih uyumsuzlukları Data Annotation ve özel filtrelerle çözüldü.
* **Admin Paneli & UI:** `IHttpClientFactory` kullanılarak API uç noktalarıyla asenkron iletişim kuruldu. Modern bir admin teması entegre edilerek kullanıcı deneyimi artırıldı.
* **CRUD Operasyonları:** Menü yönetimi, rezervasyon sistemi, iletişim bilgileri ve sosyal medya modülleri tam entegre çalışmaktadır.

## 🏗️ Katman Yapısı
1. **SignalRDine.Api:** API uç noktaları ve Hub tanımlarının bulunduğu katman.
2. **SignalRDine.BusinessLayer:** İş mantığı ve validasyon süreçlerinin yönetildiği katman.
3. **SignalRDine.DataAccessLayer:** Entity Framework Core tabanlı Repository ve Context katmanı.
4. **SignalRDine.EntityLayer:** Veritabanı tablolarının karşılığı olan Domain nesneleri.
5. **SignalRDine.DtoLayer:** Veri güvenliği ve performans için tasarlanmış DTO sınıfları.
6. **SignalRDine.WebUI:** Kullanıcı arayüzü ve Admin panelinin (SignalR Client) bulunduğu katman.

## 🚀 Kullanılan Teknolojiler
* **.NET 8**
* **Entity Framework Core** (Code First & Fluent API)
* **SignalR** (Real-time Data Communication)
* **AutoMapper** (Object-to-Object Mapping)
* **MS SQL Server** & **T-SQL Triggers**
* **ASP.NET Core MVC** (Razor View Engine)
* **Swagger / OpenAPI** (API Documentation)
* **LineAwesome & FontAwesome** (UI Icons)

## ⚙️ Kurulum
1. `appsettings.json` dosyasındaki **Connection String** bilgisini kendi yerel SQL Server adresinize göre düzenleyin.
2. Package Manager Console üzerinden `Update-Database` komutunu çalıştırarak tabloları ve initial verileri oluşturun.
3. Önce API projesini, ardından WebUI projesini çalıştırın.
