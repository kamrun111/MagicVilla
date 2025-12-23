# MagicVilla API

A RESTful API built with ASP.NET Core for managing villa properties. This project demonstrates CRUD operations, Entity Framework Core integration, and custom logging implementation.

## 📋 Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
- [API Documentation](#api-documentation)
  - [Endpoints](#endpoints)
  - [Villa Model](#villa-model)
  - [Response Codes](#response-codes)
- [Custom Logger](#custom-logger)
- [Usage Examples](#usage-examples)
- [Validation Rules](#validation-rules)
- [Future Enhancements](#future-enhancements)
- [Contributing](#contributing)
- [License](#license)

## ✨ Features

- **Complete CRUD Operations**: Create, Read, Update, and Delete villa records
- **RESTful Architecture**: Standard HTTP methods (GET, POST, PUT, PATCH, DELETE)
- **Entity Framework Core**: Database operations with EF Core
- **Data Transfer Objects (DTOs)**: Separation of entity models and API models
- **JSON Patch Support**: Partial updates using JSON Patch documents
- **Custom Logging**: Implementation of custom logger functionality
- **Model Validation**: Built-in validation with custom error messages

## 🛠️ Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- C# 
- SQL Server / Database Provider
- JSON Patch (Microsoft.AspNetCore.JsonPatch)
- Custom Logging Implementation

## 📁 Project Structure

```
MagicVilla_API/
├── Controllers/
│   └── VillaAPIController.cs       # Main API controller with all endpoints
├── Data/
│   └── ApplicationDbContext.cs     # EF Core database context
├── Models/
│   ├── Villa.cs                    # Villa entity model
│   └── DTO/
│       └── VillaDTO.cs             # Data transfer object
├── Logging/
│   └── [Logger Implementation]     # Custom logger files
├── Program.cs                       # Application entry point
└── appsettings.json                # Configuration file
```

## 🚀 Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) or higher
- SQL Server or your preferred database provider
- Visual Studio 2022 / Visual Studio Code / JetBrains Rider (optional)

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/kamrun111/MagicVilla.git
cd MagicVilla
```

2. **Restore dependencies**
```bash
dotnet restore
```

3. **Update the database**
```bash
dotnet ef database update
```

4. **Run the application**
```bash
dotnet run
```

The API will be available at `https://localhost:7xxx` or `http://localhost:5xxx`

### Configuration

Update your database connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=MagicVilla;Trusted_Connection=true;"
  }
}
```

## 📚 API Documentation

### Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/VillaAPI` | Get all villas |
| GET | `/api/VillaAPI/{id}` | Get villa by ID |
| POST | `/api/VillaAPI` | Create a new villa |
| PUT | `/api/VillaAPI/{id}` | Update entire villa |
| PATCH | `/api/VillaAPI/{id}` | Partially update villa |
| DELETE | `/api/VillaAPI/{id}` | Delete a villa |

### Villa Model

| Property | Type | Description |
|----------|------|-------------|
| VillaId | int | Unique identifier |
| VillaName | string | Name of the villa |
| Details | string | Description and details |
| Rate | double | Price rate |
| Sqft | int | Square footage |
| Occupancy | int | Maximum occupancy |
| ImageUrl | string | URL to villa image |
| Amenity | string | Available amenities |

### Response Codes

| Code | Description |
|------|-------------|
| 200 OK | Successful GET requests |
| 201 Created | Successful POST requests |
| 204 No Content | Successful PUT, PATCH, DELETE requests |
| 400 Bad Request | Invalid input or validation errors |
| 404 Not Found | Resource not found |

## 📝 Custom Logger

This project includes a custom logging implementation to track API operations and monitor application behavior. The logger captures:

- API requests and responses
- Database operations
- Error handling and exceptions
- Application lifecycle events

The custom logger provides enhanced debugging capabilities and helps maintain application health by tracking all critical operations throughout the API lifecycle.

## 💡 Usage Examples

### Get All Villas
```bash
curl -X GET https://localhost:7xxx/api/VillaAPI
```

### Create a Villa
```bash
curl -X POST https://localhost:7xxx/api/VillaAPI \
  -H "Content-Type: application/json" \
  -d '{
    "villaName": "Royal Villa",
    "details": "Luxury villa with ocean view",
    "rate": 200.0,
    "sqft": 2500,
    "occupancy": 4,
    "imageUrl": "https://example.com/image.jpg",
    "amenity": "Pool, WiFi, Parking"
  }'
```

### Update a Villa (Partial)
```bash
curl -X PATCH https://localhost:7xxx/api/VillaAPI/1 \
  -H "Content-Type: application/json-patch+json" \
  -d '[
    {
      "op": "replace",
      "path": "/rate",
      "value": 250.0
    }
  ]'
```

### Delete a Villa
```bash
curl -X DELETE https://localhost:7xxx/api/VillaAPI/1
```

## ✅ Validation Rules

- Villa names must be unique (case-insensitive)
- Villa ID cannot be 0
- All required fields must be provided for creation and updates
- Duplicate villa names will return a custom error message

## 🔮 Future Enhancements

- [ ] Authentication and Authorization (JWT)
- [ ] Pagination for GET requests
- [ ] Filtering and Sorting capabilities
- [ ] Image upload functionality
- [ ] API versioning
- [ ] Comprehensive unit and integration tests
- [ ] Swagger/OpenAPI documentation
- [ ] Rate limiting
- [ ] Caching implementation

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

## 📧 Contact

For questions or feedback, please open an issue on the GitHub repository.

---

**Repository**: [https://github.com/kamrun111/MagicVilla.git](https://github.com/kamrun111/MagicVilla.git)

⭐ If you find this project helpful, please consider giving it a star!
