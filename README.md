# 🌐 IoT Device Monitoring System

A complete, full-stack monorepo project designed to simulate, transmit, and monitor real-time sensor data. This system bridges the gap between hardware electronics and front-end web development, demonstrating a robust Client-Server architecture.

## 🏗️ System Architecture

This repository is structured into three independent, yet fully integrated components:

1. **`Backend-API/`**: An ASP.NET Core Web API acting as the central data hub. It securely receives real-time telemetry from the simulated hardware and provides RESTful endpoints.
2. **`Device-Simulator/`**: A C# Console Application serving as a virtual microcontroller (mimicking devices like the ESP32). It generates continuous environmental data (maintaining stable voltage readings around 8V) and transmits it via HTTP POST requests, demonstrating reliable data streaming capabilities.
3. **`iot-frontend/`**: A responsive, real-time React application built with Vite and styled with Bootstrap. It continuously fetches data from the API and visualizes the live stream in a clean, user-friendly dashboard.

## 🛠️ Technologies & Tools

* **Backend:** C#, ASP.NET Core Web API
* **Frontend:** React.js, Vite, Bootstrap, Axios
* **Hardware Simulation:** C# Console Application (HTTP Client)
* **Architecture:** Monorepo, RESTful APIs




## 🚀 Getting Started

Follow these steps to run the complete system locally:

### 1. Start the Backend API
Navigate to the API directory and start the server:
```bash
cd Backend-API/IotDataApi
dotnet run
```
*(The API will typically run on `https://localhost:7047`)*

### 2. Start the Frontend Dashboard
Open a new terminal, install the dependencies, and start the development server:
```bash
cd iot-frontend
npm install
npm run dev
```

### 3. Launch the Device Simulator
Open a third terminal and start the data stream:
```bash
cd Device-Simulator
dotnet run
```

*Navigate to the frontend URL provided in your terminal and watch the dashboard update automatically as new data packets are successfully transmitted!*

## 🔮 Future Integration
The architecture is fully prepared for the replacement of the software simulator with physical microcontrollers, and the integration of Entity Framework Core for persistent database storage.
