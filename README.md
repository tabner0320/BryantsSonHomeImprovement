# 🏠 Bryant's Son Home Improvement

Bryant's Son Home Improvement is a full-stack **C#** and **.NET 10** application that showcases home improvement services through a customer-facing website, REST API, console application, and automated integration tests.

This project demonstrates modern .NET development practices, including ASP.NET Core Minimal APIs, RESTful API development, CRUD operations, asynchronous programming, API consumption with `HttpClient`, and a multi-project solution architecture.

---

## Features

- ASP.NET Core Minimal API
- Customer-facing web application
- Console application that communicates with the API using `HttpClient`
- Full CRUD operations (Create, Read, Update, Delete)
- Asynchronous programming with `async` and `await`
- Integration testing with xUnit
- API testing using `WebApplicationFactory`
- JSON serialization and deserialization
- Responsive website layout
- Multi-project .NET solution architecture

---

## Technologies Used

| Category | Technology |
|----------|------------|
| Language | C# |
| Framework | .NET 10 |
| Backend | ASP.NET Core Minimal API |
| Frontend | HTML5, CSS3, JavaScript |
| API Client | HttpClient |
| Testing | xUnit, WebApplicationFactory |
| Data Format | JSON |
| Version Control | Git & GitHub |
| IDE | Visual Studio Code |

---

## Project Structure

```text
BryantsSonHomeImprovement/
│
├── BryantsSonHomeImprovement.Api/
│   └── ASP.NET Core Minimal API
│
├── BryantsSonHomeImprovement.Console/
│   └── Console application using HttpClient
│
├── BryantsSonHomeImprovement.Tests/
│   └── xUnit integration tests
│
├── BryantsSonHomeImprovement.Web/
│   └── Customer-facing website
│
├── BryantsSonHomeImprovement.slnx
└── README.md
```

---

## API Endpoints

| Method | Endpoint | Description |
|---------|----------|-------------|
| GET | `/api/services` | Retrieve all services |
| GET | `/api/services/{id}` | Retrieve a service by ID |
| POST | `/api/services` | Create a new service |
| PUT | `/api/services/{id}` | Update an existing service |
| DELETE | `/api/services/{id}` | Delete a service |

---

## Sample Services

The application currently includes the following sample services:

- Interior Painting
- Drywall Repair
- Flooring Installation

---

## Running the Application

### Clone the Repository

```bash
git clone https://github.com/tabner0320/BryantsSonHomeImprovement.git
```

### Navigate to the Project

```bash
cd BryantsSonHomeImprovement
```

---

## Run the API

```bash
dotnet run --project BryantsSonHomeImprovement.Api
```

Open the API in your browser using the URL displayed in the terminal.

Example:

```text
http://localhost:5270/api/services
```

---

## Run the Console Application

With the API running in one terminal:

```bash
dotnet run --project BryantsSonHomeImprovement.Console
```

The console application provides the following menu:

```text
=========================================
 Bryant's Son Home Improvement
=========================================

1. View All Services
2. View Service by ID
3. Add Service
4. Update Service
5. Delete Service
6. Exit
```

---

## Run the Website

```bash
dotnet run --project BryantsSonHomeImprovement.Web
```

Open the localhost URL displayed in the terminal to view the website.

---

## Run the Tests

```bash
dotnet test
```

### Current Test Coverage

- ✅ Get all services
- ✅ Get service by valid ID
- ✅ Invalid service ID returns `404 Not Found`
- ✅ Add a new service
- ✅ Update an existing service
- ✅ Delete a service
- ✅ API integration testing with `WebApplicationFactory`

---

## Test Results

```text
Total Tests: 7
Passed: 7
Failed: 0
Skipped: 0
```

---

## Application Architecture

```text
                     Browser
                        │
                        ▼
      BryantsSonHomeImprovement.Web
                        │
                    HTTP Requests
                        │
                        ▼
      BryantsSonHomeImprovement.Api
                        │
                In-Memory Service Data

      BryantsSonHomeImprovement.Console
                        │
                   HttpClient
                        │
                        ▼
      BryantsSonHomeImprovement.Api

      BryantsSonHomeImprovement.Tests
                        │
                        ▼
      BryantsSonHomeImprovement.Api
```

---

## Skills Demonstrated

- C#
- .NET 10
- ASP.NET Core Minimal APIs
- REST API Development
- CRUD Operations
- HttpClient
- JSON Serialization
- Asynchronous Programming
- HTML5
- CSS3
- JavaScript
- xUnit Integration Testing
- WebApplicationFactory
- Object-Oriented Programming (OOP)
- Git & GitHub
- Multi-project .NET Solution Architecture
- Debugging and Troubleshooting

---

## AI-Assisted Development

This project was developed with assistance from OpenAI's ChatGPT.

AI was used to help explain concepts, troubleshoot development issues, generate example code, and improve project documentation. All AI-assisted code was reviewed, tested, and modified by the project author before being incorporated into the project.

---

## Future Enhancements

- Connect the website directly to the API using JavaScript `fetch()`
- Add SQLite or SQL Server database support
- Implement Entity Framework Core
- Add customer estimate request forms
- Create a project gallery with before-and-after photos
- Add customer testimonials
- Implement authentication and authorization
- Develop an administrative dashboard
- Deploy the application to Azure

---

## Author

**Theophilus Abner**

- GitHub: https://github.com/tabner0320
- LinkedIn: *www.linkedin.com/in/theophilus-abner-561606a4*