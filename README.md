# Conrad Interview Project - Radiation Dose Data

This application displays approximate effective radiation doses for common diagnostic imaging procedures. It allows users to view data categorized by medical location and filter the results accordingly.

## Technologies Used

- **.NET 10.0**: The latest cross-platform framework for building modern applications.
- **Blazor Web App (Interactive Server)**: Used for building a rich, interactive web UI with C#.
- **C#**: The primary programming language used for the backend and component logic.
- **Bootstrap 5**: Utilized for responsive layout, cards, tables, and consistent styling across the application.
- **xUnit**: Testing framework used for ensuring data import integrity.

---

## How to Run the Application

Since the project is built on the .NET 10 framework, it must be run using the .NET runtime. Below are two ways to run the project depending on your environment.

### 1. Running via Docker (No .NET installation required)
If you do not have the .NET 10 SDK installed on your machine, you can run the application using Docker. This will run the application inside a container that already has the necessary .NET environment.

1.  **Build the Docker image:**
    ```bash
    docker build -t conrad-project .
    ```
2.  **Run the container:**
    ```bash
    docker run -it --rm -p 8080:8080 conrad-project
    ```
3.  **Access the application:**
    Open your browser and go to: `http://localhost:8080`

### 2. Running Locally (Requires .NET 10 SDK)
To run the application directly on your machine, you will need to install the .NET 10 SDK.

1.  **Install .NET 10 SDK:**
    Download and install it from the official Microsoft site: [.NET 10 Download](https://dotnet.microsoft.com/download/dotnet/10.0)
2.  **Clone/Open the project:**
    Navigate to the root directory of the project in your terminal.
3.  **Run the project:**
    ```bash
    dotnet run --project ConradInterviewProject/ConradInterviewProject.csproj
    ```
4.  **Access the application:**
    The terminal will provide the local URLs (e.g., `http://localhost:5080` or `https://localhost:7150`).

---

## Running Tests

To verify the data import logic and ensure application stability, you can run the included unit tests:

```bash
dotnet test
```

## Project Structure

- `ConradInterviewProject/`: The main web application.
- `ConradInterviewProject.Tests/`: Unit tests for data processing.
- `ConradInterviewProject/Components/Data/`: Contains data models and the CSV importer logic.
- `ConradInterviewProject/Components/Pages/`: Contains the UI components (Home, etc.).
