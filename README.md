# 🛡️ VardSec Auth API

Bu proje, **VardSec** için geliştirilmiş, yüksek güvenlikli ve mikroservis mimarisine uygun bir **Kimlik Doğrulama (Authentication)** servisidir.

## 🚀 Proje Hakkında
Bu API, kurumsal standartlarda **JWT (JSON Web Token)** tabanlı yetkilendirme sağlar. Kullanıcı verilerini güvenli bir şekilde saklar, doğrular ve yetkili kullanıcılara süreli erişim anahtarları (Token) üretir.

**Öne Çıkan Özellikler:**
* 🔒 **Güvenlik:** BCrypt ile şifreleme ve JWT Bearer Token koruması.
* 🐳 **Containerization:** Docker ve Docker Compose ile tam izole çalışma ortamı.
* 🗄️ **Veritabanı:** MSSQL Server (Code-First yaklaşımı ile otomatik migration).
* ⚡ **Teknoloji:** .NET 10 (Preview) & Entity Framework Core.

## 🛠️ Kurulum (Tek Komutla)

Projeyi bilgisayarınızda çalıştırmak için **Visual Studio** veya **SQL Server** kurmanıza gerek yoktur. Sadece [Docker Desktop](https://www.docker.com/products/docker-desktop)'ın yüklü olması yeterlidir.

1.  Projeyi klonlayın.
2.  Terminali proje dizininde açın.
3.  Aşağıdaki komutu çalıştırın:

```bash
docker-compose up --build
