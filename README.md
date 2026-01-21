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
- **DTO Katmanı** → Güvenli ve kontrollü veri transferi  

---

## 🚀 Öne Çıkan Özellikler

### 🔐 Kimlik Doğrulama & Yetkilendirme
- ASP.NET Core **Identity** ile kullanıcı ve rol yönetimi
- Global **Authorize Filter** ile sayfa bazlı güvenlik
- Login / AccessDenied yönlendirmeleri

### ⚡ SignalR – Gerçek Zamanlı İletişim
- Anlık bildirimler
- Masa ve sipariş durumlarının canlı takibi
- Dashboard üzerinde real-time veri güncellemeleri

### 🧾 CRUD, Sepet ve Asenkron İşlemler
- Menü, rezervasyon, iletişim ve içerik yönetimi için CRUD operasyonları
- **AJAX destekli sepet yönetimi** (sayfa yenilenmeden ekleme/çıkarma)
- Business katmanında **%10 KDV ve genel toplam hesaplamaları**
- AutoMapper ile DTO–Entity dönüşümleri

### 📊 Dashboard & Yönetim Paneli
- Yönetici paneli üzerinden:
  - Sipariş takibi
  - Masa doluluk durumu
  - Finansal özetler
- Modern ve sade admin arayüzü

### 📱 QR Kod Yönetimi
- **QRCoder** ile dinamik QR kod oluşturma
- QR kod görselini Base64 formatında üretme ve indirme
- **ZXing.Net** ile QR kod çözümleme (görsel üzerinden)
- Masa, menü veya özel linkler için kullanım senaryoları

---

## 🛠 Kullanılan Teknolojiler

- **C#**
- **.NET 8**
- **ASP.NET Core MVC**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SignalR**
- **ASP.NET Core Identity**
- **MS SQL Server**
- **AutoMapper**
- **AJAX**
- **QRCoder**
- **ZXing.Net**
- **HTML / CSS / Bootstrap**
- **JavaScript**
- **Font Awesome**
- **Visual Studio**

---

## 🔐 Güvenlik & Yapılandırma

- Global Authorization Policy
- Şifre kuralları:
  - En az 6 karakter
  - Büyük harf, küçük harf, rakam ve özel karakter zorunluluğu
- Authentication & Authorization middleware yapılandırması

---

## 📌 Amaç

Bu proje ile:
- Katmanlı mimari mantığını kavramak
- Gerçek zamanlı uygulamalar geliştirmek
- ASP.NET Core Identity ve SignalR entegrasyonunu öğrenmek
- Kurumsal projelere uygun backend & frontend yapısını deneyimlemek
amaçlanmıştır.

---

## 📎 Not

> Bu proje bir eğitim sürecinin parçası olarak geliştirilmiştir.  
> Kod yapısı ve mimari tercihler, gerçek dünya projelerine referans olacak şekilde kurgulanmıştır.
