# 🏦 Banking System API

A backend banking system built with **ASP.NET Core** following **Clean Architecture** principles.
The project focuses on **real-world business logic**, **transaction safety**, and **scalable design**, rather than simple CRUD operations.

---

## 🚀 Features

### 🔐 Authentication & Authorization
- JWT-based authentication
- Role-based authorization (Admin / Customer)
- Secure password hashing using BCrypt

### 👤 Users
- User registration
- Login with JWT token generation
- Role management (Admin / Customer)

### 💳 Accounts
- Create bank accounts
- Activate / Suspend accounts
- Deposit & Withdraw operations
- Balance consistency enforced at domain level

### 🔄 Transactions
- Deposit, Withdraw, and Transfer transactions
- Transaction lifecycle:
  - Pending
  - Completed
  - Failed
  - Reversed
- Transaction history per account
- Filtering by status and date range

### 🔁 Transaction Reversal (Refund System)
- Reverse completed transactions safely
- Supports:
  - Deposit reversal
  - Withdraw reversal
  - Transfer reversal
- Maintains full transaction traceability

### 🗑️ Admin Operations
- Soft delete transactions
- Reverse transactions
- Protected by role-based authorization

---

## 🧱 Architecture

The project follows **Clean Architecture**:


### Key Principles
- Business logic isolated in the Domain
- No EF Core dependency in Application or Domain
- Explicit transaction boundaries
- Clear separation of responsibilities

---

## 🛠️ Tech Stack

- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT Authentication
- BCrypt (Password Hashing)
- Clean Architecture
- Repository & Unit of Work Patterns

---

## 📌 Why This Project?

This project was built to:
- Practice **real-world backend design**
- Handle **complex business rules**
- Understand **transaction consistency**
- Go beyond basic CRUD APIs

---

## 📄 API Documentation

- Swagger enabled
- JWT authentication supported via Swagger UI

---

## 📦 Future Improvements
- Audit Logs
- Refresh Tokens
- Account daily limits
- Event-based notifications
- CQRS for read-heavy endpoints

---

## 🤝 Contribution

Feel free to fork the project, open issues, or suggest improvements.

---

## 📬 Contact

If you'd like to discuss the project or the architecture, feel free to reach out.


