// See https://aka.ms/new-console-template for more information

// Метод обработки действия пользователя
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
			//Input();
			Append(Input());
			break;
		case "0":
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
	string data = "";
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
	for (var i = 0; i < hints.Length; i++)
	{
		Console.WriteLine(hints[i]);
		if (i < hints.Length-1)
			data += Console.ReadLine() + "#";
		else
			data += Console.ReadLine() + "\n";
	}
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

Console.WriteLine("Введите действие (1 - вывод файла, 2 - запись в файл, 0 - выход): ");
string act = Console.ReadLine();
Console.WriteLine();
Action(act);

