FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY PushMate.TemplatingService.API/PushMate.TemplatingService.API.csproj PushMate.TemplatingService.API/
COPY PushMate.TemplatingService/PushMate.TemplatingService.csproj PushMate.TemplatingService/
RUN dotnet restore PushMate.TemplatingService.API/PushMate.TemplatingService.API.csproj
COPY . .
WORKDIR /src/PushMate.TemplatingService.API
RUN dotnet build PushMate.TemplatingService.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PushMate.TemplatingService.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PushMate.TemplatingService.API.dll"]
