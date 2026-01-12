# SignalRDine - Restoran Yönetim Sistemi

Bu proje, modern teknolojiler kullanılarak geliştirilmiş, anlık veri iletişimi sağlayan bir restoran yönetim sistemidir.

## 🛠️ Şu Ana Kadar Neler Yapıldı?
* **Mimari Kurulum:** Proje, profesyonel standartlara uygun olarak **5 katmanlı (N-Tier)** yapıda kuruldu.
* **Veritabanı Tasarımı:** Restoran ihtiyaçlarına yönelik (Kategori, Ürün, Masa, Rezervasyon vb.) tablolar tasarlandı.
* **Bağlantı Ayarları:** Entity Framework Core kullanılarak SQL Server bağlantısı yapıldı.
* **İlk Göç (Migration):** Veritabanı tabloları kod tarafında oluşturulup SQL tarafına başarıyla aktarıldı.
* **DTO ve AutoMapper:** Veri güvenliği için **DTO** yapısı kurgulandı ve tüm dönüşümler için **AutoMapper** entegrasyonu tamamlandı.
* **API Endpoints:** Tüm nesneler için CRUD işlemlerini yöneten profesyonel API uç noktaları yazıldı.

## 🏗️ Katman Yapısı
1. **SignalRDine.Api:** API uç noktalarının bulunduğu katman.
2. **SignalRDine.BusinessLayer:** İş mantığının ve kontrollerin yapıldığı yer.
3. **SignalRDine.DataAccessLayer:** Veritabanı erişim ve Repository katmanı.
4. **SignalRDine.EntityLayer:** Veritabanı tablolarının karşılığı olan sınıflar.
5. **SignalRDine.DtoLayer:** Veri taşıma nesnelerinin (DTO) bulunduğu katman.



## 🚀 Kullanılan Teknolojiler
* .NET 8
* Entity Framework Core
* **AutoMapper**
* SignalR (Real-time)
* MS SQL Server
* N-Tier Architecture
* Swagger / OpenAPI
