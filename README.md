# 🍽️ SignalRDine – Restaurant Management System

Bu proje, **ASP.NET Core Web API** ve **ASP.NET Core MVC (WebUI)** kullanılarak geliştirilmiş,  
**çok katmanlı mimariye (N-Tier / Layered Architecture)** sahip bir restoran yönetim sistemidir.

Proje; **gerçek bir restoran senaryosu** baz alınarak masa yönetimi, sipariş akışı, anlık bildirimler, QR kod işlemleri ve finansal süreçleri kapsayacak şekilde; **performans, sürdürülebilirlik ve ölçeklenebilirlik** prensipleri gözetilerek geliştirilmiştir.

> 📌 Proje, birebir dersler takip edilerek uygulanmış olup; sektör standartlarına uygun mimari ve kodlama pratiklerini öğrenme ve pekiştirme amacı taşımaktadır.

---

## 🧩 Mimari Yapı

- **Entity Layer** → Veritabanı varlıkları  
- **Data Access Layer** → EF Core ile veri erişimi  
- **Business Layer** → İş kuralları ve servisler  
- **Web API** → RESTful servisler  
- **WebUI (MVC)** → Kullanıcı arayüzü  
- **DTO Layer** → Güvenli ve kontrollü veri transferi  
- **Test Layer** → xUnit ile birim testleri (Unit Tests)

---

## 🚀 Öne Çıkan Özellikler

### 🛡️ Kalite Güvencesi & Güvenlik
- **xUnit Unit Testing:** Ürün fiyat mantığı, AutoMapper eşleşmeleri ve Entity ilişkileri (Category-Product-Order) için kapsamlı test senaryoları kurgulandı.
- **Global Exception Handling:** Özel yazılan **Middleware** ile uygulama genelindeki tüm hatalar merkezi olarak yakalanır; sistem çökmesi engellenerek kullanıcıya profesyonel JSON yanıtları dönülür.
- **Serilog Logging:** Uygulamanın tüm hareketleri ve hata kayıtları dosya tabanlı olarak loglanır, izlenebilirlik maksimize edildi.
- **Identity & Authorization:** ASP.NET Core Identity ile rol bazlı yetkilendirme ve global authorize filtreleri uygulandı.
- **🔧 Service Extensions:** Bağımlılık yönetimi (DI) ve konfigürasyonlar özel Extension metodları ile temiz bir yapıda sunuldu.

### 🌍 Dünya Mutfağı Entegrasyonu
- **RapidAPI (Tasty) Entegrasyonu:** Dış kaynaktan çekilen verilerle tarif videoları, görseller ve hazırlık sürelerini içeren geniş bir yemek listesi sunuldu.

### 🪑 Masa Seçimi & Akıllı Yönlendirme
- **Durum Bazlı Görselleştirme:** Masaların anlık doluluk durumuna göre (Boş/Dolu) Yeşil/Kırmızı renk kodları ve özel ikonlarla dinamik gösterimi sağlandı.
- **Akıllı İş Akışı:**
    - **Boş Masalar:** Müşteriyi doğrudan ürün seçim menüsüne yönlendirir.
    - **Dolu Masalar:** Ödeme ve adisyon kontrolü için doğrudan sepet sayfasına yönlendirilir.

### 🧾 Gelişmiş Sepet & Hesaplama Sistemi
- **AJAX Destekli Sepet:** Sayfa yenilenmeden ürün ekleme ve çıkarma işlemleri.
- **Yüksek Performanslı Hesaplama:** %10 KDV ve Genel Toplam hesaplamaları, performans odaklı asenkron mantıkla yönetildi.

### 📱 QR Kod Yönetimi
- **QRCoder** ile dinamik QR kod oluşturma ve **ZXing.Net** ile QR kod çözümleme altyapısı.

### ⚡ SignalR – Gerçek Zamanlı İletişim
- Anlık bildirim altyapısı, masa durumlarının canlı takibi ve Dashboard veri güncellemeleri.

### 📖 API Dokümantasyonu
- **Swagger & XML Docs:** Her endpoint, parametre ve dönüş tipi Swagger üzerinde detaylıca dökümante edildi.
- **Postman:** API testleri için organize edilmiş koleksiyonlar hazırlandı.

---

## 🛠 Kullanılan Teknolojiler

- **Backend:** .NET 8, Web API, EF Core, Identity, SignalR, AutoMapper.
- **Testing:** xUnit, Moq, FluentAssertions.
- **Logging & Monitoring:** Serilog.
- **Frontend:** ASP.NET Core MVC, AJAX, Bootstrap, JavaScript.
- **Araçlar:** QRCoder, ZXing.Net, MailKit, MimeKit.
- **Veritabanı:** MS SQL Server.

---

## 🔐 Güvenlik & Yapılandırma

- Global Authorization Policy.
- **HttpClient Factory:** Socket exhaustion riskini önlemek için merkezi HTTP yönetimi.
- Exception Middleware & Logging Pipeline.

---

## 📌 Amaç

Bu proje ile katmanlı mimari mantığını kavramak, gerçek zamanlı (real-time) uygulamalar geliştirmek ve kurumsal projelere uygun backend & frontend yapılarını deneyimlemek amaçlanmıştır.
