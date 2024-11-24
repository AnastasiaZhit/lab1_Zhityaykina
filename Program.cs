class Item //Создаем класс
{
    public string Name { get; set; }
    public int Value { get; set; }
    public DateTime Date { get; set; }

    public Item(string name, int value, DateTime date) //Конструктор для инициализации объекта
    {
        Name = name;
        Value = value;
        Date = date;
    }

    public string ToString() //Метод формата данных для записи листа в файл
    {
        return $"{Name}, {Value}, {Date:yyyy-MM-dd}";
    }
}

class Program
{
    static void Main()
    {
        List<Item> items = new List<Item> //Заполняем лист Item своими значениями
        {
            new Item("Item1", 10, new DateTime(2023, 1, 1)),
            new Item("Item2", 5, new DateTime(2023, 2, 1)),
            new Item("Item3", 15, new DateTime(2023, 3, 1)),
            new Item("Item4", 20, new DateTime(2023, 4, 1)),
            new Item("Item5", 12, new DateTime(2023, 5, 1)),
            new Item("Item6", 25, new DateTime(2023, 6, 1)),
            new Item("Item7", 8, new DateTime(2023, 7, 1)),
            new Item("Item8", 21, new DateTime(2023, 8, 1)),
            new Item("Item9", 18, new DateTime(2023, 9, 1)),
            new Item("Item10", 30, new DateTime(2023, 10, 1)),
            new Item("Item11", 5, new DateTime(2023, 11, 1)),
            new Item("Item12", 25, new DateTime(2023, 12, 1)),
        };

        items.Sort((x, y) => string.Compare(x.Name, y.Name)); //Сортировка по имени
        WriteToFile("sorted_by_name.txt", items);

        items.Sort((x, y) => x.Value.CompareTo(y.Value)); //Сортировка по значению
        WriteToFile("sorted_by_value.txt", items);

        items.Sort((x, y) => DateTime.Compare(x.Date, y.Date)); //Сортировка по дате
        WriteToFile("sorted_by_date.txt", items);
    }

    static void WriteToFile(string fileName, List<Item> items) //Функция записи в файл
    {
        using (StreamWriter writer = new StreamWriter(fileName)) //Создаем объект для записи данных в файл
        {
            foreach (var item in items) //Проходим по всему листу items
            {
                writer.WriteLine(item.ToString()); //Зписываем каждый элемент конвертируя в строку
            }
        }
        Console.WriteLine($"Вывод в файл: {fileName}");
    }
}