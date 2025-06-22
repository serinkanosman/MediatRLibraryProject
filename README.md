MediatR.LibraryProject
Bu proje, MediatR tasarım desenini temel alan, modüler ve genişletilebilir bir .NET uygulama altyapısı sunar.
Proje, komut/sorgu (CQRS) desenini ve bağımlılık enjeksiyonunu kullanarak temiz ve sürdürülebilir bir mimari hedefler.

Proje Yapısı
MediatR/
MediatR arayüzleri ve temel altyapı kodlarını içerir.
IRequest, IRequestHandler, ISender gibi arayüzler ve bunların temel implementasyonları burada bulunur.
MediatRExtensions ile servis kayıtları kolaylaştırılır.
eTicaret.Application/
Uygulama katmanıdır.
Komutlar (ör. ProductCreateCommand), handler'lar ve servis kayıtları burada yer alır.
ServiceRegistrar ile uygulama servisleri eklenir.
Örnek/test amaçlı bir Test sınıfı da mevcuttur.
MediatR.LibraryProject.API/
API katmanıdır.
Program.cs dosyasında servisler eklenir ve endpointler tanımlanır.
Swagger/OpenAPI desteği ile API dokümantasyonu sağlanır.
/products endpointi ile ürün oluşturma işlemi örneklenmiştir.


Temel Özellikler
MediatR altyapısı:
Komutlar ve handler'lar ile gevşek bağlılık (loose coupling) sağlanır.
CQRS desteği:
Komut ve sorgular ayrı handler'lar ile yönetilir.
Bağımlılık enjeksiyonu:
Servisler kolayca eklenip yönetilebilir.
Swagger/OpenAPI:
API endpointleri kolayca test edilebilir.

Örnek Kullanım 
POST /products
Content-Type: application/json
{
  "name": "Ürün Adı",
  "price": 100.0
}
Yanıt
{
  "Message": "Create product is successful"
}
