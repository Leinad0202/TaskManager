using System;
using System.Collections.Generic;
using TaskManager.Models;
using TaskManager.Services;

class Program
{
    static TaskService taskService = new TaskService("tasks.json");

    static void Main(string[] args)
    {
        Console.WriteLine("Gerenciador de Tarefas Simples");
        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Listar tarefas");
            Console.WriteLine("2 - Adicionar tarefa");
            Console.WriteLine("3 - Atualizar tarefa");
            Console.WriteLine("4 - Remover tarefa");
            Console.WriteLine("5 - Sair");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ListTasks();
                    break;
                case "2":
                    AddTask();
                    break;
                case "3":
                    UpdateTask();
                    break;
                case "4":
                    RemoveTask();
                    break;
                case "5":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void ListTasks()
    {
        var tasks = taskService.GetAllTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.");
            return;
        }

        Console.WriteLine("\nTarefas:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"[{task.Id}] {task.Title} - {(task.IsCompleted ? "Concluída" : "Pendente")}");
        }
    }

    static void AddTask()
    {
        Console.Write("Título da tarefa: ");
        var title = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Título não pode ser vazio.");
            return;
        }

        taskService.AddTask(new TaskItem { Title = title, IsCompleted = false });
        Console.WriteLine("Tarefa adicionada.");
    }

    static void UpdateTask()
    {
        Console.Write("ID da tarefa para atualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var task = taskService.GetTaskById(id);
        if (task == null)
        {
            Console.WriteLine("Tarefa não encontrada.");
            return;
        }

        Console.Write("Novo título (deixe vazio para não alterar): ");
        var title = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(title))
        {
            task.Title = title;
        }

        Console.Write("Concluir tarefa? (s/n): ");
        var done = Console.ReadLine();
        if (done?.ToLower() == "s")
        {
            task.IsCompleted = true;
        }
        else if (done?.ToLower() == "n")
        {
            task.IsCompleted = false;
        }

        taskService.UpdateTask(task);
        Console.WriteLine("Tarefa atualizada.");
    }

    static void RemoveTask()
    {
        Console.Write("ID da tarefa para remover: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        if (taskService.RemoveTask(id))
        {
            Console.WriteLine("Tarefa removida.");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }
}
