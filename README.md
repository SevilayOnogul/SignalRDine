# SignalRDine - Restoran Yönetim Sistemi

Bu proje, modern teknolojiler kullanılarak geliştirilmiş, anlık veri iletişimi sağlayan bir restoran yönetim sistemidir.

## 🛠️ Şu Ana Kadar Neler Yapıldı?
* **Mimari Kurulum:** Proje, profesyonel standartlara uygun olarak **6 katmanlı (N-Tier)** yapıda kuruldu.
* **Veritabanı Tasarımı:** Restoran ihtiyaçlarına yönelik tablolar tasarlandı ve EF Core ile SQL Server bağlantısı yapıldı.
* **DTO ve AutoMapper:** Veri güvenliği için DTO yapısı kurgulandı ve AutoMapper entegrasyonu tamamlandı.
* **İlişkisel Veri Yapısı:** Ürünler ve Kategoriler arasında bire-çok ilişki kurgulandı; **Include** metodu ile ilişkili verilerin çekilmesi sağlandı.
* **Admin Paneli & Tema:** Modern bir admin teması entegre edildi ve UI tarafı `IHttpClientFactory` kullanılarak API uç noktalarıyla asenkron şekilde bağlandı.
* **CRUD Operasyonları:** About, Booking, Contact, Discount, SocialMedia ve Testimonial modülleri API üzerinden tam entegre edildi.
* **SignalR & Real-Time İstatistik:** Dashboard üzerindeki verilerin (en pahalı ürün, kategori sayısı vb.) anlık güncellenmesi için SignalR altyapısı ve optimize edilmiş LINQ sorguları geliştirildi.
* **Finansal Mantık & Kasa Yönetimi:** * **Automated Case Tracking:** SQL Trigger kullanılarak, sipariş tamamlandığında kasa (`MoneyCase`) toplamının otomatik güncellenmesi sağlandı.
    * **Precise Date Reporting:** `DateTime` ve SQL `Date` tipi arasındaki uyumsuzluklar, Data Annotation (`[Column(TypeName="Date")]`) kullanılarak çözüldü.
    * **Daily Earnings:** Günlük toplam ciroyu (`TodayTotalPrice`) hesaplayan hatasız raporlama mantığı kuruldu.

## 🏗️ Katman Yapısı
1. **SignalRDine.Api:** API uç noktalarının bulunduğu katman.
2. **SignalRDine.BusinessLayer:** İş mantığının ve kontrollerin yapıldığı yer.
3. **SignalRDine.DataAccessLayer:** Veritabanı erişim ve Repository katmanı.
4. **SignalRDine.EntityLayer:** Veritabanı tablolarının karşılığı olan sınıflar.
5. **SignalRDine.DtoLayer:** Veri taşıma nesnelerinin (DTO) bulunduğu katman.
6. **SignalRDine.WebUI:** Kullanıcı arayüzü ve Admin panelinin yönetildiği katman.

## 🚀 Kullanılan Teknolojiler
* **.NET 8**
* **Entity Framework Core** (Code First & Fluent API)
* **SignalR** (Real-time / Anlık Veri İletişimi)
* **AutoMapper** (Nesne Eşleme)
* **MS SQL Server** & **T-SQL Triggers**
* **ASP.NET Core MVC** (Layout & View Engine)
* **Swagger / OpenAPI**
