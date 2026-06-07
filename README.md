# Comrad Interview Project - Radiation Dose Data

This application displays approximate effective radiation doses for common diagnostic imaging procedures. 
It allows users to view data categorized by medical location and filter the results accordingly.  
*This application is part of a technical assessment exercise and is not intended for
clinical use, diagnosis, treatment, or medical decision making.*

## Technologies Used

- **Rider**: IDE choosen for development.
- **Junie**: AI assistant used in helping to create this project.
- **Gemini**: AI tool used for parsing the PDF file into CSV.
- **.NET 10.0**: The latest cross-platform framework for building modern applications.
- **Blazor Web App (Interactive Server)**: Used for building a rich, interactive web UI with C#.
- **C#**: The primary programming language used for the backend and component logic.
- **xUnit**: Testing framework used for ensuring data import integrity.
- **Bootstrap 5**: Utilized for responsive layout, cards, tables, and consistent styling across the application. 
(Default with Blazor Web App)

---

## How to Run the Application

Since the project is built on the .NET 10 framework, it must be run using the .NET runtime.
### Running Locally (Requires .NET 10 SDK)
To run the application directly on your machine, you will need to install the .NET 10 SDK.
[REFLECTION.md](REFLECTION.md)
1.  **Install .NET 10 SDK:**
    Download and install it from the official Microsoft site: [.NET 10 Download](https://dotnet.microsoft.com/download/dotnet/10.0)
2.  **Clone/Open the project:**
    Navigate to the root directory of the project in your terminal.
3.  **Run the project:**
    ```bash
    dotnet run --project ComradInterviewProject/ComradInterviewProject.csproj
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

---

## Assumptions

- This has not been made deployable to production.
- CSV is used as data storage rather than a database.

## Limitations

- Used default styling for the webpage
- Styling hasnt been fully completed with default names still being present
