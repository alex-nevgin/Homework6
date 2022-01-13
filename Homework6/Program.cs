// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;

/// <summary>
/// Метод для добавления данных в файл
/// </summary>
/// <param name="s">Строка для добавления</param>
void Append(string s)
{
    string path = @"test.txt";
    File.AppendAllText(path, s);
}

/// <summary>
/// Метод для вывода файла в консоль 
/// </summary>
void View()
{
    string path = @"test.txt";
    string[] lines = File.ReadAllLines(path);
    for (int i = 0; i < lines.Length; i++)
    {
        string[] line = lines[i].Split('#');
        foreach (string s in line)
        {
            Console.Write(s + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine("");
}

/// <summary>
/// Метод обработки выбранного действия
/// </summary>
void Action(string action)
{
    switch (action)
    {
        case "1":
            if (File.Exists(@"test.txt"))
            {
                View();
            }
            else
            {
                File.Create(@"test.txt");
            }
            break;
        case "2":
            Console.WriteLine("Введите информацию для добавления");
            string[] hints =
            {
                "Номер записи",
                "Дата добавления",
                "ФИО",
                "Возраст",
                "Рост",
                "Дата рождения",
                "Место рождения"
            };
            string data = "";
            for (int i = 0; i < hints.Length; i++)
            {
                Console.WriteLine(hints[i]);
                if (i < hints.Length - 1)
                    data += Console.ReadLine() + "#";
                else
                    data += Console.ReadLine() + "\n";
            }
            Append(data);
            break;
        default:
            Console.WriteLine("Такой операции не предусмотрено");
            break;

    }

}


do
{
    Console.WriteLine("Введите действие (1 - вывод файл а (если файла нет, он будет создан); 2 - добавить информацию в файл, 0 - выход)");
    string action = Console.ReadLine();
    if (action == "0")
    {
        break;
    }
    Console.WriteLine();
    Action(action);
} while (true);






