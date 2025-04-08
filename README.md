# Wallet API

## Overview
The **Wallet API** is a RESTful service for managing wallets, including creating, updating, deleting, and retrieving wallet information. It is built using **ASP.NET Core** and follows a clean architecture approach with **MediatR** for CQRS.

---

## Features
- Create a wallet
- Update wallet details
- Delete a wallet
- Get wallet by ID
- Get wallets by document ID

---

## Technologies Used
- **.NET 8**
- **ASP.NET Core API**
- **MediatR** for CQRS
- **Entity Framework Core** (In-memory database for development)
- **FluentValidation** for request validation
- **Serilog** for logging

---

## Endpoints

### Wallet Endpoints

| Method | Endpoint               | Description                     |
|--------|------------------------|---------------------------------|
| `POST` | `/wallets`             | Create a new wallet             |
| `PUT`  | `/wallets/{id}`        | Update an existing wallet       |
| `DELETE` | `/wallets/{id}`      | Delete a wallet by ID           |
| `GET`  | `/wallets/{id}`        | Get a wallet by ID              |
| `GET`  | `/wallets?documentId=` | Get wallets by document ID      |

---

## Request Examples

### Create Wallet
**POST** `/wallets`

```json
{
  "documentId": "123456789",
  "name": "Personal Wallet",
  "initialBalance": 100.00
}