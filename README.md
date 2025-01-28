# Play Economy System Architecture

Play Economy is a comprehensive microservices-based application designed to manage a virtual economy. Built with modern technologies, this project demonstrates the power of distributed systems for scalability and maintainability.

## Features
- **Microservices Architecture**: Modular services for catalog, inventory, and frontend integration.
- **Cross-platform Support**: Powered by ASP.NET Core and C# for server-side operations.
- **Database Integration**: MongoDB for NoSQL data storage.
- **Asynchronous Communication**: RabbitMQ with MassTransit for message-based event handling.
- **Frontend**: A responsive React application styled with Bootstrap.
- **Containerized Deployment**: Docker and Docker Compose for seamless deployment.
- **CI/CD Piplines**: CI/CD pipeline for Azure Web App using GitHub Actions.

## Technologies Used
- **Backend**: ASP.NET Core, C#
- **Frontend**: React, Bootstrap
- **Database**: MongoDB
- **Message Broker**: RabbitMQ
- **Containerization**: Docker, Docker Compose
- **API Testing**: Postman
- **Dependency Management**: NuGet

## Project Structure
```
dotnet-microservices/
├── packages/            # Prebuilt NuGet packages
├── postman_collections/ # API testing collections
├── Play.Catalog/        # Catalog microservice
├── Play.Inventory/      # Inventory microservice
├── Play.Common/         # Shared libraries and utilities
├── Play.Frontend/       # React frontend application
├── Play.Infra/          # Docker and infrastructure configurations
```

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/)
- [Docker](https://www.docker.com/)
- [MongoDB](https://www.mongodb.com/)
- [RabbitMQ](https://www.rabbitmq.com/)

### Installation Steps
1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd NetMicroservicesBasics
   ```

2. **Restore NuGet Packages**
   ```bash
   dotnet restore
   ```

3. **Build and Run Docker Containers**
   ```bash
   cd source_code/Play.Infra
   docker-compose up --build
   ```

4. **Install Frontend Dependencies**
   ```bash
   cd source_code/Play.Frontend
   npm install
   npm start
   ```

5. **Run Microservices**
   Navigate to each service directory and execute:
   ```bash
   dotnet run
   ```

### Testing
- Use the provided Postman collections in `postman_collections/` to test the APIs.

## Key Modules

### Play.Catalog
Handles catalog management for items in the virtual economy.
- RESTful API endpoints
- MongoDB repository integration

### Play.Inventory
Manages inventory for users, ensuring consistent data via event-driven architecture.
- Consumes messages from RabbitMQ
- Synchronous and asynchronous communication

### Play.Common
Shared utilities and configurations, including:
- MongoDB and RabbitMQ setup
- MassTransit integration

### Play.Frontend
A responsive React application providing a user-friendly interface to interact with the economy system.
- Built with React and Bootstrap
- Communicates with backend APIs

## Architecture Overview
- **Microservices**: Independent services for scalability and separation of concerns.
- **Event-Driven**: RabbitMQ facilitates asynchronous data consistency between services.
- **Containerization**: Docker ensures portability across environments.
- **Frontend Integration**: React application consuming backend APIs.

## Future Enhancements
- Implement authentication and authorization.
- Add unit and integration tests.
- Enhance CI/CD pipelines.
- Introduce advanced analytics and reporting.
- Add cloud native virtual environment

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.

## Acknowledgments
This project is inspired by modern microservices architecture patterns and best practices.

