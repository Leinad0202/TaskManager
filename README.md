# TaskManager - Basic Task Manager in C#

Simple task manager developed in C# with a command-line interface (CLI) and JSON file persistence.

## Features

- List all registered tasks.
- Add new tasks.
- Update the title and status (pending/completed) of existing tasks.
- Remove tasks by ID.
- Persist data in a JSON file (`tasks.json`).

## Technologies Used

- C# (.NET 7/8)
- Console Application (CLI)
- Manipulating JSON files with `System.Text.Json`

## How to Use

1. Clone this repository:

```bash
git clone git@github.com:Leinad0202/TaskManager.git
```

2. Go to the project folder:
  ```bash
  cd TaskManager
```
3. Compile and run the project:
```bash
    dotnet run
```

    Use the interactive menu to manage your tasks.

## Project Structure

```plaintext
TaskManager/
│
├── Program.cs # Entry point and CLI interface
├── Models/
│ └── TaskItem.cs # Task data model
├── Services/
│ └── TaskService.cs # Task handling and persistence logic
└── tasks.json # Automatically generated file for storing data
```


Requirements

    .NET SDK 7 or 8 installed

    Compatible with Linux, Windows, and macOS

Notes

    The tasks.json file will be automatically created on the first run to store tasks.

    This project focuses on demonstrating basic C# concepts and file data manipulation.
