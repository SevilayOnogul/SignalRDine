# SignalRDine - Real-Time Restoran Yönetim Sistemi

Bu proje, modern .NET teknolojileri kullanılarak geliştirilmiş, anlık veri iletişimi (Real-Time) sağlayan kapsamlı bir restoran yönetim ve dashboard sistemidir.

> Proje, gerçek bir restoran senaryosu baz alınarak; performans, ölçeklenebilirlik ve katmanlı mimari prensipleri gözetilerek geliştirilmiştir.

## 🛠️ Yapılan Geliştirmeler

### 🔐 Identity & Kimlik Doğrulama (Yeni)
- **Özelleştirilmiş Identity:** `AppUser` ve `AppRole` sınıfları `int` anahtar tipiyle özelleştirilerek sisteme dahil edildi.
- **Güvenli Kayıt & Giriş:** `RegisterDto` ve `LoginDto` yapısı kullanılarak katmanlar arası veri güvenliği sağlandı.
- **Modern Kimlik Arayüzleri:** Kullanıcı deneyimine uygun, asenkron çalışan kayıt ve giriş sayfaları (UI) tasarlandı.

### 🎨 Dinamik UI Bileşenleri
- Ana sayfa üzerindeki Slider, Menü, Günün İndirimleri ve Müşteri Yorumları (Testimonials) alanları API üzerinden dinamik hale getirildi.
- `ViewComponent` mimarisi ile modüler yapı sağlandı.

### 🏗️ Mimari Kurulum
- Proje, profesyonel standartlara uygun olarak **6 katmanlı (N-Tier)** yapıda kurgulanmıştır.

### 🗄️ Veritabanı Tasarımı
- EF Core kullanılarak ilişkisel bir yapı oluşturulmuştur.
- Products ve Categories arasında bire-çok ilişki sağlanmıştır.

### 📊 SignalR & Real-Time Dashboard
- Dashboard üzerindeki tüm veriler (Anlık Kasa, Sipariş Sayısı, Ortalama Fiyatlar vb.) sayfa yenilenmeden anlık olarak güncellenmektedir.
- **Progress Bar Entegrasyonu:** Restoran doluluk oranları, aktif siparişler ve kapasite verileri anlık olarak ilerleme çubukları ile görselleştirilmiştir.
- İstatistikler için optimize edilmiş kompleks **LINQ** sorguları geliştirilmiştir.
- **Anlık Bağlantı Takibi (Client Counter):**  
  Sisteme o an bağlı olan aktif kullanıcı sayısı, `OnConnectedAsync` ve `OnDisconnectedAsync` metodları üzerinden takip edilerek tüm panellerde anlık olarak güncellenmektedir.

### 🍽️ SignalR ile Anlık Masa Durum Takibi
- **Real-Time Masa İzleme:** Masaların doluluk durumları (Dolu / Boş) SignalR Hub üzerinden anlık olarak takip edilmektedir.
- **Modern Premium UI:** Gradyan renk geçişli, hover animasyonlu ve ikon bazlı dashboard arayüzü tasarlanmıştır.
- **Canlı Bağlantı Göstergesi:** API bağlantı durumunu gösteren animasyonlu “Sistem Aktif” paneli entegre edilmiştir.

### 💬 SignalR ile Anlık Mesajlaşma (Chat) Modülü
- Restoran içi kullanıcılar/personeller arasında anlık mesaj iletimi sağlayan Hub altyapısı kurulmuştur.
- Mesajlar gönderen bilgisi ve profesyonel saat formatı (HH:mm) ile listelenmektedir.
- Sunucu bağlantısı kurulana kadar buton pasifize edilmesi ve mesaj sonrası input temizleme gibi UX detayları eklenmiştir.

### 💰 Finansal Mantık & Kasa Yönetimi
- **Automated Cash Tracking:**  
  SQL Trigger kullanılarak sipariş tamamlandığında kasa (`MoneyCase`) toplamının otomatik güncellenmesi sağlanmıştır.
- **Precise Date Reporting:**  
  Günlük ciro (TodayCash) hesaplamalarında tarih uyumsuzlukları Data Annotation ve özel filtrelerle giderilmiştir.

