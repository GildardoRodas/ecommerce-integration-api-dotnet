# 🛒 Ecommerce Integration API

Backend API para ecommerce desarrollado en **.NET 8**, orientado a **integraciones reales** como pagos, envíos y webhooks, siguiendo **Clean Architecture** y buenas prácticas de diseño backend.

Este proyecto simula escenarios comunes en sistemas de ecommerce modernos, incluyendo **procesamiento de pagos**, **manejo de envíos**, **eventos asincrónicos (webhooks)** y **seguridad con JWT**, siendo ideal como **demo técnico profesional** o base para proyectos reales.

## 🎯 Objetivo del proyecto

Este proyecto tiene como objetivo demostrar:

- Diseño de **APIs backend robustas**
- Aplicación correcta de **Clean Architecture**
- Manejo de **flujos reales de ecommerce**
- Integración basada en **eventos (webhooks)**
- Seguridad mediante **JWT**
- Despliegue y ejecución con **Docker**


## Tecnologías principales
- .NET 8  / ASP.NET Core
- JWT (JSON Web Tokens)
- Docker / Docker Compose
- database (relacionales / no relacionales)
- Swagger (OpenAPI)
- Clean Architecture
- Event‑driven architecture (Webhooks)


## 🧱 Arquitectura

El proyecto está estructurado siguiendo **Clean Architecture**, separando responsabilidades de forma clara:

src/
 ├── Ecommerce.Integration.API            → Capa de presentación (Controllers, Swagger, Auth)
 ├── Ecommerce.Integration.Application    → Casos de uso y lógica de aplicación
 ├── Ecommerce.Integration.Domain         → Entidades y reglas de negocio
 └── Ecommerce.Integration.Infrastructure → Persistencia, servicios externos y providers mock

## 🔐 Seguridad

La API utiliza **JWT (JSON Web Tokens)** para autenticación y autorización.

- Login mediante endpoint `/api/login`
- Endpoints protegidos con `[Authorize]`
- Webhooks expuestos sin JWT (`[AllowAnonymous]`)

## 🔄 Flujo funcional del Ecommerce

1. Creación de una orden
2. Generación de intención de pago
3. Procesamiento del pago
4. Recepción de webhook de pago
5. Creación de envío
6. Recepción de webhook de envío

## 🐳 Ejecución con Docker

Desde la raíz del repositorio:

bash:
docker compose up --build

Swagger disponible en:

http://localhost:8080/swagger

## 📘 Notas

- Persistencia en memoria (demo)
- Integraciones simuladas
- Ideal como portafolio profesional o base real

## 👨‍💻 Autor

Proyecto desarrollado con fines profesionales para demostrar experiencia en backend .NET, arquitectura limpia, ecommerce e integraciones.

