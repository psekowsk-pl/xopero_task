## [PL]

## Opis

Projekt jest zintegrowanym środowiskiem do testowania API (https://reqres.in) oraz UI (https://www.saucedemo.com) z wykorzystaniem nowoczesnych narzędzi testowych w ekosystemie .NET.

## Jak uruchomić testy

Aby uruchomić testy należy:
1. Skopiuj poniższego jsona do pliku secret:
```
  {
    "Login": "standard_user",
    "Password": "secret_sauce",
    "ApiKey": "x-api-key",
    "ApiValue": "reqres-free-v1"
  }
```
2. Skonfiguruj pliki configuration.api.json oraz configuration.ui.json pod swoje potrzeby.
3. Uruchom testy w Eksploratorze testów

## Raport z wynikami wszystkich testów:
<img width="1908" height="577" alt="obraz" src="https://github.com/user-attachments/assets/4c3d0ee4-13df-4e1f-872d-e314627cdfb5" />

## Struktura projektu:

Projekt podzielony jest na 3 główne foldery:
- Common - klasy i funkcje wykorzystywane w testach UI i API
- API-Tests - klasy, funkcje i testy API
- UI-Tests - klasy, funkcje i testy UI

W folderze API-Tests znajdują się:

📁 API-Tests
│
├── 📁 Configuration - pliki konfiguracyjne
├── 📁 Dto - klasy oraz interfejsy do parsowania danych z API
├── 📁 Helpers - klasy i funkcje służące do wspomagania projektu (ładowanie danych, itd.)
├── 📁 TestExtension - klasy i funkcje służące do wspomagania konkretnych testów (ładowanie danych z API, przygotowanie danych do POST, PUT, itd.)
│
└── 📁 Tests - folder z testami
    
W folderze UI-Tests znajdują się:

📁 UI-Tests
│
├── 📁 Configuration - pliki konfiguracyjne
├── 📁 Data - dane znajdujące się w aplikacji internetowej, wykorzystywane w testach
├── 📁 Dto - klasy oraz interfejsy do parsowania danych z plików JSON i API
├── 📁 Helpers - klasy i funkcje służące do wspomagania projektu (ładowanie danych, itd.)
├── 📁 Pages - klasy z elementami konkretnych stron
└── 📁 Tests - folder z testami

W folderze Common znajdują się:

📁 Common
│
└── 📁 Helpers - klasy i funkcje służące do wspomagania projektu (ładowanie danych, itd.)

## Wykorzystane narzędzia:
- xUnit - framework do testowania jednostkowego w .NET.
- Flurl - nowoczesna, asynchroniczna, przenośna biblioteka klienta HTTP i generator adresów URL dla platformy .NET.
- Playwright - otwarte narzędzie programistyczne, które umożliwia testowanie aplikacji internetowych na różnych przeglądarkach internetowych.
- GitHub - hostingowy serwis internetowy przeznaczony do projektów programistycznych wykorzystujących system kontroli wersji Git.

## Komentarz

Gdybym miał więcej zasobów i czasu:
- zaimplementowałbym zaawansowany generator raportów takich jak Allure lub ExtentReport i zintegrowałbym go z obecną architekturą

--
## [EN]

## Opis

The project is an integrated environment for testing APIs (https://reqres.in) and UIs (https://www.saucedemo.com) using modern testing tools in the .NET ecosystem.

## How to run tests

To run tests, you need to:
1. Copy the following JSON to the secret file:
```
  {
    “Login”: “standard_user”,
    “Password”: “secret_sauce”,
    “ApiKey”: “x-api-key”,
    “ApiValue”: “reqres-free-v1”
  }
```
2. Configure the configuration.api.json and configuration.ui.json files according to your needs.
3. Run the tests in the Test Explorer

## Report with all test results:
<img width="1908" height="577" alt="image" src="https://github.com/user-attachments/assets/4c3d0ee4-13df-4e1f-872d-e314627cdfb5" />

## Project structure:

The project is divided into 3 main folders:
- Common - classes and functions used in UI and API tests
- API-Tests - classes, functions, and API tests
- UI-Tests - classes, functions, and UI tests

The API-Tests folder contains:

📁 API-Tests
│
├── 📁 Configuration - configuration files
├── 📁 Dto - classes and interfaces for parsing data from the API
├── 📁 Helpers - classes and functions used to support the project (loading data, etc.)
├── 📁 TestExtension - classes and functions used to support specific tests (loading data from the API, preparing data for POST, PUT, etc.)
│
└── 📁 Tests - folder with tests
    
The UI-Tests folder contains:

📁 UI-Tests
│
├── 📁 Configuration - configuration files
├── 📁 Data - locators from web pages, used in tests
├── 📁 Dto - classes and interfaces for parsing data from JSON files and APIs
├── 📁 Helpers - classes and functions used to support the project (loading data, etc.)
├── 📁 Pages - classes with elements of specific pages
└── 📁 Tests - folder with tests

The Common folder contains:

📁 Common
│
└── 📁 Helpers - classes and functions used to support the project (loading data, etc.)

## Tools used:
- xUnit - a framework for unit testing in .NET.
- Flurl - a modern, asynchronous, portable HTTP client library and URL generator for the .NET platform.
- Playwright - an open-source development tool that allows you to test web applications on different web browsers.
- GitHub - a web hosting service for programming projects using the Git version control system.

## Comment

If I had more resources and time:
- I would implement an advanced report generator such as Allure or ExtentReport and integrate it with the current architecture.

