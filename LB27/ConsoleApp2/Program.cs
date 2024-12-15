
using System;

class TicTacToe
{
    // Размер игрового поля
    private const int SIZE = 3;

    // Символы для отображения на игровом поле
    private static readonly char[] SYMBOLS = { ' ', 'X', 'O' };

    // Массив для хранения состояния игрового поля
    private int[,] board = new int[SIZE, SIZE];

    // Счетчик раундов
    private int roundCount = 0;

    // Флаг продолжения игры
    private bool isRunning = true;

    public void Run()
    {
        while (isRunning)
        {
            PrintMenu();
            ProcessInput();
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("Меню команд:");
        Console.WriteLine("1. go     - начать новую игру");
        Console.WriteLine("2. help   - показать помощь");
        Console.WriteLine("3. total  - показать общее количество сыгранных партий");
        Console.WriteLine("4. list   - показать список команд");
        Console.WriteLine("5. clear  - очистить экран");
        Console.WriteLine("6. exit   - выйти из программы");
        Console.WriteLine("Введите команду:");
    }

    private void ProcessInput()
    {
        string input = Console.ReadLine()?.Trim().ToLower() ?? "";

        switch (input)
        {
            case "go":
                Play();
                break;
            case "help":
                PrintHelp();
                break;
            case "total":
                PrintTotal();
                break;
            case "list":
                PrintMenu();
                break;
            case "clear":
                Console.Clear();
                break;
            case "exit":
                ExitProgram();
                break;
            default:
                Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                break;
        }
    }

    private void Play()
    {
        InitializeBoard();

        while (!IsGameOver())
        {
            PrintBoard();

            MakeMove('X'); // Ход игрока
            if (IsGameOver()) break;

            PrintBoard();

            MakeMove('O'); // Ход компьютера
        }

        PrintResult();
        roundCount++; // Увеличиваем счетчик раундов
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                board[i, j] = 0;
            }
        }
    }

    private bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < SIZE &&
               col >= 0 && col < SIZE &&
               board[row, col] == 0;
    }

    private void MakeMove(char playerSymbol)
    {
        if (playerSymbol == 'X')
        {
            Console.WriteLine($"Ходит игрок '{playerSymbol}'");
            int row, col;

            do
            {
                Console.Write("Введите строку (1-3): ");
                row = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Введите столбец (1-3): ");
                col = Convert.ToInt32(Console.ReadLine()) - 1;
            } while (!IsValidMove(row, col));

            board[row, col] = playerSymbol == 'X' ? 1 : 2;
        }
        else
        {
            Random random = new Random();
            int row, col;

            do
            {
                row = random.Next(0, SIZE);
                col = random.Next(0, SIZE);
            } while (!IsValidMove(row, col));

            board[row, col] = playerSymbol == 'X' ? 1 : 2;
        }
    }

    private bool CheckWinCondition(int player)
    {
        // Проверка строк
        for (int i = 0; i < SIZE; i++)
        {
            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                    return true;
        }

        // Проверка столбцов
        for (int j = 0; j < SIZE; j++)
        {
            if (board[0, j] == player && board[1, j] == player && board[2, j] == player)
                return true;
        }

        // Проверка главной диагонали
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            return true;

        // Проверка побочной диагонали
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            return true;

        return false;
    }

    private bool IsGameOver()
    {
        if (CheckWinCondition(1))
        {
            Console.WriteLine("Победил игрок 'X'");
            return true;
        }
        else if (CheckWinCondition(2))
        {
            Console.WriteLine("Победил компьютер 'O'");
            return true;
        }
        else
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (board[i, j] == 0)
                        return false;
                }
            }
            Console.WriteLine("Ничья!");
            return true;
        }
    }

    private void PrintBoard()
    {
        Console.WriteLine("\nТекущее состояние доски:");
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                Console.Write(SYMBOLS[board[i, j]] + " ");
            }
            Console.WriteLine();
        }
    }

    private void PrintResult()
    {
        Console.WriteLine("\nИгра окончена.");
    }

    private void PrintHelp()
    {
        Console.WriteLine("Это меню помощи. Выберите команду для получения дополнительной информации.");
    }

    private void PrintTotal()
    {
        Console.WriteLine($"Общее количество сыгранных партий: {roundCount}");
    }

    private void ExitProgram()
    {
        Console.WriteLine("Выход из программы...");
        isRunning = false;
    }

    static void Main(string[] args)
    {
        var game = new TicTacToe();
        game.Run();
    }
}