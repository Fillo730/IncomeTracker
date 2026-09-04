# --- Stage 1: build the Angular frontend ---
FROM node:20-alpine AS angular-build
WORKDIR /app
COPY TutorTrackAngular/package*.json ./
RUN npm install
COPY TutorTrackAngular/. .
RUN npx ng build --configuration production

# --- Stage 2: build the .NET API ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS api-build
WORKDIR /src
COPY TutorTrackApi/*.csproj ./
RUN dotnet restore
COPY TutorTrackApi/. .
RUN dotnet publish -c Release -o /app/publish --no-restore

# --- Stage 3: final runtime image ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=api-build /app/publish .
COPY --from=angular-build /app/dist/TutorTrack/browser ./wwwroot

RUN mkdir -p /app/data

ENV ASPNETCORE_URLS=http://+:8080
ENV ConnectionStrings__DefaultConnection="Data Source=/app/data/tutortrack.db"

EXPOSE 8080

ENTRYPOINT ["dotnet", "TutorTrackApi.dll"]
