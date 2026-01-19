# SignalRDine - Real-Time Restoran Yönetim Sistemi

Bu proje, modern .NET teknolojileri kullanılarak geliştirilmiş, anlık veri iletişimi (Real-Time) sağlayan kapsamlı bir restoran yönetim ve dashboard sistemidir.

> Proje, gerçek bir restoran senaryosu baz alınarak; performans, ölçeklenebilirlik ve katmanlı mimari prensipleri gözetilerek geliştirilmiştir.

## 🛠️ Yapılan Geliştirmeler

* **Dinamik UI Bileşenleri:** Ana sayfa üzerindeki Slider, Menü, Günün İndirimleri ve Müşteri Yorumları (Testimonials) alanları API üzerinden dinamik hale getirilmiş ve `ViewComponent` mimarisi ile entegre edilmiştir.

* **Mimari Kurulum:** Proje, profesyonel standartlara uygun olarak **6 katmanlı (N-Tier)** yapıda kurgulanmıştır.

* **Veritabanı Tasarımı:** EF Core kullanılarak ilişkisel bir yapı oluşturulmuş; Products ve Categories arasında bire-çok ilişki sağlanmıştır.

* **SignalR & Real-Time Dashboard:** * Dashboard üzerindeki tüm veriler (Anlık Kasa, Sipariş Sayısı, Ortalama Fiyatlar vb.) sayfa yenilenmeden anlık olarak güncellenmektedir.  
  * **Progress Bar Entegrasyonu:** Restoran doluluk oranları, aktif siparişler ve kapasite verileri anlık olarak dolan ilerleme çubukları ile görselleştirilmiştir.  
  * İstatistikler için optimize edilmiş kompleks **LINQ** sorguları geliştirilmiştir.

* **SignalR ile Anlık Masa Durum Takibi:**
  * **Real-Time Masa İzleme:** Restoran içerisindeki masaların doluluk durumları (Dolu/Boş) SignalR Hub üzerinden anlık olarak takip edilmektedir.
  * **Modern Premium UI:** Masalar için gradyan renk geçişli, hover animasyonlu ve ikon bazlı modern bir dashboard arayüzü kurgulanmıştır.
  * **Canlı Bağlantı Göstergesi:** Sistemin API ile olan canlı bağlantısını doğrulayan, animasyonlu "Sistem Aktif" durum paneli entegre edilmiştir.

* **Finansal Mantık & Kasa Yönetimi:** * **Automated Cash Tracking:** SQL Trigger kullanılarak, sipariş tamamlandığında kasa (`MoneyCase`) toplamının otomatik güncellenmesi sağlanmıştır.  
  * **Precise Date Reporting:** Günlük ciro (TodayCash) hesaplamalarında SQL ve .NET tarafındaki tarih uyumsuzlukları Data Annotation ve özel filtrelerle giderilmiştir.

* **Admin Paneli & UI:** `IHttpClientFactory` kullanılarak API uç noktalarıyla asenkron iletişim kurulmuş, modern bir admin teması entegre edilerek kullanıcı deneyimi artırılmıştır.

* **CRUD Operasyonleri:** Menü yönetimi, rezervasyon sistemi, iletişim bilgileri ve sosyal medya modülleri tam entegre şekilde çalışmaktadır.

* **Asenkron İşlemler (AJAX):** Menü ve ürün yönetim süreçlerinde sayfa yenilenmesini engellemek ve performansı artırmak amacıyla AJAX metotları entegre edilmiştir.

* **Dinamik Kategori & Ürün Yönetimi:** Menü öğeleri, API üzerinden gelen verilerle dinamik olarak listelenmekte ve kullanıcı etkileşimleri (ID takibi vb.) anlık olarak yönetilmektedir.

* **Sepet Yönetimi ve Finansal Hesaplamalar:** * AJAX ve SweetAlert2 entegrasyonu ile sayfa yenilenmeden dinamik ürün ekleme altyapısı kurulmuştur.  
  * Business katmanı üzerinden ürün bazlı %10 KDV ve genel toplam tutar hesaplama mantığı geliştirilmiştir.  
  * API üzerinden masaya özel sepet listeleme ve ürün silme fonksiyonları asenkron olarak entegre edilmiştir.

* **SignalR ile Anlık Rezervasyon Yönetimi:** * Rezervasyon süreçleri SignalR Hub yapısına entegre edilerek, verilerin admin paneline anlık (real-time) düşmesi sağlanmıştır.  
  * Hub üzerinden gelen rezervasyon listesi, UI tarafında dinamik HTML tabloları üzerinde anlık olarak güncellenecek şekilde kurgulanmıştır.

* **Bildirim Sistemi & Kullanıcı Deneyimi (UX):**
  * **Anlık Bildirimler:** SignalR Hub üzerinden okunmamış bildirim sayıları ve listesi anlık olarak tüm admin paneline dağıtılmaktadır.
  * **Multimedya Uyarıları:** Yeni bir bildirim geldiğinde tetiklenen `.mp3` formatlı sesli uyarı sistemi entegre edilmiştir.
  * **Görsel Bildirim (SweetAlert2):** Kullanıcı deneyimini artırmak amacıyla yeni bildirimlerde sağ üst köşede otomatik kapanan "Toast" mesajları kurgulanmıştır.
  * **AutoMapper Entegrasyonu:** Notification DTO'ları ve Entity nesneleri arasındaki dönüşümler asenkron ve güvenli şekilde yönetilmektedir.

## 🏗️ Katman Yapısı

1. **SignalRDine.Api:** API uç noktaları ve SignalR Hub tanımlarının bulunduğu katman  
2. **SignalRDine.BusinessLayer:** İş mantığı ve validasyon süreçlerinin yönetildiği katman  
3. **SignalRDine.DataAccessLayer:** Entity Framework Core tabanlı Repository ve DbContext katmanı  
4. **SignalRDine.EntityLayer:** Veritabanı tablolarının karşılığı olan domain nesneleri  
5. **SignalRDine.DtoLayer:** Veri güvenliği ve performans için tasarlanmış DTO sınıfları  
6. **SignalRDine.WebUI:** Kullanıcı arayüzü ve Admin panelinin (SignalR Client) bulunduğu katman  

## 🚀 Kullanılan Teknolojiler

* **.NET 8**
* **Entity Framework Core** (Code First & Fluent API)
* **SignalR** (Real-Time Data Communication)
* **AutoMapper** (Object-to-Object Mapping)
* **MS SQL Server** & **T-SQL Triggers**
* **ASP.NET Core MVC** (Razor View Engine)
* **Swagger / OpenAPI** (API Documentation)
* **SweetAlert2** (Modern UI Notifications)
* **LineAwesome & FontAwesome** (UI Icons)

## ⚙️ Kurulum

1. `appsettings.json` dosyasındaki **Connection String** bilgisini kendi yerel SQL Server adresinize göre düzenleyin.
2. Package Manager Console üzerinden `Update-Database` komutunu çalıştırarak tabloları ve initial verileri oluşturun.
3. Önce **API** projesini, ardından **WebUI** projesini çalıştırın.
