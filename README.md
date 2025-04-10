# AspNetCoreCodingExamples

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core-red)
![xUnit](https://img.shields.io/badge/xUnit-tested-green)
![CQRS](https://img.shields.io/badge/Architecture-Clean%20Architecture-yellow)

## 🌐 Overview
AspNetCoreCodingExamples is an ASP.NET Core Web API application of coding examples and data structures in C#.  Includes testable algorithms, OOP design, and API endpoints.

---

## 🔄 Architecture
```
AspNetCoreCodingExamples.sln
|
|-- AspNetCoreCodingExamples.API            --> ASP.NET Core Web API project
|    |-- Controllers                        --> API controllers for all modules
|
|-- AspNetCoreCodingExamples.Domain         --> Domain logic, interfaces, and services
|    |-- DataStructures
|    |   |-- DTOs
|    |   |-- Interfaces
|            |-- IArrayAlgorithms.cs
|            |-- ICharStringAlgorithms.cs
|            |-- IDictionaryAlgorithms.cs
|            |-- IHashSetExamples.cs
|            |-- IStackQueueExamples.cs
|    |   |-- Services
|            |-- ArrayAlgorithms.cs
|            |-- CharStringAlgorithms.cs
|            |-- DictionaryAlgorithms.cs
|            |-- HashSetExamples.cs
|            |-- StackQueueExamples.cs
|    |-- ParkingLot
|        |-- DTOs
|        |-- Entities
|        |-- Enums
|        |-- Interfaces
|        |-- Services
|    |-- MessageSelector
|        |-- DTOs
|            |-- MessageRequestDto.cs
|        |-- Interfaces
|            |-- IMessageService.cs
|            |-- IMessageServiceFactory.cs
|        |-- Services
|            |-- EmailService.cs
|            |-- SmsService.cs
|            |-- MessageServiceFactory.cs
|
|-- AspNetCoreCodingExamples.Tests          --> xUnit test project for all domain services
     |-- DataStructures
     |   |-- ArrayAlgorithms
     |   |-- CharStringAlgorithms
     |   |-- DictionaryAlgorithms
     |   |-- HashSetExamples
     |   |-- StackQueueExamples
     |-- ParkingLot
     |-- MessageSelector
```

---

## 🔍 Features

### ⚖️ Object-Oriented Design
- Parking Lot Simulation
  - OOP/OOD principles in action (interfaces, services, and inheritance)

### 🔀 Message Selector (Factory Pattern)
- Demonstration only - does not send real email or SMS
- Supports sending messages via `Email` or `Sms`
- Selects correct `IMessageService` based on input
- DI container configuration for service resolution
- POST endpoint: `/api/message/send`

### 📏 Array Algorithms
- Reverse array (manual & LINQ)
- Sum, FindMin, FindMax
- Detect Duplicates (manual & LINQ)

### 📊 Dictionary Algorithms
- Invert Dictionary
- Merge Dictionaries

### 🔹 Character/String Algorithms
- Convert 12-hour time to 24-hour format
- Palindrome check
- Replace vowels
- Remove special characters
- Validate IPv4 address

### 🚫 Stack & Queue Algorithms
- Balanced parentheses checker
- Reverse queue
- Evaluate postfix expressions

### 💫 HashSet Algorithms
- Detect duplicates
- Set difference
- Intersection

Each feature includes:
- Interface-first design
- Clean domain logic
- Unit tests with xUnit & FluentAssertions
- API endpoints exposed for interactive testing

---

## 🎓 How to Use

### Run the API
```bash
cd AspNetCoreCodingExamples.API
dotnet run
```

### Test the Library
```bash
cd AspNetCoreCodingExamples.Tests
dotnet test
```

### Try API Endpoints in Postman
**Example:** Reverse Queue
- `POST /api/stack-queue/reverse-queue`
```json
{
  "InputQueue": [1, 2, 3, 4]
}
```
**Response:** `[4, 3, 2, 1]`

**Example:** Send Message
- `POST /api/message/send`
```json
{
  "Type": "email",
  "Message": "Sont des mots qui vont tres bien ensemble"
}
```
**Response:** `Message sent successfully via Email`

---

## 🌟 Roadmap
- Add additional coding examples
- Add Swagger UI documentation

---
