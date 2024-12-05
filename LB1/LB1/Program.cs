using System.Runtime.Intrinsics.X86;


using System;

PrintYellow(" Вариант 23 ");
PrintGreen("");
PrintGreen("1+x");
PrintGreen("-------  x<=0 ");
PrintGreen("корень 1 + x^2");
PrintGreen("");
PrintGreen("-x+2e^-2x xэ(0;1)");
PrintGreen("");
PrintGreen("|2-x|^1/3  x>1");


while (true) // безконченый цыкл  - что  бы не перезапускать  программу каждый раз 
{
    MyProgramm(); // сам алгоритм 
}



// методы 

void MyProgramm()
{
    PrintGreen("Введите x минимальный"); // все диалги будем делать зелеными  - чтоб красиво

    double xMin = GetDouble(); // получит  число  -сложная  задача - вынесем  в  отдельный  метод 
    double xMin2 = GetDouble();
    double xMin3 = GetDouble();
    PrintGreen("Введите x максимальный");

    double xMax = GetDouble();
    double xMax2 = GetDouble();
    double xMax3 = GetDouble();
    PrintGreen("Введите шаг функции ");

    double xStep = GetDouble();
    double xStep2 = GetDouble();
    double xStep3 = GetDouble();
    Myfunction(xMin, xMax, xStep); // когда  у  нас  есть  все данные  дадим их отдельному методу 
    Myfunction2(xMin2, xMax2, xStep2); // когда  у  нас  есть  все данные  дадим их отдельному методу 
    Myfunction3(xMin3, xMax3, xStep3); // когда  у  нас  есть  все данные  дадим их отдельному методу 
}


void Myfunction(double xMin, double xMax, double xStep)
{
    // валидация  входных параметров 
    if (xMin > xMax)
    {
        PrintRed("x1 минимальная больше чем x1 максимальная");
        return; // выход из функции  дострочно
    }

    if (xStep == 0)
    {
        PrintRed("Шаг первой функции равен нулю");
        return;
    }

    if (xStep < 0)
    {
        PrintRed("Шаг меньше нуля");
        return;
    }

    PrintYellow("_____Ответ____");
    /// переберем функцию 
    for (double i = xMin; i <= xMax; i += xStep)
    {
        double y = GetValueFunction(i);
        PrintYellow($"x={i}: y={y}"); // Ответ 
    }
    PrintYellow($"Пересечение первой функции с осью Y в точке: {GetValueFunction(0)}");
}


double GetValueFunction(double x)
{
    double y = 1 + x;
    return Math.Sqrt(1 + Math.Pow(x, 2));   // формула 1, если x<0
}
double GetValueFunction2(double x)
{
    double z = -2 * x;
    return -x + Math.Pow(2, z);  // формула 2, если 0<=x<=1
}
double GetValueFunction3(double x)
{
    double k = Math.Abs(2 - x);
    double c = 1 / 3;
    return Math.Pow(k, c); // формула 3, если x>1
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
    ConsoleColor color = Console.ForegroundColor; // запомнит текущий цвет
    Console.ForegroundColor = ConsoleColor.Yellow; // поменяем  на  зеленый цвет
    Console.WriteLine(message);  //  выведем  сообщение 
    Console.ForegroundColor = color; // вернем  базовый цвет
}


void PrintRed(string message)
{
    ConsoleColor color = Console.ForegroundColor; // запомнит текущий цвет
    Console.ForegroundColor = ConsoleColor.Red; // поменяем  на  зеленый цвет
    Console.WriteLine(message);  //  выведем  сообщение 
    Console.ForegroundColor = color; // вернем  базовый цвет
}



double GetDouble()
{
    try
    {
        string temp = Console.ReadLine();
        return Convert.ToDouble(temp);
    }
    catch
    {
        PrintRed("Не верный ввод, введите число");
        return GetDouble();
    }
}


void Myfunction2(double xMin2, double xMax2, double xStep2)
{
    // валидация  входных параметров 
    if (xMin2 > xMax2)
    {
        PrintRed("x1 минимальная больше чем x1 максимальная");
        return; // выход из функции  дострочно
    }

    if (xStep2 == 0)
    {
        PrintRed("Шаг первой функции равен нулю");
        return;
    }

    if (xStep2 < 0)
    {
        PrintRed("Шаг меньше нуля");
        return;
    }


    PrintYellow("_____Ответ____");
    // переберем функцию 
    for (double i = xMin2; i <= xMax2; i += xStep2)
    {
        double y = GetValueFunction2(i);
        PrintYellow($"x={i}: y={y}"); // Ответ 
    }
    PrintYellow($"Пересечение первой функции с осью Y в точке: {GetValueFunction2(0)}");
}



void Myfunction3(double xMin3, double xMax3, double xStep3)
{
    // валидация  входных параметров 
    if (xMin3 > xMax3)
    {
        PrintRed("x минимальная больше чем x максимальная");
        return; // выход из функции  дострочно
    }

    if (xStep3 == 0)
    {
        PrintRed("Шаг функции равен нулю");
        return;
    }

    if (xStep3 < 0)
    {
        PrintRed("Шаг меньше нуля");
        return;
    }

    PrintYellow("_____Ответ____");
    /// переберем функцию 
    for (double i = xMin3; i <= xMax3; i += xStep3)
    {
        double y = GetValueFunction3(i);
        PrintYellow($"x={i}: y={y}"); // Ответ 
    }

}