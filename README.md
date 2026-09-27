# PetShopSystem

A simple console-based Pet Shop Management System built with **C#**, **Entity Framework Core** and **SQL Server**.

This project was created as a practice project to improve my understanding of:

- C#
- OOP
- Entity Framework Core
- SQL Server
- CRUD operations
- Relationships between entities
- Git & GitHub

---

## About The Project

**PetShopSystem** is a console application for managing a small pet shop.

The system allows users to:

- Add products
- View all products
- Find a product by ID
- Delete products
- Add customers
- View all customers
- Find customers by ID
- Buy products
- View orders
- Find orders by ID
- Cancel orders
- View orders of a customer
- View orders of a product

The project uses **Entity Framework Core** to store and manage data in a SQL Server database.

---

## Technologies

- **C#**
- **.NET**
- **Entity Framework Core**
- **SQL Server**
- **Git**
- **GitHub**
- **Visual Studio**

---

## Project Structure

```text
PetShopSystem
│
├── PetShopSystem
│   ├── Entities
│   │   ├── Product.cs
│   │   ├── Customer.cs
│   │   ├── Category.cs
│   │   └── Order.cs
│   │
│   ├── Data
│   │   └── AppDbContext.cs
│   │
│   ├── Services
│   │   └── PetShopService.cs
│   │
│   ├── Migrations
│   │
│   └── Program.cs
│
└── PetShopSystem.slnx
```

---

## Entities

### Product

Contains information about products:

- Id
- Name
- Category
- Price
- Stock

### Customer

Contains customer information:

- Id
- Name
- Age

### Order

Contains order information:

- Id
- CustomerId
- ProductId
- Quantity
- TotalPrice

### Category

Product categories:

- Food
- Toy
- Medicine
- Accessory

---

## Main Features

### Product Management

The system can:

- Add a new product
- Show all products
- Find a product by ID
- Delete a product

The system also checks:

- Duplicate product IDs
- Invalid prices
- Negative stock values

### Customer Management

The system can:

- Add customers
- Show all customers
- Find customers by ID

### Order Management

Customers can buy products by selecting:

- Customer ID
- Product ID
- Quantity
- Order ID

When a product is purchased:

- The total price is calculated
- Product stock decreases
- A new order is saved to the database

When an order is cancelled:

- The order is removed
- Product stock is returned

---

## Database

The project uses **Entity Framework Core** with **SQL Server**.

Database name:

```text
PetShopSystemDb
```

Connection:

```text
Server=.\SQLEXPRESS
```

EF Core migrations are used to create and update the database.

---

## Console Interface

The application has a simple console menu with separate sections for:

- Products
- Customers
- Orders

The console interface uses colors and ASCII-style borders to make the menu easier to read.

---

## Learning Goals

This project helped me practice:

- Classes and objects
- Constructors
- Properties
- Enums
- Methods
- Nullable reference types
- LINQ
- Entity Framework Core
- DbContext
- DbSet
- SQL Server
- Relationships
- Foreign keys
- CRUD operations
- Migrations
- Git and GitHub

---

## Author

**Fidan Meherremli**

C# Student | Junior Developer in Progress
