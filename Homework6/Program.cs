// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;

/// <summary>
/// Метод для добавления данных в файл
/// </summary>
/// <param name="text">Строка для добавления</param>
void Append(string text)
{
	StreamWriter streamWriter = new StreamWriter(@"D:\\Test\test.txt");
	
}

void View()
{
	string[] text = File.ReadAllLines("D:\\Test\test.txt");

	foreach (var line in text)
	{
		Console.WriteLine(line);
	}
}

/// <summary>
/// Метод обработки выбранного действия
/// </summary>
void Action(string action)
{
	switch (action)
	{
		case "1":
			if (File.Exists(@"D:\Test\D:\\Test\test.txttest.txt"))
			{
				View();
			}
			else
			{
				File.Create(@"D:\Test\test.txt");
			}
			break;
		case "2":
			Console.WriteLine("Введите информацию для добавления (в формате: ФИО Возраст Рост Дата Рождения Место рождения");
			string text = Console.ReadLine();
			string[] line = text.Split(" ");
			
			break;

	}
}


Console.WriteLine("Введите действие (1 - вывод файла (если файла нет, он будет создан); 2 - добавить информацию в файл)");

string action = Console.ReadLine();
Action(action);
	


