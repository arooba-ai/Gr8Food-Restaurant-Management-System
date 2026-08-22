# Gr8Food Management System

A C# Windows Forms restaurant management system integrated with a SQL Server database. The system provides role-based functionality for customers, chefs, managers, and system administrators.

## 📌 Project Overview

Gr8Food is a restaurant management system designed to manage the complete restaurant ordering workflow, from food browsing and customer orders to kitchen order processing, wallet transactions, feedback management, and administrative reporting.

The project was developed using **C# Windows Forms** with **Microsoft SQL Server** for database management.

## ✨ Key Features

### 👤 Customer
- User profile management
- Browse restaurant menu
- Search for food items
- Add items to cart
- Place orders
- View order status
- Wallet balance management
- Wallet top-up functionality
- Submit food/service feedback
- Rate orders using a 1–5 star rating system

### 👨‍🍳 Chef
- View incoming customer orders
- View food items and quantities
- Update order status
- Track order progress
- Refresh order information

### 📊 Manager
- View restaurant sales reports
- Filter sales by month, year, and category
- View wallet transactions
- Filter wallet reports by customer and date
- Manage customer feedback
- Reply to customer feedback
- Monitor order and restaurant activity

### 🛠️ System Administrator
- Manage users
- Add, edit and manage menu items
- Manage system information
- View sales reports
- Monitor restaurant operations

## 🧰 Technologies Used

- **C#**
- **.NET / Windows Forms**
- **Microsoft SQL Server**
- **SQL**
- **Visual Studio**
- **ADO.NET**
- **Git & GitHub**

## 🗄️ Database

The application uses Microsoft SQL Server for persistent data storage.

Major database entities include:

- Users
- Menu
- Orders
- OrderDetails
- Feedback
- WalletTransactions
- Cart

The application uses SQL queries and ADO.NET to perform database operations such as:

- CRUD operations
- Order management
- User management
- Feedback management
- Wallet transactions
- Filtering and reporting

## 🏗️ System Architecture

The project separates database operations and application functionality into dedicated classes and forms.

Example structure:

```text
Gr8Food
│
├── Customer
│   ├── Customer Dashboard
│   ├── Menu
│   ├── Cart
│   ├── Order Status
│   └── Feedback
│
├── Chef
│   └── Order Management
│
├── Manager
│   ├── Sales Report
│   ├── Wallet Report
│   └── Feedback Management
│
├── Administrator
│   ├── User Management
│   └── Menu Management
│
├── Database
│   └── SQL Server / ADO.NET
│
└── Resources
    └── Application UI resources
