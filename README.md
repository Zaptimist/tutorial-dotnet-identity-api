# Project Name

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/get-started)
- [PostgreSQL](https://www.postgresql.org/download/)

## Setup

1. **Clone the repository:**

    ```sh
    git clone https://github.com/johannessnakeware/your-repo-name.git
    cd your-repo-name
    ```

2. **Start the PostgreSQL container:**

    Ensure Docker is running and execute:

    ```sh
    docker-compose -f Docker/docker-compose.yml up -d
    ```

3. **Update the database connection string:**

    Ensure your `appsettings.Development.json` has the correct connection string:

    ```json
    {
      "ConnectionStrings": {
        "Database": "Host=postgres-for-identity;Database=identity;Username=postgres;Password=postgres;Include Error Detail=true"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      }
    }
    ```

4. **Apply database migrations:**

    ```sh
    dotnet ef database update
    ```

## Running the Project

1. **Build and run the project:**

    ```sh
    dotnet run
    ```

2. **Access the API:**

    Open your browser and navigate to `https://localhost:5001/swagger` to view the Swagger UI and test the endpoints.

## Testing

1. **Execute the HTTP requests:**

    Use the `generated-requests.http` file to test the endpoints. For example, to confirm an email:

    ```http
    GET http://localhost:5080/confirmEmail?userId={{$placeholder}}&code={{$placeholder}}&changedEmail={{$placeholder}}
    ```

## Troubleshooting

- **No such host is known:** Ensure the service name in `docker-compose.yml` matches the host in your connection string.
- **No authenticationScheme was specified:** Ensure the default authentication scheme is set in `Program.cs`.

## Additional Information

- **Volumes:** The PostgreSQL data is stored in `C:\Databases\postgress-to-identity`.

## License

This project is licensed under the MIT License.