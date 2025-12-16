# 🍏 Green Gleam – Fruits & Vegetables Ordering App

GreenGleam is a full-stack application for browsing, ordering, and managing fruits & vegetables.  
It allows users to register, login, add items to cart, place orders, and track their order history.  
The app also supports persistent cart storage, secure authentication, and a clean modern UI built with Blazor + Tailwind CSS.

---

## 🚀 Features

- 👤 **Authentication & Authorization**
  - Register & Login with JWT-based security
  - Profile management (name, number, password changes)

- 🛒 **Shopping Cart**
  - Add/remove/update items
  - Persistent cart storage using **SQLite** (data is saved even after app closes)

- 📦 **Orders**
  - Place new orders
  - Order history with status tracking
  - Detailed order view (info + items)

- 🎨 **UI/UX**
  - Responsive design with **Tailwind CSS**
  - Clean card-based layout
  - Loading states (spinners, placeholders)

---

## 🏗️ Tech Stack

### **Frontend / App**
- **C# Blazor** – UI and app logic  
- **Tailwind CSS** – Styling  
- **SQLite** – Local persistent storage for cart  

### **Backend / API**
- **ASP.NET Core Web API**  
- **Entity Framework Core** 
- **SQL Server** 

### **Shared**
- **DTOs (Data Transfer Objects)** 

### **Authentication**
- **JWT (JSON Web Tokens)** – Secure login & authorization  

---
