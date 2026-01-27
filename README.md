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

---

## 🚀 Öne Çıkan Özellikler

### 🔐 Kimlik Doğrulama & Yetkilendirme
- ASP.NET Core **Identity** ile kullanıcı ve rol yönetimi.
- Global **Authorize Filter Policy** ile sayfa bazlı güvenlik.
- Yetkisiz veya hatalı URL erişimlerinde kullanıcı deneyimini artırmak amacıyla özel 404 hata sayfası entegre edildi.
- **🔧 Service Extensions:** `Program.cs` dosyasındaki kod kalabalığını önlemek ve bağımlılık yönetimini (Dependency Injection) daha temiz bir yapıda sunmak amacıyla özel  **Extension Methods** yapısı kurgulandı.

### 🌍 Dünya Mutfağı Entegrasyonu
- **RapidAPI (Tasty) Entegrasyonu:** Dış kaynaktan çekilen verilerle tarif videoları, görseller ve hazırlık sürelerini içeren geniş bir yemek listesi sunuldu.

### 🪑 Masa Seçimi & Akıllı Yönlendirme
- **Durum Bazlı Görselleştirme:** Masaların anlık doluluk durumuna göre (Boş/Dolu) Yeşil/Kırmızı renk kodları ve özel ikonlarla (Sandalye/Kasa) dinamik gösterimi sağlandı.
- **Akıllı İş Akışı:** - **Boş Masalar:** Müşteriyi doğrudan ürün seçim menüsüne yönlendirir.
    - **Dolu Masalar:** Ödeme ve adisyon kontrolü için doğrudan sepet sayfasına yönlendirilir.
- **Kullanıcı Deneyimi:** Breadcrumb yapısı ve Bootstrap bileşenleri ile optimize edilmiş masa seçim süreci tasarlandı.

### 🧾 Gelişmiş Sepet & Hesaplama Sistemi
- **AJAX Destekli Sepet:** Sayfa yenilenmeden ürün ekleme ve çıkarma işlemleri.
- **Yüksek Performanslı Hesaplama:** %10 KDV ve Genel Toplam hesaplamaları, performans odaklı döngü dışı mantıkla asenkron olarak yönetildi.
- **Ürün Gruplama:** LINQ ve GroupBy kullanılarak aynı ürünlerin adet bazlı listelenmesi sağlandı.

### 📱 QR Kod Yönetimi
- **QRCoder** ile dinamik QR kod oluşturma ve Base64 formatında indirme.
- **ZXing.Net** ile görsel üzerinden QR kod çözümleme.
- Masa ve menü entegrasyonu ile temassız sipariş altyapısı.

### ⚡ SignalR – Gerçek Zamanlı İletişim
- Anlık bildirim altyapısı ve masa durumlarının canlı takibi.
- Dashboard üzerinde real-time veri güncellemeleri.

### 📧 Mail Servis Entegrasyonu 
- **MailKit & MimeKit** ile profesyonel SMTP altyapısı.
- **Summernote (Rich Text Editor)** entegrasyonu ile zengin içerikli mail gönderimi.

---

## 🛠 Kullanılan Teknolojiler

- **Backend:** .NET 8, Web API, EF Core, Identity, SignalR, AutoMapper.
- **Frontend:** ASP.NET Core MVC, AJAX, HTML5/CSS3, Bootstrap, JavaScript.
- **Araçlar:** QRCoder, ZXing.Net, MailKit, MimeKit, Font Awesome.
- **Veritabanı:** MS SQL Server.

---

## 🔐 Güvenlik & Yapılandırma

- Global Authorization Policy.
- Güçlü şifre politikaları ve Authentication middleware yapılandırması.
- **HttpClient Factory:** Socket exhaustion riskini önlemek için merkezi HTTP yönetimi.
- Service Extensions

---

## 📌 Amaç

Bu proje ile katmanlı mimari mantığını kavramak, gerçek zamanlı (real-time) uygulamalar geliştirmek ve kurumsal projelere uygun backend & frontend yapılarını deneyimlemek amaçlanmıştır.
