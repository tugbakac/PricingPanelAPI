Backend Architecture (TaskFlow API)

Backend, Clean Architecture prensiplerine göre tasarlanmıştır. / The backend is designed according to Clean Architecture principles.

### Proje yapısı katmanlı mimari (layered architecture) üzerine kuruludur:

- TaskFlow.API → Presentation layer (ASP.NET Core Web API)
- TaskFlow.Application → Business logic & use-cases
- TaskFlow.Domain → Core entities & business rules
- TaskFlow.Infrastructure → Data access & external services

### Teknoloji ve Mimari / Technology && Architecture

- .NET 7.0 Web API
- Clean Architecture (DDD-inspired structure)
- Layered separation of concerns
- RESTful API design

### Tasarım Yaklaşımı / Design Approach

Sistem aşağıdaki prensiplerle geliştirilmiştir: / The system was developed based on the following principles:

- Separation of Concerns (katman ayrımı)
- Dependency inversion (Domain bağımsızlığı)
- Business logic Application katmanında izole edilmiştir / Business logic is isolated at the Application layer.
- Infrastructure katmanı dış bağımlılıkları yönetir (DB, external services) / The infrastructure layer manages external dependencies (DB, external services).

### Multi-tenant Design

Sistem çok müşterili (multi-tenant) olarak tasarlanmıştır. / The system is designed as multi-tenant.

Her veri merchantId üzerinden izole edilir ve kullanıcılar yalnızca kendi verilerini görür. / Each data point is isolated via merchantId, and users only see their own data.

### Future Architecture Design

Proje monolithic Clean Architecture olarak başlamış olup, ilerleyen aşamalarda microservice mimarisine evrilmesi hedeflenmektedir. 
/ 
This project is designed with scalability in mind and follows a modular monolithic approach that can evolve into a microservice architecture.

Potansiyel servis ayrımları: / Potential service differences:

- Identity Service
- Pricing Service
- Product Service
- Notification Service

### Repositories

- Backend API → https://github.com/tugbakac/PricingPanelAPI
- Frontend UI → https://github.com/tugbakac/pricing-panel

### Installation

- Projeyi bilgisayarınıza klonlayın / Clone the project to your local machine
- git clone https://github.com/username/TaskFlow.git
- cd TaskFlow

- cd backend/TaskFlow.API
- dotnet restore
- dotnet run

- frontend projesini run ettiğinizde varsayılan olarak http://localhost:5173 portunu kullanır. / The frontend application uses the following default URL: http://localhost:5173
- Bu portu kullanmıyorsa backend projesinde TaskFlow.API içerisindeki Program.cs de http://localhost:5173 bilgisinin yer aldığı tarafı güncellemeniz gerekir. / If your frontend runs on a different port, you must update the corresponding http://localhost:5173 configuration inside: TaskFlow.API/Program.cs
- Frontend tarafının sağlıklı bir şekilde çalışması için API projesinin ayakta olması gerekmektedir. / For the frontend application to function correctly, the backend API project must be running.

### Important

Frontend ve Backend bağımsız olarak geliştirilebilir. / Frontend and backend are developed and deployed independently.
REST API aracılığıyla iletişim kurarlar. / They communicate via REST API.
