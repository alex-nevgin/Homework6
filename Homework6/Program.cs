// See https://aka.ms/new-console-template for more information

// Метод обработки действия пользователя

using System.Diagnostics;

static void Action(string act)
{
	switch (act)
	{
		case "1":
			if (File.Exists(@"test.txt"))
			{
				Output();
			}
			else
				using (FileStream fs = File.Create(@"test.txt"))
				{
					Input();
					fs.Close();
				}
			break;
		case "2":
			
			Append(Input());
			break;
		case "0":
			Environment.Exit(0);
			break;
		default:
			Console.WriteLine("Такой операции не предусмотрено");
			break;
	}
}

// Метод добавления текста в файл
static void Append(string data)
{
	using (StreamWriter streamWriter = new StreamWriter(@"test.txt", true))
	{
		streamWriter.Write(data);
		// streamWriter.Close();
	}
}

// Метод обработки ввода данных пользователем
static string Input()
{
	Console.WriteLine("Введите информацию для добавления");
	string[] hints =
	{
		"ФИО",
		"Возраст",
		"Рост",
		"Дата рождения",
		"Место рождения"
	};

	int id;
	string[] lines = File.ReadAllLines(@"test.txt");
	id = lines.Length+1;
	
	DateTime creationDateTime = DateTime.Now;
	
	Console.WriteLine(hints[0]);
	string name = Console.ReadLine();
	
	Console.WriteLine(hints[1]);
	byte age = Byte.Parse(Console.ReadLine());
	
	Console.WriteLine(hints[2]);
	byte height = Byte.Parse(Console.ReadLine());
	
	Console.WriteLine(hints[3]);
	DateOnly birthDate = DateOnly.Parse(Console.ReadLine());
	
	Console.WriteLine(hints[4]);
	string birthPlace = Console.ReadLine();

	string data = $"{id}#{creationDateTime}#{name}#{age}#{height}#{birthDate}#{birthPlace}" + "\n";
	
	return data;
}

// Метод считывания и вывода данных в консоль
static void Output()
{
	string line;
	using (StreamReader streamReader = new StreamReader(@"test.txt"))
	{
		while ((line = streamReader.ReadLine()) != null)
		{
			string[] lines = line.Split("#");
			for (int i = 0; i < lines.Length; i++)
			{
				Console.Write(lines[i] + " ");
			}
			Console.WriteLine();
		}
		streamReader.Close();
	}
}

while (true)
{
	Console.WriteLine("Введите действие (1 - вывод файла, 2 - запись в файл, 0 - выход): ");
    string act = Console.ReadLine();
    Console.WriteLine();
    Action(act);
    Console.WriteLine();
}





