FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY ./GcpBlog.sln ./
COPY ./GcpBlog.Api/GcpBlog.Api.csproj  ./GcpBlog.Api/GcpBlog.Api.csproj
COPY ./GcpBlog.Application/GcpBlog.Application.csproj  ./GcpBlog.Application/GcpBlog.Application.csproj
COPY ./GcpBlog.Domain/GcpBlog.Domain.csproj  ./GcpBlog.Domain/GcpBlog.Domain.csproj
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "GcpBlog.Api.dll"]