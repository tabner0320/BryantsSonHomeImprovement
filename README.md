# Bryant's Son Home Improvement

**Bryant's Son Home Improvement** is a full-stack web application built with **C#, ASP.NET Core, HTML, CSS, and JavaScript** for a home improvement business.

The application allows customers to browse available home improvement services, select a service, complete an estimate request form, and submit their project information directly to an ASP.NET Core Web API.

This project demonstrates full-stack development, REST API design, JavaScript API integration, asynchronous programming, automated testing, and Git/GitHub version control.

---

## Features

### Customer Website

- Responsive home improvement website
- Business branding and service information
- Home improvement service cards
- Starting-price information
- Interactive **Request Estimate** buttons
- Automatic service selection
- Customer estimate request form
- Smooth scrolling to the estimate form
- Form validation
- Customer contact information collection
- Preferred project date selection
- Project description field
- JavaScript `fetch()` API integration
- Customer confirmation after successful submission

### ASP.NET Core API

- ASP.NET Core Minimal API
- RESTful API endpoints
- Full CRUD operations for services
- Customer estimate request endpoint
- Automatic estimate request ID generation
- JSON request and response handling
- CORS configuration
- In-memory data storage

### Testing

- xUnit automated testing
- API integration testing
- `WebApplicationFactory`
- HTTP endpoint testing

---

## Technologies Used

| Category | Technology |
|---|---|
| Language | C# |
| Framework | .NET / ASP.NET Core |
| Back End | ASP.NET Core Minimal API |
| Front End | HTML5, CSS3, JavaScript |
| API Communication | Fetch API / HttpClient |
| Data Format | JSON |
| Testing | xUnit |
| Integration Testing | WebApplicationFactory |
| Version Control | Git & GitHub |
| Development Environment | Visual Studio Code |

---

## Project Structure

```text
BryantsSonHomeImprovement/
│
├── BryantsSonHomeImprovement.Api/
│   ├── Models/
│   │   ├── Service.cs
│   │   └── EstimateRequest.cs
│   ├── Program.cs
│   └── BryantsSonHomeImprovement.Api.csproj
│
├── BryantsSonHomeImprovement.Console/
│   ├── Program.cs
│   └── BryantsSonHomeImprovement.Console.csproj
│
├── BryantsSonHomeImprovement.Tests/
│   └── BryantsSonHomeImprovement.Tests.csproj
│
├── BryantsSonHomeImprovement.Web/
│   ├── wwwroot/
│   │   ├── css/
│   │   │   └── site.css
│   │   ├── images/
│   │   ├── js/
│   │   │   └── app.js
│   │   └── index.html
│   ├── Program.cs
│   └── BryantsSonHomeImprovement.Web.csproj
│
├── BryantsSonHomeImprovement.slnx
├── .gitignore
└── README.md
```

---

## Available Services

The application currently includes services such as:

- Interior Painting
- Drywall Repair
- Flooring Installation

Each service displays information about the work offered and a starting price.

Customers can click **Request Estimate** to begin an estimate request for the selected service.

---

## Estimate Request Workflow

The customer estimate process works like this:

```text
Customer Visits Website
        ↓
Views Available Services
        ↓
Clicks Request Estimate
        ↓
Selected Service Automatically Added to Form
        ↓
Customer Enters Contact Information
        ↓
Customer Enters Project Information
        ↓
Clicks Submit Estimate Request
        ↓
JavaScript Creates JSON Request
        ↓
Fetch API Sends HTTP POST Request
        ↓
ASP.NET Core API
        ↓
Estimate Request Created
        ↓
Customer Receives Confirmation
```

This demonstrates communication between a JavaScript front end and a C# back end.

---

## API Endpoints

### API Status

```http
GET /
```

Confirms that the API is running.

Example response:

```text
Bryant's Son Home Improvement API is running!
```

---

## Service Endpoints

### Get All Services

```http
GET /api/services
```

Returns all available home improvement services.

### Get Service by ID

```http
GET /api/services/{id}
```

Example:

```http
GET /api/services/1
```

### Create a Service

```http
POST /api/services
```

### Update a Service

```http
PUT /api/services/{id}
```

### Delete a Service

```http
DELETE /api/services/{id}
```

---

## Estimate Endpoints

### Get All Estimate Requests

```http
GET /api/estimates
```

Returns submitted customer estimate requests.

### Get Estimate by ID

```http
GET /api/estimates/{id}
```

Example:

```http
GET /api/estimates/1
```

### Submit an Estimate Request

```http
POST /api/estimates
```

Example request:

```json
{
  "customerName": "Customer Name",
  "customerPhone": "555-555-5555",
  "customerEmail": "customer@example.com",
  "address": "123 Main Street",
  "serviceNeeded": "Interior Painting",
  "preferredDate": "2026-08-20",
  "projectDescription": "Paint the living room and dining room."
}
```

The API assigns the request an ID and records when the estimate request was submitted.

---

## Running the Application

### 1. Clone the Repository

```bash
git clone https://github.com/tabner0320/BryantsSonHomeImprovement.git
```

Navigate into the project:

```bash
cd BryantsSonHomeImprovement
```

---

### 2. Start the API

Open a terminal and run:

```bash
dotnet run --project BryantsSonHomeImprovement.Api
```

The terminal will display an address similar to:

```text
Now listening on: http://localhost:5270
```

Keep the API running.

---

### 3. Start the Website

Open a second terminal and run:

```bash
dotnet run --project BryantsSonHomeImprovement.Web
```

Open the localhost address displayed in the terminal.

---

## Front-End/API Connection

The JavaScript front end communicates with the ASP.NET Core API using the Fetch API.

For example:

```javascript
const response = await fetch(
    "http://localhost:5270/api/estimates",
    {
        method: "POST",

        headers: {
            "Content-Type": "application/json"
        },

        body: JSON.stringify(estimateRequest)
    }
);
```

The estimate information is converted into JSON and sent to the C# API using an asynchronous HTTP `POST` request.

> **Development note:** The localhost API URL is currently configured for local development. The URL will need to be changed when the application is deployed.

---

## Running Tests

Run all automated tests from the solution directory:

```bash
dotnet test
```

The test project uses **xUnit** and **WebApplicationFactory** to test API functionality.

---

## Data Storage

The application currently uses **in-memory data storage**.

This means service and estimate data exists while the API is running but does not persist after the application is stopped or restarted.

A database can be added in a future version for permanent storage.

---

## Future Improvements

Potential future enhancements include:

- SQL database integration
- Entity Framework Core
- Persistent estimate request storage
- Admin dashboard
- Estimate request status tracking
- Customer email confirmations
- SMS notifications
- Photo uploads for customer projects
- Additional home improvement services
- Authentication and authorization
- Improved mobile responsiveness
- Cloud deployment
- Additional automated tests

---

## Project Purpose

Bryant's Son Home Improvement was created to demonstrate the development of a practical full-stack application using **C#, ASP.NET Core, JavaScript, HTML, and CSS**.

The project demonstrates:

- REST API development
- CRUD operations
- Front-end and back-end integration
- Asynchronous JavaScript
- Fetch API requests
- JSON serialization
- C# data modeling
- Customer form processing
- API integration testing
- Git and GitHub version control
- Debugging and troubleshooting

---

## Author

**Theophilus Abner**

- GitHub: [tabner0320](https://github.com/tabner0320)
- Repository: [BryantsSonHomeImprovement](https://github.com/tabner0320/BryantsSonHomeImprovement)

---

## Developer

Developed as a full-stack software development project using **C#, ASP.NET Core, JavaScript, HTML, CSS, REST APIs, and JSON**.
