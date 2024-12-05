using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

Dice[] AllDice = new Dice[]
{
    new Dice(TypeColor.Black),
    new Dice(TypeColor.Black),
    new Dice(TypeColor.White),
    new Dice(TypeColor.White),
 };

int raund = 0;  // каждый ответ  - это  раунд 
int pointUser = 0; //для счета  
int pointPK = 0;


while (true) // цикл - раунды  
{
    PrintListCommand();
    Console.WriteLine("Введите команду:");

    switch (Console.ReadLine())
    {
        case "go":
            GoGame(); // Игра за игрока 
            GoGame();//Игра за пк 
            break;
        case "help": PrintHelp(); break;
        case "total": PrintTotal(); break;
        case "list":
            PrintListCommand(); break;
            break;  // игра за  пк  и за  человка  
        case "clear": Console.Clear(); break;
        default:
            Console.WriteLine("Не понятно ( ");
            break;
    }
}


void PrintHelp()
{

    PrintRed("Игра: "); PrintYellow("“4 кубика с невидимой гранью \n" +
"В коробке находятся четыре игральных кубика: два\n" +
"белых и два черных. Берут наугад два кубика и\n" +
"бросают. Белый кубик показывает число выигрышных\n" +
"очков, невидимая грань черного кубика – число\n" +
"проигравших.");
    PrintGreen("");
}

void PrintTotal()
{
   PrintRed($"Общий счет игры: человек: {pointUser} - компьютер: {pointPK}");
}

void GoGame()
{
    raund++;
    if (raund % 2 == 0)
    {
        RaundUser();
    }
    else
    {
        RaundPK();
    }
}
void RaundPK()
{
    PrintGreen("Мы играем с пк");
    List<Dice> randDice = new List<Dice>();
    Random rand = new Random();

    for (int i = 0; i < 2; i++)
    {
        int r = rand.Next(0, AllDice.Length - 1);
        randDice.Add(AllDice[r]);
        int myDice = rand.Next(1, 7);
        int result = randDice[i].GetReversCount(randDice[i].typeColor, myDice);
        PrintYellow($"пк получил: {result}");
        pointPK += result;
    }
    PrintRed(pointPK.ToString());
}

void RaundUser()
{
    Console.WriteLine();
    List<Dice> randDice = new List<Dice>();
    Random rand = new Random();

    for (int i = 0; i < 2; i++)
    {
        int r = rand.Next(0, AllDice.Length - 1);
        randDice.Add(AllDice[r]);
        int myDice = rand.Next(1, 7);
        int result = randDice[i].GetReversCount(randDice[i].typeColor, myDice);
        PrintYellow($"игрок: {result}");
        pointUser += result;
    }
    PrintRed(pointUser.ToString());
}

void PrintListCommand()
{
    PrintGreen("Посмотреть правила: \"help\"");
    PrintGreen("Посмотреть счет: \"total\"");
    PrintGreen("Играть: \"go\"");
    PrintGreen("список команд: \"list\"");
    PrintGreen("Очистить  консоль: \"clear\"");
}

void PrintGreen(string message)
{
    ConsoleColor color = Console.ForegroundColor; // запомнит текущий цвет 
    Console.ForegroundColor = ConsoleColor.Green; // поменяем  на  зеленый цвет 
    Console.WriteLine(message);  //  выведем  сообщение  
    Console.ForegroundColor = color; // вернем  базовый цвет 
}

void PrintYellow(string message)
{
    ConsoleColor color = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(message);   //выше написанно читай 
    Console.ForegroundColor = color;
}

void PrintRed(string message)
{
    ConsoleColor color = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);  //выше написанно читай 
    Console.ForegroundColor = color;
}