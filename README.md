# TaskManager - Gerenciador Básico de Tarefas em C#

Gerenciador simples de tarefas desenvolvido em C# com interface de linha de comando (CLI) e persistência em arquivo JSON.

## Funcionalidades

- Listar todas as tarefas cadastradas.
- Adicionar novas tarefas.
- Atualizar título e status (pendente/concluída) das tarefas existentes.
- Remover tarefas pelo ID.
- Persistência dos dados em arquivo JSON (`tasks.json`).

## Tecnologias Utilizadas

- C# (.NET 7/8)
- Aplicação Console (CLI)
- Manipulação de arquivos JSON com `System.Text.Json`

## Como Usar

1. Clone este repositório:

   ```bash
   git clone git@github.com:Leinad0202/TaskManager.git

Entre na pasta do projeto:
  ```bash
  cd TaskManager
```
Compile e execute o projeto:

    dotnet run

    Use o menu interativo para gerenciar suas tarefas.

Estrutura do Projeto

TaskManager/
│
├── Program.cs          # Ponto de entrada e interface CLI
├── Models/
│   └── TaskItem.cs     # Modelo de dados da tarefa
├── Services/
│   └── TaskService.cs  # Lógica de manipulação e persistência de tarefas
└── tasks.json          # Arquivo gerado automaticamente para armazenar dados

Requisitos

    .NET SDK 7 ou 8 instalado

    Compatível com Linux, Windows e macOS

Observações

    O arquivo tasks.json será criado automaticamente na primeira execução para armazenar as tarefas.

    Projeto focado em demonstrar conceitos básicos de C# e manipulação de dados em arquivo
