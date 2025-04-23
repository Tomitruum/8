using System.Runtime.Serialization;

namespace _8
{
    public static class Pomoshnik
    {
        public static List<Zadacha> zadachi = new List<Zadacha>();
        public static string putKFailu = "zadachi.dat";

        public static void ZapisatDannyeVBinar()
        {
            try
            {
                using FileStream fs = new FileStream(putKFailu, FileMode.Create);
                var serializer = new DataContractSerializer(typeof(List<Zadacha>));
                serializer.WriteObject(fs, zadachi);
                Console.WriteLine("Данные успешно сохранены.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении: " + ex.Message);
            }
        }

        public static void ProchitatIzBinara()
        {
            try
            {
                if (File.Exists(putKFailu))
                {
                    using FileStream fs = new FileStream(putKFailu, FileMode.Open);
                    var serializer = new DataContractSerializer(typeof(List<Zadacha>));
                    zadachi = serializer.ReadObject(fs) as List<Zadacha> ?? new List<Zadacha>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении: " + ex.Message);
            }
        }

        public static void DobavitZadachu()
        {
            try
            {
                Console.Write("Введите ID: ");
                int id = int.Parse(Console.ReadLine());

                if (zadachi.Any(z => z.Id == id))
                {
                    Console.WriteLine("Задача с таким ID уже существует!");
                    return;
                }

                Console.Write("Введите описание: ");
                string opis = Console.ReadLine();

                Console.Write("Введите дату (дд-мм-гггг): ");
                DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

                Console.Write("Это важная задача? (true/false): ");
                bool vazhno = bool.Parse(Console.ReadLine());

                Console.Write("Введите длительность в часах: ");
                double dlitelnost = double.Parse(Console.ReadLine());

                zadachi.Add(new Zadacha(id, opis, data, vazhno, dlitelnost));
                Console.WriteLine("Задача добавлена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении: " + ex.Message);
            }
        }

        public static void PosmotretVse()
        {
            if (zadachi.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
            }
            else
            {
                foreach (var z in zadachi)
                {
                    Console.WriteLine(z);
                }
            }
        }

        public static void UdalitPoId()
        {
            Console.Write("Введите ID задачи для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var zadacha = zadachi.FirstOrDefault(z => z.Id == id);
                if (zadacha != null)
                {
                    zadachi.Remove(zadacha);
                    Console.WriteLine("Задача удалена.");
                }
                else
                {
                    Console.WriteLine("Задача не найдена.");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод ID.");
            }
        }

        public static void SdelatZaprosy()
        {
            Console.WriteLine("1. Список важных задач");
            Console.WriteLine("2. Задачи на этой неделе");
            Console.WriteLine("3. Самая длинная задача");
            Console.WriteLine("4. Количество всех задач");
            Console.Write("Выберите номер запроса: ");
            string vibor = Console.ReadLine();

            switch (vibor)
            {
                case "1":
                    var vazhnye = zadachi.Where(z => z.Vazhno).ToList();
                    if (vazhnye.Count == 0)
                        Console.WriteLine("Нет важных задач.");
                    else
                        foreach (var z in vazhnye) Console.WriteLine(z);
                    break;

                case "2":
                    DateTime segodnya = DateTime.Today;
                    int offset = DayOfWeek.Monday - segodnya.DayOfWeek;
                    if (offset > 0) offset -= 7;
                    DateTime startOfWeek = segodnya.AddDays(offset);
                    DateTime endOfWeek = startOfWeek.AddDays(6);

                    var etayaNedelya = zadachi
                        .Where(z => z.Data.Date >= startOfWeek && z.Data.Date <= endOfWeek)
                        .ToList();

                    if (etayaNedelya.Count == 0)
                        Console.WriteLine("На этой неделе нет задач.");
                    else
                        foreach (var z in etayaNedelya) Console.WriteLine(z);
                    break;

                case "3":
                    if (zadachi.Count == 0)
                    {
                        Console.WriteLine("Нет задач для анализа.");
                    }
                    else
                    {
                        var max = zadachi.OrderByDescending(z => z.DlitelnostChasov).First();
                        Console.WriteLine("Самая длинная задача: " + max);
                    }
                    break;

                case "4":
                    Console.WriteLine("Всего задач: " + zadachi.Count);
                    break;

                default:
                    Console.WriteLine("Неверный номер.");
                    break;
            }
        }
    }
}
