using System;
using System.Text;
using TimeLibrary;

namespace TimeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Time tUser = new Time();
            Console.WriteLine("Введіть момент часу для демонстрації операцій:");
            try
            {
                tUser.Input();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка введення ({ex.Message}). Встановлено 14:25:30.");
                tUser = new Time(14, 25, 30);
            }
            Console.WriteLine($"\nВаш введений час (tUser): {tUser}\n");

            Time tDefault = new Time();
            Time tReference = new Time(12, 0, 0);
            Time tCopy = new Time(tUser);

            Console.WriteLine($"Конструктор за замовчуванням: {tDefault}");
            Console.WriteLine($"Конструктор з параметрами:   {tReference} (опорний час)");
            Console.WriteLine($"Конструктор копіювання:      {tCopy} (копія tUser)\n");

            tUser++;
            Console.WriteLine($"Після tUser++ (+1 сек):      {tUser}");
            tUser--;
            Console.WriteLine($"Після tUser-- (-1 сек):      {tUser}");

            Time tMidnight = new Time(23, 59, 59);
            tMidnight++;
            Console.WriteLine($"Перехід через добу (23:59:59++): {tMidnight}\n");

            int diffSeconds = tUser - tReference;
            Console.WriteLine($"Різниця ({tUser} - {tReference}): {diffSeconds} сек.\n");

            Console.WriteLine($"Перевірка tUser ({tUser}):       {(tUser ? "true (не опівніч)" : "false (опівніч)")}");
            Console.WriteLine($"Перевірка tDefault ({tDefault}): {(tDefault ? "true (не опівніч)" : "false (опівніч)")}\n");

            int userSeconds = tUser; // Неявне: Time -> int
            Console.WriteLine($"Неявне приведення {tUser} у секунди: {userSeconds} сек.");

            Time tFromSeconds = (Time)userSeconds; // Явне: int -> Time
            Console.WriteLine($"Явне приведення {userSeconds} сек. у Time: {tFromSeconds}\n");


            Console.WriteLine($"{tUser} == {tCopy}:      {tUser == tCopy}");
            Console.WriteLine($"{tUser} != {tReference}: {tUser != tReference}");
            Console.WriteLine($"{tUser} >  {tReference}: {tUser > tReference}");
            Console.WriteLine($"{tUser} <= {tReference}: {tUser <= tReference}");
        }
    }
}