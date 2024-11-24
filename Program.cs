class Record //Создаем класс
{
    public string Patient { get; set; } //Имя пациента
    public int Bloodgroup { get; set; }  //Группа крови пациента
    public DateTime Birthday { get; set; }  //Дата рождения

    public Record(string patient, int group, DateTime date) //Конструктор 
    {
        Patient = patient;
        Bloodgroup = group;
        Birthday = date;
    }

    public string Format() //Метод формата данных для записи в файл
    {
        return $"{Patient}, {Bloodgroup}, {Birthday:yyyy-MM-dd}";
    }
}

class Program
{
    static void Main()
    {
        List<Record> Patients = new List<Record> //Заполняем лист данными
        {
            new Record("Katya", 1, new DateTime(2003, 12, 10)),
            new Record("Petya", 2, new DateTime(2002, 3, 9)),
            new Record("Vasya", 4, new DateTime(2000, 8, 4)),
            new Record("Chan", 3, new DateTime(2006, 6, 6)),
            new Record("Han", 2, new DateTime(2004, 5, 25)),
            new Record("Minho", 2, new DateTime(2000, 7, 18)),
            new Record("Leebit", 1, new DateTime(2008, 9, 6)),
            new Record("Mary", 3, new DateTime(2000, 2, 19)),
            new Record("Nastya", 1, new DateTime(2002, 7, 16)),
            new Record("Anna", 3, new DateTime(2002, 11, 23)),
            new Record("Eva", 4, new DateTime(2000, 4, 9)),
            new Record("Jam", 2, new DateTime(2001, 12, 18)),
        };

        Patients.Sort((x, y) => string.Compare(x.Patient, y.Patient)); //Сортировка по имени
        WriteToFile("Name_patient.txt", Patients);

        Patients.Sort((x, y) => x.Bloodgroup.CompareTo(y.Bloodgroup)); //Сортировка по группе крови
        WriteToFile("Blood_group.txt", Patients);

        Patients.Sort((x, y) => DateTime.Compare(x.Birthday, y.Birthday)); //Сортировка по дате рождения
        WriteToFile("Birthday.txt", Patients);
    }

    static void WriteToFile(string fileName, List<Record> Patients) //Функция записи в файл
    {
        using (StreamWriter writer = new StreamWriter(fileName)) //Создаем объект для записи данных в файл
        {
            foreach (var Patient in Patients) //Проходим по всему листу 
            {
                writer.WriteLine(Patient.Format()); //Зписываем каждый элемент конвертируя в строку
            }
        }
        Console.WriteLine($"Вывод в файл: {fileName}");
    }
}