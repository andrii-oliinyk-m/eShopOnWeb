dotnet restore
dotnet tool restore

set ASPNETCORE_ENVIRONMENT=Development
dotnet build
dotnet ef database update --no-build -c catalogcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj
dotnet ef database update --no-build -c appidentitydbcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj
