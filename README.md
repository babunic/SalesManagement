
# 📊 Sales Management System

A full-stack web application for managing sales records and sales representatives with seamless server-side and client-side filtering, clean error handling, and a user-friendly UI.

---

## 📖 Project Summary

This application allows users to:

- **Add, View, Edit, and Delete sales records**
- **Search and filter** records by:
  - Product name
  - Customer information
  - Sales representative
  - Date ranges
- Retrieve **sales representative names using representative IDs**
- See real-time **error messages and loading indicators**
- Use a clean, centered, responsive UI with styled inputs, selects, buttons, tables, and tooltips
- Enjoy both **server-side filtering (C# ASP.NET Core API)** and later **Angular-side filtering**

---

## 📋 Prerequisites

### 🔧 Backend: ASP.NET Core 9 Web API

- [.NET SDK 9.0+](https://dotnet.microsoft.com/en-us/download)
- CORS enabled for `http://localhost:4200`
- Swagger/OpenAPI configured for testing and contract validation

**Run Command On Your CLI**
 `0. dotnet tool install --global dotnet-ef --version 9.*`
 `1. dotnet-ef migrations add InitialCreate`
 `2. dotnet-ef database update`

**Endpoints:**
- `GET /api/SalesRecords`
- `POST /api/SalesRecords`
- `PUT /api/SalesRecords/{id}`
- `DELETE /api/SalesRecords/{id}`
- `GET /api/SalesRecords/{id}`

**Models:**
- `SalesRecord`
- `SalesRepresentative`

---

### 🖥️ Frontend: Angular Standalone Application (Angular 18+)

- [Node.js v18+](https://nodejs.org/en/download)
- [Angular CLI](https://angular.io/cli)

  ```bash
  npm install -g @angular/cli