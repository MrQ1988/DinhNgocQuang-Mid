using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Enemy
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }

    public int CalculateDamage(int[] damageArray, int minDamage, int maxDamage)
    {
        Random random = new Random();
        int randomValue = random.Next(minDamage, maxDamage);
        return randomValue;
    }

    public bool IsValidDamageRange()
    {
        return MinDamage >= 0 && MaxDamage <= 100;
    }
}

class TestEnemy
{
    private List<Enemy> enemies;

    public TestEnemy()
    {
        enemies = new List<Enemy>();
    }

    public void AddEnemy()
    {
        Enemy enemy = new Enemy();

        Console.WriteLine("Enter Enemy Id:");
        string idInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(idInput))
        {
            Console.WriteLine("Id cannot be empty. Enemy not added.");
            return;
        }
        enemy.Id = Convert.ToInt32(idInput);

        Console.WriteLine("Enter Enemy Name:");
        string nameInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nameInput))
        {
            Console.WriteLine("Name cannot be empty. Enemy not added.");
            return;
        }
        enemy.Name = nameInput;

        Console.WriteLine("Enter Enemy Health:");
        string healthInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(healthInput))
        {
            Console.WriteLine("Health cannot be empty. Enemy not added.");
            return;
        }
        enemy.Health = Convert.ToInt32(healthInput);

        Console.WriteLine("Enter Enemy Min Damage:");
        string minDamageInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(minDamageInput))
        {
            Console.WriteLine("Min Damage cannot be empty. Enemy not added.");
            return;
        }
        enemy.MinDamage = Convert.ToInt32(minDamageInput);

        Console.WriteLine("Enter Enemy Max Damage:");
        string maxDamageInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(maxDamageInput))
        {
            Console.WriteLine("Max Damage cannot be empty. Enemy not added.");
            return;
        }
        enemy.MaxDamage = Convert.ToInt32(maxDamageInput);


        if (!enemy.IsValidDamageRange())
        {
            Console.WriteLine("Invalid damage range. Damage must be between 0 and 100.");
            return;
        }

        enemies.Add(enemy);
    }

    public void SearchEnemyByName() //chưa làm được
    {

    }

    public void UpdateEnemy() //chưa làm được
    {

    }

    public void DeleteEnemy() //chưa làm được
    {

    }

    public void SortEnemiesByAverageDamage()
    {
        enemies.Sort((e1, e2) =>
        {
            int e1AverageDamage = (e1.MinDamage + e1.MaxDamage) / 2;
            int e2AverageDamage = (e2.MinDamage + e2.MaxDamage) / 2;
            return e1AverageDamage.CompareTo(e2AverageDamage);
        });

        Console.WriteLine("Enemies sorted by average damage:");
        foreach (Enemy enemy in enemies)
        {
            DisplayEnemy(enemy);
        }
    }

    public void DisplayAllEnemies()
    {
        Console.WriteLine("All Enemies:");
        foreach (Enemy enemy in enemies)
        {
            DisplayEnemy(enemy);
        }
    }

    private void DisplayEnemy(Enemy enemy)
    {
        Console.WriteLine($"Id: {enemy.Id}");
        Console.WriteLine($"Name: {enemy.Name}");
        Console.WriteLine($"Health: {enemy.Health}");
        Console.WriteLine($"Min Damage: {enemy.MinDamage}");
        Console.WriteLine($"Max Damage: {enemy.MaxDamage}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        TestEnemy testEnemy = new TestEnemy();
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Enemy");
            Console.WriteLine("2. Sort Enemies by Average Damage");
            Console.WriteLine("3. Display All Enemies");
            Console.WriteLine("4. Search Enemy by Name");
            Console.WriteLine("5. Delete Enemy by Id");
            Console.WriteLine("6. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nYour choice: " + choice);

            switch (choice)
            {
                case 1:
                    testEnemy.AddEnemy();
                    break;
                case 2:
                    testEnemy.SortEnemiesByAverageDamage();
                    break;
                case 3:
                    testEnemy.DisplayAllEnemies();
                    break;
                case 4:
                    testEnemy.SearchEnemyByName();
                    break;
                case 5:
                    testEnemy.DeleteEnemy();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}