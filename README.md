# Simple Employee Management System

A full-stack web application for managing employee records, built with **ASP.NET Core Web API** and **Angular**. The system features JWT-based admin authentication and persistent SQL Server storage.

---

## Business Context

Organizations need a centralized system to manage employee information efficiently. This application provides a secure, admin-only interface to:

- Add new employees to the organization
- View all employees at a glance
- Remove employees from the system
- Protect sensitive employee data behind a login wall

This project serves as a practical foundation for HR management tools, demonstrating real-world patterns such as REST API design, token-based authentication, and database persistence.

---

## Technologies Used

### Backend
| Technology | Version | Purpose |
|---|---|---|
| ASP.NET Core Web API | .NET 10 | REST API framework |
| Entity Framework Core | Latest | ORM for database access |
| SQL Server | MSSQL | Persistent data storage |
| JWT (JSON Web Tokens) | — | Admin authentication |
| C# | 13 | Backend language |

### Frontend
| Technology | Version | Purpose |
|---|---|---|
| Angular | 22 | Frontend SPA framework |
| TypeScript | Latest | Frontend language |
| Angular HttpClient | — | API communication |
| Angular Router | — | Page navigation |

### Tools
| Tool | Purpose |
|---|---|
| SQL Server Management Studio (SSMS) | Database management |
| Git & GitHub | Version control |
| Visual Studio Code | Code editor |

---

## Project Structure

```
Simple_Employee_Management/
│
├── EmployeeManagementAPI/              ← .NET Backend (runs on port 5204)
│   ├── Controllers/
│   │   ├── AuthController.cs           ← Login & JWT token generation
│   │   └── EmployeesController.cs      ← CRUD endpoints (protected)
│   ├── Data/
│   │   └── AppDbContext.cs             ← EF Core database context
│   ├── Models/
│   │   └── Employee.cs                 ← Employee data model
│   ├── Services/
│   │   ├── IEmployeeService.cs         ← Service interface
│   │   └── EmployeeService.cs          ← Business logic + DB operations
│   ├── Migrations/                     ← EF Core auto-generated migrations
│   ├── Program.cs                      ← App configuration & middleware
│   └── appsettings.json                ← Connection string & JWT config
│
└── employee-management-frontend/       ← Angular Frontend (runs on port 4200)
    └── src/
        └── app/
            ├── components/
            │   ├── login/              ← Admin login page
            │   └── dashboard/          ← Main employee management page
            ├── services/
            │   ├── auth.ts             ← Auth service (token management)
            │   └── employee.ts         ← Employee API service
            ├── app.routes.ts           ← Route definitions
            ├── app.config.ts           ← App-level providers
            └── app.ts                  ← Root component
```

---

## Features

- 🔐 **JWT Authentication** — Secure admin login with token-based auth
- 👥 **Employee CRUD** — Add, view, and delete employee records
- 💾 **SQL Server Persistence** — Data survives server restarts
- 🔄 **Protected API** — All employee endpoints require a valid JWT token
- 🚀 **Angular SPA** — Fast, component-based frontend
- 🔁 **Auto Redirect** — Unauthenticated users are redirected to login

---

## API Endpoints

### Auth
| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/auth/login` | Login and get JWT token | ❌ |

### Employees
| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| GET | `/api/employees` | Get all employees | ✅ |
| GET | `/api/employees/{id}` | Get employee by ID | ✅ |
| POST | `/api/employees` | Add new employee | ✅ |
| PUT | `/api/employees/{id}` | Update employee | ✅ |
| DELETE | `/api/employees/{id}` | Delete employee | ✅ |
| PATCH | `/api/employees/{id}/salary` | Update salary | ✅ |

---

## Prerequisites

Make sure the following are installed before running the project:

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js LTS](https://nodejs.org)
- [Angular CLI](https://angular.dev/tools/cli) (`npm install -g @angular/cli`)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) (any edition)
- [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (optional but recommended)

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/HamimKhan2019/Simple_Employee_Management.git
cd Simple_Employee_Management
```

---

### 2. Configure the Backend

Open `EmployeeManagementAPI/appsettings.json` and update the connection string to match your SQL Server instance:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\YOUR_INSTANCE;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "ThisIsASecretKeyForJwtToken12345!",
    "Issuer": "EmployeeManagementAPI",
    "Audience": "EmployeeManagementClient"
  }
}
```

> To find your SQL Server instance name, open SSMS and check the Server name field on the connect dialog.

---

### 3. Set Up the Database

```bash
cd EmployeeManagementAPI
dotnet ef database update
```

This creates the `EmployeeDB` database and `Employees` table automatically.

---

### 4. Run the Backend API

```bash
cd EmployeeManagementAPI
dotnet run
```

API runs at: `http://localhost:5204`

---

### 5. Install Frontend Dependencies

```bash
cd employee-management-frontend
npm install
```

---

### 6. Run the Frontend

```bash
ng serve
```

Frontend runs at: `http://localhost:4200`

---

### 7. Login

Open `http://localhost:4200` in your browser.

| Field | Value |
|-------|-------|
| Username | `admin` |
| Password | `admin123` |

---

## How It Works

```
User opens http://localhost:4200
        ↓
Angular checks localStorage for JWT token
        ↓
No token → redirect to /login
        ↓
User enters credentials
        ↓
POST /api/auth/login → JWT token returned
        ↓
Token saved to localStorage
        ↓
Redirect to /dashboard
        ↓
All API calls include: Authorization: Bearer <token>
        ↓
.NET API validates token → returns data
```

---

## Default Admin Credentials

> ⚠️ These are hardcoded for development. Replace with database-backed auth in production.

- **Username:** `admin`
- **Password:** `admin123`

---

## Future Improvements

- [ ] ASP.NET Core Identity for database-backed user management
- [ ] Multiple admin roles (Super Admin, HR, Viewer)
- [ ] Employee search and filter
- [ ] Edit employee details
- [ ] Pagination for large employee lists
- [ ] Input validation and error handling middleware
- [ ] Production deployment (Azure / IIS)

---

## License

This project is for educational and internship purposes.
