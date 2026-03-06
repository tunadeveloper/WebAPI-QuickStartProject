# 🚀 Quick Start: ASP.NET Core 10 API & MVC

![.NET 10](https://img.shields.io/badge/.NET%2010-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-000000?style=flat-square&logo=json-web-tokens&logoColor=white)
![Scalar](https://img.shields.io/badge/Scalar-FFDB1C?style=flat-square&logo=scalar&logoColor=black)
![AutoMapper](https://img.shields.io/badge/AutoMapper-8A2BE2?style=flat-square&logo=nuget&logoColor=white)
![FluentValidation](https://img.shields.io/badge/FluentValidation-42A5F5?style=flat-square&logo=nuget&logoColor=white)

## 📖 Proje Hakkında

Bu proje, kurumsal bir landing page ve yönetim panelini kapsayan, modern mimari prensiplerine uygun **ASP.NET Core 10** tabanlı bir ekosistemdir. Projeyi, verinin yönetimini sağlayan bir **REST API** katmanı ve bu API'yi tüketen, son kullanıcıya ve yöneticiye hitap eden bir **MVC Web arayüzü** olmak üzere iki ana katman üzerine inşa ettim.

Sistem; hakkımızda, hizmetler, fiyatlandırma ve SSS gibi tüm site içeriğini API üzerinden dinamik olarak yönetebilmemi sağlıyor. Admin paneli üzerinden yaptığım tüm CRUD işlemleri anında anasayfaya yansımakta, Dashboard üzerinde ise **RapidAPI** entegrasyonu ile gerçek zamanlı dünya haberlerini listelemekteyim.

## 🏗️ Mimari ve Teknik Detaylar

Projeyi geliştirirken kodun sürdürülebilirliği, güvenliği ve performansını ön planda tuttum.

| Kategori | Teknoloji / Kütüphane | Kullanım Amacı |
|----------|-----------------------|----------------|
| **Framework** | .NET 10 | En güncel .NET çalışma zamanı |
| **Veritabanı** | Microsoft SQL Server | İlişkisel veri depolama |
| **ORM** | Entity Framework Core | Veritabanı modelleme ve erişim |
| **API Dokümantasyonu** | Scalar | Modern ve interaktif API test arayüzü |
| **Güvenlik (API)** | Identity & JWT | Token tabanlı kimlik doğrulama |
| **Güvenlik (UI)** | Cookie Authentication | Yönetim paneli oturum yönetimi |
| **Validasyon** | FluentValidation | DTO bazlı merkezi veri doğrulama |
| **Mapping** | AutoMapper | Entity-DTO arası hızlı dönüşüm |
| **Veri Çekme** | IHttpClientFactory | Backend API ve RapidAPI tüketimi |



### 🔧 Geliştirme Prensipleri
* **2 Katmanlı Mimari:** İş mantığını API tarafında (WebAPILayer) tutarken, sunum ve kullanıcı etkileşimini MVC tarafında (WebUILayer) izole ettim.
* **Repository Design Pattern:** Veri erişim metotlarını soyutlayarak kod tekrarının önüne geçtim.
* **DTO (Data Transfer Objects):** API trafiğinde veriyi güvenli ve optimize bir şekilde taşımak için özelleşmiş DTO sınıfları kullandım.
* **Dinamik Hata Yönetimi:** 401, 404 ve 500 hataları için kullanıcıyı karşılayan özel, tema ile uyumlu hata sayfaları geliştirdim.

## ✨ Öne Çıkan Özellikler

### 🛡️ REST API Katmanı (WebAPILayer)
* **JWT Auth:** Endpointleri korumak için Identity ile entegre JWT altyapısını kurdum.
* **Scalar Entegrasyonu:** Klasik Swagger yerine daha şık bir dökümantasyon sunan Scalar kütüphanesini kullandım.
* **Generic Repository:** Tüm entity'ler için ortak CRUD operasyonlarını tek merkezden yönetiyorum.

### 💻 MVC & Admin Paneli (WebUILayer)
* **Dashboard:** Gelen mesaj/abonelik sayıları ve **RapidAPI** üzerinden çektiğim son 6 güncel haberin kart tasarımıyla listelenmesi.
* **ViewComponent Yapısı:** Anasayfadaki Hero, Services, Pricing gibi alanları API'den beslenen bağımsız bileşenler olarak tasarladım.
* **İletişim Formu:** Anasayfadan gönderilen mesajların `MessageController` aracılığıyla API'ye POST edilmesi.
* **Yönetim Paneli:** Hakkımızda, İletişim, SSS, Hizmetler ve Referanslar gibi tüm modüller için tam kapsamlı CRUD desteği.

## 📂 Klasör Yapısı

Proje yapısı katmanlar arası sorumlulukları net bir şekilde yansıtmaktadır:

```text
WebAPI-QuickStartProject/
├── QuickStartProject.WebAPILayer/    # REST API Projesi
│   ├── Context/                      # EF Core DbContext (ApiContext)
│   ├── Controllers/                  # API Endpoint'leri
│   ├── DTOs/                         # Create, Update, Result DTO'ları
│   ├── Entities/                     # Veritabanı Entity'leri ve BaseEntity
│   ├── FluentValidation/             # Doğrulama Sınıfları
│   ├── AutoMapper/                   # Entity-DTO Eşleme Profilleri
│   └── Repositories/                 # IRepositoryService & RepositoryService
│
└── QuickStartProject.WebUILayer/     # MVC Web Arayüzü
    ├── Areas/Admin/                  # Yönetim Paneli (Dashboard, CRUD vs.)
    ├── Controllers/                  # UI ve Form Yönetimi
    ├── ViewComponents/               # Anasayfa ve Admin Bileşenleri
    ├── DTOs/                         # UI Tarafında Kullanılan DTO'lar
    ├── wwwroot/                      # Statik Dosyalar (Mantis/QuickStart Temaları)

```

<img width="1920" height="3447" alt="Image" src="https://github.com/user-attachments/assets/41696206-fd0f-45ca-a48b-67b45123e206" />
<img width="1920" height="2294" alt="Image" src="https://github.com/user-attachments/assets/b1c47192-2d9e-4de1-9275-7e46c446256d" />
<img width="1920" height="2897" alt="Image" src="https://github.com/user-attachments/assets/0ba21e6a-da6f-42a6-a2f7-40a511df94f6" />

<img width="1912" height="937" alt="Image" src="https://github.com/user-attachments/assets/fb967231-75ed-427f-b209-a4928343009f" />
<img width="1913" height="933" alt="Image" src="https://github.com/user-attachments/assets/e4c9ac5a-e3e0-4974-87d6-1fcb4620252d" />
<img width="1902" height="934" alt="Image" src="https://github.com/user-attachments/assets/05175546-87b2-4adc-b5fc-1d8c289669f8" />

<img width="1914" height="934" alt="Image" src="https://github.com/user-attachments/assets/4efe3d41-cc04-4835-a078-dbf502e239c7" />
<img width="1913" height="934" alt="Image" src="https://github.com/user-attachments/assets/0b451524-30fc-4af7-ad9e-374162ff46dd" />
<img width="1912" height="938" alt="Image" src="https://github.com/user-attachments/assets/36e3e5ec-e173-42a4-a8b8-e6d8e5d49f16" />
<img width="1912" height="930" alt="Image" src="https://github.com/user-attachments/assets/c3806cfe-c94f-4e7b-9689-b0c3aa6fe16e" />
<img width="1910" height="936" alt="Image" src="https://github.com/user-attachments/assets/9f30b58d-168a-4770-9cfe-20b7346bc900" />
<img width="1913" height="939" alt="Image" src="https://github.com/user-attachments/assets/79cbcfb6-2543-41c9-ba4f-b4eceb38ed58" />
<img width="1913" height="936" alt="Image" src="https://github.com/user-attachments/assets/72b3f940-ca32-4206-ae93-863bfa8ceb9a" />
<img width="1912" height="935" alt="Image" src="https://github.com/user-attachments/assets/0b03fccf-2918-460d-ac75-a0f9ce085204" />
<img width="1914" height="936" alt="Image" src="https://github.com/user-attachments/assets/f8822a00-4466-4d04-b0ac-9c77f4a33d36" />
<img width="1897" height="933" alt="Image" src="https://github.com/user-attachments/assets/cc117d52-9963-4fca-989a-14d66cf41bb2" />
<img width="1896" height="937" alt="Image" src="https://github.com/user-attachments/assets/aef0bb99-c872-409f-b18b-380245c94360" />
