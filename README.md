# 🏠 Rental Manager

[![.NET](https://img.shields.io/badge/.NET-9.0-blue)](https://dotnet.microsoft.com/pt-br/) 
[![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/pt-br/dotnet/csharp/)
[![ASP.NET](https://img.shields.io/badge/ASP.NET-512BD4?style=flat&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/pt-br/apps/aspnet)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=flat&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat&logo=swagger&logoColor=white)](https://swagger.io/)

---

## 📖 Sobre o projeto

**Rental Manager** é uma API RESTful para **gerenciar imóveis locados**, contratos, proprietários e inquilinos.  
O projeto segue **DDD (Domain-Driven Design)** e **Clean Architecture**, garantindo escalabilidade e código organizado.

### Funcionalidades principais
- CRUD de **contratos, imóveis, proprietários e inquilinos**  
- Relacionamento entre **proprietários → imóveis → contratos → inquilinos**  
- Documentação interativa da API com **Swagger**  
- Uso de **DTOs** e **AutoMapper** para mapeamento de dados  

---

## 🔗 Endpoints da API

### Contract
- **POST** `/{propertyId}/contracts` – Criar contrato para um imóvel  
- **GET** `/{propertyId}/contracts` – Listar contratos de um imóvel  
- **PUT** `/contracts/{contractId}` – Atualizar contrato  
- **DELETE** `/contracts/{contractId}` – Remover contrato  

### Owner
- **POST** `/owners` – Criar proprietário  
- **GET** `/owners` – Listar proprietários  
- **PUT** `/owners/{id}` – Atualizar proprietário  
- **DELETE** `/owners/{id}` – Remover proprietário  

### Property
- **POST** `/owners/{ownerId}/properties` – Criar imóvel para um proprietário  
- **GET** `/owners/{ownerId}/properties` – Listar imóveis de um proprietário  
- **PUT** `/properties/{propertyId}` – Atualizar imóvel  
- **DELETE** `/properties/{propertyId}` – Remover imóvel  

### Tenant
- **POST** `/{contractId}/tenants` – Criar inquilino para um contrato  
- **PUT** `/tenants/{tenantId}` – Atualizar inquilino  
- **DELETE** `/tenants/{tenantId}` – Remover inquilino  

---

## 🛠 Tecnologias

- **Backend:** ASP.NET Core (.NET 9), C#  
- **Arquitetura:** Domain-Driven Design (DDD), Clean Architecture  
- **Banco de dados:** PostgreSQL (Railway)  
- **Mapeamento de objetos:** AutoMapper  
- **Documentação da API:** Swagger  

---

## ⚡ Próximos passos

- Implementar relatórios e alertas de contratos e pagamentos  
- Criar frontend responsivo para administradores  
- Integrar autenticação e autorização de usuários  
