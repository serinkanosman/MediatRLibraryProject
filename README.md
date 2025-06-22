# MediatR.LibraryProject

Bu proje, **MediatR tasarım desenini** temel alan, modüler ve genişletilebilir bir .NET uygulama altyapısı sunar.  
CQRS (Command Query Responsibility Segregation) ve bağımlılık enjeksiyonu ile temiz, sürdürülebilir ve test edilebilir bir mimari hedeflenmiştir.

---

## 🧱 Proje Yapısı

MediatR.LibraryProject/
│
├── MediatR/ # MediatR arayüzleri ve temel altyapı
│ ├── IRequest, ISender, IRequestHandler
│ └── MediatRExtensions # DI için uzantılar
│
├── eTicaret.Application/ # Uygulama katmanı (CQRS)
│ ├── Commands/
│ │ └── ProductCreateCommand.cs
│ ├── Handlers/
│ │ └── ProductCreateCommandHandler.cs
│ ├── ServiceRegistrar.cs
│ └── Test.cs # Örnek kullanım sınıfı
│
└── MediatR.LibraryProject.API/ # API katmanı
├── Program.cs
└── Swagger/OpenAPI dokümantasyonu

---

## 🚀 Temel Özellikler

- ✅ **MediatR Altyapısı:** Komutlar ve handler’lar ile gevşek bağlılık (loose coupling).
- ✅ **CQRS Desteği:** Komut ve sorgular ayrı handler’larla yönetilir.
- ✅ **Bağımlılık Enjeksiyonu (DI):** Servisler kolayca kayıt edilir ve yönetilir.
- ✅ **Swagger/OpenAPI:** API endpoint'leri kolayca test edilebilir.

---

## 📦 Örnek Kullanım

### 📬 POST `/products`

**İstek:**
```http
POST /products
Content-Type: application/json

{
  "name": "Ürün Adı",
  "price": 100.0
}
{
  "message": "Create product is successful"
}

