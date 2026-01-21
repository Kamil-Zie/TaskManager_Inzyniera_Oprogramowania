
# Sprawozdanie z Projektu TaskManager

## Wprowadzenie

Celem projektu było stworzenie aplikacji typu "Task Manager" składającej się z dwóch głównych komponentów: backendowego API napisanego w technologii ASP.NET Core oraz frontendowej aplikacji klienckiej stworzonej przy użyciu biblioteki ReactJS.

## 1. Backend - TaskManager_API

Backend aplikacji został zrealizowany jako API RESTful w technologii ASP.NET Core.

### Kluczowe technologie:
- **Framework:** ASP.NET Core 8.0
- **Baza danych:** MongoDB
- **Wzorce:** Dependency Injection, Repository (w formie serwisu `TaskManagerService` bazujący na `ITaskManagerService`)

### Struktura i funkcjonalność:

- **`Program.cs`**: Główny plik aplikacji, w którym konfigurowane są serwisy, połączenie z bazą danych, CORS oraz routing. Aplikacja nasłuchuje na porcie 5130.
- **`Models/`**:
    - **`Task.cs`**: Definiuje model zadania, zawierający pola takie jak `Id`, `TaskName`, `TaskDateStart` i `TaskDateEnd`. Atrybuty BSON wskazują na mapowanie na kolekcję w MongoDB.
    - **`TaskManagerDataBaseSettings.cs`**: Przechowuje konfigurację połączenia z bazą danych (Connection String, nazwa bazy i kolekcji).
- **`Services/`**:
    - **`TaskManagerService.cs`**: Implementuje interfejs `ITaskManagerService` i zawiera logikę biznesową do operacji CRUD na zadaniach w bazie MongoDB.
- **`Controllers/`**:
    - **`TaskController.cs`**: Kontroler API, który udostępnia następujące punkty końcowe (endpoints) do zarządzania zadaniami:
        - `GET /api/tasks`: Pobiera wszystkie zadania.
        - `GET /api/tasks/{id}`: Pobiera zadanie o określonym ID.
        - `POST /api/tasks`: Tworzy nowe zadanie.
        - `PUT /api/tasks/{id}`: Aktualizuje istniejące zadanie.
        - `DELETE /api/tasks/{id}`: Usuwa zadanie.

## 2. Testy - TaskManager_API.Tests

Projekt zawiera również zestaw testów jednostkowych dla backendu.

### Kluczowe technologie:
- **Framework do testów:** xUnit
- **Mockowanie:** Moq

### Struktura i funkcjonalność:

- **`TaskControllerTests.cs`**: Zawiera testy jednostkowe dla każdej metody akcji w `TaskController`. Serwis `ITaskManagerService` jest mockowany, co pozwala na izolację testowanego kontrolera od warstwy dostępu do danych. Testy weryfikują:
    - Poprawne zwracanie listy zadań.
    - Zwracanie zadania po ID.
    - Tworzenie nowego zadania.
    - Aktualizację i usuwanie istniejących zadań.
    - Poprawne zwracanie kodów statusu HTTP (np. `NotFound`, `NoContent`).

## 3. Frontend - taskmanager-webapp

Frontend aplikacji został stworzony jako Single Page Application przy użyciu biblioteki ReactJS.

### Kluczowe technologie:
- **Biblioteka:** ReactJS
- **Komponenty UI:** Material-UI (MUI)

### Struktura i funkcjonalność:

- **`App.js`**: Główny komponent aplikacji, który zarządza stanem (listą zadań) oraz zawiera logikę do komunikacji z backendowym API (pobieranie, dodawanie, usuwanie zadań).
- **`components/`**:
    - **`TaskList.js`**: Komponent odpowiedzialny za wyświetlanie listy zadań. Iteruje po tablicy zadań i dla każdego z nich renderuje komponent `TaskItem`.
    - **`TaskItem.js`**: Komponent reprezentujący pojedyncze zadanie na liście. Wyświetla jego nazwę, daty oraz przycisk do usunięcia.
    - **`AddTaskForm.js`**: Formularz pozwalający użytkownikowi na wprowadzenie nazwy i dat dla nowego zadania oraz jego dodanie.

### Komunikacja z API:

Aplikacja frontendowa komunikuje się z API `TaskManager_API` pod adresem `http://localhost:5130/api/tasks` w celu wykonywania operacji CRUD na zadaniach.

## Podsumowanie

Projekt `TaskManager` stanowi kompletną aplikację full-stack. Backend w ASP.NET Core z bazą danych MongoDB dostarcza solidne i przetestowane API, podczas gdy frontend w React z Material-UI zapewnia interaktywny i funkcjonalny interfejs użytkownika do zarządzania zadaniami. Całość jest dobrze zorganizowana, z wyraźnym podziałem na warstwy (API, testy, UI).
