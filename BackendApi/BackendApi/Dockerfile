FROM microsoft/dotnet:2.2-sdk-alpine AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "BackendApi.dll"]