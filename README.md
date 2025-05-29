
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

  
## ⚙️ Setup Instructions

### 📌 Backend (ASP.NET Core 8 API)

1. **Navigate to your backend project folder**

2. **Restore project dependencies**

   ```bash
   dotnet tool install --global dotnet-ef --version 9.*
   dotnet-ef migrations add InitialCreate
   dotnet-ef database update
   ```

   ```bash
   dotnet restore
   ```

3. **Build the backend project**

   ```bash
   dotnet build
   ```

4. **Run the API**

   ```bash
   dotnet run
   ```

5. **Verify the API is running at:**  
   [http://localhost:5050/swagger](http://localhost:5050/swagger/index.html)

---

### 📌 Frontend (Angular Standalone Project)

1. **Navigate to your Angular project folder**

2. **Install npm dependencies**

   ```bash
   npm install
   ```

3. **Run the Angular development server**

   ```bash
   ng serve --open
   ```

4. **Visit the Angular UI at:**  
   [http://localhost:4200](http://localhost:4200)

---

## 📦 Project Structure

### 📁 Backend (ASP.NET Core 8)

```
SalesManagementAPI/
 ├── Controllers/
 │    └── SalesRecordsController.cs
 ├── Models/
 │    └── SalesRecord.cs
 │    └── SalesRepresentative.cs
 ├── Repositories/
 │    └── ISalesRecordRepository.cs
 │    └── SalesRecordRepository.cs
 ├── Services/
 │    └── SalesRecordService.cs
 ├── Program.cs
```

### 📁 Frontend (Angular Standalone)

```
sales-management-angular/
 ├── src/app/
 │    ├── sales-records/
 │    │    └── sales-records.component.ts
 │    │    └── sales-records.component.html
 │    │    └── sales-records.component.css
 │    └── services/
 │         └── sales-record.service.ts
 ├── main.ts
 └── app.config.ts
```

---

## 🔧 Technologies Used

- ASP.NET Core 9 Web API
- Angular 18 Standalone
- SQLlite Database
- Swagger/OpenAPI
- CSS Flexbox for UI layout
- CORS Middleware
- HTTP Client in Angular
- Angular FormsModule (`ngModel`)
- Tooltips using native `title` attribute and optional CSS tooltips

---

## ✅ Notes

- Make sure to **start the API first** before running the Angular app
- API CORS policy must allow requests from `http://localhost:4200`
- Both apps run on:
  - API: `http://localhost:5050`
  - Angular: `http://localhost:4200`

---

## 🚀 Author

Soumya  
Open for feedback and enhancements!
