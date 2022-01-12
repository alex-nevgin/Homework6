// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;

/// <summary>
/// Метод для добавления данных в файл
/// </summary>
/// <param name="text">Строка для добавления</param>
void Append(string[] s)
{
	string path = @"D:\Test\test.txt";
	File.AppendAllLines(path, s);
}

void View()
{
	string path = @"D:\Test\test.txt";
	string[] lines = File.ReadAllLines(path);
	foreach (string line in lines)
    {
        Console.Write(line);
    }

}

/// <summary>usi
/// Метод обработки выбранного действия
/// </summary>
void Action(string action)
{
	switch (action)
	{
		case "1":
			if (File.Exists(@"D:\Test\test.txt"))
			{
				View();
			}
			else
			{
				File.Create(@"D:\Test\test.txt");
			}
			break;
		case "2":
			Console.WriteLine("Введите информацию для добавления (в формате: №, Дата добавления, ФИО, Возраст, Рост, Дата Рождения, Место Рождения");
			string text = Console.ReadLine();
			string[] line = text.Split(',');
			Append(line);
			break;
	}
}


Console.WriteLine("Введите действие (1 - вывод файла (если файла нет, он будет создан); 2 - добавить информацию в файл)");

string action = Console.ReadLine();
Console.WriteLine();
Action(action);
	


