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
- ASP.NET Core **Identity** ile kullanıcı ve rol yönetimi
- Global **Authorize Filter Policy** ile sayfa bazlı güvenlik
- Login / AccessDenied yönlendirmeleri
- Yetkisiz veya hatalı URL erişimlerinde kullanıcı deneyimini artırmak amacıyla özel 404 hata sayfası entegre edildi.

### ⚙️ Kullanıcı Ayarları & Profil Yönetimi 
- **Settings Modülü:** Kullanıcıların profil bilgilerini (Ad, Soyad, Kullanıcı Adı vb.) güncelleyebileceği özel bir arayüz geliştirildi.
- **Güvenli Güncelleme:** Bilgi değişikliği sırasında şifre ve şifre tekrarı eşleşmesi kontrol edilerek hatalı girişlerin önüne geçildi.

### ⚡ SignalR – Gerçek Zamanlı İletişim
- Anlık bildirim altyapısı
- Masa ve sipariş durumlarının canlı takibi
- Dashboard üzerinde real-time veri güncellemeleri

### 🥗 Menü & Kategori Yönetimi
- Dinamik Kategori Sistemi: Menü kategorileri API üzerinden asenkron olarak çekilerek kullanıcı arayüzünde dinamik olarak listelendi.

### 🧾 CRUD, Sepet ve Asenkron İşlemler
- Menü, rezervasyon, iletişim ve içerik yönetimi için CRUD operasyonları
- **AJAX destekli sepet yönetimi** (sayfa yenilenmeden ekleme / çıkarma)
- Business katmanında **%10 KDV ve genel toplam hesaplamaları**
- AutoMapper ile DTO–Entity dönüşümleri
- Footer ve iletişim alanı verileri, API üzerinden
  IHttpClientFactory kullanılarak asenkron şekilde çekildi.

### 📊 Dashboard & Yönetim Paneli
- Yönetici paneli üzerinden:
  - Sipariş takibi
  - Masa doluluk durumu
  - Finansal özetler
- Modern ve sade admin arayüzü

### 📱 QR Kod Yönetimi
- **QRCoder** ile dinamik QR kod oluşturma
- QR kod görsellerinin Base64 formatında üretilmesi ve indirilmesi
- **ZXing.Net** ile QR kod çözümleme (görsel üzerinden)
- Masa, menü veya özel linkler için kullanım senaryoları

### 📧 Mail Servis Entegrasyonu 
- **MailKit & MimeKit:** Projeye profesyonel SMTP mail gönderim altyapısı kuruldu.
- **Zengin Metin Editörü (Summernote):** Kullanıcıların mail içeriklerini kalın, italik ve listeli şekilde görsel olarak düzenleyebilmesi sağlandı.
- **Google App Password:** Gmail SMTP sunucusu üzerinden güvenli kimlik doğrulama protokolü uygulandı.
- **Dinamik Alıcı** Alıcı, konu ve içerik yönetimi
- İletişim alanında tek tıkla arama (tel:) ve mail gönderme (mailto:) entegrasyonları sağlandı.
- Harita lokasyonları Html.Raw kullanılarak dinamik şekilde yönetildi.

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
- **MailKit**
- **MimeKit**
- **Summernote (Rich Text Editor)**

---

## 🔐 Güvenlik & Yapılandırma

- Global Authorization Policy
- Şifre kuralları:
  - En az 6 karakter
  - Büyük harf, küçük harf, rakam ve özel karakter zorunluluğu
- Authentication & Authorization middleware yapılandırması
- HttpClient yönetimi, socket exhaustion riskini önlemek amacıyla
  merkezi ve kontrollü bir yapıya taşındı.

---

## 📌 Amaç

Bu proje ile:
- Katmanlı mimari mantığını kavramak
- Gerçek zamanlı uygulamalar geliştirmek
- ASP.NET Core Identity ve SignalR entegrasyonunu öğrenmek
- Kurumsal projelere uygun backend & frontend yapısını deneyimlemek
  amaçlanmıştır.


