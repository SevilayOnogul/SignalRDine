# SignalRDine - Restoran Yönetim Sistemi

Bu proje, modern teknolojiler kullanılarak geliştirilmiş, anlık veri iletişimi sağlayan bir restoran yönetim sistemidir.

## 🛠️ Şu Ana Kadar Neler Yapıldı?
* **Mimari Kurulum:** Proje, profesyonel standartlara uygun olarak **6 katmanlı (N-Tier)** yapıda kuruldu.
* **Veritabanı Tasarımı:** Restoran ihtiyaçlarına yönelik tablolar tasarlandı ve EF Core ile SQL Server bağlantısı yapıldı.
* **DTO ve AutoMapper:** Veri güvenliği için DTO yapısı kurgulandı ve AutoMapper entegrasyonu tamamlandı.
* **İlişkisel Veri Yapısı:** Ürünler ve Kategoriler arasında bire-çok ilişki kurgulandı; **Include** metodu ile ilişkili verilerin çekilmesi sağlandı.
* **Admin Paneli Hazırlığı:** UI tarafında projenin ana iskeletini oluşturacak olan **Admin Layout** yapısı kuruldu.
* **Dinamik Tema Entegrasyonu:** Admin paneli için modern bir tema entegre edildi ve tüm sayfaların bu iskelet üzerinden yönetilmesi için gerekli `AdminLayoutController` yapısı oluşturuldu.
* **API Tüketimi (Consume):** `IHttpClientFactory` kullanılarak API uç noktaları WebUI tarafında tüketildi. Kategori listeleme ve asenkron silme işlemleri başarıyla entegre edildi.

## 🏗️ Katman Yapısı
1. **SignalRDine.Api:** API uç noktalarının bulunduğu katman.
2. **SignalRDine.BusinessLayer:** İş mantığının ve kontrollerin yapıldığı yer.
3. **SignalRDine.DataAccessLayer:** Veritabanı erişim ve Repository katmanı.
4. **SignalRDine.EntityLayer:** Veritabanı tablolarının karşılığı olan sınıflar.
5. **SignalRDine.DtoLayer:** Veri taşıma nesnelerinin (DTO) bulunduğu katman.
6. **SignalRDine.WebUI:** Kullanıcı arayüzü ve Admin panelinin yönetildiği, API'yi tüketen katman.

## 🚀 Kullanılan Teknolojiler
* .NET 8
* Entity Framework Core (Code First & Fluent API)
* **AutoMapper**
* SignalR (Real-time)
* MS SQL Server
* ASP.NET Core MVC (Layout & View Engine)
* Swagger / OpenAPI
