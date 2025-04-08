# Wallet API

## Overview
The **Wallet API** is a RESTful service for managing wallets and transactions, including creating, updating, deleting, and retrieving wallet and transaction information. It is built using **ASP.NET Core** and follows a clean architecture approach with **MediatR** for CQRS.

---

## Features
- Wallet Management:
    - Create a wallet
    - Update wallet details
    - Delete a wallet
    - Get wallet by ID
    - Get wallets by document ID
- Transaction Management:
    - Create a transaction
    - Get transactions by wallet ID

---

## Technologies Used
- **.NET 8**
- **ASP.NET Core  API**
- **MediatR** for CQRS
- **Entity Framework Core** (In-memory database for development)
- **FluentValidation** for request validation
- **Serilog** for logging

---

## Endpoints

### Wallet Endpoints

| Method   | Endpoint               | Description                     |
|----------|------------------------|---------------------------------|
| `POST`   | `/wallets`             | Create a new wallet             |
| `PUT`    | `/wallets/{id}`        | Update an existing wallet       |
| `DELETE` | `/wallets/{id}`        | Delete a wallet by ID           |
| `GET`    | `/wallets/{id}`        | Get a wallet by ID              |
| `GET`    | `/wallets?documentId=` | Get wallets by document ID      |

### Transaction Endpoints

| Method   | Endpoint               | Description                              |
|----------|------------------------|------------------------------------------|
| `POST`   | `/transactions`        | Create a new transaction                 |
| `GET`    | `/transactions?walletId={id}` | Get transactions by wallet ID          |

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