### 🧑‍💼 Admin Paneli & UI
- `IHttpClientFactory` kullanılarak API uç noktalarıyla asenkron iletişim kurulmuştur.
- Modern bir admin teması entegre edilerek kullanıcı deneyimi artırılmıştır.

### 🧾 CRUD Operasyonları
- Menü yönetimi
- Rezervasyon sistemi
- İletişim bilgileri
- Sosyal medya modülleri  
tam entegre şekilde çalışmaktadır.

### ✉️ Mesaj Yönetimi & AutoMapper Refactoring
- **Partial View Entegrasyonu:**  
  İletişim formu `PartialView` mimarisi ile ana sayfaya entegre edilmiştir.
- **Otomatik Veri Eşleme:**  
  Mesaj gönderimlerinde `AutoMapper` kullanılmış, `DateTime.Now` ataması Mapper profil seviyesinde yapılandırılmıştır.

### ⚡ Asenkron İşlemler (AJAX)
- Menü ve ürün yönetiminde sayfa yenilenmeden işlem yapılması sağlanmıştır.
- Performans ve kullanıcı deneyimi artırılmıştır.

### 🧩 Dinamik Kategori & Ürün Yönetimi
- Menü öğeleri API üzerinden gelen verilerle dinamik olarak listelenmektedir.
- Kullanıcı etkileşimleri (ID takibi vb.) anlık olarak yönetilmektedir.

### 🛒 Sepet Yönetimi ve Finansal Hesaplamalar
- AJAX ve SweetAlert2 entegrasyonu ile sayfa yenilenmeden ürün ekleme altyapısı kurulmuştur.
- Business katmanı üzerinden ürün bazlı %10 KDV ve genel toplam tutar hesaplama mantığı geliştirilmiştir.
- API üzerinden masaya özel sepet listeleme ve ürün silme fonksiyonları asenkron olarak entegre edilmiştir.

### 📅 SignalR ile Anlık Rezervasyon Yönetimi
- Rezervasyon süreçleri SignalR Hub yapısına entegre edilmiştir.
- Rezervasyonlar admin paneline anlık (real-time) olarak düşmektedir.
- UI tarafında dinamik HTML tabloları üzerinden anlık güncellenmektedir.

### 🔔 Bildirim Sistemi & Kullanıcı Deneyimi (UX)
- **Anlık Bildirimler:** Okunmamış bildirim sayıları ve listesi tüm admin paneline anlık olarak dağıtılmaktadır.
- **Multimedya Uyarıları:** Yeni bildirimlerde `.mp3` formatlı sesli uyarı sistemi entegre edilmiştir.
- **Görsel Bildirimler:** SweetAlert2 ile otomatik kapanan Toast mesajları kurgulanmıştır.
- **AutoMapper Entegrasyonu:** Notification DTO ve Entity dönüşümleri güvenli şekilde yönetilmektedir.

## 🏗️ Katman Yapısı

1. **SignalRDine.Api** – API uç noktaları ve SignalR Hub tanımları  
2. **SignalRDine.BusinessLayer** – İş mantığı ve validasyonlar  
3. **SignalRDine.DataAccessLayer** – EF Core tabanlı Repository & DbContext  
4. **SignalRDine.EntityLayer** – Domain / Entity sınıfları  
5. **SignalRDine.DtoLayer** – DTO yapıları  
6. **SignalRDine.WebUI** – Kullanıcı arayüzü ve Admin paneli  

## 🚀 Kullanılan Teknolojiler

- **.NET 8**
- **ASP.NET Core Identity**
- **Entity Framework Core**
- **SignalR**
- **AutoMapper**
- **MS SQL Server & T-SQL Triggers**
- **ASP.NET Core MVC**
- **Swagger / OpenAPI**
- **SweetAlert2**
- **LineAwesome & FontAwesome**

## ⚙️ Kurulum

1. `appsettings.json` dosyasındaki **Connection String** bilgisini kendi SQL Server ortamınıza göre düzenleyin.
2. Package Manager Console üzerinden `Update-Database` komutunu çalıştırın.
3. Önce **API**, ardından **WebUI** projesini çalıştırın.
